namespace Daan.LIMS.Manage
{
    partial class FrmHospitalItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHospitalItem));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gvHospitalitem = new System.Windows.Forms.DataGridView();
            this.TestCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnglishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EngShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FastCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsHospitalitem = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearchKey = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHospitalitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHospitalitem)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gvHospitalitem);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(1, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(962, 426);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "医院项目";
            // 
            // gvHospitalitem
            // 
            this.gvHospitalitem.AllowUserToAddRows = false;
            this.gvHospitalitem.AllowUserToDeleteRows = false;
            this.gvHospitalitem.AutoGenerateColumns = false;
            this.gvHospitalitem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvHospitalitem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvHospitalitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHospitalitem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestCode,
            this.TestName,
            this.ShortName,
            this.EnglishName,
            this.EngShortName,
            this.IsGroup,
            this.FastCode,
            this.TestMethod,
            this.TestType});
            this.gvHospitalitem.DataSource = this.bsHospitalitem;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvHospitalitem.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvHospitalitem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvHospitalitem.Location = new System.Drawing.Point(2, 22);
            this.gvHospitalitem.Name = "gvHospitalitem";
            this.gvHospitalitem.ReadOnly = true;
            this.gvHospitalitem.RowHeadersWidth = 20;
            this.gvHospitalitem.RowTemplate.Height = 23;
            this.gvHospitalitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvHospitalitem.Size = new System.Drawing.Size(958, 361);
            this.gvHospitalitem.TabIndex = 1;
            this.gvHospitalitem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvHospitalitem_CellFormatting);
            this.gvHospitalitem.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvHospitalitem_RowPostPaint);
            this.gvHospitalitem.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gvHospitalitem_Scroll);
            // 
            // TestCode
            // 
            this.TestCode.DataPropertyName = "TestCode";
            this.TestCode.HeaderText = "项目代码";
            this.TestCode.Name = "TestCode";
            this.TestCode.ReadOnly = true;
            this.TestCode.Width = 160;
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "TestName";
            this.TestName.HeaderText = "项目名称";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            this.TestName.Width = 200;
            // 
            // ShortName
            // 
            this.ShortName.DataPropertyName = "ShortName";
            this.ShortName.HeaderText = "项目简称";
            this.ShortName.Name = "ShortName";
            this.ShortName.ReadOnly = true;
            this.ShortName.Width = 150;
            // 
            // EnglishName
            // 
            this.EnglishName.DataPropertyName = "EnglishName";
            this.EnglishName.HeaderText = "英文全称";
            this.EnglishName.Name = "EnglishName";
            this.EnglishName.ReadOnly = true;
            this.EnglishName.Width = 160;
            // 
            // EngShortName
            // 
            this.EngShortName.DataPropertyName = "EngShortName";
            this.EngShortName.HeaderText = "英文简称";
            this.EngShortName.Name = "EngShortName";
            this.EngShortName.ReadOnly = true;
            this.EngShortName.Width = 150;
            // 
            // IsGroup
            // 
            this.IsGroup.DataPropertyName = "IsGroup";
            this.IsGroup.HeaderText = "单项/组合";
            this.IsGroup.Name = "IsGroup";
            this.IsGroup.ReadOnly = true;
            this.IsGroup.Width = 120;
            // 
            // FastCode
            // 
            this.FastCode.DataPropertyName = "FastCode";
            this.FastCode.HeaderText = "助记码";
            this.FastCode.Name = "FastCode";
            this.FastCode.ReadOnly = true;
            // 
            // TestMethod
            // 
            this.TestMethod.DataPropertyName = "TestMethod";
            this.TestMethod.HeaderText = "检测方法";
            this.TestMethod.Name = "TestMethod";
            this.TestMethod.ReadOnly = true;
            // 
            // TestType
            // 
            this.TestType.DataPropertyName = "TestType";
            this.TestType.HeaderText = "项目所属学科";
            this.TestType.Name = "TestType";
            this.TestType.ReadOnly = true;
            this.TestType.Width = 200;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRecord);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 41);
            this.panel1.TabIndex = 0;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(10, 14);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(83, 12);
            this.lblRecord.TabIndex = 4;
            this.lblRecord.Text = "共 {0} 条记录";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(874, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panel2.Size = new System.Drawing.Size(962, 33);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.tbxSearchKey);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 32);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "查找:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(208, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查找(&Q)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearchKey
            // 
            this.tbxSearchKey.Location = new System.Drawing.Point(52, 4);
            this.tbxSearchKey.Name = "tbxSearchKey";
            this.tbxSearchKey.Size = new System.Drawing.Size(150, 21);
            this.tbxSearchKey.TabIndex = 0;
            this.tbxSearchKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Enter);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panel5.Size = new System.Drawing.Size(964, 34);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupControl1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 34);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(1);
            this.panel6.Size = new System.Drawing.Size(964, 428);
            this.panel6.TabIndex = 4;
            // 
            // FrmHospitalItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 462);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHospitalItem";
            this.Text = "医院项目";
            this.Load += new System.EventHandler(this.FrmHospitalItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvHospitalitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHospitalitem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView gvHospitalitem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearchKey;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.BindingSource bsHospitalitem;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnglishName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EngShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn FastCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestType;
    }
}