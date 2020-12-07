using System.IO;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.PaceAlert.UI;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.PaceAlert.Logic
{
    public class PaceAlertComponent : LogicComponent
    {
        private readonly NotificationManager _notificationManager;
        private readonly ComponentSettings _settings;
        private readonly PaceAlertSettingsControl _settingsControlControl;

        private LiveSplitState _state;

        public PaceAlertComponent(LiveSplitState state)
        {
            _state = state;

            _settings = new ComponentSettings();
            _settingsControlControl = new PaceAlertSettingsControl(state, _settings);
            _notificationManager = new NotificationManager(state, _settings);
            StartBot();
        }

        public override string ComponentName => PaceAlertFactory.PaceAlertName;

        public override void Dispose()
        {
            _settingsControlControl.Dispose();
            _notificationManager.Dispose();
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

            if (webhookURL != null) PaceBot.Connect(webhookURL);
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height,
            LayoutMode mode)
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