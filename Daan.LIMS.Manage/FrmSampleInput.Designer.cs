namespace Daan.LIMS.Manage
{
    partial class FrmSampleInput
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


        private void initHeadDoctorControl()
        {


            this.HeadDoctorControl = new Daan.control.DictDoctorSelect();

            this.HeadDoctorControl.colDisplay = null;
            this.HeadDoctorControl.colExtend1 = null;
            this.HeadDoctorControl.colExtend2 = null;
            this.HeadDoctorControl.colInCode = null;
            this.HeadDoctorControl.colSeq = "";
            this.HeadDoctorControl.colValue = null;
            this.HeadDoctorControl.DataFromLocal = "0";
            this.HeadDoctorControl.displayMember = "";
            this.HeadDoctorControl.EnterColsePop = true;
            this.HeadDoctorControl.EnterMoveNext = true;
            this.HeadDoctorControl.Location = new System.Drawing.Point(273, 123);
            this.HeadDoctorControl.Lookup = true;
            this.HeadDoctorControl.Name = "HeadDoctorControl";
            this.HeadDoctorControl.ReadOnly = false;
            this.HeadDoctorControl.SelectOnly = true;
            this.HeadDoctorControl.ShowDropButton = true;
            this.HeadDoctorControl.Size = new System.Drawing.Size(64, 21);
            this.HeadDoctorControl.TabIndex = 24;
            this.HeadDoctorControl.valueMember = null;
            this.HeadDoctorControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HeadDoctorControl_KeyPress);

            this.panel2.Controls.Add(this.HeadDoctorControl);
        }
        
        private void initHeadLocation()
        {
            this.HeadLocationControl = new Daan.control.DictLocationSelect();

            this.HeadLocationControl.colDisplay = null;
            this.HeadLocationControl.colExtend1 = null;
            this.HeadLocationControl.colExtend2 = null;
            this.HeadLocationControl.colInCode = null;
            this.HeadLocationControl.colSeq = "";
            this.HeadLocationControl.colValue = null;
            this.HeadLocationControl.DataFromLocal = "0";
            this.HeadLocationControl.displayMember = "";
            this.HeadLocationControl.EnterColsePop = true;
            this.HeadLocationControl.EnterMoveNext = true;
            this.HeadLocationControl.Location = new System.Drawing.Point(92, 123);
            this.HeadLocationControl.Lookup = true;
            this.HeadLocationControl.Name = "HeadLocationControl";
            this.HeadLocationControl.ReadOnly = false;
            this.HeadLocationControl.SelectOnly = true;
            this.HeadLocationControl.ShowDropButton = true;
            this.HeadLocationControl.Size = new System.Drawing.Size(85, 21);
            this.HeadLocationControl.TabIndex = 23;
            this.HeadLocationControl.valueMember = null;
            this.HeadLocationControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HeadLocationControl_KeyPress);

            this.panel2.Controls.Add(this.HeadLocationControl);


           
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSampleInput));
            this.bgSource = new System.Windows.Forms.BindingSource(this.components);
            this.bgListItem = new System.Windows.Forms.BindingSource(this.components);
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblRecord = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvHospital = new System.Windows.Forms.DataGridView();
            this.ischeck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.outspecimenidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patientname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ageunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.txtDaanBarcode = new System.Windows.Forms.TextBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.dictLibrarySelect = new daan.control.DictLibrarySelect();
            this.label19 = new System.Windows.Forms.Label();
            this.dictCustomerSelect = new daan.control.DictCustomerSelect();
            this.TestItemsControl = new Daan.control.DictTestSelect();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gvLisrequest = new System.Windows.Forms.DataGridView();
            this.datestitemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datestcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datestnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.englishnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engshortnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label33 = new System.Windows.Forms.Label();
            this.chbTestItem = new System.Windows.Forms.CheckBox();
            this.chbSingle = new System.Windows.Forms.CheckBox();
            this.chbProject = new System.Windows.Forms.CheckBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtDiagnostication = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.chbReceivingDate = new System.Windows.Forms.CheckBox();
            this.dtpReceivingDate = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.chbSamplingDate = new System.Windows.Forms.CheckBox();
            this.dtpSamplingDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.txtBabycount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtLmpDate = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtLmp = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtPregnant = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtBultrasonic = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.chbDoctor = new System.Windows.Forms.CheckBox();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtPatientsource = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBedNum = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bgSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgListItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospital)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLisrequest)).BeginInit();
            this.SuspendLayout();
            // 
            // bgSource
            // 
            this.bgSource.DataSource = typeof(Daan.Interface.Entity.DAOutspecimen);
            // 
            // bgListItem
            // 
            this.bgListItem.DataSource = typeof(Daan.Interface.Entity.DADicttestitem);
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chkSelect.DataPropertyName = "IsSelect";
            this.chkSelect.Frozen = true;
            this.chkSelect.HeaderText = "";
            this.chkSelect.MinimumWidth = 30;
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chkSelect.Width = 30;
            // 
            // IsSelect
            // 
            this.IsSelect.DataPropertyName = "IsSelect";
            this.IsSelect.Frozen = true;
            this.IsSelect.HeaderText = "IsSelect";
            this.IsSelect.Name = "IsSelect";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1206, 536);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(317, 530);
            this.tabControl1.TabIndex = 36;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.dtpBeginDate);
            this.tabPage1.Controls.Add(this.txtDaanBarcode);
            this.tabPage1.Controls.Add(this.dtpEndDate);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(309, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "已录清单";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblRecord);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 473);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(303, 28);
            this.panel5.TabIndex = 133;
            // 
            // lblRecord
            // 
            this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(9, 7);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(71, 12);
            this.lblRecord.TabIndex = 9;
            this.lblRecord.Text = "共 0 条记录";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvHospital);
            this.panel1.Location = new System.Drawing.Point(-4, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 391);
            this.panel1.TabIndex = 43;
            // 
            // dgvHospital
            // 
            this.dgvHospital.AllowUserToAddRows = false;
            this.dgvHospital.AllowUserToDeleteRows = false;
            this.dgvHospital.AutoGenerateColumns = false;
            this.dgvHospital.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHospital.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHospital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospital.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ischeck,
            this.outspecimenidDataGridViewTextBoxColumn,
            this.requestcodeDataGridViewTextBoxColumn,
            this.Patientname,
            this.sexDataGridViewTextBoxColumn,
            this.Age,
            this.Ageunit});
            this.dgvHospital.DataSource = this.bgSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHospital.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHospital.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHospital.Location = new System.Drawing.Point(0, 0);
            this.dgvHospital.MultiSelect = false;
            this.dgvHospital.Name = "dgvHospital";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHospital.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHospital.RowHeadersWidth = 20;
            this.dgvHospital.RowTemplate.Height = 23;
            this.dgvHospital.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHospital.Size = new System.Drawing.Size(310, 391);
            this.dgvHospital.TabIndex = 2;
            this.dgvHospital.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHospital_CellClick);
            this.dgvHospital.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHospital_CellFormatting);
            this.dgvHospital.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHospital_RowPostPaint);
            this.dgvHospital.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvHospital_Scroll);
            // 
            // ischeck
            // 
            this.ischeck.DataPropertyName = "IsSelect";
            this.ischeck.Frozen = true;
            this.ischeck.HeaderText = "";
            this.ischeck.Name = "ischeck";
            this.ischeck.Width = 30;
            // 
            // outspecimenidDataGridViewTextBoxColumn
            // 
            this.outspecimenidDataGridViewTextBoxColumn.DataPropertyName = "Outspecimenid";
            this.outspecimenidDataGridViewTextBoxColumn.HeaderText = "Outspecimenid";
            this.outspecimenidDataGridViewTextBoxColumn.Name = "outspecimenidDataGridViewTextBoxColumn";
            this.outspecimenidDataGridViewTextBoxColumn.Visible = false;
            // 
            // requestcodeDataGridViewTextBoxColumn
            // 
            this.requestcodeDataGridViewTextBoxColumn.DataPropertyName = "Requestcode";
            this.requestcodeDataGridViewTextBoxColumn.Frozen = true;
            this.requestcodeDataGridViewTextBoxColumn.HeaderText = "达安条码";
            this.requestcodeDataGridViewTextBoxColumn.Name = "requestcodeDataGridViewTextBoxColumn";
            // 
            // Patientname
            // 
            this.Patientname.DataPropertyName = "Patientname";
            this.Patientname.Frozen = true;
            this.Patientname.HeaderText = "姓名";
            this.Patientname.Name = "Patientname";
            // 
            // sexDataGridViewTextBoxColumn
            // 
            this.sexDataGridViewTextBoxColumn.DataPropertyName = "Sex";
            this.sexDataGridViewTextBoxColumn.HeaderText = "性别";
            this.sexDataGridViewTextBoxColumn.Name = "sexDataGridViewTextBoxColumn";
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "年龄";
            this.Age.Name = "Age";
            // 
            // Ageunit
            // 
            this.Ageunit.DataPropertyName = "Ageunit";
            this.Ageunit.HeaderText = "年龄单位";
            this.Ageunit.Name = "Ageunit";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(238, 50);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询(&Q)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(73, 17);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(106, 21);
            this.dtpBeginDate.TabIndex = 2;
            this.dtpBeginDate.Value = new System.DateTime(2012, 12, 10, 16, 24, 52, 0);
            // 
            // txtDaanBarcode
            // 
            this.txtDaanBarcode.Location = new System.Drawing.Point(73, 46);
            this.txtDaanBarcode.Name = "txtDaanBarcode";
            this.txtDaanBarcode.Size = new System.Drawing.Size(106, 21);
            this.txtDaanBarcode.TabIndex = 6;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(213, 17);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(107, 21);
            this.dtpEndDate.TabIndex = 4;
            this.dtpEndDate.Value = new System.DateTime(2012, 12, 10, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "条码号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "录单日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "→";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(3, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(876, 533);
            this.tabControl2.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(868, 507);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "样本基本信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.txtDay);
            this.panel2.Controls.Add(this.txtMonth);
            this.panel2.Controls.Add(this.txtYears);
            this.panel2.Controls.Add(this.dictLibrarySelect);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.dictCustomerSelect);
            this.panel2.Controls.Add(this.TestItemsControl);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.chbTestItem);
            this.panel2.Controls.Add(this.chbSingle);
            this.panel2.Controls.Add(this.chbProject);
            this.panel2.Controls.Add(this.txtRemark);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.txtDiagnostication);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.chbReceivingDate);
            this.panel2.Controls.Add(this.dtpReceivingDate);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.chbSamplingDate);
            this.panel2.Controls.Add(this.dtpSamplingDate);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.dtpBirthday);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.txtBabycount);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.txtLmpDate);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.txtLmp);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.txtPregnant);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txtBultrasonic);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.chbDoctor);
            this.panel2.Controls.Add(this.btnDoctor);
            this.panel2.Controls.Add(this.btnLocation);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtWeight);
            this.panel2.Controls.Add(this.txtPatientsource);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtBedNum);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtHeight);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cbSex);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBarcode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 504);
            this.panel2.TabIndex = 0;
            // 
            // label37
            // 
            initHeadLocation();
            initHeadDoctorControl();
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(278, 90);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(23, 12);
            this.label37.TabIndex = 131;
            this.label37.Text = "(*)";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(26, 275);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(23, 12);
            this.label36.TabIndex = 130;
            this.label36.Text = "(*)";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(278, 50);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(23, 12);
            this.label35.TabIndex = 129;
            this.label35.Text = "(*)";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(26, 51);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(23, 12);
            this.label34.TabIndex = 128;
            this.label34.Text = "(*)";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(10, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(23, 12);
            this.label27.TabIndex = 127;
            this.label27.Text = "(*)";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(454, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(23, 12);
            this.label26.TabIndex = 126;
            this.label26.Text = "(*)";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(219, 88);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(35, 21);
            this.txtDay.TabIndex = 20;
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDay_KeyPress);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(155, 88);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(35, 21);
            this.txtMonth.TabIndex = 19;
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonth_KeyPress);
            // 
            // txtYears
            // 
            this.txtYears.Location = new System.Drawing.Point(92, 88);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(35, 21);
            this.txtYears.TabIndex = 18;
            this.txtYears.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYears_KeyPress);
            // 
            // dictLibrarySelect
            // 
            this.dictLibrarySelect.colDisplay = null;
            this.dictLibrarySelect.colExtend1 = null;
            this.dictLibrarySelect.colExtend2 = null;
            this.dictLibrarySelect.colInCode = null;
            this.dictLibrarySelect.colSeq = "";
            this.dictLibrarySelect.colValue = null;
            this.dictLibrarySelect.DataFromLocal = "0";
            this.dictLibrarySelect.DictLibraryTypeCode = "bbzt";
            this.dictLibrarySelect.displayMember = "";
            this.dictLibrarySelect.EnterColsePop = true;
            this.dictLibrarySelect.EnterMoveNext = true;
            this.dictLibrarySelect.Location = new System.Drawing.Point(340, 88);
            this.dictLibrarySelect.Lookup = true;
            this.dictLibrarySelect.Name = "dictLibrarySelect";
            this.dictLibrarySelect.ReadOnly = false;
            this.dictLibrarySelect.SelectOnly = true;
            this.dictLibrarySelect.ShowDropButton = true;
            this.dictLibrarySelect.Size = new System.Drawing.Size(83, 21);
            this.dictLibrarySelect.TabIndex = 20;
            this.dictLibrarySelect.valueMember = null;
            this.dictLibrarySelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dictLibrarySelect_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(231, 126);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 75;
            this.label19.Text = "医生：";
            // 
            // dictCustomerSelect
            // 
            this.dictCustomerSelect.colDisplay = null;
            this.dictCustomerSelect.colExtend1 = null;
            this.dictCustomerSelect.colExtend2 = null;
            this.dictCustomerSelect.colInCode = null;
            this.dictCustomerSelect.colSeq = "";
            this.dictCustomerSelect.colValue = null;
            this.dictCustomerSelect.DataFromLocal = "0";
            this.dictCustomerSelect.displayMember = "";
            this.dictCustomerSelect.EnterColsePop = true;
            this.dictCustomerSelect.EnterMoveNext = true;
            this.dictCustomerSelect.Location = new System.Drawing.Point(521, 13);
            this.dictCustomerSelect.Lookup = true;
            this.dictCustomerSelect.Name = "dictCustomerSelect";
            this.dictCustomerSelect.ReadOnly = false;
            this.dictCustomerSelect.SelectOnly = true;
            this.dictCustomerSelect.ShowDropButton = true;
            this.dictCustomerSelect.Size = new System.Drawing.Size(295, 21);
            this.dictCustomerSelect.TabIndex = 13;
            this.dictCustomerSelect.TabStop = false;
            this.dictCustomerSelect.valueMember = null;
            this.dictCustomerSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dictCustomerSelect_KeyPress);
            // 
            // TestItemsControl
            // 
            this.TestItemsControl.colDisplay = null;
            this.TestItemsControl.colExtend1 = null;
            this.TestItemsControl.colExtend2 = null;
            this.TestItemsControl.colInCode = null;
            this.TestItemsControl.colSeq = "";
            this.TestItemsControl.colValue = null;
            this.TestItemsControl.DataFromLocal = "0";
            this.TestItemsControl.displayMember = "";
            this.TestItemsControl.EnterColsePop = true;
            this.TestItemsControl.EnterMoveNext = true;
            this.TestItemsControl.Location = new System.Drawing.Point(91, 272);
            this.TestItemsControl.Lookup = true;
            this.TestItemsControl.Name = "TestItemsControl";
            this.TestItemsControl.ReadOnly = false;
            this.TestItemsControl.SelectOnly = true;
            this.TestItemsControl.ShowDropButton = true;
            this.TestItemsControl.Size = new System.Drawing.Size(331, 21);
            this.TestItemsControl.TabIndex = 35;
            this.TestItemsControl.TestType = "2";
            this.TestItemsControl.valueMember = null;
            this.TestItemsControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TestItemsControl_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(765, 476);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(539, 475);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 23);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(425, 476);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 23);
            this.btnPrint.TabIndex = 39;
            this.btnPrint.Text = "导出Excel(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(652, 475);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 23);
            this.btnSend.TabIndex = 36;
            this.btnSend.Text = "保存(&S)";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.gvLisrequest);
            this.panel3.Location = new System.Drawing.Point(4, 330);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(868, 140);
            this.panel3.TabIndex = 112;
            // 
            // gvLisrequest
            // 
            this.gvLisrequest.AllowUserToAddRows = false;
            this.gvLisrequest.AllowUserToDeleteRows = false;
            this.gvLisrequest.AutoGenerateColumns = false;
            this.gvLisrequest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLisrequest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvLisrequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLisrequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datestitemidDataGridViewTextBoxColumn,
            this.SampleType,
            this.datestcodeDataGridViewTextBoxColumn,
            this.datestnameDataGridViewTextBoxColumn,
            this.englishnameDataGridViewTextBoxColumn,
            this.engshortnameDataGridViewTextBoxColumn,
            this.Column3});
            this.gvLisrequest.DataSource = this.bgListItem;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLisrequest.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvLisrequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLisrequest.Location = new System.Drawing.Point(0, 0);
            this.gvLisrequest.MultiSelect = false;
            this.gvLisrequest.Name = "gvLisrequest";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLisrequest.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvLisrequest.RowHeadersWidth = 20;
            this.gvLisrequest.RowTemplate.Height = 23;
            this.gvLisrequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLisrequest.Size = new System.Drawing.Size(868, 140);
            this.gvLisrequest.TabIndex = 1;
            this.gvLisrequest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLisrequest_CellClick);
            this.gvLisrequest.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.gvLisrequest_ColumnWidthChanged);
            this.gvLisrequest.CurrentCellChanged += new System.EventHandler(this.gvLisrequest_CurrentCellChanged);
            this.gvLisrequest.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvLisrequest_RowPostPaint);
            this.gvLisrequest.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gvLisrequest_Scroll);
            // 
            // datestitemidDataGridViewTextBoxColumn
            // 
            this.datestitemidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.datestitemidDataGridViewTextBoxColumn.DataPropertyName = "Datestitemid";
            this.datestitemidDataGridViewTextBoxColumn.HeaderText = "Datestitemid";
            this.datestitemidDataGridViewTextBoxColumn.Name = "datestitemidDataGridViewTextBoxColumn";
            this.datestitemidDataGridViewTextBoxColumn.Visible = false;
            // 
            // SampleType
            // 
            this.SampleType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SampleType.DataPropertyName = "SampleType";
            this.SampleType.FillWeight = 18.56358F;
            this.SampleType.HeaderText = "标本类型";
            this.SampleType.Name = "SampleType";
            this.SampleType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SampleType.Width = 150;
            // 
            // datestcodeDataGridViewTextBoxColumn
            // 
            this.datestcodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.datestcodeDataGridViewTextBoxColumn.DataPropertyName = "Datestcode";
            this.datestcodeDataGridViewTextBoxColumn.FillWeight = 36.451F;
            this.datestcodeDataGridViewTextBoxColumn.HeaderText = "项目代码";
            this.datestcodeDataGridViewTextBoxColumn.Name = "datestcodeDataGridViewTextBoxColumn";
            this.datestcodeDataGridViewTextBoxColumn.Width = 200;
            // 
            // datestnameDataGridViewTextBoxColumn
            // 
            this.datestnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.datestnameDataGridViewTextBoxColumn.DataPropertyName = "Datestname";
            this.datestnameDataGridViewTextBoxColumn.FillWeight = 60.66972F;
            this.datestnameDataGridViewTextBoxColumn.HeaderText = "项目名称";
            this.datestnameDataGridViewTextBoxColumn.Name = "datestnameDataGridViewTextBoxColumn";
            this.datestnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // englishnameDataGridViewTextBoxColumn
            // 
            this.englishnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.englishnameDataGridViewTextBoxColumn.DataPropertyName = "Englishname";
            this.englishnameDataGridViewTextBoxColumn.FillWeight = 122.1944F;
            this.englishnameDataGridViewTextBoxColumn.HeaderText = "英文名称";
            this.englishnameDataGridViewTextBoxColumn.Name = "englishnameDataGridViewTextBoxColumn";
            this.englishnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // engshortnameDataGridViewTextBoxColumn
            // 
            this.engshortnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.engshortnameDataGridViewTextBoxColumn.DataPropertyName = "Engshortname";
            this.engshortnameDataGridViewTextBoxColumn.FillWeight = 247.1467F;
            this.engshortnameDataGridViewTextBoxColumn.HeaderText = "快捷码";
            this.engshortnameDataGridViewTextBoxColumn.Name = "engshortnameDataGridViewTextBoxColumn";
            this.engshortnameDataGridViewTextBoxColumn.Width = 160;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "Datestitemid";
            this.Column3.FillWeight = 164.9746F;
            this.Column3.HeaderText = "删除";
            this.Column3.Name = "Column3";
            this.Column3.Text = "删除";
            this.Column3.UseColumnTextForButtonValue = true;
            this.Column3.Width = 50;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(50, 275);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 12);
            this.label33.TabIndex = 110;
            this.label33.Text = "项目：";
            // 
            // chbTestItem
            // 
            this.chbTestItem.AutoSize = true;
            this.chbTestItem.Location = new System.Drawing.Point(741, 238);
            this.chbTestItem.Name = "chbTestItem";
            this.chbTestItem.Size = new System.Drawing.Size(72, 16);
            this.chbTestItem.TabIndex = 109;
            this.chbTestItem.Text = "院感项目";
            this.chbTestItem.UseVisualStyleBackColor = true;
            // 
            // chbSingle
            // 
            this.chbSingle.AutoSize = true;
            this.chbSingle.Location = new System.Drawing.Point(741, 216);
            this.chbSingle.Name = "chbSingle";
            this.chbSingle.Size = new System.Drawing.Size(72, 16);
            this.chbSingle.TabIndex = 108;
            this.chbSingle.Text = "简易录单";
            this.chbSingle.UseVisualStyleBackColor = true;
            // 
            // chbProject
            // 
            this.chbProject.AutoSize = true;
            this.chbProject.Location = new System.Drawing.Point(741, 196);
            this.chbProject.Name = "chbProject";
            this.chbProject.Size = new System.Drawing.Size(72, 16);
            this.chbProject.TabIndex = 107;
            this.chbProject.Text = "锁定项目";
            this.chbProject.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(521, 234);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(199, 21);
            this.txtRemark.TabIndex = 34;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(454, 238);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(65, 12);
            this.label32.TabIndex = 105;
            this.label32.Text = "其它信息：";
            // 
            // txtDiagnostication
            // 
            this.txtDiagnostication.Location = new System.Drawing.Point(521, 198);
            this.txtDiagnostication.Name = "txtDiagnostication";
            this.txtDiagnostication.Size = new System.Drawing.Size(199, 21);
            this.txtDiagnostication.TabIndex = 32;
            this.txtDiagnostication.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiagnostication_KeyPress);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(454, 201);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 12);
            this.label31.TabIndex = 103;
            this.label31.Text = "临床诊断：";
            // 
            // chbReceivingDate
            // 
            this.chbReceivingDate.AutoSize = true;
            this.chbReceivingDate.Location = new System.Drawing.Point(390, 236);
            this.chbReceivingDate.Name = "chbReceivingDate";
            this.chbReceivingDate.Size = new System.Drawing.Size(36, 16);
            this.chbReceivingDate.TabIndex = 102;
            this.chbReceivingDate.Text = "锁";
            this.chbReceivingDate.UseVisualStyleBackColor = true;
            // 
            // dtpReceivingDate
            // 
            this.dtpReceivingDate.Location = new System.Drawing.Point(91, 234);
            this.dtpReceivingDate.Name = "dtpReceivingDate";
            this.dtpReceivingDate.Size = new System.Drawing.Size(276, 21);
            this.dtpReceivingDate.TabIndex = 33;
            this.dtpReceivingDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReceivingDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpReceivingDate_KeyPress);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(26, 238);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 12);
            this.label30.TabIndex = 100;
            this.label30.Text = "接收时间：";
            // 
            // chbSamplingDate
            // 
            this.chbSamplingDate.AutoSize = true;
            this.chbSamplingDate.Location = new System.Drawing.Point(390, 199);
            this.chbSamplingDate.Name = "chbSamplingDate";
            this.chbSamplingDate.Size = new System.Drawing.Size(36, 16);
            this.chbSamplingDate.TabIndex = 99;
            this.chbSamplingDate.Text = "锁";
            this.chbSamplingDate.UseVisualStyleBackColor = true;
            // 
            // dtpSamplingDate
            // 
            this.dtpSamplingDate.Location = new System.Drawing.Point(90, 196);
            this.dtpSamplingDate.Name = "dtpSamplingDate";
            this.dtpSamplingDate.Size = new System.Drawing.Size(276, 21);
            this.dtpSamplingDate.TabIndex = 31;
            this.dtpSamplingDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpSamplingDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpSamplingDate_KeyPress);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(26, 201);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(65, 12);
            this.label29.TabIndex = 97;
            this.label29.Text = "采样时间：";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(273, 159);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(150, 21);
            this.dtpBirthday.TabIndex = 28;
            this.dtpBirthday.Value = new System.DateTime(1754, 1, 1, 0, 0, 0, 0);
            this.dtpBirthday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpBirthday_KeyPress);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(231, 162);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 12);
            this.label28.TabIndex = 95;
            this.label28.Text = "生日：";
            // 
            // txtBabycount
            // 
            this.txtBabycount.Location = new System.Drawing.Point(90, 159);
            this.txtBabycount.Name = "txtBabycount";
            this.txtBabycount.Size = new System.Drawing.Size(119, 21);
            this.txtBabycount.TabIndex = 27;
            this.txtBabycount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBabycount_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(48, 162);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 93;
            this.label25.Text = "胎数：";
            // 
            // txtLmpDate
            // 
            this.txtLmpDate.Location = new System.Drawing.Point(706, 159);
            this.txtLmpDate.Name = "txtLmpDate";
            this.txtLmpDate.Size = new System.Drawing.Size(110, 21);
            this.txtLmpDate.TabIndex = 30;
            this.txtLmpDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLmpDate_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(650, 162);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 12);
            this.label23.TabIndex = 86;
            this.label23.Text = "孕周/月：";
            // 
            // txtLmp
            // 
            this.txtLmp.Location = new System.Drawing.Point(522, 159);
            this.txtLmp.Name = "txtLmp";
            this.txtLmp.Size = new System.Drawing.Size(98, 21);
            this.txtLmp.TabIndex = 29;
            this.txtLmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLmp_KeyPress);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(441, 162);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 12);
            this.label24.TabIndex = 84;
            this.label24.Text = "LMP孕周/月：";
            // 
            // txtPregnant
            // 
            this.txtPregnant.Location = new System.Drawing.Point(707, 123);
            this.txtPregnant.Name = "txtPregnant";
            this.txtPregnant.Size = new System.Drawing.Size(109, 21);
            this.txtPregnant.TabIndex = 26;
            this.txtPregnant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPregnant_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(650, 126);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 12);
            this.label22.TabIndex = 82;
            this.label22.Text = "孕周/月：";
            // 
            // txtBultrasonic
            // 
            this.txtBultrasonic.Location = new System.Drawing.Point(522, 123);
            this.txtBultrasonic.Name = "txtBultrasonic";
            this.txtBultrasonic.Size = new System.Drawing.Size(98, 21);
            this.txtBultrasonic.TabIndex = 25;
            this.txtBultrasonic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBultrasonic_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(439, 126);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 12);
            this.label21.TabIndex = 80;
            this.label21.Text = "B超孕周/月：";
            // 
            // chbDoctor
            // 
            this.chbDoctor.AutoSize = true;
            this.chbDoctor.Location = new System.Drawing.Point(389, 126);
            this.chbDoctor.Name = "chbDoctor";
            this.chbDoctor.Size = new System.Drawing.Size(36, 16);
            this.chbDoctor.TabIndex = 79;
            this.chbDoctor.Text = "锁";
            this.chbDoctor.UseVisualStyleBackColor = true;
            // 
            // btnDoctor
            // 
            this.btnDoctor.Location = new System.Drawing.Point(347, 121);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(36, 23);
            this.btnDoctor.TabIndex = 78;
            this.btnDoctor.Text = "存";
            this.btnDoctor.UseVisualStyleBackColor = true;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(189, 121);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(36, 23);
            this.btnLocation.TabIndex = 77;
            this.btnLocation.Text = "存";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(47, 126);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 73;
            this.label20.Text = "科室：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(817, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 72;
            this.label18.Text = "(kg)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(624, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 71;
            this.label17.Text = "(cm)";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(706, 88);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(110, 21);
            this.txtWeight.TabIndex = 22;
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // txtPatientsource
            // 
            this.txtPatientsource.Location = new System.Drawing.Point(706, 48);
            this.txtPatientsource.Name = "txtPatientsource";
            this.txtPatientsource.Size = new System.Drawing.Size(110, 21);
            this.txtPatientsource.TabIndex = 17;
            this.txtPatientsource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientsource_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(624, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 12);
            this.label15.TabIndex = 68;
            this.label15.Text = "住院/门诊号：";
            // 
            // txtBedNum
            // 
            this.txtBedNum.Location = new System.Drawing.Point(521, 48);
            this.txtBedNum.Name = "txtBedNum";
            this.txtBedNum.Size = new System.Drawing.Size(99, 21);
            this.txtBedNum.TabIndex = 16;
            this.txtBedNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBedNum_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(474, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 66;
            this.label16.Text = "床号：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(303, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 64;
            this.label14.Text = "状态：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(260, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "日";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(196, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 61;
            this.label13.Text = "月";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(133, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 59;
            this.label12.Text = "岁";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 54;
            this.label11.Text = "年龄：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(668, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "体重：";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(521, 88);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(99, 21);
            this.txtHeight.TabIndex = 21;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeight_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(475, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 50;
            this.label9.Text = "身高：";
            // 
            // cbSex
            // 
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Location = new System.Drawing.Point(340, 48);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(82, 20);
            this.cbSex.TabIndex = 15;
            this.cbSex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSex_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "性别：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 21);
            this.txtName.TabIndex = 14;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 46;
            this.label6.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "医院：";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(90, 13);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(335, 21);
            this.txtBarcode.TabIndex = 12;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "条码号：";
            // 
            // FrmSampleInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 539);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmSampleInput";
            this.Text = "样本录入";
            this.Load += new System.EventHandler(this.FrmSampleInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bgSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgListItem)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospital)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLisrequest)).EndInit();
            this.ResumeLayout(false);

        }

      
        #endregion

        #region
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtDaanBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gvLisrequest;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox chbTestItem;
        private System.Windows.Forms.CheckBox chbSingle;
        private System.Windows.Forms.CheckBox chbProject;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtDiagnostication;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox chbReceivingDate;
        private System.Windows.Forms.DateTimePicker dtpReceivingDate;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox chbSamplingDate;
        private System.Windows.Forms.DateTimePicker dtpSamplingDate;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtBabycount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtLmpDate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtLmp;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtPregnant;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtBultrasonic;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox chbDoctor;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtPatientsource;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBedNum;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private control.DictTestSelect TestItemsControl;
        private System.Windows.Forms.BindingSource bgListItem;
        private control.DictLocationSelect HeadLocationControl;
        private control.DictDoctorSelect HeadDoctorControl;
        private daan.control.DictCustomerSelect dictCustomerSelect;
        private daan.control.DictLibrarySelect dictLibrarySelect;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtYears;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.BindingSource bgSource;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblRecord;
        #endregion

        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelect;
        private System.Windows.Forms.DataGridView dgvHospital;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ischeck;
        private System.Windows.Forms.DataGridViewTextBoxColumn outspecimenidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patientname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ageunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn datestitemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn datestcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datestnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn englishnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn engshortnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;

    }
}