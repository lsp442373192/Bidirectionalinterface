using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Daan.LIMS.Manage
{
    public partial class FrmBase : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public FrmBase()
        {
            InitializeComponent();
            ContextMenuStrip cms = new System.Windows.Forms.ContextMenuStrip();
            ToolStripMenuItem tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // cms
            // 
            tsmiClose.Name = "cms";
            tsmiClose.Size = new System.Drawing.Size(98, 22);
            tsmiClose.Text = "关闭";
            tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // tsmiClose
            // 
            cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
             tsmiClose});
            cms.Name = "tsmiClose";
            cms.Size = new System.Drawing.Size(99, 26);

            this.TabPageContextMenuStrip = cms;
            this.MaximizeBox = true;
            
        }
        //Tab右键关闭事件
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmBase_Load(object sender, EventArgs e)
        {
            

        }
    }
}
