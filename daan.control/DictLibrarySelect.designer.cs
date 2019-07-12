namespace daan.control
{
    partial class DictLibrarySelect
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
            this.dictlibraryidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.librarynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.librarytypenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.librarytypecodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEdit1
            // 
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dictlibraryidDataGridViewTextBoxColumn,
            this.librarynameDataGridViewTextBoxColumn,
            this.librarytypenameDataGridViewTextBoxColumn,
            this.librarytypecodeDataGridViewTextBoxColumn});
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
            this.dictBindingSource.DataSource = typeof(Daan.Interface.Entity.DADictlibrary);
            // 
            // dictlibraryidDataGridViewTextBoxColumn
            // 
            this.dictlibraryidDataGridViewTextBoxColumn.DataPropertyName = "Dictlibraryid";
            this.dictlibraryidDataGridViewTextBoxColumn.HeaderText = "Dictlibraryid";
            this.dictlibraryidDataGridViewTextBoxColumn.Name = "dictlibraryidDataGridViewTextBoxColumn";
            this.dictlibraryidDataGridViewTextBoxColumn.ReadOnly = true;
            this.dictlibraryidDataGridViewTextBoxColumn.Visible = false;
            // 
            // librarynameDataGridViewTextBoxColumn
            // 
            this.librarynameDataGridViewTextBoxColumn.DataPropertyName = "Libraryname";
            this.librarynameDataGridViewTextBoxColumn.HeaderText = "状态名称";
            this.librarynameDataGridViewTextBoxColumn.Name = "librarynameDataGridViewTextBoxColumn";
            this.librarynameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // librarytypenameDataGridViewTextBoxColumn
            // 
            this.librarytypenameDataGridViewTextBoxColumn.DataPropertyName = "Librarytypename";
            this.librarytypenameDataGridViewTextBoxColumn.HeaderText = "描述";
            this.librarytypenameDataGridViewTextBoxColumn.Name = "librarytypenameDataGridViewTextBoxColumn";
            this.librarytypenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // librarytypecodeDataGridViewTextBoxColumn
            // 
            this.librarytypecodeDataGridViewTextBoxColumn.DataPropertyName = "Librarytypecode";
            this.librarytypecodeDataGridViewTextBoxColumn.HeaderText = "状态类型";
            this.librarytypecodeDataGridViewTextBoxColumn.Name = "librarytypecodeDataGridViewTextBoxColumn";
            this.librarytypecodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DictLibrarySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("colDisplay", this.dictBindingSource, "Libraryname", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("colExtend1", this.dictBindingSource, "Librarytypename", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("colExtend2", this.dictBindingSource, "Librarytypecode", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("colInCode", this.dictBindingSource, "Fastcode", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("colValue", this.dictBindingSource, "Dictlibraryid", true));
            this.Name = "DictLibrarySelect";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dictLibraryItemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dictlibraryidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn librarynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn librarytypenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn librarytypecodeDataGridViewTextBoxColumn;
    }
}
