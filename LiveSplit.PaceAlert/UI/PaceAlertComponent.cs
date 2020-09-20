using System;
using System.IO;
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
        private PaceAlertSettingsControl _settingsControlControl;

        public PaceAlertComponent(LiveSplitState state)
        {
            _state = state;
            _settingsControlControl = new PaceAlertSettingsControl(state);
            StartBot();
        }

        public override void Dispose()
        {
            
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
                PaceBot.SetURL(webhookURL);
            }
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            
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