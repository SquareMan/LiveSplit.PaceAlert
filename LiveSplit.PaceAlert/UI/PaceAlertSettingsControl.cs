using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.UI;
using Settings = LiveSplit.PaceAlert.Logic.Settings;

namespace LiveSplit.PaceAlert.UI
{
    public partial class PaceAlertSettingsControl : UserControl
    {
        private LiveSplitState _state;
        private BindingList<string> splitNames;
        
        public PaceAlertSettingsControl(LiveSplitState state)
        {
            InitializeComponent();

            _state = state;
            Dock = DockStyle.Fill;
            
            
            BuildSplitNames();
            state.RunManuallyModified += splitNames_RunManuallyModified;
            
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var element = document.CreateElement("Settings");

            SettingsHelper.CreateSetting(document, element, "Version",
                Assembly.GetExecutingAssembly().GetName().Version.ToString(3));
            
            // Serialize settings for split conditions
            SettingsHelper.CreateSetting(document, element, "SelectedSplit", Settings.SelectedSplit);
            SettingsHelper.CreateSetting(document, element, "DeltaTarget", Settings.DeltaTarget);
            SettingsHelper.CreateSetting(document, element, "Ahead", Settings.Ahead);
            SettingsHelper.CreateSetting(document, element, "Comparison", Settings.Comparison);
            
            // Serialize settings for notification message
            SettingsHelper.CreateSetting(document, element, "MessageTemplate", Settings.MessageTemplate);
            
            return element;
        }

        public void SetSettings(XmlNode settings)
        {
            cboSelectedSplit.SelectedIndex = SettingsHelper.ParseInt(settings["SelectedSplit"], -1);

            Settings.DeltaTarget = SettingsHelper.ParseTimeSpan(settings["DeltaTarget"], TimeSpan.Zero);
            
            // Set individual time text boxes, using TotalHours to account for TimeSpans with 24 or more hours
            txtDeltaHour.Text = ((int)Settings.DeltaTarget.TotalHours).ToString("D2");
            txtDeltaMinute.Text = Settings.DeltaTarget.Minutes.ToString("D2");
            txtDeltaSecond.Text = Settings.DeltaTarget.Seconds.ToString("D2");
            txtDeltaMillisecond.Text = Settings.DeltaTarget.Milliseconds.ToString("D3");

            // Parse Settings for Ahead/Behind radio buttons
            var ahead = SettingsHelper.ParseBool(settings["Ahead"], true);
            cboAheadBehind.SelectedIndex = ahead ? 0 : 1;
            
            // Parse Settings for Timing Method Comparison
            var comparison = SettingsHelper.ParseEnum(settings["Comparison"], TimingMethod.RealTime);
            switch (comparison)
            {
                case TimingMethod.RealTime:
                    rdoRealTime.Checked = true;
                    break;
                case TimingMethod.GameTime:
                    rdoGameTime.Checked = true;
                    break;
            }
            
            // Parse settings for notification message
            txtMessage.Text = SettingsHelper.ParseString(settings["MessageTemplate"], string.Empty);
            Settings.MessageTemplate = txtMessage.Text;
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
        }

        private void btnSetURL_Click(object sender, EventArgs e)
        {
            using (var form = new WebhookURLForm())
            {
                form.ShowDialog();
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            PaceBot.SendMessage(txtMessage.Text);
        }

        private void cboSelectedSplit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.SelectedSplit = cboSelectedSplit.SelectedIndex;
        }

        private void txtDeltaHour_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaHour.Text, out var newTime) && newTime >= 0)
            {
                txtDeltaHour.Text = newTime.ToString("D2");

                var oldTime = Settings.DeltaTarget;
                Settings.DeltaTarget = new TimeSpan(0, newTime, oldTime.Minutes, oldTime.Seconds, oldTime.Milliseconds);
            }
            else
            {
                txtDeltaHour.Text = ((int)Settings.DeltaTarget.TotalHours).ToString("D2");
            }
        }

        private void txtDeltaMinute_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaMinute.Text, out var newTime) && newTime >= 0 && newTime < 60)
            {
                txtDeltaMinute.Text = newTime.ToString("D2");

                var oldTime = Settings.DeltaTarget;
                Settings.DeltaTarget = new TimeSpan(oldTime.Days, oldTime.Hours, newTime, oldTime.Seconds, oldTime.Milliseconds);
            }
            else
            {
                txtDeltaMinute.Text = Settings.DeltaTarget.Minutes.ToString("D2");
            }
        }

        private void txtDeltaSecond_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaSecond.Text, out var newTime) && newTime >= 0 && newTime < 60)
            {
                txtDeltaSecond.Text = newTime.ToString("D2");

                var oldTime = Settings.DeltaTarget;
                Settings.DeltaTarget = new TimeSpan(oldTime.Days, oldTime.Hours, oldTime.Minutes, newTime, oldTime.Milliseconds);
            }
            else
            {
                txtDeltaSecond.Text = Settings.DeltaTarget.Seconds.ToString("D2");
            }
        }

        private void txtDeltaMillisecond_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaMillisecond.Text, out var newTime) && newTime >= 0 && newTime < 1000)
            {
                txtDeltaMillisecond.Text = newTime.ToString("D3");

                var oldTime = Settings.DeltaTarget;
                Settings.DeltaTarget = new TimeSpan(oldTime.Days, oldTime.Hours, oldTime.Minutes, oldTime.Seconds, newTime);
            }
            else
            {
                txtDeltaMillisecond.Text = Settings.DeltaTarget.Milliseconds.ToString("D3");
            }
        }

        private void rdoRealTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRealTime.Checked)
            {
                Settings.Comparison = TimingMethod.RealTime;
            }
        }

        private void rdoGameTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGameTime.Checked)
            {
                Settings.Comparison = TimingMethod.GameTime;
            }
        }

        private void cboAheadBehind_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Ahead = cboAheadBehind.SelectedIndex == 0;
        }

        private void txtMessage_Validated(object sender, EventArgs e)
        {
            Settings.MessageTemplate = txtMessage.Text;
        }
    }
}