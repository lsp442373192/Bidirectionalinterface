namespace Daan.control
{
    partial class LISPopSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LISPopSelect));
            this.popupContainerEdit1 = new System.Windows.Forms.TextBox();
            this.btnDropDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.popupContainerEdit1.BackColor = System.Drawing.Color.White;
            this.popupContainerEdit1.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Size = new System.Drawing.Size(162, 21);
            this.popupContainerEdit1.TabIndex = 7;
            this.popupContainerEdit1.TextChanged += new System.EventHandler(this.popupContainerEdit1_EditValueChanged);
            this.popupContainerEdit1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.popupContainerEdit1_PreviewKeyDown);
            this.popupContainerEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.popupContainerEdit1_KeyDown);
            this.popupContainerEdit1.Leave += new System.EventHandler(this.popupContainerEdit1_Leave);
            this.popupContainerEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.popupContainerEdit1_KeyPress);
            this.popupContainerEdit1.Enter += new System.EventHandler(this.popupContainerEdit1_Enter);
            // 
            // btnDropDown
            // 
            this.btnDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDropDown.BackColor = System.Drawing.Color.White;
            this.btnDropDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDropDown.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDropDown.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDropDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDropDown.Image")));
            this.btnDropDown.Location = new System.Drawing.Point(161, 0);
            this.btnDropDown.Name = "btnDropDown";
            this.btnDropDown.Size = new System.Drawing.Size(15, 20);
            this.btnDropDown.TabIndex = 6;
            this.btnDropDown.TabStop = false;
            this.btnDropDown.Tag = "yes";
            this.btnDropDown.UseVisualStyleBackColor = false;
            this.btnDropDown.Click += new System.EventHandler(this.btnDropDown_Click);
            // 
            // LISPopSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerEdit1);
            this.Controls.Add(this.btnDropDown);
            this.Name = "LISPopSelect";
            this.Size = new System.Drawing.Size(177, 22);
            this.Load += new System.EventHandler(this.HopePopSelect_Load);
            this.Leave += new System.EventHandler(this.LISPopSelect_Leave);
            this.Resize += new System.EventHandler(this.HopePopSelect_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox popupContainerEdit1;
        protected System.Windows.Forms.Button btnDropDown;
    }
}
