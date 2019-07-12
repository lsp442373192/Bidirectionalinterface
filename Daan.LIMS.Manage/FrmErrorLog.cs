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
    public partial class FrmErrorLog : Form
    {
        public FrmErrorLog()
        {
            InitializeComponent();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            FrmLogsDetails frm = new FrmLogsDetails();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
     
    }
}
