using System.ComponentModel;

namespace LiveSplit.PaceAlert.UI
{
    partial class PaceAlertSettings
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
            // PaceAlertSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetURL);
            this.Name = "PaceAlertSettings";
            this.Size = new System.Drawing.Size(450, 150);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnSetURL;

        #endregion
    }
}