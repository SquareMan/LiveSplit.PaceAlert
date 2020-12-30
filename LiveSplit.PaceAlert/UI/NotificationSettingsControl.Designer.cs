using System;
using System.ComponentModel;

namespace LiveSplit.PaceAlert.UI
{
    partial class NotificationSettingsControl
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
            this.grpNotificationCondition = new System.Windows.Forms.GroupBox();
            this.chkTakeScreenshot = new System.Windows.Forms.CheckBox();
            this.cboNotificationType = new System.Windows.Forms.ComboBox();
            this.lblNotificationType = new System.Windows.Forms.Label();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtMessage = new LiveSplit.PaceAlert.UI.MessageTextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.cboSelectedSplit = new System.Windows.Forms.ComboBox();
            this.pnlComparison = new System.Windows.Forms.Panel();
            this.rdoRealTime = new System.Windows.Forms.RadioButton();
            this.rdoGameTime = new System.Windows.Forms.RadioButton();
            this.txtTimeSpan = new System.Windows.Forms.TextBox();
            this.grpNotificationCondition.SuspendLayout();
            this.grpMessage.SuspendLayout();
            this.grpCondition.SuspendLayout();
            this.pnlComparison.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNotificationCondition
            // 
            this.grpNotificationCondition.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNotificationCondition.Controls.Add(this.chkTakeScreenshot);
            this.grpNotificationCondition.Controls.Add(this.cboNotificationType);
            this.grpNotificationCondition.Controls.Add(this.lblNotificationType);
            this.grpNotificationCondition.Controls.Add(this.grpMessage);
            this.grpNotificationCondition.Controls.Add(this.grpCondition);
            this.grpNotificationCondition.Location = new System.Drawing.Point(0, 0);
            this.grpNotificationCondition.Name = "grpNotificationCondition";
            this.grpNotificationCondition.Size = new System.Drawing.Size(430, 247);
            this.grpNotificationCondition.TabIndex = 116;
            this.grpNotificationCondition.TabStop = false;
            this.grpNotificationCondition.Text = "Notification Settings";
            // 
            // chkTakeScreenshot
            // 
            this.chkTakeScreenshot.Location = new System.Drawing.Point(272, 18);
            this.chkTakeScreenshot.Name = "chkTakeScreenshot";
            this.chkTakeScreenshot.Size = new System.Drawing.Size(130, 16);
            this.chkTakeScreenshot.TabIndex = 120;
            this.chkTakeScreenshot.Text = "Take Screenshot";
            this.chkTakeScreenshot.UseVisualStyleBackColor = true;
            this.chkTakeScreenshot.CheckedChanged += new System.EventHandler(this.chkTakeScreenshot_CheckedChanged);
            // 
            // cboNotificationType
            // 
            this.cboNotificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotificationType.Location = new System.Drawing.Point(105, 16);
            this.cboNotificationType.Name = "cboNotificationType";
            this.cboNotificationType.Size = new System.Drawing.Size(161, 21);
            this.cboNotificationType.TabIndex = 119;
            this.cboNotificationType.SelectionChangeCommitted += new System.EventHandler(this.cboNotificationType_SelectionChangeCommitted);
            // 
            // lblNotificationType
            // 
            this.lblNotificationType.Location = new System.Drawing.Point(12, 16);
            this.lblNotificationType.Name = "lblNotificationType";
            this.lblNotificationType.Size = new System.Drawing.Size(87, 21);
            this.lblNotificationType.TabIndex = 118;
            this.lblNotificationType.Text = "Notification Type";
            this.lblNotificationType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpMessage
            // 
            this.grpMessage.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMessage.Controls.Add(this.btnRemove);
            this.grpMessage.Controls.Add(this.txtMessage);
            this.grpMessage.Controls.Add(this.btnSendMessage);
            this.grpMessage.Location = new System.Drawing.Point(6, 122);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(418, 119);
            this.grpMessage.TabIndex = 117;
            this.grpMessage.TabStop = false;
            this.grpMessage.Text = "Message Template";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(145, 89);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(115, 26);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove Notification";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsReturn = true;
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.ListBox = null;
            this.txtMessage.Location = new System.Drawing.Point(6, 19);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(406, 64);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.Text = "Line 1\r\nLine 2\r\nLine 3";
            this.txtMessage.WordWrap = false;
            this.txtMessage.Validated += new System.EventHandler(this.txtMessage_Validated);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Location = new System.Drawing.Point(266, 89);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(146, 26);
            this.btnSendMessage.TabIndex = 11;
            this.btnSendMessage.Text = "Send Message (DEBUG)";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // grpCondition
            // 
            this.grpCondition.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCondition.Controls.Add(this.cboSelectedSplit);
            this.grpCondition.Controls.Add(this.pnlComparison);
            this.grpCondition.Controls.Add(this.txtTimeSpan);
            this.grpCondition.Location = new System.Drawing.Point(6, 43);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(418, 73);
            this.grpCondition.TabIndex = 116;
            this.grpCondition.TabStop = false;
            this.grpCondition.Text = "Condition";
            // 
            // cboSelectedSplit
            // 
            this.cboSelectedSplit.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectedSplit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectedSplit.Location = new System.Drawing.Point(6, 19);
            this.cboSelectedSplit.Name = "cboSelectedSplit";
            this.cboSelectedSplit.Size = new System.Drawing.Size(337, 21);
            this.cboSelectedSplit.TabIndex = 0;
            this.cboSelectedSplit.SelectionChangeCommitted += new System.EventHandler(this.cboSelectedSplit_SelectionChangeCommitted);
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
            this.pnlComparison.TabIndex = 12;
            // 
            // rdoRealTime
            // 
            this.rdoRealTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdoRealTime.Checked = true;
            this.rdoRealTime.Location = new System.Drawing.Point(21, 3);
            this.rdoRealTime.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.rdoRealTime.Name = "rdoRealTime";
            this.rdoRealTime.Size = new System.Drawing.Size(73, 21);
            this.rdoRealTime.TabIndex = 6;
            this.rdoRealTime.TabStop = true;
            this.rdoRealTime.Text = "Real Time";
            this.rdoRealTime.UseVisualStyleBackColor = true;
            this.rdoRealTime.CheckedChanged += new System.EventHandler(this.rdoRealTime_CheckedChanged);
            // 
            // rdoGameTime
            // 
            this.rdoGameTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdoGameTime.Location = new System.Drawing.Point(100, 3);
            this.rdoGameTime.Name = "rdoGameTime";
            this.rdoGameTime.Size = new System.Drawing.Size(91, 21);
            this.rdoGameTime.TabIndex = 7;
            this.rdoGameTime.Text = "Game Time";
            this.rdoGameTime.UseVisualStyleBackColor = true;
            // 
            // txtTimeSpan
            // 
            this.txtTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeSpan.Location = new System.Drawing.Point(349, 19);
            this.txtTimeSpan.Name = "txtTimeSpan";
            this.txtTimeSpan.Size = new System.Drawing.Size(63, 20);
            this.txtTimeSpan.TabIndex = 5;
            this.txtTimeSpan.Text = "12:34:56.78";
            this.txtTimeSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimeSpan.Validating += new System.ComponentModel.CancelEventHandler(this.txtTimeSpan_Validating);
            // 
            // NotificationSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.grpNotificationCondition);
            this.Name = "NotificationSettingsControl";
            this.Size = new System.Drawing.Size(430, 250);
            this.grpNotificationCondition.ResumeLayout(false);
            this.grpMessage.ResumeLayout(false);
            this.grpMessage.PerformLayout();
            this.grpCondition.ResumeLayout(false);
            this.grpCondition.PerformLayout();
            this.pnlComparison.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox chkTakeScreenshot;

        private System.Windows.Forms.ComboBox cboNotificationType;
        private System.Windows.Forms.Label lblNotificationType;
        private System.Windows.Forms.Button btnRemove;

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.ComboBox cboSelectedSplit;
        private System.Windows.Forms.GroupBox grpCondition;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.GroupBox grpNotificationCondition;
        private System.Windows.Forms.Panel pnlComparison;
        private System.Windows.Forms.RadioButton rdoGameTime;
        private System.Windows.Forms.RadioButton rdoRealTime;
        private System.Windows.Forms.TextBox txtTimeSpan;
        private LiveSplit.PaceAlert.UI.MessageTextBox txtMessage;

        #endregion
    }
}