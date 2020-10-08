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
            this.lblDelta = new System.Windows.Forms.Label();
            this.txtDeltaHour = new System.Windows.Forms.TextBox();
            this.txtDeltaMinute = new System.Windows.Forms.TextBox();
            this.txtDeltaSecond = new System.Windows.Forms.TextBox();
            this.txtDeltaMillisecond = new System.Windows.Forms.TextBox();
            this.lblDeltaHour = new System.Windows.Forms.Label();
            this.lblDeltaMinute = new System.Windows.Forms.Label();
            this.lblDeltaSecond = new System.Windows.Forms.Label();
            this.lblDeltaMillisecond = new System.Windows.Forms.Label();
            this.rdoGameTime = new System.Windows.Forms.RadioButton();
            this.rdoRealTime = new System.Windows.Forms.RadioButton();
            this.rdoBehind = new System.Windows.Forms.RadioButton();
            this.rdoAhead = new System.Windows.Forms.RadioButton();
            this.pnlAheadBehind = new System.Windows.Forms.Panel();
            this.pnlComparison = new System.Windows.Forms.Panel();
            this.pnlAheadBehind.SuspendLayout();
            this.pnlComparison.SuspendLayout();
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
            this.txtMessage.Location = new System.Drawing.Point(3, 266);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(444, 100);
            this.txtMessage.TabIndex = 100;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Location = new System.Drawing.Point(301, 372);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(146, 26);
            this.btnSendMessage.TabIndex = 101;
            this.btnSendMessage.Text = "Send Message (DEBUG)";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblSelectedSplit
            // 
            this.lblSelectedSplit.Location = new System.Drawing.Point(3, 32);
            this.lblSelectedSplit.Name = "lblSelectedSplit";
            this.lblSelectedSplit.Size = new System.Drawing.Size(146, 21);
            this.lblSelectedSplit.TabIndex = 1;
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
            this.cboSelectedSplit.TabIndex = 2;
            this.cboSelectedSplit.SelectedIndexChanged += new System.EventHandler(this.cboSelectedSplit_SelectedIndexChanged);
            // 
            // lblDelta
            // 
            this.lblDelta.Location = new System.Drawing.Point(3, 53);
            this.lblDelta.Name = "lblDelta";
            this.lblDelta.Size = new System.Drawing.Size(146, 21);
            this.lblDelta.TabIndex = 3;
            this.lblDelta.Text = "Target Delta";
            // 
            // txtDeltaHour
            // 
            this.txtDeltaHour.Location = new System.Drawing.Point(155, 53);
            this.txtDeltaHour.Name = "txtDeltaHour";
            this.txtDeltaHour.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaHour.TabIndex = 4;
            this.txtDeltaHour.Text = "99";
            this.txtDeltaHour.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaHour_Validating);
            // 
            // txtDeltaMinute
            // 
            this.txtDeltaMinute.Location = new System.Drawing.Point(192, 53);
            this.txtDeltaMinute.Name = "txtDeltaMinute";
            this.txtDeltaMinute.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaMinute.TabIndex = 102;
            this.txtDeltaMinute.Text = "99";
            this.txtDeltaMinute.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaMinute_Validating);
            // 
            // txtDeltaSecond
            // 
            this.txtDeltaSecond.Location = new System.Drawing.Point(232, 53);
            this.txtDeltaSecond.Name = "txtDeltaSecond";
            this.txtDeltaSecond.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaSecond.TabIndex = 103;
            this.txtDeltaSecond.Text = "99";
            this.txtDeltaSecond.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaSecond_Validating);
            // 
            // txtDeltaMillisecond
            // 
            this.txtDeltaMillisecond.Location = new System.Drawing.Point(272, 53);
            this.txtDeltaMillisecond.Name = "txtDeltaMillisecond";
            this.txtDeltaMillisecond.Size = new System.Drawing.Size(24, 20);
            this.txtDeltaMillisecond.TabIndex = 104;
            this.txtDeltaMillisecond.Text = "999";
            this.txtDeltaMillisecond.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaMillisecond_Validating);
            // 
            // lblDeltaHour
            // 
            this.lblDeltaHour.Location = new System.Drawing.Point(176, 53);
            this.lblDeltaHour.Name = "lblDeltaHour";
            this.lblDeltaHour.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaHour.TabIndex = 105;
            this.lblDeltaHour.Text = "h";
            this.lblDeltaHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeltaMinute
            // 
            this.lblDeltaMinute.Location = new System.Drawing.Point(216, 53);
            this.lblDeltaMinute.Name = "lblDeltaMinute";
            this.lblDeltaMinute.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaMinute.TabIndex = 106;
            this.lblDeltaMinute.Text = "m";
            this.lblDeltaMinute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeltaSecond
            // 
            this.lblDeltaSecond.Location = new System.Drawing.Point(256, 53);
            this.lblDeltaSecond.Name = "lblDeltaSecond";
            this.lblDeltaSecond.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaSecond.TabIndex = 107;
            this.lblDeltaSecond.Text = "s";
            this.lblDeltaSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeltaMillisecond
            // 
            this.lblDeltaMillisecond.Location = new System.Drawing.Point(302, 53);
            this.lblDeltaMillisecond.Name = "lblDeltaMillisecond";
            this.lblDeltaMillisecond.Size = new System.Drawing.Size(20, 21);
            this.lblDeltaMillisecond.TabIndex = 108;
            this.lblDeltaMillisecond.Text = "ms";
            this.lblDeltaMillisecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdoGameTime
            // 
            this.rdoGameTime.Location = new System.Drawing.Point(79, 0);
            this.rdoGameTime.Name = "rdoGameTime";
            this.rdoGameTime.Size = new System.Drawing.Size(91, 21);
            this.rdoGameTime.TabIndex = 112;
            this.rdoGameTime.Text = "Game Time";
            this.rdoGameTime.UseVisualStyleBackColor = true;
            this.rdoGameTime.CheckedChanged += new System.EventHandler(this.rdoGameTime_CheckedChanged);
            // 
            // rdoRealTime
            // 
            this.rdoRealTime.Checked = true;
            this.rdoRealTime.Location = new System.Drawing.Point(0, 0);
            this.rdoRealTime.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.rdoRealTime.Name = "rdoRealTime";
            this.rdoRealTime.Size = new System.Drawing.Size(73, 21);
            this.rdoRealTime.TabIndex = 111;
            this.rdoRealTime.TabStop = true;
            this.rdoRealTime.Text = "Real Time";
            this.rdoRealTime.UseVisualStyleBackColor = true;
            this.rdoRealTime.CheckedChanged += new System.EventHandler(this.rdoRealTime_CheckedChanged);
            // 
            // rdoBehind
            // 
            this.rdoBehind.Location = new System.Drawing.Point(79, 0);
            this.rdoBehind.Name = "rdoBehind";
            this.rdoBehind.Size = new System.Drawing.Size(91, 21);
            this.rdoBehind.TabIndex = 110;
            this.rdoBehind.Text = "Behind";
            this.rdoBehind.UseVisualStyleBackColor = true;
            this.rdoBehind.CheckedChanged += new System.EventHandler(this.rdoBehind_CheckedChanged);
            // 
            // rdoAhead
            // 
            this.rdoAhead.Checked = true;
            this.rdoAhead.Location = new System.Drawing.Point(0, 0);
            this.rdoAhead.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.rdoAhead.Name = "rdoAhead";
            this.rdoAhead.Size = new System.Drawing.Size(73, 21);
            this.rdoAhead.TabIndex = 109;
            this.rdoAhead.TabStop = true;
            this.rdoAhead.Text = "Ahead";
            this.rdoAhead.UseVisualStyleBackColor = true;
            this.rdoAhead.CheckedChanged += new System.EventHandler(this.rdoAhead_CheckedChanged);
            // 
            // pnlAheadBehind
            // 
            this.pnlAheadBehind.Controls.Add(this.rdoAhead);
            this.pnlAheadBehind.Controls.Add(this.rdoBehind);
            this.pnlAheadBehind.Location = new System.Drawing.Point(16, 74);
            this.pnlAheadBehind.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlAheadBehind.Name = "pnlAheadBehind";
            this.pnlAheadBehind.Size = new System.Drawing.Size(156, 21);
            this.pnlAheadBehind.TabIndex = 113;
            // 
            // pnlComparison
            // 
            this.pnlComparison.Controls.Add(this.rdoRealTime);
            this.pnlComparison.Controls.Add(this.rdoGameTime);
            this.pnlComparison.Location = new System.Drawing.Point(16, 95);
            this.pnlComparison.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.pnlComparison.Name = "pnlComparison";
            this.pnlComparison.Size = new System.Drawing.Size(168, 20);
            this.pnlComparison.TabIndex = 114;
            // 
            // PaceAlertSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlComparison);
            this.Controls.Add(this.pnlAheadBehind);
            this.Controls.Add(this.lblDeltaMillisecond);
            this.Controls.Add(this.lblDeltaSecond);
            this.Controls.Add(this.lblDeltaMinute);
            this.Controls.Add(this.lblDeltaHour);
            this.Controls.Add(this.txtDeltaMillisecond);
            this.Controls.Add(this.txtDeltaSecond);
            this.Controls.Add(this.txtDeltaMinute);
            this.Controls.Add(this.txtDeltaHour);
            this.Controls.Add(this.lblDelta);
            this.Controls.Add(this.cboSelectedSplit);
            this.Controls.Add(this.lblSelectedSplit);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSetURL);
            this.Name = "PaceAlertSettingsControl";
            this.Size = new System.Drawing.Size(450, 401);
            this.pnlAheadBehind.ResumeLayout(false);
            this.pnlComparison.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSetURL;
        private System.Windows.Forms.ComboBox cboSelectedSplit;
        private System.Windows.Forms.Label lblDelta;
        private System.Windows.Forms.Label lblDeltaHour;
        private System.Windows.Forms.Label lblDeltaMillisecond;
        private System.Windows.Forms.Label lblDeltaMinute;
        private System.Windows.Forms.Label lblDeltaSecond;
        private System.Windows.Forms.Label lblSelectedSplit;
        private System.Windows.Forms.Panel pnlAheadBehind;
        private System.Windows.Forms.Panel pnlComparison;
        private System.Windows.Forms.RadioButton rdoAhead;
        private System.Windows.Forms.RadioButton rdoBehind;
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