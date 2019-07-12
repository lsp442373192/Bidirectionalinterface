namespace Daan.LIMS.Manage
{
    partial class FrmDockingService
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnParaSet = new System.Windows.Forms.Button();
            this.btnDataBaseConfig = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbStartService = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(348, 393);
            this.listBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbStartService);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDataBaseConfig);
            this.panel1.Controls.Add(this.btnParaSet);
            this.panel1.Controls.Add(this.btnStopService);
            this.panel1.Controls.Add(this.btnBegin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(348, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 393);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 393);
            this.panel2.TabIndex = 2;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(48, 28);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 0;
            this.btnBegin.Text = "开始服务";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Enabled = false;
            this.btnStopService.Location = new System.Drawing.Point(48, 80);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(75, 23);
            this.btnStopService.TabIndex = 1;
            this.btnStopService.Text = "停止服务";
            this.btnStopService.UseVisualStyleBackColor = true;
            // 
            // btnParaSet
            // 
            this.btnParaSet.Location = new System.Drawing.Point(48, 136);
            this.btnParaSet.Name = "btnParaSet";
            this.btnParaSet.Size = new System.Drawing.Size(75, 23);
            this.btnParaSet.TabIndex = 2;
            this.btnParaSet.Text = "参数设置";
            this.btnParaSet.UseVisualStyleBackColor = true;
            this.btnParaSet.Click += new System.EventHandler(this.btnParaSet_Click);
            // 
            // btnDataBaseConfig
            // 
            this.btnDataBaseConfig.Location = new System.Drawing.Point(48, 233);
            this.btnDataBaseConfig.Name = "btnDataBaseConfig";
            this.btnDataBaseConfig.Size = new System.Drawing.Size(75, 23);
            this.btnDataBaseConfig.TabIndex = 3;
            this.btnDataBaseConfig.Text = "数据库配置";
            this.btnDataBaseConfig.UseVisualStyleBackColor = true;
            this.btnDataBaseConfig.Click += new System.EventHandler(this.btnDataBaseConfig_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(48, 293);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbStartService
            // 
            this.cbStartService.AutoSize = true;
            this.cbStartService.Location = new System.Drawing.Point(48, 340);
            this.cbStartService.Name = "cbStartService";
            this.cbStartService.Size = new System.Drawing.Size(96, 16);
            this.cbStartService.TabIndex = 5;
            this.cbStartService.Text = "自动开启服务";
            this.cbStartService.UseVisualStyleBackColor = true;
            // 
            // FrmDockingService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 393);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmDockingService";
            this.Text = "达安双向对接服务";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbStartService;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDataBaseConfig;
        private System.Windows.Forms.Button btnParaSet;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnBegin;
    }
}