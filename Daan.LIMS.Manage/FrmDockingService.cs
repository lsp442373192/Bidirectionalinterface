using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Daan.LIMS.Manage
{
    public partial class FrmDockingService : Form
    {
        public FrmDockingService()
        {
            InitializeComponent();
        }

        //数据库配置
        private void btnDataBaseConfig_Click(object sender, EventArgs e)
        {
            FrmDBConfiguration frm = new FrmDBConfiguration();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        //参数配置
        private void btnParaSet_Click(object sender, EventArgs e)
        {
            FrmParaConfiguration frm = new FrmParaConfiguration();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        //关闭
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //开始服务
        private void btnBegin_Click(object sender, EventArgs e)
        {
           
        }
    }
}
