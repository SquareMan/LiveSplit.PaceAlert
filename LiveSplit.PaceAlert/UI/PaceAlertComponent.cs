using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.PaceAlert.Logic;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.PaceAlert.UI
{
    public class PaceAlertComponent : LogicComponent
    {
        public override string ComponentName => PaceAlertFactory.PaceAlertName;

        private LiveSplitState _state;
        private ComponentSettings _settings;
        private PaceAlertSettingsControl _settingsControlControl;
        private bool notified = false;

        public PaceAlertComponent(LiveSplitState state)
        {
            _state = state;
            
            _settings = new ComponentSettings();
            _settingsControlControl = new PaceAlertSettingsControl(state, _settings);
            StartBot();

            _state.OnSplit += PaceAlert_OnSplit;
            _state.OnStart += PaceAlert_OnStart;
        }

        public override void Dispose()
        {
            _settingsControlControl.Dispose();
            _state.OnSplit -= PaceAlert_OnSplit;
            _state.OnStart -= PaceAlert_OnStart;
        }

        private void StartBot()
        {
            string webhookURL = null;

            // TODO: Something better than plaintext?
            try
            {
                webhookURL = File.ReadAllText("webhookURL");
            }
            catch (IOException e)
            {
                // Do Something
            }

            if (webhookURL != null)
            {
                PaceBot.Connect(webhookURL);
            }
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            
        }

        private void PaceAlert_OnStart(object sender, EventArgs e)
        {
            notified = false;
        }

        private void PaceAlert_OnSplit(object sender, EventArgs e)
        {
            var activeSettings = _settings.GetActiveSettings(_state);

            foreach (var setting in activeSettings)
            {
                if (notified || _state.CurrentSplitIndex != setting.SelectedSplit + 1)
                    continue;
                
                var split = _state.Run[setting.SelectedSplit];
                var delta = (split.SplitTime - split.PersonalBestSplitTime)[setting.Comparison];

                if (!delta.HasValue) continue;
                
                var deltaValue = delta.Value;
                var deltaTarget = setting.Ahead
                    ? setting.DeltaTarget.Negate()
                    : setting.DeltaTarget;

                if (!(deltaValue.TotalSeconds < deltaTarget.TotalSeconds))
                    continue;
                
                StringBuilder messageStringBuilder = new StringBuilder();
                string[] substrings = setting.MessageTemplate.Split('$');
                foreach (var substring in substrings)
                {
                    //Parse message variables
                    if (substring.StartsWith("delta"))
                    {
                        string time = ToDeltaFormat(deltaValue);
                        char negative = deltaValue.TotalMilliseconds < 0 ? '-' : '+';
                        messageStringBuilder.Append(negative + time);
                        messageStringBuilder.Append(substring.Substring("delta".Length));
                    }
                    else if (substring.StartsWith("split"))
                    {
                        messageStringBuilder.Append(split.Name);
                        messageStringBuilder.Append(substring.Substring("split".Length));
                    }
                    else
                    {
                        messageStringBuilder.Append(substring);
                    }
                }

                var messageString = messageStringBuilder.ToString();
                if (messageString != string.Empty)
                {
                    PaceBot.SendMessage(messageString);
                }

                notified = true;
            }
        }

        private string ToDeltaFormat(TimeSpan t)
        {
            //TODO: The existence of this method is stupid
            if (t.Hours != 0)
            {
                return t.ToString(@"h\:mm\:ss\.ff");
            }

            if (t.Minutes != 0)
            {
                return t.ToString(@"m\:ss\.ff");
            }
            
            return t.ToString(@"s\.ff");
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return _settingsControlControl;
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return _settingsControlControl.GetSettings(document);
        }

        public override void SetSettings(XmlNode settings)
        {
            _settingsControlControl.SetSettings(settings);
        }
    }
}