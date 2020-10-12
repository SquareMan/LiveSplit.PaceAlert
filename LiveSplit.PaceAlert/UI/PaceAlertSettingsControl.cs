using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.PaceAlert.Logic;
using LiveSplit.UI;
using Settings = LiveSplit.PaceAlert.Logic.Settings;

namespace LiveSplit.PaceAlert.UI
{
    public partial class PaceAlertSettingsControl : UserControl
    {
        private LiveSplitState _state;
        private NotificationSettings _activeSettings;
        private BindingList<string> splitNames;
        
        public PaceAlertSettingsControl(LiveSplitState state)
        {
            _state = state;
            Dock = DockStyle.Fill;
            
            InitializeComponent();
            BuildSplitNames();
            SetActiveSettings();
            state.RunManuallyModified += splitNames_RunManuallyModified;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            if (_activeSettings != null)
            {
                _activeSettings.SelectedSplit = cboSelectedSplit.SelectedIndex;
                _activeSettings.Ahead = cboSelectedSplit.SelectedIndex == 0;
                _activeSettings.Comparison = rdoRealTime.Checked ? TimingMethod.RealTime : TimingMethod.GameTime;
                _activeSettings.MessageTemplate = txtMessage.Text;
            }

            var settingsElement = document.CreateElement("Settings");
            SettingsHelper.CreateSetting(document, settingsElement, "Version",
                Assembly.GetExecutingAssembly().GetName().Version.ToString(3));

            var splitsElement = document.CreateElement("RunFiles");
            settingsElement.AppendChild(splitsElement);
            
            foreach (var runSettingsKvp in Settings.SettingsDictionary)
            {
                var runElement = document.CreateElement("Run");
                splitsElement.AppendChild(runElement);
                
                // Serialize settings for notification
                var runSettings = runSettingsKvp.Value;
                SettingsHelper.CreateSetting(document, runElement, "FilePath", runSettingsKvp.Key);
                SettingsHelper.CreateSetting(document, runElement, "SelectedSplit", runSettings.SelectedSplit);
                SettingsHelper.CreateSetting(document, runElement, "DeltaTarget", runSettings.DeltaTarget);
                SettingsHelper.CreateSetting(document, runElement, "Ahead", runSettings.Ahead);
                SettingsHelper.CreateSetting(document, runElement, "Comparison", runSettings.Comparison);
                SettingsHelper.CreateSetting(document, runElement, "MessageTemplate", runSettings.MessageTemplate);
            }
            
            return settingsElement;
        }

        public void SetSettings(XmlNode settings)
        {
            Settings.SettingsDictionary = new Dictionary<string, NotificationSettings>();

            var runFileList = settings.SelectNodes(".//RunFiles/Run");
            if (runFileList != null)
            {
                foreach (XmlNode runNode in runFileList)
                {
                    string filePath = SettingsHelper.ParseString(runNode["FilePath"]);
                    if (filePath == null) continue;
                    
                    var notificationSettings = new NotificationSettings
                    {
                        SelectedSplit = SettingsHelper.ParseInt(runNode["SelectedSplit"], -1),
                        DeltaTarget = SettingsHelper.ParseTimeSpan(runNode["DeltaTarget"], TimeSpan.Zero),
                        Ahead = SettingsHelper.ParseBool(runNode["Ahead"], true),
                        Comparison = SettingsHelper.ParseEnum(runNode["Comparison"], TimingMethod.RealTime),
                        MessageTemplate = SettingsHelper.ParseString(runNode["MessageTemplate"], string.Empty)
                    };
                    
                    Settings.SettingsDictionary.Add(filePath, notificationSettings);
                }    
            }

            SetActiveSettings();
        }

        private void SetActiveSettings()
        {
            //Set form settings to settings associated with currently opened splits file.
            _activeSettings = Settings.GetActiveSettings(_state);
            if (_activeSettings == null)
            {
                _activeSettings = new NotificationSettings();
                Settings.SettingsDictionary.Add(_state.Run.FilePath, _activeSettings);
            }

            cboSelectedSplit.SelectedIndex = _activeSettings.SelectedSplit;
            cboAheadBehind.SelectedIndex = _activeSettings.Ahead ? 0 : 1;
            txtMessage.Text = _activeSettings.MessageTemplate;
        
            // Set individual time text boxes, using TotalHours to account for TimeSpans with 24 or more hours
            txtDeltaHour.Text = ((int)_activeSettings.DeltaTarget.TotalHours).ToString("D2");
            txtDeltaMinute.Text = _activeSettings.DeltaTarget.Minutes.ToString("D2");
            txtDeltaSecond.Text = _activeSettings.DeltaTarget.Seconds.ToString("D2");
            txtDeltaMillisecond.Text = _activeSettings.DeltaTarget.Milliseconds.ToString("D3");

            // Parse Settings for Timing Method Comparison
            switch (_activeSettings.Comparison)
            {
                case TimingMethod.RealTime:
                    rdoRealTime.Checked = true;
                    break;
                case TimingMethod.GameTime:
                    rdoGameTime.Checked = true;
                    break;
            }
        }
        
