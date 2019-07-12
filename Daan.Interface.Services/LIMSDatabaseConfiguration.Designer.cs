namespace Daan.Interface.Services
{
    partial class LIMSDatabaseConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LIMSDatabaseConfiguration));
            this.label1 = new System.Windows.Forms.Label();
            this.radSQLserver = new System.Windows.Forms.RadioButton();
            this.radOracel = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnInitTable = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.tbxDataBase = new System.Windows.Forms.TextBox();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxPassWord = new System.Windows.Forms.TextBox();
            this.lblmsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型：";
            // 
            // radSQLserver
            // 
            this.radSQLserver.AutoSize = true;
            this.radSQLserver.Checked = true;
            this.radSQLserver.Location = new System.Drawing.Point(100, 19);
            this.radSQLserver.Name = "radSQLserver";
            this.radSQLserver.Size = new System.Drawing.Size(83, 16);
            this.radSQLserver.TabIndex = 1;
            this.radSQLserver.TabStop = true;
            this.radSQLserver.Text = "SQL Server";
            this.radSQLserver.UseVisualStyleBackColor = true;
            this.radSQLserver.CheckedChanged += new System.EventHandler(this.radSQLserver_CheckedChanged);
            // 
            // radOracel
            // 
            this.radOracel.AutoSize = true;
            this.radOracel.Location = new System.Drawing.Point(244, 19);
            this.radOracel.Name = "radOracel";
            this.radOracel.Size = new System.Drawing.Size(59, 16);
            this.radOracel.TabIndex = 2;
            this.radOracel.Text = "Oracle";
            this.radOracel.UseVisualStyleBackColor = true;
            this.radOracel.CheckedChanged += new System.EventHandler(this.radOracel_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "服务器IP：";
            // 
            // lblTypeName
            // 
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(17, 72);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(65, 12);
            this.lblTypeName.TabIndex = 4;
            this.lblTypeName.Text = "数据库名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "用户名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "密码：";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(10, 184);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(84, 23);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "测试连接(&T)";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnInitTable
            // 
            this.btnInitTable.Location = new System.Drawing.Point(100, 184);
            this.btnInitTable.Name = "btnInitTable";
            this.btnInitTable.Size = new System.Drawing.Size(90, 23);
            this.btnInitTable.TabIndex = 8;
            this.btnInitTable.Text = "初始化表结构";
            this.btnInitTable.UseVisualStyleBackColor = true;
            this.btnInitTable.Click += new System.EventHandler(this.btnInitTable_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(196, 184);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(266, 184);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(100, 41);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(206, 21);
            this.tbxIP.TabIndex = 11;
            // 
            // tbxDataBase
            // 
            this.tbxDataBase.Location = new System.Drawing.Point(100, 68);
            this.tbxDataBase.Name = "tbxDataBase";
            this.tbxDataBase.Size = new System.Drawing.Size(206, 21);
            this.tbxDataBase.TabIndex = 12;
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(100, 95);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(206, 21);
            this.tbxUserName.TabIndex = 13;
            // 
            // tbxPassWord
            // 
            this.tbxPassWord.Location = new System.Drawing.Point(100, 122);
            this.tbxPassWord.Name = "tbxPassWord";
            this.tbxPassWord.PasswordChar = '*';
            this.tbxPassWord.Size = new System.Drawing.Size(206, 21);
            this.tbxPassWord.TabIndex = 14;
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(104, 153);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 12);
            this.lblmsg.TabIndex = 15;
            // 
            // LIMSDatabaseConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 217);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.tbxPassWord);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.tbxDataBase);
            this.Controls.Add(this.tbxIP);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInitTable);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radOracel);
            this.Controls.Add(this.radSQLserver);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LIMSDatabaseConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radSQLserver;
        private System.Windows.Forms.RadioButton radOracel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnInitTable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbxIP;
        private System.Windows.Forms.TextBox tbxDataBase;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxPassWord;
        private System.Windows.Forms.Label lblmsg;
    }
}