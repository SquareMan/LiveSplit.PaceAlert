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

namespace LiveSplit.PaceAlert.UI
{
    public partial class PaceAlertSettingsControl : UserControl
    {
        private List<NotificationSettings> _activeSettingsList;
        private readonly ComponentSettings _settings;
        private readonly LiveSplitState _state;
        private BindingList<string> splitNames;

        public PaceAlertSettingsControl(LiveSplitState state, ComponentSettings componentSettings)
        {
            _state = state;
            _settings = componentSettings;
            Dock = DockStyle.Fill;

            InitializeComponent();
            BuildSplitNames();
            SetActiveSettings();
            state.RunManuallyModified += splitNames_RunManuallyModified;
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            _state.RunManuallyModified -= splitNames_RunManuallyModified;

            if (disposing) components?.Dispose();

            base.Dispose(disposing);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var settingsElement = document.CreateElement("Settings");
            SettingsHelper.CreateSetting(document, settingsElement, "Version",
                Assembly.GetExecutingAssembly().GetName().Version.ToString(3));

            var splitsElement = document.CreateElement("RunFiles");
            settingsElement.AppendChild(splitsElement);

            foreach (var runSettingsKvp in _settings.SettingsDictionary)
            {
                var runElement = document.CreateElement("Run");
                splitsElement.AppendChild(runElement);
                SettingsHelper.CreateSetting(document, runElement, "FilePath", runSettingsKvp.Key);
                var runSettings = runSettingsKvp.Value;

                // Serialize settings for notifications
                foreach (var setting in runSettings)
                {
                    var settingElement = document.CreateElement("Notification");
                    runElement.AppendChild(settingElement);

                    SettingsHelper.CreateSetting(document, settingElement, "Type", setting.Type);
                    SettingsHelper.CreateSetting(document, settingElement, "SelectedSplit", setting.SelectedSplit);
                    SettingsHelper.CreateSetting(document, settingElement, "DeltaTarget", setting.DeltaTarget);
                    SettingsHelper.CreateSetting(document, settingElement, "Ahead", setting.Ahead);
                    SettingsHelper.CreateSetting(document, settingElement, "Comparison", setting.TimingMethod);
                    SettingsHelper.CreateSetting(document, settingElement, "MessageTemplate", setting.MessageTemplate);
                }
            }

            return settingsElement;
        }

        public void SetSettings(XmlNode settingsNode)
        {
            _settings.SettingsDictionary.Clear();

            var runNodes = settingsNode.SelectNodes(".//Run");
            if (runNodes != null)
                foreach (XmlNode runNode in runNodes)
                {
                    var filePath = SettingsHelper.ParseString(runNode["FilePath"]);
                    if (filePath == null)
                        continue;

                    var notificationSettingsList = new List<NotificationSettings>();
                    _settings.SettingsDictionary.Add(filePath, notificationSettingsList);

                    var notificationNodes = runNode.SelectNodes("Notification");
                    if (notificationNodes == null)
                        continue;

                    foreach (XmlNode notificationNode in notificationNodes)
                    {
                        var notificationSettings = new NotificationSettings
                        {
                            Type = SettingsHelper.ParseEnum(notificationNode["Type"], NotificationType.Delta),
                            SelectedSplit = SettingsHelper.ParseInt(notificationNode["SelectedSplit"], -1),
                            DeltaTarget = SettingsHelper.ParseTimeSpan(notificationNode["DeltaTarget"], TimeSpan.Zero),
                            Ahead = SettingsHelper.ParseBool(notificationNode["Ahead"], true),
                            TimingMethod =
                                SettingsHelper.ParseEnum(notificationNode["Comparison"], TimingMethod.RealTime),
                            MessageTemplate =
                                SettingsHelper.ParseString(notificationNode["MessageTemplate"], string.Empty)
                        };

                        notificationSettingsList.Add(notificationSettings);
                    }
                }

            SetActiveSettings();
        }

        private void SetActiveSettings()
        {
            if (_state.Run.FilePath == null)
                // No split file is opened.
                return;

            //Set form settings to settings associated with currently opened splits file.
            var settingsExist = _settings.SettingsDictionary.TryGetValue(_state.Run.FilePath, out _activeSettingsList);
            if (!settingsExist)
            {
                // No Settings Found
                _activeSettingsList = new List<NotificationSettings>();
                _settings.SettingsDictionary.Add(_state.Run.FilePath, _activeSettingsList);
            }

            flpConditionList.Controls.Clear();
            foreach (var setting in _activeSettingsList) AddNotificationControl(setting);
        }

        internal void RemoveNotificationControl(NotificationSettingsControl control)
        {
            flpConditionList.Controls.Remove(control);
            _activeSettingsList.Remove(control.BoundSettings);
        }

        private void AddNotificationControl(NotificationSettings settings)
        {
            var notificationControl = new NotificationSettingsControl(_state, splitNames);
            notificationControl.BindSettings(settings);
            flpConditionList.Controls.Add(notificationControl);
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

            for (var i = 0; i < _state.Run.Count; i++) splitNames.Add(_state.Run[i].Name);
        }

        private void splitNames_RunManuallyModified(object sender, EventArgs e)
        {
            // Determine if a new splits file has been loaded
            var newActiveSettings = _settings.GetActiveSettings(_state);
            if (newActiveSettings != _activeSettingsList)
            {
                BuildSplitNames();
                SetActiveSettings();
                return;
            }

            // TODO: Moving splits Up/Down results in a deletion followed by an addition, which isn't handled correctly
            for (var i = 0; i < _state.Run.Count; i++)
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
                //Split was removed from end
                splitNames.RemoveAt(splitNames.Count - 1);
        }

        private void PaceAlertSettingsControl_Load(object sender, EventArgs e)
        {
            flpConditionList.Visible = _activeSettingsList != null;
            btnAddNotification.Visible = _activeSettingsList != null;
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

        private void btnAddNotification_Click(object sender, EventArgs e)
        {
            var newSettings = new NotificationSettings();
            _activeSettingsList.Add(newSettings);
            AddNotificationControl(newSettings);
        }
    }
}