using System;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.PaceAlert.Discord;

namespace LiveSplit.PaceAlert.UI
{
    public partial class PaceAlertSettings : UserControl
    {
        public PaceAlertSettings()
        {
            InitializeComponent();
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return document.CreateElement("Settings");
        }

        public void SetSettings(XmlNode settings)
        {
            
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
    }
}