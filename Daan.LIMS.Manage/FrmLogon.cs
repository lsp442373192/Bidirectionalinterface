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
using System.Reflection;
using System.Configuration;
using Daan.Interface.Entity;
using Daan.Interface.Dao;
using Daan.Interface.BLL;
using System.Xml;
using Daan.Interface.Util;
using System.Data.SqlClient;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Configuration;
using System.Drawing.Drawing2D;


namespace Daan.LIMS.Manage
{
    public partial class FrmLogon : Form
    {
        #region property
        public bool bLogin = false; //判断用户是否登陆
        private bool bCheckversion = false;//判断是否已经检测新
        DESEncrypt desEncrypt = new DESEncrypt();//加密类
        DAConfigBLL configBll = new DAConfigBLL();
        DASoftversionBLL dasoftversionbll = new DASoftversionBLL();
        CommonBLL common = new CommonBLL();
        DAConfig config = null;
        private bool isAutoRun = true;//是否由自动更新启动本程序
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        #endregion

        public FrmLogon()
        {
            InitializeComponent();
        }

        #region>>>> zhouy 重写 画窗口圆角
        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);//this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 
            FormPath = GetRoundedRectPath(rect, 10);
            this.Region = new Region(FormPath);
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            //   左上角   
            Rectangle arcRect2 = new Rectangle(rect.Location, new Size(5, 5));
            path.AddArc(arcRect2, 180, 90);
            //   右上角   
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角   
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角   
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnResize(System.EventArgs e)
        {
            this.Region = null;
            SetWindowRegion();
        }

        #endregion

