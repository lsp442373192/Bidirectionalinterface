namespace Daan.LIMS.Manage
{
    partial class FrmDaanItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDaanItem));
            this.bsDaanItem = new System.Windows.Forms.BindingSource(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gvDaanItem = new System.Windows.Forms.DataGridView();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Datestcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datestname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Englishname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Engshortname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Isgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FASTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Testmethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnsynchro = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearchKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsDaanItem)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDaanItem)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupControl1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 40);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(1);
            this.panel6.Size = new System.Drawing.Size(964, 422);
            this.panel6.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gvDaanItem);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(1, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(962, 420);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "达安项目";
            // 
            // gvDaanItem
            // 
            this.gvDaanItem.AllowUserToAddRows = false;
            this.gvDaanItem.AllowUserToDeleteRows = false;
            this.gvDaanItem.AutoGenerateColumns = false;
            this.gvDaanItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDaanItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDaanItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDaanItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSelect,
            this.Datestcode,
            this.Datestname,
            this.Englishname,
            this.Engshortname,
            this.Isgroup,
            this.FASTCODE,
            this.Testmethod,
            this.Id});
            this.gvDaanItem.DataSource = this.bsDaanItem;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDaanItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvDaanItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDaanItem.Location = new System.Drawing.Point(2, 22);
            this.gvDaanItem.Name = "gvDaanItem";
            this.gvDaanItem.RowHeadersWidth = 20;
            this.gvDaanItem.RowTemplate.Height = 23;
            this.gvDaanItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDaanItem.Size = new System.Drawing.Size(958, 351);
            this.gvDaanItem.TabIndex = 1;
            this.gvDaanItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvDaanItem_CellFormatting);
            this.gvDaanItem.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvDaanItem_RowPostPaint);
            this.gvDaanItem.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gvDaanItem_Scroll);
            // 
            // chkSelect
            // 
            this.chkSelect.HeaderText = "";
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Width = 30;
            // 
            // Datestcode
            // 
            this.Datestcode.DataPropertyName = "Datestcode";
            this.Datestcode.HeaderText = "达安项目代码";
            this.Datestcode.Name = "Datestcode";
            this.Datestcode.ReadOnly = true;
            this.Datestcode.Width = 120;
            // 
            // Datestname
            // 
            this.Datestname.DataPropertyName = "Datestname";
            this.Datestname.HeaderText = "达安项目名称";
            this.Datestname.Name = "Datestname";
            this.Datestname.ReadOnly = true;
            this.Datestname.Width = 200;
            // 
            // Englishname
            // 
            this.Englishname.DataPropertyName = "Englishname";
            this.Englishname.HeaderText = "英文全称";
            this.Englishname.Name = "Englishname";
            this.Englishname.ReadOnly = true;
            this.Englishname.Width = 200;
            // 
            // Engshortname
            // 
            this.Engshortname.DataPropertyName = "Engshortname";
            this.Engshortname.HeaderText = "英文简称";
            this.Engshortname.Name = "Engshortname";
            this.Engshortname.ReadOnly = true;
            // 
            // Isgroup
            // 
            this.Isgroup.DataPropertyName = "Isgroup";
            this.Isgroup.HeaderText = "单项/组合";
            this.Isgroup.Name = "Isgroup";
            this.Isgroup.ReadOnly = true;
            this.Isgroup.Width = 200;
            // 
            // FASTCODE
            // 
            this.FASTCODE.DataPropertyName = "FASTCODE";
            this.FASTCODE.HeaderText = "助记码";
            this.FASTCODE.Name = "FASTCODE";
            this.FASTCODE.ReadOnly = true;
            // 
            // Testmethod
            // 
            this.Testmethod.DataPropertyName = "Testmethod";
            this.Testmethod.HeaderText = "检测方法";
            this.Testmethod.Name = "Testmethod";
            this.Testmethod.ReadOnly = true;
            this.Testmethod.Width = 160;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Datestitemid";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRecord);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnsynchro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 373);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 45);
            this.panel1.TabIndex = 0;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(9, 18);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(83, 12);
            this.lblRecord.TabIndex = 3;
            this.lblRecord.Text = "共 {0} 条记录";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(874, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(793, 13);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "删除(&D)";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnsynchro
            // 
            this.btnsynchro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsynchro.Location = new System.Drawing.Point(712, 13);
            this.btnsynchro.Name = "btnsynchro";
            this.btnsynchro.Size = new System.Drawing.Size(75, 23);
            this.btnsynchro.TabIndex = 0;
            this.btnsynchro.Text = "同步(&S)";
            this.btnsynchro.UseVisualStyleBackColor = true;
            this.btnsynchro.Click += new System.EventHandler(this.btnsynchro_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panel5.Size = new System.Drawing.Size(964, 40);
            this.panel5.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panel2.Size = new System.Drawing.Size(962, 39);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.tbxSearchKey);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 38);
            this.panel4.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(210, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查找(&Q)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearchKey
            // 
            this.tbxSearchKey.Location = new System.Drawing.Point(54, 9);
            this.tbxSearchKey.Name = "tbxSearchKey";
            this.tbxSearchKey.Size = new System.Drawing.Size(150, 21);
            this.tbxSearchKey.TabIndex = 1;
            this.tbxSearchKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找:";
            // 
            // FrmDaanItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 462);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDaanItem";
            this.Text = "达安项目";
            this.Load += new System.EventHandler(this.FrmDaanItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDaanItem)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDaanItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearchKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvDaanItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnsynchro;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.BindingSource bsDaanItem;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datestcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datestname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Englishname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Engshortname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn FASTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Testmethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}