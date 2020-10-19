using System.ComponentModel;

namespace LiveSplit.PaceAlert.UI
{
    partial class PaceAlertSettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSetURL = new System.Windows.Forms.Button();
            this.lblWebhookStatus = new System.Windows.Forms.Label();
            this.flpConditionList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddNotification = new System.Windows.Forms.Button();
            this.btnVariables = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetURL
            // 
            this.btnSetURL.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetURL.Location = new System.Drawing.Point(304, 10);
            this.btnSetURL.Margin = new System.Windows.Forms.Padding(3, 10, 10, 3);
            this.btnSetURL.Name = "btnSetURL";
            this.btnSetURL.Size = new System.Drawing.Size(136, 26);
            this.btnSetURL.TabIndex = 0;
            this.btnSetURL.Text = "Set Webhook URL";
            this.btnSetURL.UseVisualStyleBackColor = true;
            this.btnSetURL.Click += new System.EventHandler(this.btnSetURL_Click);
            // 
            // lblWebhookStatus
            // 
            this.lblWebhookStatus.Location = new System.Drawing.Point(10, 10);
            this.lblWebhookStatus.Name = "lblWebhookStatus";
            this.lblWebhookStatus.Size = new System.Drawing.Size(290, 25);
            this.lblWebhookStatus.TabIndex = 116;
            this.lblWebhookStatus.Text = "Webhook Status: Not Connected";
            this.lblWebhookStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpConditionList
            // 
            this.flpConditionList.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flpConditionList.AutoScroll = true;
            this.flpConditionList.Location = new System.Drawing.Point(10, 42);
            this.flpConditionList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.flpConditionList.Name = "flpConditionList";
            this.flpConditionList.Size = new System.Drawing.Size(430, 110);
            this.flpConditionList.TabIndex = 117;
            // 
            // btnAddNotification
            // 
            this.btnAddNotification.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNotification.Location = new System.Drawing.Point(304, 158);
            this.btnAddNotification.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.btnAddNotification.Name = "btnAddNotification";
            this.btnAddNotification.Size = new System.Drawing.Size(136, 26);
            this.btnAddNotification.TabIndex = 118;
            this.btnAddNotification.Text = "Add Notification";
            this.btnAddNotification.UseVisualStyleBackColor = true;
            this.btnAddNotification.Click += new System.EventHandler(this.btnAddNotification_Click);
            // 
            // btnVariables
            // 
            this.btnVariables.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVariables.Location = new System.Drawing.Point(183, 158);
            this.btnVariables.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnVariables.Name = "btnVariables";
            this.btnVariables.Size = new System.Drawing.Size(115, 26);
            this.btnVariables.TabIndex = 119;
            this.btnVariables.Text = "Message Variables";
            this.btnVariables.UseVisualStyleBackColor = true;
            this.btnVariables.Click += new System.EventHandler(this.btnVariables_Click);
            // 
            // PaceAlertSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnVariables);
            this.Controls.Add(this.btnAddNotification);
            this.Controls.Add(this.flpConditionList);
            this.Controls.Add(this.lblWebhookStatus);
            this.Controls.Add(this.btnSetURL);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PaceAlertSettingsControl";
            this.Size = new System.Drawing.Size(450, 194);
            this.Load += new System.EventHandler(this.PaceAlertSettingsControl_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnAddNotification;
        private System.Windows.Forms.Button btnSetURL;
        private System.Windows.Forms.Button btnVariables;
        private System.Windows.Forms.FlowLayoutPanel flpConditionList;
        private System.Windows.Forms.Label lblWebhookStatus;

        #endregion
    }
}