        #region >>> fenghp 页面事件
        private void FrmLogon_Load(object sender, EventArgs e)
        {
            //获取配置文件转换为bool型
            isAutoRun = (Boolean)Convert.ChangeType(ConfigurationManager.AppSettings["CheckVersion"].ToString(), typeof(bool));
            this.Focus();
            tbxUserName.Focus();

        }
        //登录
        private void btLogin_Click(object sender, EventArgs e)
        {

            if (tbxUserName.Text.Trim() == "")
            {
                ShowMessageHelper.ShowBoxMsg("帐号不能为空，请输入!");
                tbxUserName.Focus();
                return;
            }
            if (tbxPwd.Text.Trim() == "")
            {
                ShowMessageHelper.ShowBoxMsg("密码不能为空，请输入!");
                tbxPwd.Focus();
                return;
            }

            //检查数据库表连接
            if (!IsConnect(DefaultConfig.DATABASENAME, "数据库表")) return;
            //检查数据库视图连接
            if (!IsConnect(DefaultConfig.VIEWDATABASENAME, "医院LIS数据库")) return;

            //版本检测，有自动更新启动才进行版本检测
            if (isAutoRun)
                CheckVersion();

            //开始检查用户名密码登录
            if (radDaan.Checked == true)//达安帐号
            {
                DoLoginWeb();
            }
            else//本地
            {
                //登录
                DoLogin();
            }
            //登录成功设置系统参数信息 检测数据库版本
            if (bLogin)
            {
                setSystemConfig();
            }
        }
        //取消
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //设置数据库
        private void btnSet_Click(object sender, EventArgs e)
        {
            FrmDBConfiguration con = new FrmDBConfiguration();
            con.StartPosition = FormStartPosition.CenterParent;
            con.ShowDialog();
            tbxUserName.Focus();
        }
        //最小化
        private void btnMinForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            tbxUserName.Focus();
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Enter
        private void NAMEKeyDown_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxPwd.SelectAll();
                this.tbxPwd.Focus();
            }
        }

        //Enter
        private void PWDKeyDown_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btLogin_Click(sender, null);
            }
        }
        //首次打开显示在最前端
        private void FrmLogon_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        //选择登录方式后光标指到用户名
        private void radLocation_CheckedChanged(object sender, EventArgs e)
        {
            tbxUserName.Focus();
        }
        //实现鼠标拖动窗体
        private void FrmLogon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }
        private void FrmLogon_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }
        private void FrmLogon_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        #endregion

        #region >>> fenghp 本地方法
        /// <summary>
        /// 用戶登錄
        /// </summary>
        private void DoLogin()
        {
            try
            {
                string strCode = tbxUserName.Text.ToString();
                string strPwd = desEncrypt.getMd5Hash(tbxPwd.Text.ToString());
                //获取用户信息
                DADictuser user = new DADictuser();
                user.Usercode = strCode;
                string strUsercode = user.Usercode;
                user = new DADictuserBLL().GetDADictuserInfoByUserCode(user);
                //获取系统参数
                decimal cid = DefaultConfig.DACONFIGID;
                //转换不成功
                if (!decimal.TryParse(ConfigurationManager.AppSettings["DaConfigID"], out cid))
                {
                    ShowMessageHelper.ShowBoxMsg("请先维护好配置ID!");
                    return;
                }
                config = configBll.SelectyDAConfigInfo(cid);
                if (config == null)
                {
                    ShowMessageHelper.ShowBoxMsg("没有ID为[" + cid + "]的配置记录");
                    return;
                }
                //再次校验用户名
                if (user == null || user.Usercode != strUsercode)
                {
                    ShowMessageHelper.ShowBoxMsg("帐号或密码错误，请重新输入!");
                    return;
                }
                //存在对应用户校验密码跟用户状态
                if (user != null && user.Password == strPwd)
                {
                    //账户已被停用
                    if (user.Isactive.ToString() == "0")
                    {
                        ShowMessageHelper.ShowBoxMsg("该账户已被停用!");
                        return;
                    }
                    else//账户未已被停用
                    {
                        //保存用户信息
                        LoginUserInfo userInfo = new LoginUserInfo();
                        userInfo.UserCode = tbxUserName.Text.ToString();
                        userInfo.UserId = user.Dictuserid.ToString();
                        userInfo.UserName = user.Username;
                        userInfo.UserType = 1;
                        //登录webservice获取SID保存
                        if (config != null)
                        {
                            string strSideCode = config.Sitecode;//分点代码
                            string strUrl = config.Address;     //调用webservice地址
                            string username = config.Username; //登录用户名
                            string password = config.Password; //登录用户密码

                            //设置调用webservice登录方法的参数
                            string[] par = new string[] { strSideCode, username, password, user.Username };
                            //获取webservice更新
                            WebServiceUtils.SetIsUpdate(config.Address);
                            //登录验证
                            object loginResult = WebServiceUtils.ExecuteMethod("Login",par);

                            //返回登录验证信息:1|SID,0|errorMsg
                            string[] loginMsg = loginResult.ToString().Split('|');
                            //登录成功 设置SID
                            if (loginMsg[0] == "1")
                            {
                                userInfo.SID = loginMsg[1].ToString();
                                ////设置调用webservice获取中心库数据(客户表、项目表、基础字典表)方法的参数
                                //DateTime itemdt = new DATablelastdateBLL().SelectyDATablelastdateInfoByTableName("da_dicttestitem");
                                //DateTime librarydt = new DATablelastdateBLL().SelectyDATablelastdateInfoByTableName("da_dictlibrary");
                                //DateTime customerdt = new DATablelastdateBLL().SelectyDATablelastdateInfoByTableName("da_dictcustomer");
                                //object[] parameters = new object[] { userInfo.SID, itemdt, librarydt, customerdt };
                                //string strXML = WebServiceUtils.Execute(strUrl, "GetCenterTableDate", parameters);
                                //string  reg  =   common.GetCenterTableDate(strXML);
                                //ShowMessageHelper.ShowBoxMsg(reg);
                            }
                            else
                            {
                                ShowMessageHelper.ShowBoxMsg("WebService登录失败,错误信息：" + loginMsg[1].ToString() + "\n请检查系统参数配置!");
                            }
                        }
                        //保存用户信息到SystemConfig类
                        SystemConfig.UserInfo = userInfo;
                        //登录成功
                        bLogin = true;
                        this.DialogResult = DialogResult.OK;

                    }
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("帐号或密码错误，请重新输入!");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg("登录的过程中发生了错误,错误信息:" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region >>> fenghp 调用中心WEBSERVICE接口GetUerInfo方法获取用户信息
        private void DoLoginWeb()
        {
            try
            {
                //获取系统参数
                decimal cid = DefaultConfig.DACONFIGID;
                //转换不成功
                if (!decimal.TryParse(ConfigurationManager.AppSettings["DaConfigID"], out cid))
                {
                    ShowMessageHelper.ShowBoxMsg("请先维护好配置ID!");
                    return;
                }
                config = configBll.SelectyDAConfigInfo(cid);
                if (config == null)
                {
                    ShowMessageHelper.ShowBoxMsg("没有ID为[" + cid + "]的配置记录");
                    return;
                }
                if (config != null)
                {
                    LoginWebservice();
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("获取系统参数配置失败，请检查数据库表配置!");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg("登录的过程中发生了错误,错误信息:" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginWebservice()
        {
            string strSideCode = config.Sitecode;//分点代码
            string url = config.Address;//调用webservice地址
            string username = tbxUserName.Text.ToString(); //登录用户名
            string password = tbxPwd.Text.ToString();//登录用户密码

            //设置调用webservice登录方法的参数
            string[] par = new string[] { strSideCode, username, password };
            //获取webservice更新
            WebServiceUtils.SetIsUpdate(config.Address);
            //登录验证
            object loginResult = WebServiceUtils.ExecuteMethod("GetUerInfo", par);

            //返回登录验证信息:1|SID,0|errorMsg
            string[] loginMsg = loginResult.ToString().Split('|');

            if (loginMsg[0] == "0") //登录失败     
            {
                ShowMessageHelper.ShowBoxMsg(loginMsg[1].ToString());
                return;
            }
            //读取返回的信息
            XmlDocument dc = new XmlDocument();
            dc.LoadXml(loginMsg[1].ToString());
            XmlNode nodeUserId = dc.SelectSingleNode(@"UserInfo/UserId");
            XmlNode nodeUserName = dc.SelectSingleNode(@"UserInfo/UserName");
            XmlNode nodeSID = dc.SelectSingleNode(@"UserInfo/SID");
            LoginUserInfo userInfo = new LoginUserInfo();
            if (nodeUserId != null)
            {
                userInfo.UserId = nodeUserId.InnerText;
            }
            if (nodeUserName != null)
            {
                userInfo.UserName = nodeUserName.InnerText;
            }
            //if (nodeSID != null)
            //{
            //    userInfo.SID = nodeSID.InnerText;
            //}
            //登录webservice获取SID保存
            string[] loginMsg1 = common.UserLogin(config);
            //登录成功 设置SID
            if (loginMsg1[0] == "1")
            {
                userInfo.SID = loginMsg1[1].ToString();
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("WebService登录失败,错误信息：" + loginMsg[1].ToString() + "\n请检查系统参数配置!");

            }
            userInfo.UserCode = tbxUserName.Text.ToString();
            userInfo.UserType = 0;
            //保存用户信息到SystemConfig类
            SystemConfig.UserInfo = userInfo;
            //登录成功
            bLogin = true;
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region >>> fenghp 系统参数配置
        //设置系统参数信息
        private void setSystemConfig()
        {
            if (config != null)
            {
                SystemConfig.Config = config;
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("初始化系统参数失败,请检查服务端系统参数配置!");
            }
        }
        #endregion

        #region >>> fenghp 检测版本
        private void CheckVersion()
        {
            double oldVersion;
            double newVersion;
            //是否不存在表LastSoftVersion
            bool isExist = true;
            try
            {
                //读取数据库获取旧版本号，防止并发，在获取最新版本时锁定Soft_Version表
                DASoftversion oObj = new DASoftversion();
                try
                {
                    oObj = dasoftversionbll.GetLastSoftVersion();
                }
                catch
                {
                    isExist = false;
                    if (ShowMessageHelper.ShowBoxMsg("当前连接的数据库表不健全，是否初始化数据库?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
                if (oObj != null)
                    oldVersion = Convert.ToDouble(oObj.Versioncode);
                else
                    oldVersion = 0.0;
                //读取list.txt获取最新版本号
                string filePath = Application.StartupPath + @"\edition.txt";
                if (!File.Exists(filePath))
                {
                    ShowMessageHelper.ShowBoxMsg("检测数据库版本时发生错误,找不到版本文件!");
                    return;
                }
                FileStream fs = new FileStream(Application.StartupPath + @"\edition.txt", FileMode.Open, FileAccess.Read);

                StreamReader m_streamReader = new StreamReader(fs);

                //使用StreamReader类来读取文件

                newVersion = Convert.ToDouble(m_streamReader.ReadLine());
                if (newVersion > oldVersion)
                {
                    if (isExist && ShowMessageHelper.ShowBoxMsg("检查到新的数据库版本，是否执行更新?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    //读取数据库配置XML文件
                    DataBaseinfo baseinfo = XMLHelper.ReadDataBase(DefaultConfig.DATABASENAME);
                    //版本更新,更新数据库脚本
                    common.ScriptUpdateByBat(baseinfo, oldVersion, newVersion);
                }
                else if (newVersion < oldVersion)
                {
                    //版本回溯,删除最新版本信息
                    DeleteLastVersion(newVersion.ToString());
                }
                else
                {
                    //无版本操作
                }
            }
            catch
            {
                ShowMessageHelper.ShowBoxMsg("检测数据库版本时发生错误,请检查相关配置!");
            }

        }
        /// <summary>
        /// 删除比回溯版本号更高的版本
        /// </summary>
        /// <param name="version">回溯版本号</param>
        private void DeleteLastVersion(string version)
        {
            dasoftversionbll.DelVersionByID(version);
        }
        #endregion

        #region >>> fenghp 测试视图连接是否正常
        private bool testViewConnection()
        {
            try
            {
                List<VDAListests> vdl = new VDAListestsBLL().GetDaListestsList(new Hashtable());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region >>> fenghp 测试数据库连接是否正常
        /// <summary>
        /// 测试数据库连接是否正常
        /// </summary>
        /// <param name="conPath">XML路径文件名</param>
        /// <param name="strMessage">弹出错误信息，指明是哪个数据连接出错</param>
        /// <returns></returns>
        public bool IsConnect(string conPath, string strMessage)
        {
            string testsql = string.Empty;
            DataBaseinfo info = XMLHelper.ReadDataBase(conPath);
            if (info.databasetype == "0")
            {
                testsql = "select 1 from dual";
            }
            else
            {
                testsql = "select 1";
            }
            bool istrue = false;
            //测试链接
            bool connetctionStatus = false;
            bool timeOut = false;
            TimeoutChecker timeout = new TimeoutChecker(
                    delegate
                    {
                        ISqlMapper mapper = null;
                        try
                        {
                            //获取ISqlMapper尝试连接
                            mapper = mapperobj.NewMapper(info);
                            DataSet ds = new DataSet();
                            mapper.OpenConnection();
                            IDbCommand command = mapper.LocalSession.CreateCommand(CommandType.Text);
                            command.CommandText = testsql;//"SELECT 1 FROM DA_CONFIG";
                            mapper.LocalSession.CreateDataAdapter(command).Fill(ds);
                            connetctionStatus = true;
                            //ShowMessageHelper.ShowBoxMsg("数据库连接成功!");
                            istrue = true;
                        }
                        catch
                        {
                            //如果没有超时
                            if (!timeOut)
                            {
                                connetctionStatus = true;
                                ShowMessageHelper.ShowBoxMsg(string.Format("{0}连接失败,数据库不存在或用户名、密码错误,请检查数据库配置!",strMessage));
                            }
                        }
                    },
                    delegate
                    {
                        //如果没有链接上
                        if (!connetctionStatus)
                        {
                            timeOut = true;
                            ShowMessageHelper.ShowBoxMsg(string.Format("{0}连接超时,请检查数据库配置!", strMessage));

                        }
                    });
            timeout.Wait(5000);
            return istrue;
        }
        #endregion






    }
}
