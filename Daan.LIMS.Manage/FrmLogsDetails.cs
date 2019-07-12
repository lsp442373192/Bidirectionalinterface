using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Daan.LIMS.Manage
{
    public partial class FrmLogsDetails : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogsDetails()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}