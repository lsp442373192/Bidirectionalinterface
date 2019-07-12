namespace Daan.LIMS.Manage
{
    partial class FrmItemHoapitalAndDaanImportError
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvItemHospitalAndDaan = new System.Windows.Forms.DataGridView();
            this.TestCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaTestCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemHospitalAndDaan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 314);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblRecord);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(697, 35);
            this.panel3.TabIndex = 1;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(12, 11);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(83, 12);
            this.lblRecord.TabIndex = 5;
            this.lblRecord.Text = "共 {0} 条记录";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(610, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvItemHospitalAndDaan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 279);
            this.panel2.TabIndex = 0;
            // 
            // gvItemHospitalAndDaan
            // 
            this.gvItemHospitalAndDaan.AllowUserToAddRows = false;
            this.gvItemHospitalAndDaan.AllowUserToDeleteRows = false;
            this.gvItemHospitalAndDaan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gvItemHospitalAndDaan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvItemHospitalAndDaan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvItemHospitalAndDaan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestCode,
            this.TestName,
            this.DaTestCode,
            this.DaTestName,
            this.Reason});
            this.gvItemHospitalAndDaan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvItemHospitalAndDaan.Location = new System.Drawing.Point(0, 0);
            this.gvItemHospitalAndDaan.Name = "gvItemHospitalAndDaan";
            this.gvItemHospitalAndDaan.ReadOnly = true;
            this.gvItemHospitalAndDaan.RowHeadersWidth = 20;
            this.gvItemHospitalAndDaan.RowTemplate.Height = 23;
            this.gvItemHospitalAndDaan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvItemHospitalAndDaan.Size = new System.Drawing.Size(697, 279);
            this.gvItemHospitalAndDaan.TabIndex = 3;
            this.gvItemHospitalAndDaan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvItemHospitalAndDaan_CellFormatting);
            this.gvItemHospitalAndDaan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvItemHospitalAndDaan_RowPostPaint);
            this.gvItemHospitalAndDaan.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gvItemHospitalAndDaan_Scroll);
            // 
            // TestCode
            // 
            this.TestCode.DataPropertyName = "TestCode";
            this.TestCode.HeaderText = "医院项目代码";
            this.TestCode.Name = "TestCode";
            this.TestCode.ReadOnly = true;
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "TestName";
            this.TestName.HeaderText = "医院项目名称";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            // 
            // DaTestCode
            // 
            this.DaTestCode.DataPropertyName = "DATESTCODE";
            this.DaTestCode.HeaderText = "达安项目代码";
            this.DaTestCode.Name = "DaTestCode";
            this.DaTestCode.ReadOnly = true;
            // 
            // DaTestName
            // 
            this.DaTestName.DataPropertyName = "DATESTNAME";
            this.DaTestName.HeaderText = "达安项目名称";
            this.DaTestName.Name = "DaTestName";
            this.DaTestName.ReadOnly = true;
            // 
            // Reason
            // 
            this.Reason.DataPropertyName = "Reason";
            this.Reason.HeaderText = "导入结果";
            this.Reason.Name = "Reason";
            this.Reason.ReadOnly = true;
            this.Reason.Width = 274;
            // 
            // FrmItemHoapitalAndDaanImportError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 314);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItemHoapitalAndDaanImportError";
            this.Text = "项目对照导入";
            this.Load += new System.EventHandler(this.FrmItemHoapitalAndDaanImportError_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvItemHospitalAndDaan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gvItemHospitalAndDaan;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaTestCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
    }
}