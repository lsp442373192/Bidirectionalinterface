using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.Interface.Entity;
using Daan.Interface.Util;
using Daan.Interface.BLL;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace Daan.LIMS.Manage
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        //是否按了右上角关闭
        private static bool closeTag = false;
        //是否注销
        private static bool dispTag = false;

        //加载主窗体
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //创建主菜单
            SetMenu();
        }

        #region 单击菜单事件
        void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            string str = t.Text;
            if ("系统用户".Equals(str))
            {
                LoadMdiForm(this, typeof(FrmSystemUser));

            }
            else if ("修改密码".Equals(str))
            {
                FrmModifyPwd frm = new FrmModifyPwd();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            else if ("注销".Equals(str))
            {
                tsbCancel_Click(sender, e);
            }
            else if ("退出".Equals(str))
            {
                tsbExit_Click(sender, e);
            }
            else if ("医院项目".Equals(str))
            {
                LoadMdiForm(this, typeof(FrmHospitalItem));
            }
            else if ("达安项目".Equals(str))
            {
                LoadMdiForm(this, typeof(FrmDaanItem));
            }
            else if ("项目对照表".Equals(str))
            {
                LoadMdiForm(this, typeof(FrmItemHospitalAndDaan));
            }
            else if ("委外订单".Equals(str))
            {
                LoadMdiForm(this, typeof(FrmOutOrder));
            }
            //else if ("送检标本".Equals(str))
            //{
            //    FrmSendCheckOrder frm = new FrmSendCheckOrder();
            //    ShowForm(frm);
            //}
            else if ("综合查询".Equals(str))
            {
                LoadMdiForm(this, typeof(FrmSpecSeach));
            }
            else if ("样本录入".Equals(str))
            {
                LoadMdiForm(this, typeof(FrmSampleInput));
                //LoadMdiForm(this, typeof(FrmSampleInput));
            }
            //else if ("错误日志".Equals(str))
            //{
            //    FrmErrorLog frm = new FrmErrorLog();
            //    ShowForm(frm);
            //}

        }
        #endregion

        #region 注销
        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (ShowMessageHelper.ShowBoxMsg("您确定要注销系统吗?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                try
                {
                    //Program.CloseALLForm(this);
                    CloseForm();
                    this.Hide();
                }
                catch
                {
                }

                FrmLogon login = new FrmLogon();
                login.StartPosition = FormStartPosition.CenterParent;
                login.BringToFront();
                login.Focus();
                //login.TopMost = true;
                if (login.ShowDialog() == DialogResult.Cancel)
                {
                    closeTag = true;
                    dispTag = false;
                    Application.Exit();
                }
                else
                {
                    if (login.bLogin)
                    {
                        //closeTag = true;
                        dispTag = false;

                        this.WindowState = FormWindowState.Maximized;
                        this.Show();
                        this.BringToFront();
                        this.Activate();
                        this.Focus();
                        SetStatuStrip();
                    }
                    login.Dispose();
                }
            }
        }
        #endregion

        #region 退出
        private void tsbExit_Click(object sender, EventArgs e)
        {
            if (ShowMessageHelper.ShowBoxMsg("您确定要退出系统吗?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                return;
            closeTag = true;
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeTag)
            {
                if (ShowMessageHelper.ShowBoxMsg("您确定要退出系统吗?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                closeTag = true;
            }
        }
        #endregion

        #region 页面方法
        //委外订单工具栏快捷打开
        private void tsOutOrder_Click(object sender, EventArgs e)
        {
            LoadMdiForm(this, typeof(FrmOutOrder));
        }
        //综合查询工具栏快捷打开
        private void tsSpecSeach_Click(object sender, EventArgs e)
        {
            LoadMdiForm(this, typeof(FrmSpecSeach));
        }
        //显示窗体MDI
        public Form LoadMdiForm(Form mainDialog, System.Type formType)
        {
            DockContent form = null;
            try
            {
                bool flag = false;
                foreach (DockContent form2 in mainDialog.MdiChildren)
                {
                    if (form2.GetType() == formType)
                    {
                        flag = true;
                        form = form2;
                        break;
                    }
                }
                if (!flag)
                {
                    form = (DockContent)Activator.CreateInstance(formType);
                    form.MdiParent = mainDialog;
                    form.Show(this.dockPanel);

                }
                form.BringToFront();
                form.Activate();
            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg("页面加载错误!" + ex.Message);
            }
            return form;
        }
        //关闭窗体
        private void CloseForm()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
            }
            else
            {
                IDockContent[] documents = dockPanel.DocumentsToArray();
                foreach (IDockContent content in documents)
                {
                    content.DockHandler.Close();
                }
            }
        }

        //设置状态栏
        private void SetStatuStrip()
        {
            if (SystemConfig.UserInfo != null)
            {
                toolStripStatusLabel1.Text = SystemConfig.UserInfo.UserType == 0 ? "达安用户:" : "本地用户:";
                lblName.Text = SystemConfig.UserInfo.UserName;
                lblIp.Text = new CommonBLL().GetHostIP();
            }
            if (SystemConfig.Config != null)
            {
                lblHospName.Text = SystemConfig.Config.Hospname;
            }
        }

        //设置当前时间
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        //创建菜单栏
        private void ToolStripCreate(string[] fn)
        {
            for (int i = 0; i < fn.Length; i++)
            {
                ToolStripMenuItem t = new ToolStripMenuItem();
                string[] s = null;
                if ("系统管理".Equals(fn[i]))
                {
                    t.Text = fn[i];
                    s = new string[] { "系统用户", "修改密码", "注销", "退出" };
                }
                else if ("项目对照".Equals(fn[i]))
                {
                    t.Text = fn[i];
                    s = new string[] { "医院项目", "达安项目", "项目对照表" };
                }
                else if ("委外订单管理".Equals(fn[i]))
                {
                    t.Text = fn[i];
                    s = new string[] { "委外订单", "综合查询"/* ,"样本录入"*/};
                    //s = new string[] { "委外订单", "综合查询" };
                }
                for (int j = 0; j < s.Length; j++)
                {
                    ToolStripMenuItem toolStripButton = new ToolStripMenuItem();
                    toolStripButton.Text = s[j];
                    toolStripButton.Image = imageList1.Images[i.ToString() + j.ToString() + ".ico"];
                    t.DropDownItems.Add(toolStripButton);
                    toolStripButton.Click += new EventHandler(toolStripButton_Click);
                }
                msMenu.Items.Add(t);
            }
        }

        public void SetMenu()
        {
            SetStatuStrip();
            string[] s = new string[] { "系统管理", "项目对照", "委外订单管理" };
            ToolStripCreate(s);
        }
        #endregion
    }
}
