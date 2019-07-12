namespace Daan.LIMS.Manage
{
    partial class FrmReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNoPrint = new System.Windows.Forms.Button();
            this.btnReportPrint = new System.Windows.Forms.Button();
            this.btnReportView = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbReportStatus = new System.Windows.Forms.ComboBox();
            this.cbbLabDept = new System.Windows.Forms.ComboBox();
            this.txtOrdersNum = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtHospitalBarcode = new System.Windows.Forms.TextBox();
            this.txtHospital = new System.Windows.Forms.TextBox();
            this.txtDaanBarcode = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(999, 438);
            this.panel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panel4);
            this.groupControl1.Controls.Add(this.panel3);
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(1, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(997, 436);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "报告单";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvReport);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(2, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(993, 312);
            this.panel4.TabIndex = 2;
            // 
            // dgvReport
            // 
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Location = new System.Drawing.Point(0, 0);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowTemplate.Height = 23;
            this.dgvReport.Size = new System.Drawing.Size(993, 312);
            this.dgvReport.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "报告日期";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "报告单号";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "医院条码";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "达安条码";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "病人姓名";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "性别";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "年龄";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "年龄单位";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "送检科室";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "送检医生";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "项目名称";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "采样日期";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "打印次数";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "打印时间";
            this.Column14.Name = "Column14";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNoPrint);
            this.panel3.Controls.Add(this.btnReportPrint);
            this.panel3.Controls.Add(this.btnReportView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 397);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(993, 37);
            this.panel3.TabIndex = 1;
            // 
            // btnNoPrint
            // 
            this.btnNoPrint.Location = new System.Drawing.Point(190, 6);
            this.btnNoPrint.Name = "btnNoPrint";
            this.btnNoPrint.Size = new System.Drawing.Size(75, 23);
            this.btnNoPrint.TabIndex = 2;
            this.btnNoPrint.Text = "打印未打";
            this.btnNoPrint.UseVisualStyleBackColor = true;
            // 
            // btnReportPrint
            // 
            this.btnReportPrint.Location = new System.Drawing.Point(102, 6);
            this.btnReportPrint.Name = "btnReportPrint";
            this.btnReportPrint.Size = new System.Drawing.Size(75, 23);
            this.btnReportPrint.TabIndex = 1;
            this.btnReportPrint.Text = "报告单打印";
            this.btnReportPrint.UseVisualStyleBackColor = true;
            // 
            // btnReportView
            // 
            this.btnReportView.Location = new System.Drawing.Point(15, 6);
            this.btnReportView.Name = "btnReportView";
            this.btnReportView.Size = new System.Drawing.Size(75, 23);
            this.btnReportView.TabIndex = 0;
            this.btnReportView.Text = "报告单预览";
            this.btnReportView.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbReportStatus);
            this.panel2.Controls.Add(this.cbbLabDept);
            this.panel2.Controls.Add(this.txtOrdersNum);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.txtHospitalBarcode);
            this.panel2.Controls.Add(this.txtHospital);
            this.panel2.Controls.Add(this.txtDaanBarcode);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpEndDate);
            this.panel2.Controls.Add(this.dtpBeginDate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 63);
            this.panel2.TabIndex = 0;
            // 
            // cbbReportStatus
            // 
            this.cbbReportStatus.FormattingEnabled = true;
            this.cbbReportStatus.Location = new System.Drawing.Point(746, 33);
            this.cbbReportStatus.Name = "cbbReportStatus";
            this.cbbReportStatus.Size = new System.Drawing.Size(121, 20);
            this.cbbReportStatus.TabIndex = 19;
            // 
            // cbbLabDept
            // 
            this.cbbLabDept.FormattingEnabled = true;
            this.cbbLabDept.Location = new System.Drawing.Point(746, 8);
            this.cbbLabDept.Name = "cbbLabDept";
            this.cbbLabDept.Size = new System.Drawing.Size(121, 20);
            this.cbbLabDept.TabIndex = 18;
            // 
            // txtOrdersNum
            // 
            this.txtOrdersNum.Location = new System.Drawing.Point(558, 33);
            this.txtOrdersNum.Name = "txtOrdersNum";
            this.txtOrdersNum.Size = new System.Drawing.Size(100, 21);
            this.txtOrdersNum.TabIndex = 17;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(387, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 16;
            // 
            // txtHospitalBarcode
            // 
            this.txtHospitalBarcode.Location = new System.Drawing.Point(558, 8);
            this.txtHospitalBarcode.Name = "txtHospitalBarcode";
            this.txtHospitalBarcode.Size = new System.Drawing.Size(100, 21);
            this.txtHospitalBarcode.TabIndex = 14;
            // 
            // txtHospital
            // 
            this.txtHospital.Location = new System.Drawing.Point(387, 8);
            this.txtHospital.Name = "txtHospital";
            this.txtHospital.Size = new System.Drawing.Size(100, 21);
            this.txtHospital.TabIndex = 13;
            // 
            // txtDaanBarcode
            // 
            this.txtDaanBarcode.Location = new System.Drawing.Point(78, 34);
            this.txtDaanBarcode.Name = "txtDaanBarcode";
            this.txtDaanBarcode.Size = new System.Drawing.Size(217, 21);
            this.txtDaanBarcode.TabIndex = 12;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(891, 33);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "复位";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(891, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(680, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "报告状态:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(505, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "订单号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "姓名:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "达安条码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "医院科室:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "医院条码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "住院/门诊:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(190, 8);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(107, 21);
            this.dtpEndDate.TabIndex = 2;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(78, 8);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(106, 21);
            this.dtpBeginDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "报告日期:";
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 438);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReport";
            this.Text = "报告单";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtHospitalBarcode;
        private System.Windows.Forms.TextBox txtHospital;
        private System.Windows.Forms.TextBox txtDaanBarcode;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNoPrint;
        private System.Windows.Forms.Button btnReportPrint;
        private System.Windows.Forms.Button btnReportView;
        private System.Windows.Forms.TextBox txtOrdersNum;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.ComboBox cbbReportStatus;
        private System.Windows.Forms.ComboBox cbbLabDept;
    }
}