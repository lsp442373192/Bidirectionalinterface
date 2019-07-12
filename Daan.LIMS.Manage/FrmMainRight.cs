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
    public partial class FrmMainRight : Form
    {
        public FrmMainRight()
        {
            InitializeComponent();
        }
        public FrmMainRight(string str)
        {
            InitializeComponent();
            groupControl1.Text = str;
        }
    }
}
