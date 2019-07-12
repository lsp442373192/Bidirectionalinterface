namespace Daan.LIMS.Manage
{
    partial class FrmItemHospitalAndDaan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemHospitalAndDaan));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbxSearchKey = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gvItemHospitalAndDaan = new System.Windows.Forms.DataGridView();
            this.TESTMAPID = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TestCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATESTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATESTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENGLISHNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENGSHORTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FASTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TESTMETHOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsItemHospitalAndDaan = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemHospitalAndDaan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItemHospitalAndDaan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panel2.Size = new System.Drawing.Size(962, 45);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.tbxSearchKey);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 44);
            this.panel4.TabIndex = 0;
            // 
            // tbxSearchKey
            // 
            this.tbxSearchKey.Location = new System.Drawing.Point(52, 9);
            this.tbxSearchKey.Name = "tbxSearchKey";
            this.tbxSearchKey.Size = new System.Drawing.Size(150, 21);
            this.tbxSearchKey.TabIndex = 2;
            this.tbxSearchKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Enter);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(208, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查找(&Q)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gvItemHospitalAndDaan);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(1, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(962, 414);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "项目对照表";
            // 
            // gvItemHospitalAndDaan
            // 
            this.gvItemHospitalAndDaan.AllowUserToAddRows = false;
            this.gvItemHospitalAndDaan.AllowUserToDeleteRows = false;
            this.gvItemHospitalAndDaan.AutoGenerateColumns = false;
            this.gvItemHospitalAndDaan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvItemHospitalAndDaan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvItemHospitalAndDaan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvItemHospitalAndDaan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TESTMAPID,
            this.TestCode,
            this.TestName,
            this.DATESTCODE,
            this.DATESTNAME,
            this.ShortName,
            this.IsGroup,
            this.ENGLISHNAME,
            this.ENGSHORTNAME,
            this.TestType,
            this.FASTCODE,
            this.TESTMETHOD});
            this.gvItemHospitalAndDaan.DataSource = this.bsItemHospitalAndDaan;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvItemHospitalAndDaan.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvItemHospitalAndDaan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvItemHospitalAndDaan.Location = new System.Drawing.Point(2, 22);
            this.gvItemHospitalAndDaan.Name = "gvItemHospitalAndDaan";
            this.gvItemHospitalAndDaan.ReadOnly = true;
            this.gvItemHospitalAndDaan.RowHeadersWidth = 20;
            this.gvItemHospitalAndDaan.RowTemplate.Height = 23;
            this.gvItemHospitalAndDaan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvItemHospitalAndDaan.Size = new System.Drawing.Size(958, 346);
            this.gvItemHospitalAndDaan.TabIndex = 1;
            this.gvItemHospitalAndDaan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvItemHospitalAndDaan_CellFormatting);
            this.gvItemHospitalAndDaan.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gvItemHospitalAndDaan_CellPainting);
            this.gvItemHospitalAndDaan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvItemHospitalAndDaan_RowPostPaint);
            this.gvItemHospitalAndDaan.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gvItemHospitalAndDaan_Scroll);
            // 
            // TESTMAPID
            // 
            this.TESTMAPID.DataPropertyName = "Testmapid";
            this.TESTMAPID.HeaderText = "√";
            this.TESTMAPID.Name = "TESTMAPID";
            this.TESTMAPID.ReadOnly = true;
            this.TESTMAPID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TESTMAPID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TESTMAPID.Width = 20;
            // 
            // TestCode
            // 
            this.TestCode.DataPropertyName = "TestCode";
            this.TestCode.HeaderText = "医院项目代码";
            this.TestCode.Name = "TestCode";
            this.TestCode.ReadOnly = true;
            this.TestCode.Width = 120;
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "TestName";
            this.TestName.HeaderText = "医院项目名称";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            this.TestName.Width = 150;
            // 
            // DATESTCODE
            // 
            this.DATESTCODE.DataPropertyName = "DATESTCODE";
            this.DATESTCODE.HeaderText = "达安项目代码";
            this.DATESTCODE.Name = "DATESTCODE";
            this.DATESTCODE.ReadOnly = true;
            this.DATESTCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DATESTCODE.Width = 180;
            // 
            // DATESTNAME
            // 
            this.DATESTNAME.DataPropertyName = "DATESTNAME";
            this.DATESTNAME.HeaderText = "达安项目名称";
            this.DATESTNAME.Name = "DATESTNAME";
            this.DATESTNAME.ReadOnly = true;
            this.DATESTNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DATESTNAME.Width = 250;
            // 
            // ShortName
            // 
            this.ShortName.DataPropertyName = "ShortName";
            this.ShortName.HeaderText = "项目简称";
            this.ShortName.Name = "ShortName";
            this.ShortName.ReadOnly = true;
            // 
            // IsGroup
            // 
            this.IsGroup.DataPropertyName = "IsGroup";
            this.IsGroup.HeaderText = "单项/组合";
            this.IsGroup.Name = "IsGroup";
            this.IsGroup.ReadOnly = true;
            this.IsGroup.Width = 120;
            // 
            // ENGLISHNAME
            // 
            this.ENGLISHNAME.DataPropertyName = "ENGLISHNAME";
            this.ENGLISHNAME.FillWeight = 34.69984F;
            this.ENGLISHNAME.HeaderText = "英文全称";
            this.ENGLISHNAME.Name = "ENGLISHNAME";
            this.ENGLISHNAME.ReadOnly = true;
            // 
            // ENGSHORTNAME
            // 
            this.ENGSHORTNAME.DataPropertyName = "ENGSHORTNAME";
            this.ENGSHORTNAME.HeaderText = "英文简称";
            this.ENGSHORTNAME.Name = "ENGSHORTNAME";
            this.ENGSHORTNAME.ReadOnly = true;
            // 
            // TestType
            // 
            this.TestType.DataPropertyName = "TestType";
            this.TestType.HeaderText = "项目类别";
            this.TestType.Name = "TestType";
            this.TestType.ReadOnly = true;
            // 
            // FASTCODE
            // 
            this.FASTCODE.DataPropertyName = "FASTCODE";
            this.FASTCODE.HeaderText = "助记码";
            this.FASTCODE.Name = "FASTCODE";
            this.FASTCODE.ReadOnly = true;
            // 
            // TESTMETHOD
            // 
            this.TESTMETHOD.DataPropertyName = "TESTMETHOD";
            this.TESTMETHOD.HeaderText = "检测方法";
            this.TESTMETHOD.Name = "TESTMETHOD";
            this.TESTMETHOD.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblRecord);
            this.panel1.Controls.Add(this.btnDownLoad);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnimport);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 44);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(597, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "设置(联网)(&B)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(9, 16);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(83, 12);
            this.lblRecord.TabIndex = 5;
            this.lblRecord.Text = "共 {0} 条记录";
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownLoad.Location = new System.Drawing.Point(704, 11);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(83, 23);
            this.btnDownLoad.TabIndex = 3;
            this.btnDownLoad.Text = "下载模版(&D)";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(874, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnimport
            // 
            this.btnimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimport.Location = new System.Drawing.Point(793, 11);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(75, 23);
            this.btnimport.TabIndex = 1;
            this.btnimport.Text = "导入(&I)";
            this.btnimport.UseVisualStyleBackColor = true;
            this.btnimport.Click += new System.EventHandler(this.btnimport_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(516, 12);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 0;
            this.btnSet.Text = "设置(&S)";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panel3.Size = new System.Drawing.Size(964, 46);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupControl1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 46);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1);
            this.panel5.Size = new System.Drawing.Size(964, 416);
            this.panel5.TabIndex = 3;
            // 
            // FrmItemHospitalAndDaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 462);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmItemHospitalAndDaan";
            this.Text = "项目对照表";
            this.Load += new System.EventHandler(this.FrmItemHospitalAndDaan_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvItemHospitalAndDaan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItemHospitalAndDaan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxSearchKey;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView gvItemHospitalAndDaan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.BindingSource bsItemHospitalAndDaan;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TESTMAPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATESTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATESTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENGLISHNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENGSHORTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FASTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TESTMETHOD;
        private System.Windows.Forms.Button button1;
    }
}