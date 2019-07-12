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
    public partial class FrmParaConfiguration : Form
    {
        public FrmParaConfiguration()
        {
            InitializeComponent();
        }
        //是否下载报告单
        private void cbDownloadReport_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDownloadReport.Checked)
            {
                cbReportConver.Enabled = true;
                //cbReportSave.Enabled = true;
            }
            else
            {
                cbReportConver.Enabled = false;
                //cbReportSave.Enabled = false;
            }
          
        }

    }
}
