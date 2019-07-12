using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Daan.Interface.Util;

namespace Daan.Interface.Services
{
    public partial class Exit : Form
    {
        NotifyIcon _NI;
        public Exit(NotifyIcon ni)
        {
            InitializeComponent();
            _NI = ni;
        }




        //确认
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string strpath = ConfigurationManager.AppSettings["Exit"].ToString();
            if (this.txtPassword.Text.Equals(strpath))
            {
                ShowMessageHelper.ShowBoxMsg("密码正确，程序即将关闭！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Application.Exit();
                _NI.Visible = false;
                System.Environment.Exit(0);
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("密码错误，您不能关闭程序！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPassword.Text = string.Empty;
            }
        }
    }
}
