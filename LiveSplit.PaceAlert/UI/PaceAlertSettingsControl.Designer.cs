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
            this.cboSelectedSplit = new System.Windows.Forms.ComboBox();
            this.txtDeltaHour = new System.Windows.Forms.TextBox();
            this.txtDeltaMinute = new System.Windows.Forms.TextBox();
            this.txtDeltaSecond = new System.Windows.Forms.TextBox();
            this.txtDeltaMillisecond = new System.Windows.Forms.TextBox();
            this.lblDeltaHour = new System.Windows.Forms.Label();
            this.lblDeltaMinute = new System.Windows.Forms.Label();
            this.lblDeltaSecond = new System.Windows.Forms.Label();
            this.lblDeltaMillisecond = new System.Windows.Forms.Label();
            this.grpSplitCondition = new System.Windows.Forms.GroupBox();
            this.cboAheadBehind = new System.Windows.Forms.ComboBox();
            this.pnlComparison = new System.Windows.Forms.Panel();
            this.rdoRealTime = new System.Windows.Forms.RadioButton();
            this.rdoGameTime = new System.Windows.Forms.RadioButton();
            this.grpSplitCondition.SuspendLayout();
            this.pnlComparison.SuspendLayout();
            this.SuspendLayout();
            this.btnSetURL.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetURL.Location = new System.Drawing.Point(294, 10);
            this.btnSetURL.Margin = new System.Windows.Forms.Padding(3, 10, 10, 3);
            this.btnSetURL.Name = "btnSetURL";
            this.btnSetURL.Size = new System.Drawing.Size(146, 26);
            this.btnSetURL.TabIndex = 0;
            this.btnSetURL.Text = "Set Webhook URL";
            this.btnSetURL.UseVisualStyleBackColor = true;
            this.btnSetURL.Click += new System.EventHandler(this.btnSetURL_Click);
            this.txtMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMessage.Location = new System.Drawing.Point(10, 259);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(430, 100);
            this.txtMessage.TabIndex = 100;
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Location = new System.Drawing.Point(294, 365);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(146, 26);
            this.btnSendMessage.TabIndex = 101;
            this.btnSendMessage.Text = "Send Message (DEBUG)";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            this.cboSelectedSplit.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectedSplit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSelectedSplit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSelectedSplit.FormattingEnabled = true;
            this.cboSelectedSplit.Location = new System.Drawing.Point(6, 19);
            this.cboSelectedSplit.Name = "cboSelectedSplit";
            this.cboSelectedSplit.Size = new System.Drawing.Size(207, 21);
            this.cboSelectedSplit.TabIndex = 2;
            this.cboSelectedSplit.SelectedIndexChanged += new System.EventHandler(this.cboSelectedSplit_SelectedIndexChanged);
            this.txtDeltaHour.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeltaHour.Location = new System.Drawing.Point(257, 20);
            this.txtDeltaHour.Name = "txtDeltaHour";
            this.txtDeltaHour.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaHour.TabIndex = 4;
            this.txtDeltaHour.Text = "99";
            this.txtDeltaHour.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaHour_Validating);
            this.txtDeltaMinute.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeltaMinute.Location = new System.Drawing.Point(294, 20);
            this.txtDeltaMinute.Name = "txtDeltaMinute";
            this.txtDeltaMinute.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaMinute.TabIndex = 102;
            this.txtDeltaMinute.Text = "99";
            this.txtDeltaMinute.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaMinute_Validating);
            this.txtDeltaSecond.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeltaSecond.Location = new System.Drawing.Point(334, 20);
            this.txtDeltaSecond.Name = "txtDeltaSecond";
            this.txtDeltaSecond.Size = new System.Drawing.Size(18, 20);
            this.txtDeltaSecond.TabIndex = 103;
            this.txtDeltaSecond.Text = "99";
            this.txtDeltaSecond.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaSecond_Validating);
            this.txtDeltaMillisecond.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeltaMillisecond.Location = new System.Drawing.Point(374, 20);
            this.txtDeltaMillisecond.Name = "txtDeltaMillisecond";
            this.txtDeltaMillisecond.Size = new System.Drawing.Size(24, 20);
            this.txtDeltaMillisecond.TabIndex = 104;
            this.txtDeltaMillisecond.Text = "999";
            this.txtDeltaMillisecond.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeltaMillisecond_Validating);
            this.lblDeltaHour.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaHour.Location = new System.Drawing.Point(278, 20);
            this.lblDeltaHour.Name = "lblDeltaHour";
            this.lblDeltaHour.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaHour.TabIndex = 105;
            this.lblDeltaHour.Text = "h";
            this.lblDeltaHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeltaMinute.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaMinute.Location = new System.Drawing.Point(318, 20);
            this.lblDeltaMinute.Name = "lblDeltaMinute";
            this.lblDeltaMinute.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaMinute.TabIndex = 106;
            this.lblDeltaMinute.Text = "m";
            this.lblDeltaMinute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeltaSecond.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaSecond.Location = new System.Drawing.Point(358, 20);
            this.lblDeltaSecond.Name = "lblDeltaSecond";
            this.lblDeltaSecond.Size = new System.Drawing.Size(10, 21);
            this.lblDeltaSecond.TabIndex = 107;
            this.lblDeltaSecond.Text = "s";
            this.lblDeltaSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeltaMillisecond.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaMillisecond.Location = new System.Drawing.Point(404, 19);
            this.lblDeltaMillisecond.Name = "lblDeltaMillisecond";
            this.lblDeltaMillisecond.Size = new System.Drawing.Size(20, 21);
            this.lblDeltaMillisecond.TabIndex = 108;
            this.lblDeltaMillisecond.Text = "ms";
            this.lblDeltaMillisecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.grpSplitCondition.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSplitCondition.Controls.Add(this.cboAheadBehind);
            this.grpSplitCondition.Controls.Add(this.cboSelectedSplit);
            this.grpSplitCondition.Controls.Add(this.pnlComparison);
            this.grpSplitCondition.Controls.Add(this.txtDeltaHour);
            this.grpSplitCondition.Controls.Add(this.txtDeltaMinute);
            this.grpSplitCondition.Controls.Add(this.lblDeltaMillisecond);
            this.grpSplitCondition.Controls.Add(this.txtDeltaSecond);
            this.grpSplitCondition.Controls.Add(this.lblDeltaSecond);
            this.grpSplitCondition.Controls.Add(this.txtDeltaMillisecond);
            this.grpSplitCondition.Controls.Add(this.lblDeltaMinute);
            this.grpSplitCondition.Controls.Add(this.lblDeltaHour);
            this.grpSplitCondition.Location = new System.Drawing.Point(10, 40);
            this.grpSplitCondition.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.grpSplitCondition.Name = "grpSplitCondition";
            this.grpSplitCondition.Size = new System.Drawing.Size(430, 72);
            this.grpSplitCondition.TabIndex = 115;
            this.grpSplitCondition.TabStop = false;
            this.grpSplitCondition.Text = "Split Condition";
            this.cboAheadBehind.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAheadBehind.FormattingEnabled = true;
            this.cboAheadBehind.Items.AddRange(new object[] {"-", "+"});
            this.cboAheadBehind.Location = new System.Drawing.Point(219, 19);
            this.cboAheadBehind.Name = "cboAheadBehind";
            this.cboAheadBehind.Size = new System.Drawing.Size(32, 21);
            this.cboAheadBehind.TabIndex = 115;
            this.cboAheadBehind.Text = "-";
            this.cboAheadBehind.SelectedIndexChanged += new System.EventHandler(this.cboAheadBehind_SelectedIndexChanged);
            this.pnlComparison.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlComparison.Controls.Add(this.rdoRealTime);
            this.pnlComparison.Controls.Add(this.rdoGameTime);
            this.pnlComparison.Location = new System.Drawing.Point(219, 43);
            this.pnlComparison.Margin = new System.Windows.Forms.Padding(0);
            this.pnlComparison.Name = "pnlComparison";
            this.pnlComparison.Size = new System.Drawing.Size(210, 27);
            this.pnlComparison.TabIndex = 114;
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
            this.rdoRealTime.CheckedChanged += new System.EventHandler(this.rdoRealTime_CheckedChanged);
            this.rdoGameTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdoGameTime.Location = new System.Drawing.Point(100, 3);
            this.rdoGameTime.Name = "rdoGameTime";
            this.rdoGameTime.Size = new System.Drawing.Size(91, 21);
            this.rdoGameTime.TabIndex = 112;
            this.rdoGameTime.Text = "Game Time";
            this.rdoGameTime.UseVisualStyleBackColor = true;
            this.rdoGameTime.CheckedChanged += new System.EventHandler(this.rdoGameTime_CheckedChanged);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSplitCondition);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSetURL);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PaceAlertSettingsControl";
            this.Size = new System.Drawing.Size(450, 401);
            this.grpSplitCondition.ResumeLayout(false);
            this.grpSplitCondition.PerformLayout();
            this.pnlComparison.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSetURL;
        private System.Windows.Forms.ComboBox cboAheadBehind;
        private System.Windows.Forms.ComboBox cboSelectedSplit;
        private System.Windows.Forms.GroupBox grpSplitCondition;
        private System.Windows.Forms.Label lblDeltaHour;
        private System.Windows.Forms.Label lblDeltaMillisecond;
        private System.Windows.Forms.Label lblDeltaMinute;
        private System.Windows.Forms.Label lblDeltaSecond;
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