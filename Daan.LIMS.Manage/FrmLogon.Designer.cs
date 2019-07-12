namespace Daan.LIMS.Manage
{
    partial class FrmLogon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogon));
            this.btnMinForm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btExit = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxPwd = new System.Windows.Forms.TextBox();
            this.radLocation = new System.Windows.Forms.RadioButton();
            this.radDaan = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnMinForm
            // 
            this.btnMinForm.BackColor = System.Drawing.Color.Transparent;
            this.btnMinForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinForm.FlatAppearance.BorderSize = 0;
            this.btnMinForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinForm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinForm.ForeColor = System.Drawing.Color.White;
            this.btnMinForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMinForm.Location = new System.Drawing.Point(301, 1);
            this.btnMinForm.Name = "btnMinForm";
            this.btnMinForm.Size = new System.Drawing.Size(18, 18);
            this.btnMinForm.TabIndex = 18;
            this.btnMinForm.TabStop = false;
            this.toolTip1.SetToolTip(this.btnMinForm, "最小化");
            this.btnMinForm.UseVisualStyleBackColor = false;
            this.btnMinForm.Click += new System.EventHandler(this.btnMinForm_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(335, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 17;
            this.btnClose.TabStop = false;
            this.toolTip1.SetToolTip(this.btnClose, "关闭");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(52, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "密  码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(52, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "帐  号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btExit
            // 
            this.btExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExit.BackgroundImage")));
            this.btExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExit.FlatAppearance.BorderSize = 0;
            this.btExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btExit.Font = new System.Drawing.Font("宋体", 9F);
            this.btExit.ForeColor = System.Drawing.Color.Black;
            this.btExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btExit.Location = new System.Drawing.Point(285, 250);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(64, 26);
            this.btExit.TabIndex = 3;
            this.btExit.Text = "取 消";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSet.BackgroundImage")));
            this.btnSet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSet.ForeColor = System.Drawing.Color.Black;
            this.btnSet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSet.Location = new System.Drawing.Point(13, 249);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(65, 26);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "  设置";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.White;
            this.btLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLogin.BackgroundImage")));
            this.btLogin.FlatAppearance.BorderSize = 0;
            this.btLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btLogin.Font = new System.Drawing.Font("宋体", 9F);
            this.btLogin.ForeColor = System.Drawing.Color.Black;
            this.btLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btLogin.Location = new System.Drawing.Point(215, 250);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(64, 26);
            this.btLogin.TabIndex = 2;
            this.btLogin.Text = "登 录";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // tbxUserName
            // 
            this.tbxUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxUserName.Location = new System.Drawing.Point(122, 180);
            this.tbxUserName.MaximumSize = new System.Drawing.Size(170, 14);
            this.tbxUserName.MinimumSize = new System.Drawing.Size(170, 14);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(170, 14);
            this.tbxUserName.TabIndex = 0;
            this.tbxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NAMEKeyDown_Enter);
            // 
            // tbxPwd
            // 
            this.tbxPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPwd.Location = new System.Drawing.Point(122, 211);
            this.tbxPwd.MaximumSize = new System.Drawing.Size(170, 14);
            this.tbxPwd.MinimumSize = new System.Drawing.Size(170, 14);
            this.tbxPwd.Name = "tbxPwd";
            this.tbxPwd.PasswordChar = '*';
            this.tbxPwd.Size = new System.Drawing.Size(170, 14);
            this.tbxPwd.TabIndex = 1;
            this.tbxPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PWDKeyDown_Enter);
            // 
            // radLocation
            // 
            this.radLocation.AutoSize = true;
            this.radLocation.BackColor = System.Drawing.Color.Transparent;
            this.radLocation.Checked = true;
            this.radLocation.Location = new System.Drawing.Point(185, 143);
            this.radLocation.Name = "radLocation";
            this.radLocation.Size = new System.Drawing.Size(95, 16);
            this.radLocation.TabIndex = 6;
            this.radLocation.TabStop = true;
            this.radLocation.Tag = "1";
            this.radLocation.Text = "本地帐号登录";
            this.radLocation.UseVisualStyleBackColor = false;
            this.radLocation.CheckedChanged += new System.EventHandler(this.radLocation_CheckedChanged);
            // 
            // radDaan
            // 
            this.radDaan.AutoSize = true;
            this.radDaan.BackColor = System.Drawing.Color.Transparent;
            this.radDaan.Location = new System.Drawing.Point(80, 142);
            this.radDaan.Name = "radDaan";
            this.radDaan.Size = new System.Drawing.Size(95, 16);
            this.radDaan.TabIndex = 5;
            this.radDaan.Tag = "0";
            this.radDaan.Text = "达安帐号登录";
            this.radDaan.UseVisualStyleBackColor = false;
            this.radDaan.CheckedChanged += new System.EventHandler(this.radLocation_CheckedChanged);
            // 
            // FrmLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(361, 282);
            this.Controls.Add(this.radLocation);
            this.Controls.Add(this.radDaan);
            this.Controls.Add(this.tbxPwd);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMinForm);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(361, 282);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(361, 282);
            this.Name = "FrmLogon";
            this.Text = "达安双向对接管理系统";
            this.Load += new System.EventHandler(this.FrmLogon_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogon_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmLogon_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmLogon_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMinForm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxPwd;
        private System.Windows.Forms.RadioButton radLocation;
        private System.Windows.Forms.RadioButton radDaan;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}