        private void UpdatePaceBotStatus()
        {
            if (PaceBot.IsConnected)
            {
                lblWebhookStatus.Text = $"Webhook Status: Connected to {PaceBot.Name}";
                lblWebhookStatus.ForeColor = SystemColors.ControlText;
            }
            else
            {
                lblWebhookStatus.Text = "Webhook Status: Not Connected";
                lblWebhookStatus.ForeColor = Color.Red;
            }
        }

        private void BuildSplitNames()
        {
            splitNames = new BindingList<string>();

            for (int i = 0; i < _state.Run.Count; i++)
            {
                splitNames.Add(_state.Run[i].Name);
            }
            
            cboSelectedSplit.DataSource = splitNames;
        }

        private void splitNames_RunManuallyModified(object sender, EventArgs e)
        {
            // TODO: Moving splits Up/Down results in a deletion followed by an addition, which isn't handled correctly
            
            for (int i = 0; i < _state.Run.Count; i++)
            {
                if (splitNames.Count > i)
                {
                    if (splitNames[i] == _state.Run[i].Name) continue;
                    
                    if (splitNames.Count < _state.Run.Count)
                    {
                        //Split was added at this index
                        splitNames.Insert(i, _state.Run[i].Name);

                        break;
                    }
                    
                    if (splitNames.Count > _state.Run.Count)
                    {
                        //Split was removed at this index
                        splitNames.RemoveAt(i);
                        if (i == cboSelectedSplit.SelectedIndex)
                        {
                            //Selected Split was deleted, deselect all splits
                            cboSelectedSplit.SelectedIndex = -1;
                        }

                        break;
                    }
                    
                    //Split was renamed at this index
                    splitNames[i] = _state.Run[i].Name;
                    break;
                }
                
                //Split was added to end
                splitNames.Add(_state.Run[i].Name);
            }

            if (splitNames.Count > _state.Run.Count)
            {
                //Split was removed from end
                splitNames.RemoveAt(splitNames.Count - 1);
            }

            // Determine if a new splits file has been loaded
            var newActiveSettings = Settings.GetActiveSettings(_state);
            if (newActiveSettings != _activeSettings)
            {
                SetActiveSettings();
            }
        }

        private void PaceAlertSettingsControl_Load(object sender, EventArgs e)
        {
            UpdatePaceBotStatus();
        }

        private void btnSetURL_Click(object sender, EventArgs e)
        {
            using (var form = new WebhookURLForm())
            {
                form.ShowDialog();
            }
            UpdatePaceBotStatus();
        }

        private void btnVariables_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Strings.NotificationMessageVariablesDescription, "Message Variables");
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            PaceBot.SendMessage(txtMessage.Text);
        }

        private void txtDeltaHour_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaHour.Text, out var newTime) && newTime >= 0)
            {
                txtDeltaHour.Text = newTime.ToString("D2");

                var oldTime = _activeSettings.DeltaTarget;
                _activeSettings.DeltaTarget = new TimeSpan(0, newTime, oldTime.Minutes, oldTime.Seconds, oldTime.Milliseconds);
            }
            else
            {
                txtDeltaHour.Text = ((int)_activeSettings.DeltaTarget.TotalHours).ToString("D2");
            }
        }

        private void txtDeltaMinute_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaMinute.Text, out var newTime) && newTime >= 0 && newTime < 60)
            {
                txtDeltaMinute.Text = newTime.ToString("D2");

                var oldTime = _activeSettings.DeltaTarget;
                _activeSettings.DeltaTarget = new TimeSpan(oldTime.Days, oldTime.Hours, newTime, oldTime.Seconds, oldTime.Milliseconds);
            }
            else
            {
                txtDeltaMinute.Text = _activeSettings.DeltaTarget.Minutes.ToString("D2");
            }
        }

        private void txtDeltaSecond_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaSecond.Text, out var newTime) && newTime >= 0 && newTime < 60)
            {
                txtDeltaSecond.Text = newTime.ToString("D2");

                var oldTime = _activeSettings.DeltaTarget;
                _activeSettings.DeltaTarget = new TimeSpan(oldTime.Days, oldTime.Hours, oldTime.Minutes, newTime, oldTime.Milliseconds);
            }
            else
            {
                txtDeltaSecond.Text = _activeSettings.DeltaTarget.Seconds.ToString("D2");
            }
        }

        private void txtDeltaMillisecond_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaMillisecond.Text, out var newTime) && newTime >= 0 && newTime < 1000)
            {
                txtDeltaMillisecond.Text = newTime.ToString("D3");

                var oldTime = _activeSettings.DeltaTarget;
                _activeSettings.DeltaTarget = new TimeSpan(oldTime.Days, oldTime.Hours, oldTime.Minutes, oldTime.Seconds, newTime);
            }
            else
            {
                txtDeltaMillisecond.Text = _activeSettings.DeltaTarget.Milliseconds.ToString("D3");
            }
        }
    }
}