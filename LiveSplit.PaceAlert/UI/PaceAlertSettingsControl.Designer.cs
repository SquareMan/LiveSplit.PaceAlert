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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.cboSelectedSplit = new System.Windows.Forms.ComboBox();
            this.txtDeltaHour = new System.Windows.Forms.TextBox();
            this.txtDeltaMinute = new System.Windows.Forms.TextBox();
            this.txtDeltaSecond = new System.Windows.Forms.TextBox();
            this.txtDeltaMillisecond = new System.Windows.Forms.TextBox();
            this.lblDeltaHour = new System.Windows.Forms.Label();
            this.lblDeltaMinute = new System.Windows.Forms.Label();
            this.lblDeltaSecond = new System.Windows.Forms.Label();
            this.lblDeltaMillisecond = new System.Windows.Forms.Label();
            this.grpNotificationCondition = new System.Windows.Forms.GroupBox();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.btnVariables = new System.Windows.Forms.Button();
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.pnlComparison = new System.Windows.Forms.Panel();
            this.rdoRealTime = new System.Windows.Forms.RadioButton();
            this.rdoGameTime = new System.Windows.Forms.RadioButton();
            this.cboAheadBehind = new System.Windows.Forms.ComboBox();
            this.lblWebhookStatus = new System.Windows.Forms.Label();
            this.grpNotificationCondition.SuspendLayout();
            this.grpMessage.SuspendLayout();
            this.grpCondition.SuspendLayout();
            this.pnlComparison.SuspendLayout();
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
            // txtMessage
            // 
            this.txtMessage.AcceptsReturn = true;
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(6, 19);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(406, 131);
            this.txtMessage.TabIndex = 100;
            this.txtMessage.WordWrap = false;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Location = new System.Drawing.Point(266, 156);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(146, 26);
            this.btnSendMessage.TabIndex = 101;
            this.btnSendMessage.Text = "Send Message (DEBUG)";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // cboSelectedSplit
            // 
            this.cboSelectedSplit.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectedSplit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSelectedSplit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSelectedSplit.FormattingEnabled = true;
            this.cboSelectedSplit.Location = new System.Drawing.Point(6, 19);
            this.cboSelectedSplit.Name = "cboSelectedSplit";
            this.cboSelectedSplit.Size = new System.Drawing.Size(217, 21);
            this.cboSelectedSplit.TabIndex = 2;
            // 
            // txtDeltaHour
            // 
            this.txtDeltaHour.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeltaHour.Location = new System.Drawing.Point(267, 20);
            this.txtDeltaHour.Name = "txtDeltaHour";
            this.txtDeltaHour.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaHour.TabIndex = 4;
            this.txtDeltaHour.Text = "99";
            this.txtDeltaHour.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaHour_Validating);
            // 
            // txtDeltaMinute
            // 
            this.txtDeltaMinute.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeltaMinute.Location = new System.Drawing.Point(300, 20);
            this.txtDeltaMinute.Name = "txtDeltaMinute";
            this.txtDeltaMinute.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaMinute.TabIndex = 102;
            this.txtDeltaMinute.Text = "99";
            this.txtDeltaMinute.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaMinute_Validating);
            // 
            // txtDeltaSecond
            // 
            this.txtDeltaSecond.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeltaSecond.Location = new System.Drawing.Point(334, 19);
            this.txtDeltaSecond.Name = "txtDeltaSecond";
            this.txtDeltaSecond.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaSecond.TabIndex = 103;
            this.txtDeltaSecond.Text = "99";
            this.txtDeltaSecond.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaSecond_Validating);
            // 
            // txtDeltaMillisecond
            // 
            this.txtDeltaMillisecond.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeltaMillisecond.Location = new System.Drawing.Point(368, 19);
            this.txtDeltaMillisecond.Name = "txtDeltaMillisecond";
            this.txtDeltaMillisecond.Size = new System.Drawing.Size(24, 20);
            this.txtDeltaMillisecond.TabIndex = 104;
            this.txtDeltaMillisecond.Text = "999";
            this.txtDeltaMillisecond.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaMillisecond_Validating);
            // 
            // lblDeltaHour
            // 
            this.lblDeltaHour.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaHour.Location = new System.Drawing.Point(288, 19);
            this.lblDeltaHour.Margin = new System.Windows.Forms.Padding(0);
            this.lblDeltaHour.Name = "lblDeltaHour";
            this.lblDeltaHour.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaHour.TabIndex = 105;
            this.lblDeltaHour.Text = "h";
            this.lblDeltaHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeltaMinute
            // 
            this.lblDeltaMinute.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaMinute.Location = new System.Drawing.Point(321, 19);
            this.lblDeltaMinute.Margin = new System.Windows.Forms.Padding(0);
            this.lblDeltaMinute.Name = "lblDeltaMinute";
            this.lblDeltaMinute.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaMinute.TabIndex = 106;
            this.lblDeltaMinute.Text = "m";
            this.lblDeltaMinute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeltaSecond
            // 
            this.lblDeltaSecond.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaSecond.Location = new System.Drawing.Point(355, 18);
            this.lblDeltaSecond.Margin = new System.Windows.Forms.Padding(0);
            this.lblDeltaSecond.Name = "lblDeltaSecond";
            this.lblDeltaSecond.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaSecond.TabIndex = 107;
            this.lblDeltaSecond.Text = "s";
            this.lblDeltaSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeltaMillisecond
            // 
            this.lblDeltaMillisecond.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaMillisecond.Location = new System.Drawing.Point(395, 18);
            this.lblDeltaMillisecond.Margin = new System.Windows.Forms.Padding(0);
            this.lblDeltaMillisecond.Name = "lblDeltaMillisecond";
            this.lblDeltaMillisecond.Size = new System.Drawing.Size(20, 21);
            this.lblDeltaMillisecond.TabIndex = 108;
            this.lblDeltaMillisecond.Text = "ms";
            this.lblDeltaMillisecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpNotificationCondition
            // 
            this.grpNotificationCondition.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNotificationCondition.Controls.Add(this.grpMessage);
            this.grpNotificationCondition.Controls.Add(this.grpCondition);
            this.grpNotificationCondition.Location = new System.Drawing.Point(10, 40);
            this.grpNotificationCondition.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.grpNotificationCondition.Name = "grpNotificationCondition";
            this.grpNotificationCondition.Size = new System.Drawing.Size(430, 292);
            this.grpNotificationCondition.TabIndex = 115;
            this.grpNotificationCondition.TabStop = false;
            this.grpNotificationCondition.Text = "Notification Settings";
            // 
            // grpMessage
            // 
            this.grpMessage.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMessage.Controls.Add(this.btnVariables);
            this.grpMessage.Controls.Add(this.txtMessage);
            this.grpMessage.Controls.Add(this.btnSendMessage);
            this.grpMessage.Location = new System.Drawing.Point(6, 98);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(418, 188);
            this.grpMessage.TabIndex = 117;
            this.grpMessage.TabStop = false;
            this.grpMessage.Text = "Message Template";
            // 
            // btnVariables
            // 
            this.btnVariables.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVariables.Location = new System.Drawing.Point(197, 156);
            this.btnVariables.Name = "btnVariables";
            this.btnVariables.Size = new System.Drawing.Size(63, 26);
            this.btnVariables.TabIndex = 116;
            this.btnVariables.Text = "Variables";
            this.btnVariables.UseVisualStyleBackColor = true;
            this.btnVariables.Click += new System.EventHandler(this.btnVariables_Click);
            // 
            // grpCondition
            // 
            this.grpCondition.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCondition.Controls.Add(this.cboSelectedSplit);
            this.grpCondition.Controls.Add(this.pnlComparison);
            this.grpCondition.Controls.Add(this.cboAheadBehind);
            this.grpCondition.Controls.Add(this.lblDeltaMillisecond);
            this.grpCondition.Controls.Add(this.txtDeltaMinute);
            this.grpCondition.Controls.Add(this.txtDeltaMillisecond);
            this.grpCondition.Controls.Add(this.lblDeltaSecond);
            this.grpCondition.Controls.Add(this.txtDeltaSecond);
            this.grpCondition.Controls.Add(this.txtDeltaHour);
            this.grpCondition.Controls.Add(this.lblDeltaHour);
            this.grpCondition.Controls.Add(this.lblDeltaMinute);
            this.grpCondition.Location = new System.Drawing.Point(6, 19);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(418, 73);
            this.grpCondition.TabIndex = 116;
            this.grpCondition.TabStop = false;
            this.grpCondition.Text = "Condition";
            // 
            // pnlComparison
            // 
            this.pnlComparison.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlComparison.Controls.Add(this.rdoRealTime);
            this.pnlComparison.Controls.Add(this.rdoGameTime);
            this.pnlComparison.Location = new System.Drawing.Point(205, 43);
            this.pnlComparison.Margin = new System.Windows.Forms.Padding(0);
            this.pnlComparison.Name = "pnlComparison";
            this.pnlComparison.Size = new System.Drawing.Size(210, 27);
            this.pnlComparison.TabIndex = 114;
            // 
            // rdoRealTime
            // 
            this.rdoRealTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdoRealTime.Checked = true;
            this.rdoRealTime.Location = new System.Drawing.Point(21, 3);
            this.rdoRealTime.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.rdoRealTime.Name = "rdoRealTime";
            this.rdoRealTime.Size = new System.Drawing.Size(73, 21);
            this.rdoRealTime.TabIndex = 111;
            this.rdoRealTime.TabStop = true;
            this.rdoRealTime.Text = "Real Time";
            this.rdoRealTime.UseVisualStyleBackColor = true;
            // 
            // rdoGameTime
            // 
            this.rdoGameTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdoGameTime.Location = new System.Drawing.Point(100, 3);
            this.rdoGameTime.Name = "rdoGameTime";
            this.rdoGameTime.Size = new System.Drawing.Size(91, 21);
            this.rdoGameTime.TabIndex = 112;
            this.rdoGameTime.Text = "Game Time";
            this.rdoGameTime.UseVisualStyleBackColor = true;
            // 
            // cboAheadBehind
            // 
            this.cboAheadBehind.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAheadBehind.FormattingEnabled = true;
            this.cboAheadBehind.Items.AddRange(new object[] {"-", "+"});
            this.cboAheadBehind.Location = new System.Drawing.Point(229, 19);
            this.cboAheadBehind.Name = "cboAheadBehind";
            this.cboAheadBehind.Size = new System.Drawing.Size(32, 21);
            this.cboAheadBehind.TabIndex = 115;
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
            // PaceAlertSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblWebhookStatus);
            this.Controls.Add(this.grpNotificationCondition);
            this.Controls.Add(this.btnSetURL);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PaceAlertSettingsControl";
            this.Size = new System.Drawing.Size(450, 401);
            this.Load += new System.EventHandler(this.PaceAlertSettingsControl_Load);
            this.grpNotificationCondition.ResumeLayout(false);
            this.grpMessage.ResumeLayout(false);
            this.grpMessage.PerformLayout();
            this.grpCondition.ResumeLayout(false);
            this.grpCondition.PerformLayout();
            this.pnlComparison.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSetURL;
        private System.Windows.Forms.Button btnVariables;
        private System.Windows.Forms.ComboBox cboAheadBehind;
        private System.Windows.Forms.ComboBox cboSelectedSplit;
        private System.Windows.Forms.GroupBox grpCondition;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.GroupBox grpNotificationCondition;
        private System.Windows.Forms.Label lblDeltaHour;
        private System.Windows.Forms.Label lblDeltaMillisecond;
        private System.Windows.Forms.Label lblDeltaMinute;
        private System.Windows.Forms.Label lblDeltaSecond;
        private System.Windows.Forms.Label lblWebhookStatus;
        private System.Windows.Forms.Panel pnlComparison;
        private System.Windows.Forms.RadioButton rdoGameTime;
        private System.Windows.Forms.RadioButton rdoRealTime;
        private System.Windows.Forms.TextBox txtDeltaHour;
        private System.Windows.Forms.TextBox txtDeltaMillisecond;
        private System.Windows.Forms.TextBox txtDeltaMinute;
        private System.Windows.Forms.TextBox txtDeltaSecond;
        private System.Windows.Forms.TextBox txtMessage;

        #endregion
    }
}