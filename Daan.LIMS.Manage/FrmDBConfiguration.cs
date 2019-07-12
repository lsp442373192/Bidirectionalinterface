using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.Dao;
using Daan.Interface.BLL;
using System.Xml;
using Daan.Interface.Util;
using System.Data.SqlClient;

namespace Daan.LIMS.Manage
{
    public partial class FrmDBConfiguration :Form
    {
        private ArrayList fileList = new ArrayList();  //批处理文件集合
        CommonBLL common = new CommonBLL();
        string port = string.Empty;
        public FrmDBConfiguration()
        {
            InitializeComponent();
        }

        #region >>> fenghp 页面事件

        #region >>> fenghp 表连接
        private void FrmDBConfiguration_Load(object sender, EventArgs e)
        {
            InitData();
        }
        //本地SQL
        private void rbLocalSql_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
        }

        //SQL Server
        private void rbSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
        }

        //Oracle
        private void rbOracle_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }
        //初始化表结构
        private void btnTableStruc_Click(object sender, EventArgs e)
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
            DASoftversion oObj =new DASoftversion();
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
            if (radOracle.Checked == true)
            {
                info.databasetype = "0";
                info.dataname = tbxSID.Text.ToString();
                info.userid = tbxOracleUserName.Text.ToString();
                info.password = tbxOraclePwd.Text.ToString();
                info.datasource = tbxOracleService.Text.ToString();
            }
            else
            {
                info.databasetype = "1";
                info.dataname = tbxDatabase.Text.ToString();
                info.userid = tbxSQLUserName.Text.ToString();
                info.password = tbxSQLPwd.Text.ToString();
                info.datasource = tbxSQLService.Text.ToString();
            }
            if (common.ScriptUpdateByBat(info, 0, 1.0))//只读取1.0的脚本
            {
                ShowMessageHelper.ShowBoxMsg("初始化表结构成功!");
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("初始化表结构失败!");
            }
        }
        //测试连接
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            DataBaseinfo info = new DataBaseinfo();
            if (radOracle.Checked == true)
            {
                info.databasetype = "0";
                info.dataname = tbxSID.Text.ToString();
                info.userid = tbxOracleUserName.Text.ToString();
                info.password = tbxOraclePwd.Text.ToString();
                info.datasource = tbxOracleService.Text.ToString();
                common.IsConnect(info, "select 1 from dual");
            }
            else
            {
                info.databasetype = "1";
                info.dataname = tbxDatabase.Text.ToString();
                info.userid = tbxSQLUserName.Text.ToString();
                info.password = tbxSQLPwd.Text.ToString();
                info.datasource = tbxSQLService.Text.ToString();
                common.IsConnect(info, "select 1");
            }
        }
        //保存
        private void btnOK_Click(object sender, EventArgs e)
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
        }
        //保存配置
        private bool SaveConfig()
        {
            bool isTrue = false;
           
            try
            {
                //读取配置文件重新给值，保存
                XmlDocument XD = new XmlDocument();
                XD.Load(DefaultConfig.DATABASENAME);
                XmlNode xn = XD.ChildNodes[0];
                for (int j = 0; j < xn.ChildNodes.Count; j++)
                {
                    XmlNode clxn = xn.ChildNodes[j];
                    switch (clxn.Name)
                    {
                        case "databasetype":
                            clxn.InnerText = radSQLServer.Checked ? "1" : "0";
                            break;
                        case "userid":
                            clxn.InnerText = radSQLServer.Checked ? tbxSQLUserName.Text : tbxOracleUserName.Text;
                            break;
                        case "password":
                            clxn.InnerText = radSQLServer.Checked ? tbxSQLPwd.Text : tbxOraclePwd.Text;
                            break;
                        case "dataname":
                            clxn.InnerText = radSQLServer.Checked ? tbxDatabase.Text : tbxSID.Text;
                            break;
                        case "datasource":
                            clxn.InnerText = radSQLServer.Checked ? tbxSQLService.Text : tbxOracleService.Text;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region >>> fenghp 视图连接
        private void radVSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
        }
        
        private void radVOracle_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel4.Visible = false;
        }
        //测试连接
        private void btnVTestConnect_Click(object sender, EventArgs e)
        {
            DataBaseinfo info = new DataBaseinfo();
            if (radVOracle.Checked == true)
            {
                info.databasetype = "0";
                info.dataname = tbxVSID.Text.ToString();
                info.userid = tbxVOracleUserName.Text.ToString();
                info.password = tbxVOraclePwd.Text.ToString();
                info.datasource = tbxVOracleService.Text.ToString();
                //执行语句测试
                common.IsConnect(info, "select 1 from dual");
            }
            else
            {
                info.databasetype = "2";
                info.dataname = tbxVDatabase.Text.ToString();
                info.userid = tbxVSQLUserName.Text.ToString();
                info.password = tbxVSQLPwd.Text.ToString();
                info.datasource = tbxVSQLService.Text.ToString();
                info.port = port;
                //执行语句测试
                common.IsConnect(info, "select 1");
            }
        }

        private void btnVOK_Click(object sender, EventArgs e)
        {
            //验证
            if (!CheckViewInput())
                return;

            try
            {
                //读取视图配置文件重新给值，保存
                XmlDocument XD = new XmlDocument();
                XD.Load(DefaultConfig.VIEWDATABASENAME);
                XmlNode xn = XD.ChildNodes[0];
                for (int j = 0; j < xn.ChildNodes.Count; j++)
                {
                    XmlNode clxn = xn.ChildNodes[j];
                    switch (clxn.Name)
                    {
                        case "databasetype":
                            clxn.InnerText = radVSQLServer.Checked ? "2" : "0";
                            break;
                        case "userid":
                            clxn.InnerText = radVSQLServer.Checked ? tbxVSQLUserName.Text : tbxVOracleUserName.Text;
                            break;
                        case "password":
                            clxn.InnerText = radVSQLServer.Checked ? tbxVSQLPwd.Text : tbxVOraclePwd.Text;
                            break;
                        case "dataname":
                            clxn.InnerText = radVSQLServer.Checked ? tbxVDatabase.Text : tbxVSID.Text;
                            break;
                        case "datasource":
                            clxn.InnerText = radVSQLServer.Checked ? tbxVSQLService.Text : tbxVOracleService.Text;
                            break;
                        default:
                            break;
                    }
                }
                XD.Save(DefaultConfig.VIEWDATABASENAME);
                //释放缓存，以获取新的连接串
                mapperobj.clearMapper();
                ShowMessageHelper.ShowBoxMsg("保存成功!");
                
            }
            catch
            {
                ShowMessageHelper.ShowBoxMsg("保存失败!");
            }
        }

        private void btnVCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region >>> fenghp 方法
        #region >>> fenghp 绑定数据
        private void InitData()
        {
            //绑定表连接
            DataBaseinfo info = XMLHelper.ReadDataBase(DefaultConfig.DATABASENAME);
            if (info.databasetype == "0")
            {
                radOracle.Checked = true;
                tbxOracleUserName.Text = info.userid;
                tbxOraclePwd.Text = info.password;
                tbxSID.Text = info.dataname;
                tbxOracleService.Text = info.datasource;
            }
            else
            {
                radSQLServer.Checked = true;
                tbxSQLUserName.Text = info.userid;
                tbxSQLPwd.Text = info.password;
                tbxDatabase.Text = info.dataname;
                tbxSQLService.Text = info.datasource;
            }
            //绑定视图连接
            DataBaseinfo vinfo = XMLHelper.ReadDataBase(DefaultConfig.VIEWDATABASENAME);
            if (vinfo.databasetype == "0")
            {
                radVOracle.Checked = true;
                tbxVOracleUserName.Text = vinfo.userid;
                tbxVOraclePwd.Text = vinfo.password;
                tbxVSID.Text = vinfo.dataname;
                tbxVOracleService.Text = vinfo.datasource;
            }
            else
            {
                radVSQLServer.Checked = true;
                tbxVSQLUserName.Text = vinfo.userid;
                tbxVSQLPwd.Text = vinfo.password;
                tbxVDatabase.Text = vinfo.dataname;
                tbxVSQLService.Text = vinfo.datasource;
                port = vinfo.port;
            }
        }
        #endregion

        #region>>> fenghp 验证输入
        private bool CheckInput()
        {
            if (radOracle.Checked == true)
            {
                if (tbxSID.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("SID不能为空!");
                    tbxSID.Focus();
                    return false;
                }
                if (tbxOracleUserName.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("用户名不能为空!");
                    tbxOracleUserName.Focus();
                    return false;
                }
                if (tbxOraclePwd.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("密码不能为空!");
                    tbxOraclePwd.Focus();
                    return false;
                }
            }
            else
            {
                if (tbxSQLService.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("服务器不能为空!");
                    tbxSQLService.Focus();
                    return false;
                }
                if (tbxDatabase.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("数据库不能为空!");
                    tbxDatabase.Focus();
                    return false;
                }
                if (tbxSQLUserName.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("用户名不能为空!");
                    tbxSQLUserName.Focus();
                    return false;
                }
                if (tbxSQLPwd.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("密码不能为空!");
                    tbxSQLPwd.Focus();
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region>>> fenghp 验证输入  视图
        private bool CheckViewInput()
        {
            if (radVOracle.Checked == true)
            {
                if (tbxVSID.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("SID不能为空!");
                    tbxVSID.Focus();
                    return false;
                }
                if (tbxVOracleUserName.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("用户名不能为空!");
                    tbxVOracleUserName.Focus();
                    return false;
                }
                if (tbxVOraclePwd.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("密码不能为空!");
                    tbxVOraclePwd.Focus();
                    return false;
                }
            }
            else
            {
                if (tbxVSQLService.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("服务器不能为空!");
                    tbxVSQLService.Focus();
                    return false;
                }
                if (tbxVDatabase.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("数据库不能为空!");
                    tbxVDatabase.Focus();
                    return false;
                }
                if (tbxVSQLUserName.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("用户名不能为空!");
                    tbxVSQLUserName.Focus();
                    return false;
                }
                if (tbxVSQLPwd.Text == string.Empty)
                {
                    ShowMessageHelper.ShowBoxMsg("密码不能为空!");
                    tbxVSQLPwd.Focus();
                    return false;
                }
            }
            return true;
        }
        #endregion
        #endregion

        

    }
}
