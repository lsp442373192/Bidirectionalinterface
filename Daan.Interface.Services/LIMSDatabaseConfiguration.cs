using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.Interface.Entity;
using System.Xml;
using Daan.Interface.Util;
using Daan.Interface.Dao;
using Daan.Interface.BLL;

namespace Daan.Interface.Services
{
    public partial class LIMSDatabaseConfiguration : Form
    {
        CommonBLL commonbll = new CommonBLL();
        public LIMSDatabaseConfiguration()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {

            DataBaseinfo info = XMLHelper.ReadDataBase(DefaultConfig.DATABASENAME);
            if (info.databasetype == "0") { radOracel.Checked = true; }
            tbxUserName.Text = info.userid;
            tbxPassWord.Text = info.password;
            tbxDataBase.Text = info.dataname;
            tbxIP.Text = info.datasource;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证
            if (!CheckInput())
            {
                return;

            }

            if (SaveConfig())
            {
                ShowMessageHelper.ShowBoxMsg("保存成功!");
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("保存失败!");
            }
            this.Close();

        }

        private bool SaveConfig()
        {
            bool isTrue = false;
            try
            {
                XmlDocument XD = new XmlDocument();
                XD.Load(DefaultConfig.DATABASENAME);
                XmlNode xn = XD.ChildNodes[0];
                for (int j = 0; j < xn.ChildNodes.Count; j++)
                {
                    XmlNode clxn = xn.ChildNodes[j];
                    switch (clxn.Name)
                    {
                        case "databasetype":
                            clxn.InnerText = radSQLserver.Checked ? "1" : "0";
                            break;
                        case "userid":
                            clxn.InnerText = tbxUserName.Text;
                            break;
                        case "password":
                            clxn.InnerText = tbxPassWord.Text;
                            break;
                        case "dataname":
                            clxn.InnerText = tbxDataBase.Text;
                            break;
                        case "datasource":
                            clxn.InnerText = tbxIP.Text;
                            break;
                        default:
                            break;
                    }
                }
                XD.Save(DefaultConfig.DATABASENAME);
                //释放缓存，以获取新的连接串
                mapperobj.clearMapper();
                isTrue = true;
            }
            catch 
            {
                isTrue = false;
            }
            return isTrue;
        }
        private bool CheckInput()
        {
            if (radOracel.Checked == true)
            {
                if (tbxDataBase.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("SID不能为空!");
                    tbxDataBase.Focus();
                    return false;
                }
            }
            else
            {
                if (tbxIP.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("服务器IP不能为空!");
                    tbxIP.Focus();
                    return false;
                }
                if (tbxDataBase.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("数据库不能为空!");
                    tbxDataBase.Focus();
                    return false;
                }

            }
            if (tbxUserName.Text == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("用户名不能为空!");
                tbxUserName.Focus();
                return false;
            }
            if (tbxPassWord.Text == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("密码不能为空!");
                tbxPassWord.Focus();
                return false;
            }
            return true;
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //选择Oracle
        private void radOracel_CheckedChanged(object sender, EventArgs e)
        {
            lblTypeName.Text = "服务名：";
            lblmsg.Text = "不输入IP则使用本机配置服务名\n输入IP则使用服务器的服务名";
        }

        //选择SQL
        private void radSQLserver_CheckedChanged(object sender, EventArgs e)
        {
            lblTypeName.Text = "数据库名：";
            lblmsg.Text = "";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DataBaseinfo info = new DataBaseinfo();
            if (radOracel.Checked == true)
            {
                info.databasetype = "0";
            }
            else
            {
                info.databasetype = "1";
            }
            info.dataname = tbxDataBase.Text.ToString();
            info.userid = tbxUserName.Text.ToString();
            info.password = tbxPassWord.Text.ToString();
            info.datasource = tbxIP.Text.ToString();
            if (radOracel.Checked == true)
            {
                commonbll.IsConnect(info, "select 1 from dual");
            }
            else
            {
                commonbll.IsConnect(info, "select 1");
            }
        }

        private void btnInitTable_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == ShowMessageHelper.ShowBoxMsg("是否要初始化当前连接下的表结构?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            //验证
            if (!CheckInput())
            {
                return;
            }
            //保存连接
            if (!SaveConfig())
            {
                ShowMessageHelper.ShowBoxMsg("当前连接保存失败,请检查当前输入连接!");
                return;
            }
            //读取当前版本
            double oldVersion;
            DASoftversionBLL dasoftversionbll = new DASoftversionBLL();
            DASoftversion oObj = new DASoftversion();
            try
            {
                oObj = dasoftversionbll.GetLastSoftVersion();
            }
            catch { }
            if (oObj != null)
                oldVersion = Convert.ToDouble(oObj.Versioncode);
            else
            {
                oldVersion = 0.0;
            }
            if (oldVersion >= 1.0)
            {
                ShowMessageHelper.ShowBoxMsg("当前连接下的数据表已经健全!");
                return;
            }
            DataBaseinfo info = new DataBaseinfo();

            if (radOracel.Checked == true)
            {
                info.databasetype = "0";
            }
            else
            {
                info.databasetype = "1";
            }
            info.dataname = tbxDataBase.Text.ToString();
            info.userid = tbxUserName.Text.ToString();
            info.password = tbxPassWord.Text.ToString();
            info.datasource = tbxIP.Text.ToString();

            if (commonbll.ScriptUpdateByBat(info, 0, 1.0))
            {
                ShowMessageHelper.ShowBoxMsg("初始化表结构成功!");
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("初始化表结构失败!");
            }
        }
    }
}
