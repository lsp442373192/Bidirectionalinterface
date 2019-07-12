namespace Daan.control
{
    partial class DictTestSelect
    {
        /// <summary> 
        /// 必需的设计器变量。

        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。

        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。

        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dictBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Datestname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datestcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Englishname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Engshortname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datestitemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Multiline = true;
            this.popupContainerEdit1.Size = new System.Drawing.Size(514, 21);
            // 
            // btnDropDown
            // 
            this.btnDropDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDropDown.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDropDown.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDropDown.Location = new System.Drawing.Point(514, 0);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Datestname,
            this.Datestcode,
            this.Englishname,
            this.Engshortname,
            this.Datestitemid});
            this.dataGridView1.DataSource = this.dictBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(18, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(386, 306);
            this.dataGridView1.TabIndex = 8;
            // 
            // dictBindingSource
            // 
            this.dictBindingSource.DataSource = typeof(Daan.Interface.Entity.DADicttestitem);
            // 
            // Datestname
            // 
            this.Datestname.DataPropertyName = "Datestname";
            this.Datestname.HeaderText = "项目名称";
            this.Datestname.Name = "Datestname";
            this.Datestname.ReadOnly = true;
            // 
            // Datestcode
            // 
            this.Datestcode.DataPropertyName = "Datestcode";
            this.Datestcode.HeaderText = "项目代码";
            this.Datestcode.Name = "Datestcode";
            this.Datestcode.ReadOnly = true;
            // 
            // Englishname
            // 
            this.Englishname.DataPropertyName = "Englishname";
            this.Englishname.HeaderText = "英文名称";
            this.Englishname.Name = "Englishname";
            this.Englishname.ReadOnly = true;
            // 
            // Engshortname
            // 
            this.Engshortname.DataPropertyName = "Engshortname";
            this.Engshortname.HeaderText = "快捷码";
            this.Engshortname.Name = "Engshortname";
            this.Engshortname.ReadOnly = true;
            // 
            // Datestitemid
            // 
            this.Datestitemid.DataPropertyName = "Datestitemid";
            this.Datestitemid.HeaderText = "Datestitemid";
            this.Datestitemid.Name = "Datestitemid";
            this.Datestitemid.ReadOnly = true;
            this.Datestitemid.Visible = false;
            // 
            // DictTestSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("colDisplay", this.dictBindingSource, "Datestname", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("colExtend1", this.dictBindingSource, "Englishname", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("colExtend2", this.dictBindingSource, "Datestcode", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("colInCode", this.dictBindingSource, "Engshortname", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("colValue", this.dictBindingSource, "Datestitemid", true));
            this.Name = "DictTestSelect";
            this.Size = new System.Drawing.Size(529, 21);
            this.Controls.SetChildIndex(this.btnDropDown, 0);
            this.Controls.SetChildIndex(this.popupContainerEdit1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dictBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wbmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pymDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn engShortNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn testCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isGroupValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dictTestidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datestname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datestcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Englishname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Engshortname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datestitemid;
    }
}
