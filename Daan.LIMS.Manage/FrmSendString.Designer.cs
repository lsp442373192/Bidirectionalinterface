namespace Daan.LIMS.Manage
{
    partial class FrmSendString
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSendString));
            this.webPdfReader = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webPdfReader
            // 
            this.webPdfReader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webPdfReader.Location = new System.Drawing.Point(0, 0);
            this.webPdfReader.MinimumSize = new System.Drawing.Size(20, 20);
            this.webPdfReader.Name = "webPdfReader";
            this.webPdfReader.Size = new System.Drawing.Size(806, 480);
            this.webPdfReader.TabIndex = 0;
            // 
            // FrmSendString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 480);
            this.Controls.Add(this.webPdfReader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSendString";
            this.Text = "报告预览";
            this.Load += new System.EventHandler(this.FrmSendString_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webPdfReader;
    }
}