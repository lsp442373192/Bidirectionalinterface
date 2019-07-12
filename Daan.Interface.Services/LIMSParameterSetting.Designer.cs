namespace Daan.Interface.Services
{
    partial class LIMSParameterSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LIMSParameterSetting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblID = new System.Windows.Forms.Label();
            this.tbxPassWrod = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbxInterval = new System.Windows.Forms.TextBox();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxWebAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxHospName = new System.Windows.Forms.TextBox();
            this.tbxSiteCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtpLastDate = new DevExpress.XtraEditors.DateEdit();
            this.btnRefreshData = new System.Windows.Forms.Button();
            this.tbxTableName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.gridLastDate = new System.Windows.Forms.DataGridView();
            this.tablename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LASTDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATablelastdateBindingSource = new System.Windows.Forms.BindingSource();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpLastDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpLastDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLastDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATablelastdateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 292);
            this.tabControl1.TabIndex = 21;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblID);
            this.tabPage1.Controls.Add(this.tbxPassWrod);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.tbxInterval);
            this.tabPage1.Controls.Add(this.tbxUserName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbxWebAddress);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbxHospName);
            this.tabPage1.Controls.Add(this.tbxSiteCode);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(365, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(22, 245);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 38;
            this.lblID.Visible = false;
            // 
            // tbxPassWrod
            // 
            this.tbxPassWrod.Location = new System.Drawing.Point(129, 125);
            this.tbxPassWrod.MaxLength = 200;
            this.tbxPassWrod.Name = "tbxPassWrod";
            this.tbxPassWrod.PasswordChar = '*';
            this.tbxPassWrod.Size = new System.Drawing.Size(220, 21);
            this.tbxPassWrod.TabIndex = 28;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(274, 235);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "接口密码：";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(107, 235);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(80, 23);
            this.btnTest.TabIndex = 36;
            this.btnTest.Text = "测试接口(&T)";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "接受间隔(分)：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(193, 235);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbxInterval
            // 
            this.tbxInterval.Location = new System.Drawing.Point(129, 158);
            this.tbxInterval.MaxLength = 200;
            this.tbxInterval.Name = "tbxInterval";
            this.tbxInterval.Size = new System.Drawing.Size(220, 21);
            this.tbxInterval.TabIndex = 30;
            this.tbxInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxInterval_KeyPress);
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(129, 92);
            this.tbxUserName.MaxLength = 200;
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(220, 21);
            this.tbxUserName.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "接口用户名：";
            // 
            // tbxWebAddress
            // 
            this.tbxWebAddress.Location = new System.Drawing.Point(129, 59);
            this.tbxWebAddress.MaxLength = 200;
            this.tbxWebAddress.Name = "tbxWebAddress";
            this.tbxWebAddress.Size = new System.Drawing.Size(220, 21);
            this.tbxWebAddress.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "达安分点代码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "接口地址：";
            // 
            // tbxHospName
            // 
            this.tbxHospName.Location = new System.Drawing.Point(129, 26);
            this.tbxHospName.MaxLength = 200;
            this.tbxHospName.Name = "tbxHospName";
            this.tbxHospName.Size = new System.Drawing.Size(220, 21);
            this.tbxHospName.TabIndex = 22;
            // 
            // tbxSiteCode
            // 
            this.tbxSiteCode.Location = new System.Drawing.Point(129, 191);
            this.tbxSiteCode.MaxLength = 200;
            this.tbxSiteCode.Name = "tbxSiteCode";
            this.tbxSiteCode.Size = new System.Drawing.Size(220, 21);
            this.tbxSiteCode.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "医院名称：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtpLastDate);
            this.tabPage2.Controls.Add(this.btnRefreshData);
            this.tabPage2.Controls.Add(this.tbxTableName);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbxRemark);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnClose2);
            this.tabPage2.Controls.Add(this.btnSave2);
            this.tabPage2.Controls.Add(this.gridLastDate);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(365, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "接收时间设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtpLastDate
            // 
            this.dtpLastDate.EditValue = null;
            this.dtpLastDate.Location = new System.Drawing.Point(103, 158);
            this.dtpLastDate.Name = "dtpLastDate";
            this.dtpLastDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpLastDate.Properties.DisplayFormat.FormatString = "G";
            this.dtpLastDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpLastDate.Properties.EditFormat.FormatString = "G";
            this.dtpLastDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpLastDate.Properties.Mask.EditMask = "G";
            this.dtpLastDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpLastDate.Size = new System.Drawing.Size(246, 20);
            this.dtpLastDate.TabIndex = 62;
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Location = new System.Drawing.Point(107, 235);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(80, 23);
            this.btnRefreshData.TabIndex = 61;
            this.btnRefreshData.Text = "刷新数据(&R)";
            this.btnRefreshData.UseVisualStyleBackColor = true;
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // tbxTableName
            // 
            this.tbxTableName.Location = new System.Drawing.Point(103, 130);
            this.tbxTableName.Name = "tbxTableName";
            this.tbxTableName.Size = new System.Drawing.Size(246, 21);
            this.tbxTableName.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 59;
            this.label9.Text = "表名：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "备注：";
            // 
            // tbxRemark
            // 
            this.tbxRemark.Location = new System.Drawing.Point(103, 184);
            this.tbxRemark.Multiline = true;
            this.tbxRemark.Name = "tbxRemark";
            this.tbxRemark.Size = new System.Drawing.Size(246, 45);
            this.tbxRemark.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 56;
            this.label5.Text = "最后操作时间：";
            // 
            // btnClose2
            // 
            this.btnClose2.Location = new System.Drawing.Point(274, 235);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(75, 23);
            this.btnClose2.TabIndex = 54;
            this.btnClose2.Text = "关闭(&C)";
            this.btnClose2.UseVisualStyleBackColor = true;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Location = new System.Drawing.Point(193, 235);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(75, 23);
            this.btnSave2.TabIndex = 52;
            this.btnSave2.Text = "保存(&S)";
            this.btnSave2.UseVisualStyleBackColor = true;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // gridLastDate
            // 
            this.gridLastDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLastDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tablename,
            this.LASTDATE,
            this.REMARK});
            this.gridLastDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridLastDate.Location = new System.Drawing.Point(3, 3);
            this.gridLastDate.MultiSelect = false;
            this.gridLastDate.Name = "gridLastDate";
            this.gridLastDate.RowHeadersWidth = 25;
            this.gridLastDate.RowTemplate.Height = 23;
            this.gridLastDate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLastDate.Size = new System.Drawing.Size(359, 117);
            this.gridLastDate.TabIndex = 0;
            this.gridLastDate.Click += new System.EventHandler(this.gridLastDate_Click);
            // 
            // tablename
            // 
            this.tablename.DataPropertyName = "tablename";
            this.tablename.HeaderText = "表名";
            this.tablename.Name = "tablename";
            this.tablename.ReadOnly = true;
            this.tablename.Width = 80;
            // 
            // LASTDATE
            // 
            this.LASTDATE.DataPropertyName = "LASTDATE";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.LASTDATE.DefaultCellStyle = dataGridViewCellStyle1;
            this.LASTDATE.HeaderText = "最后操作时间";
            this.LASTDATE.Name = "LASTDATE";
            this.LASTDATE.ReadOnly = true;
            this.LASTDATE.Width = 130;
            // 
            // REMARK
            // 
            this.REMARK.DataPropertyName = "REMARK";
            this.REMARK.HeaderText = "备注";
            this.REMARK.Name = "REMARK";
            this.REMARK.ReadOnly = true;
            this.REMARK.Width = 150;
            // 
            // dATablelastdateBindingSource
            // 
            this.dATablelastdateBindingSource.DataSource = typeof(Daan.Interface.Entity.DATablelastdate);
            // 
            // LIMSParameterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 292);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(387, 330);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(387, 330);
            this.Name = "LIMSParameterSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpLastDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpLastDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLastDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATablelastdateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbxPassWrod;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbxInterval;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxWebAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxHospName;
        private System.Windows.Forms.TextBox tbxSiteCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridLastDate;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.BindingSource dATablelastdateBindingSource;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxTableName;
        private System.Windows.Forms.Button btnRefreshData;
        private System.Windows.Forms.Label lblID;
        private DevExpress.XtraEditors.DateEdit dtpLastDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablename;
        private System.Windows.Forms.DataGridViewTextBoxColumn LASTDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARK;
    }
}