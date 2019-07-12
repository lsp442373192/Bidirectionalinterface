namespace Daan.LIMS.Manage
{
    partial class FrmDBConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDBConfiguration));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbxOraclePwd = new System.Windows.Forms.TextBox();
            this.tbxOracleUserName = new System.Windows.Forms.TextBox();
            this.tbxSID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxOracleService = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDatabase = new System.Windows.Forms.TextBox();
            this.tbxSQLPwd = new System.Windows.Forms.TextBox();
            this.tbxSQLUserName = new System.Windows.Forms.TextBox();
            this.tbxSQLService = new System.Windows.Forms.TextBox();
            this.radOracle = new System.Windows.Forms.RadioButton();
            this.radSQLServer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnVCancel = new System.Windows.Forms.Button();
            this.btnVOK = new System.Windows.Forms.Button();
            this.btnVTestConnect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxVOraclePwd = new System.Windows.Forms.TextBox();
            this.tbxVOracleUserName = new System.Windows.Forms.TextBox();
            this.tbxVSID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxVOracleService = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxVDatabase = new System.Windows.Forms.TextBox();
            this.tbxVSQLPwd = new System.Windows.Forms.TextBox();
            this.tbxVSQLUserName = new System.Windows.Forms.TextBox();
            this.tbxVSQLService = new System.Windows.Forms.TextBox();
            this.radVOracle = new System.Windows.Forms.RadioButton();
            this.radVSQLServer = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(457, 281);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Controls.Add(this.btnTestConnect);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.radOracle);
            this.tabPage1.Controls.Add(this.radSQLServer);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(854, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "本地数据库连接";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(345, 209);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(255, 209);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 29);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "保存(&S)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Location = new System.Drawing.Point(141, 209);
            this.btnTestConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(109, 29);
            this.btnTestConnect.TabIndex = 18;
            this.btnTestConnect.Text = "测试连接(&T)";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbxOraclePwd);
            this.panel3.Controls.Add(this.tbxOracleUserName);
            this.panel3.Controls.Add(this.tbxSID);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tbxOracleService);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(12, 49);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 152);
            this.panel3.TabIndex = 17;
            this.panel3.Visible = false;
            // 
            // tbxOraclePwd
            // 
            this.tbxOraclePwd.Location = new System.Drawing.Point(103, 110);
            this.tbxOraclePwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxOraclePwd.Name = "tbxOraclePwd";
            this.tbxOraclePwd.PasswordChar = '*';
            this.tbxOraclePwd.Size = new System.Drawing.Size(271, 25);
            this.tbxOraclePwd.TabIndex = 9;
            // 
            // tbxOracleUserName
            // 
            this.tbxOracleUserName.Location = new System.Drawing.Point(103, 76);
            this.tbxOracleUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxOracleUserName.Name = "tbxOracleUserName";
            this.tbxOracleUserName.Size = new System.Drawing.Size(271, 25);
            this.tbxOracleUserName.TabIndex = 8;
            // 
            // tbxSID
            // 
            this.tbxSID.Location = new System.Drawing.Point(103, 42);
            this.tbxSID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSID.Name = "tbxSID";
            this.tbxSID.Size = new System.Drawing.Size(271, 25);
            this.tbxSID.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 118);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "密码:";
            // 
            // tbxOracleService
            // 
            this.tbxOracleService.Location = new System.Drawing.Point(103, 9);
            this.tbxOracleService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxOracleService.Name = "tbxOracleService";
            this.tbxOracleService.Size = new System.Drawing.Size(271, 25);
            this.tbxOracleService.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 81);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "用户名:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "SID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "服务器:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbxDatabase);
            this.panel2.Controls.Add(this.tbxSQLPwd);
            this.panel2.Controls.Add(this.tbxSQLUserName);
            this.panel2.Controls.Add(this.tbxSQLService);
            this.panel2.Location = new System.Drawing.Point(12, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 148);
            this.panel2.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "数据库:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "密码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "用户名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "服务器:";
            // 
            // tbxDatabase
            // 
            this.tbxDatabase.Location = new System.Drawing.Point(103, 42);
            this.tbxDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxDatabase.Name = "tbxDatabase";
            this.tbxDatabase.Size = new System.Drawing.Size(271, 25);
            this.tbxDatabase.TabIndex = 2;
            // 
            // tbxSQLPwd
            // 
            this.tbxSQLPwd.Location = new System.Drawing.Point(103, 110);
            this.tbxSQLPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSQLPwd.Name = "tbxSQLPwd";
            this.tbxSQLPwd.PasswordChar = '*';
            this.tbxSQLPwd.Size = new System.Drawing.Size(271, 25);
            this.tbxSQLPwd.TabIndex = 3;
            // 
            // tbxSQLUserName
            // 
            this.tbxSQLUserName.Location = new System.Drawing.Point(103, 76);
            this.tbxSQLUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSQLUserName.Name = "tbxSQLUserName";
            this.tbxSQLUserName.Size = new System.Drawing.Size(271, 25);
            this.tbxSQLUserName.TabIndex = 2;
            // 
            // tbxSQLService
            // 
            this.tbxSQLService.Location = new System.Drawing.Point(103, 9);
            this.tbxSQLService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSQLService.Name = "tbxSQLService";
            this.tbxSQLService.Size = new System.Drawing.Size(271, 25);
            this.tbxSQLService.TabIndex = 0;
            // 
            // radOracle
            // 
            this.radOracle.AutoSize = true;
            this.radOracle.Location = new System.Drawing.Point(291, 10);
            this.radOracle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radOracle.Name = "radOracle";
            this.radOracle.Size = new System.Drawing.Size(76, 19);
            this.radOracle.TabIndex = 15;
            this.radOracle.Tag = "SQL";
            this.radOracle.Text = "Oracle";
            this.radOracle.UseVisualStyleBackColor = true;
            this.radOracle.CheckedChanged += new System.EventHandler(this.rbOracle_CheckedChanged);
            // 
            // radSQLServer
            // 
            this.radSQLServer.AutoSize = true;
            this.radSQLServer.Checked = true;
            this.radSQLServer.Location = new System.Drawing.Point(151, 9);
            this.radSQLServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radSQLServer.Name = "radSQLServer";
            this.radSQLServer.Size = new System.Drawing.Size(108, 19);
            this.radSQLServer.TabIndex = 14;
            this.radSQLServer.TabStop = true;
            this.radSQLServer.Tag = "SQL";
            this.radSQLServer.Text = "SQL Server";
            this.radSQLServer.UseVisualStyleBackColor = true;
            this.radSQLServer.CheckedChanged += new System.EventHandler(this.rbSQLServer_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "数据库类型:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnVCancel);
            this.tabPage2.Controls.Add(this.btnVOK);
            this.tabPage2.Controls.Add(this.btnVTestConnect);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.radVOracle);
            this.tabPage2.Controls.Add(this.radVSQLServer);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(449, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "医院LIS数据库连接";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnVCancel
            // 
            this.btnVCancel.Location = new System.Drawing.Point(345, 209);
            this.btnVCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVCancel.Name = "btnVCancel";
            this.btnVCancel.Size = new System.Drawing.Size(87, 29);
            this.btnVCancel.TabIndex = 21;
            this.btnVCancel.Text = "关闭(&C)";
            this.btnVCancel.UseVisualStyleBackColor = true;
            this.btnVCancel.Click += new System.EventHandler(this.btnVCancel_Click);
            // 
            // btnVOK
            // 
            this.btnVOK.Location = new System.Drawing.Point(255, 209);
            this.btnVOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVOK.Name = "btnVOK";
            this.btnVOK.Size = new System.Drawing.Size(87, 29);
            this.btnVOK.TabIndex = 20;
            this.btnVOK.Text = "保存(&S)";
            this.btnVOK.UseVisualStyleBackColor = true;
            this.btnVOK.Click += new System.EventHandler(this.btnVOK_Click);
            // 
            // btnVTestConnect
            // 
            this.btnVTestConnect.Location = new System.Drawing.Point(141, 209);
            this.btnVTestConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVTestConnect.Name = "btnVTestConnect";
            this.btnVTestConnect.Size = new System.Drawing.Size(109, 29);
            this.btnVTestConnect.TabIndex = 18;
            this.btnVTestConnect.Text = "测试连接(&T)";
            this.btnVTestConnect.UseVisualStyleBackColor = true;
            this.btnVTestConnect.Click += new System.EventHandler(this.btnVTestConnect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxVOraclePwd);
            this.panel1.Controls.Add(this.tbxVOracleUserName);
            this.panel1.Controls.Add(this.tbxVSID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxVOracleService);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 152);
            this.panel1.TabIndex = 17;
            this.panel1.Visible = false;
            // 
            // tbxVOraclePwd
            // 
            this.tbxVOraclePwd.Location = new System.Drawing.Point(103, 110);
            this.tbxVOraclePwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxVOraclePwd.Name = "tbxVOraclePwd";
            this.tbxVOraclePwd.PasswordChar = '*';
            this.tbxVOraclePwd.Size = new System.Drawing.Size(271, 25);
            this.tbxVOraclePwd.TabIndex = 9;
            // 
            // tbxVOracleUserName
            // 
            this.tbxVOracleUserName.Location = new System.Drawing.Point(103, 76);
            this.tbxVOracleUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxVOracleUserName.Name = "tbxVOracleUserName";
            this.tbxVOracleUserName.Size = new System.Drawing.Size(271, 25);
            this.tbxVOracleUserName.TabIndex = 8;
            // 
            // tbxVSID
            // 
            this.tbxVSID.Location = new System.Drawing.Point(103, 42);
            this.tbxVSID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxVSID.Name = "tbxVSID";
            this.tbxVSID.Size = new System.Drawing.Size(271, 25);
            this.tbxVSID.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "密码:";
            // 
            // tbxVOracleService
            // 
            this.tbxVOracleService.Location = new System.Drawing.Point(103, 9);
            this.tbxVOracleService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxVOracleService.Name = "tbxVOracleService";
            this.tbxVOracleService.Size = new System.Drawing.Size(271, 25);
            this.tbxVOracleService.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 81);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "用户名:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 48);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "SID:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "服务器:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.tbxVDatabase);
            this.panel4.Controls.Add(this.tbxVSQLPwd);
            this.panel4.Controls.Add(this.tbxVSQLUserName);
            this.panel4.Controls.Add(this.tbxVSQLService);
            this.panel4.Location = new System.Drawing.Point(12, 49);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(404, 152);
            this.panel4.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 48);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 7;
            this.label14.Text = "数据库:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 118);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 15);
            this.label15.TabIndex = 6;
            this.label15.Text = "密码:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 81);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 15);
            this.label16.TabIndex = 5;
            this.label16.Text = "用户名:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 11);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "服务器:";
            // 
            // tbxVDatabase
            // 
            this.tbxVDatabase.Location = new System.Drawing.Point(103, 42);
            this.tbxVDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxVDatabase.Name = "tbxVDatabase";
            this.tbxVDatabase.Size = new System.Drawing.Size(271, 25);
            this.tbxVDatabase.TabIndex = 2;
            // 
            // tbxVSQLPwd
            // 
            this.tbxVSQLPwd.Location = new System.Drawing.Point(103, 110);
            this.tbxVSQLPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxVSQLPwd.Name = "tbxVSQLPwd";
            this.tbxVSQLPwd.PasswordChar = '*';
            this.tbxVSQLPwd.Size = new System.Drawing.Size(271, 25);
            this.tbxVSQLPwd.TabIndex = 3;
            // 
            // tbxVSQLUserName
            // 
            this.tbxVSQLUserName.Location = new System.Drawing.Point(103, 76);
            this.tbxVSQLUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxVSQLUserName.Name = "tbxVSQLUserName";
            this.tbxVSQLUserName.Size = new System.Drawing.Size(271, 25);
            this.tbxVSQLUserName.TabIndex = 2;
            // 
            // tbxVSQLService
            // 
            this.tbxVSQLService.Location = new System.Drawing.Point(103, 9);
            this.tbxVSQLService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxVSQLService.Name = "tbxVSQLService";
            this.tbxVSQLService.Size = new System.Drawing.Size(271, 25);
            this.tbxVSQLService.TabIndex = 0;
            // 
            // radVOracle
            // 
            this.radVOracle.AutoSize = true;
            this.radVOracle.Location = new System.Drawing.Point(291, 10);
            this.radVOracle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radVOracle.Name = "radVOracle";
            this.radVOracle.Size = new System.Drawing.Size(76, 19);
            this.radVOracle.TabIndex = 15;
            this.radVOracle.Tag = "SQL";
            this.radVOracle.Text = "Oracle";
            this.radVOracle.UseVisualStyleBackColor = true;
            this.radVOracle.CheckedChanged += new System.EventHandler(this.radVOracle_CheckedChanged);
            // 
            // radVSQLServer
            // 
            this.radVSQLServer.AutoSize = true;
            this.radVSQLServer.Checked = true;
            this.radVSQLServer.Location = new System.Drawing.Point(151, 9);
            this.radVSQLServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radVSQLServer.Name = "radVSQLServer";
            this.radVSQLServer.Size = new System.Drawing.Size(68, 19);
            this.radVSQLServer.TabIndex = 14;
            this.radVSQLServer.TabStop = true;
            this.radVSQLServer.Tag = "SQL";
            this.radVSQLServer.Text = "MySQL";
            this.radVSQLServer.UseVisualStyleBackColor = true;
            this.radVSQLServer.CheckedChanged += new System.EventHandler(this.radVSQLServer_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 11);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 15);
            this.label18.TabIndex = 13;
            this.label18.Text = "数据库类型:";
            // 
            // FrmDBConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 281);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDBConfiguration";
            this.Text = "数据库配置";
            this.Load += new System.EventHandler(this.FrmDBConfiguration_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbxOraclePwd;
        private System.Windows.Forms.TextBox tbxOracleUserName;
        private System.Windows.Forms.TextBox tbxSID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxOracleService;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxDatabase;
        private System.Windows.Forms.TextBox tbxSQLPwd;
        private System.Windows.Forms.TextBox tbxSQLUserName;
        private System.Windows.Forms.TextBox tbxSQLService;
        private System.Windows.Forms.RadioButton radOracle;
        private System.Windows.Forms.RadioButton radSQLServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnVCancel;
        private System.Windows.Forms.Button btnVOK;
        private System.Windows.Forms.Button btnVTestConnect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxVOraclePwd;
        private System.Windows.Forms.TextBox tbxVOracleUserName;
        private System.Windows.Forms.TextBox tbxVSID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxVOracleService;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbxVDatabase;
        private System.Windows.Forms.TextBox tbxVSQLPwd;
        private System.Windows.Forms.TextBox tbxVSQLUserName;
        private System.Windows.Forms.TextBox tbxVSQLService;
        private System.Windows.Forms.RadioButton radVOracle;
        private System.Windows.Forms.RadioButton radVSQLServer;
        private System.Windows.Forms.Label label18;

    }
}