using System.ComponentModel;

namespace LiveSplit.PaceAlert.UI
{
    partial class PaceAlertSettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSetURL = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lblSelectedSplit = new System.Windows.Forms.Label();
            this.cboSelectedSplit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSetURL
            // 
            this.btnSetURL.Location = new System.Drawing.Point(3, 3);
            this.btnSetURL.Name = "btnSetURL";
            this.btnSetURL.Size = new System.Drawing.Size(146, 26);
            this.btnSetURL.TabIndex = 0;
            this.btnSetURL.Text = "Set Webhook URL";
            this.btnSetURL.UseVisualStyleBackColor = true;
            this.btnSetURL.Click += new System.EventHandler(this.btnSetURL_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMessage.Location = new System.Drawing.Point(3, 138);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(444, 100);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Location = new System.Drawing.Point(301, 244);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(146, 26);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "Send Message (DEBUG)";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblSelectedSplit
            // 
            this.lblSelectedSplit.Location = new System.Drawing.Point(3, 32);
            this.lblSelectedSplit.Name = "lblSelectedSplit";
            this.lblSelectedSplit.Size = new System.Drawing.Size(146, 21);
            this.lblSelectedSplit.TabIndex = 3;
            this.lblSelectedSplit.Text = "Split Condition";
            // 
            // cboSelectedSplit
            // 
            this.cboSelectedSplit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSelectedSplit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSelectedSplit.FormattingEnabled = true;
            this.cboSelectedSplit.Location = new System.Drawing.Point(155, 32);
            this.cboSelectedSplit.Name = "cboSelectedSplit";
            this.cboSelectedSplit.Size = new System.Drawing.Size(167, 21);
            this.cboSelectedSplit.TabIndex = 4;
            this.cboSelectedSplit.SelectedIndexChanged += new System.EventHandler(this.cboSelectedSplit_SelectedIndexChanged);
            // 
            // PaceAlertSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboSelectedSplit);
            this.Controls.Add(this.lblSelectedSplit);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSetURL);
            this.Name = "PaceAlertSettingsControl";
            this.Size = new System.Drawing.Size(450, 273);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSetURL;
        private System.Windows.Forms.ComboBox cboSelectedSplit;
        private System.Windows.Forms.Label lblSelectedSplit;
        private System.Windows.Forms.TextBox txtMessage;

        #endregion
    }
}