using System;
using System.Windows.Forms;
using System.Xml;

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
    }
}