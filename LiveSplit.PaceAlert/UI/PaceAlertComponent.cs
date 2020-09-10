using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using LiveSplitCore;

namespace LiveSplit.PaceAlert.UI
{
    public class PaceAlertComponent : LogicComponent
    {
        public override string ComponentName => PaceAlertFactory.PaceAlertName;

        private LiveSplitState _state;
        private PaceAlertSettings _settings;

        public PaceAlertComponent(LiveSplitState state)
        {
            _state = state;
            _settings = new PaceAlertSettings();
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
                Task.Factory.StartNew(delegate { new PaceBot().MainAsync(webhookURL).GetAwaiter().GetResult(); }, TaskCreationOptions.LongRunning);
            }
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return _settings;
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return _settings.GetSettings(document);
        }

        public override void SetSettings(XmlNode settings)
        {
            _settings.SetSettings(settings);
        }
    }
}