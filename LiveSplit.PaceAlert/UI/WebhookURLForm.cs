using System;
using System.IO;
using System.Windows.Forms;
using LiveSplit.PaceAlert.Discord;

namespace LiveSplit.PaceAlert.UI
{
    public partial class WebhookURLForm : Form
    {
        public WebhookURLForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Save URL
            // TODO: Find better option than plaintext?
            try
            {
                File.WriteAllText("webhookURL",txtWebhookURL.Text);
            }
            catch (IOException exception)
            {
                // Do Something
            }
            
            PaceBot.SetURL(txtWebhookURL.Text);
            
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}