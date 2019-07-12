using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.Interface.Entity;
using Daan.Interface.BLL;
using Daan.Interface.Util;
using System.Configuration;

namespace Daan.Interface.Services
{
    public partial class LIMSParameterSetting : Form
    {
        decimal cid = DefaultConfig.DACONFIGID;

        public LIMSParameterSetting(ref bool b)
        {

            InitializeComponent();

            if (!decimal.TryParse(ConfigurationManager.AppSettings["DaConfigID"], out cid)) { cid = DefaultConfig.DACONFIGID; }
            InitData(ref b);

        }
        #region >>>> zhouy 页面加载...
        /// <summary>
        /// 页面加载...
        /// </summary>
        void InitData(ref bool b)
        {
            DAConfig config;
            try
            {
                config = new DAConfigBLL().SelectyDAConfigInfo(cid);
            }
            catch (Exception)
            {
                ShowMessageHelper.ShowBoxMsg("数据库获取失败，请先配置好数据库连接！");
                b = false;
                return;
            }


            if (config != null)
            {
                tbxHospName.Text = config.Hospname;
                tbxWebAddress.Text = config.Address;
                tbxUserName.Text = config.Username;
                tbxPassWrod.Text = config.Password;
                tbxInterval.Text = config.Interval;
                tbxSiteCode.Text = config.Sitecode;

                lblID.Text = config.DaConfigid.ToString();
            }

            BindGridDate();

        }
        #endregion

        #region >>>> zhouy 基本设置

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            /*验证界面输入
             *...... 
             */
            if (tbxHospName.Text.Trim() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("医院名称不能为空!");
                tbxHospName.Focus();
                return;
            }
            if (tbxWebAddress.Text.Trim() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("接口地址不能为空!");
                tbxWebAddress.Focus();
                return;
            }
            if (tbxUserName.Text.Trim() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("接口用户名不能为空!");
                tbxUserName.Focus();
                return;
            }
            if (tbxPassWrod.Text.Trim() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("接口密码不能为空!");
                tbxPassWrod.Focus();
                return;
            }
            if (tbxInterval.Text.Trim() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("接收时间间隔不能为空!并且间隔范围为[30-1440]!");
                tbxInterval.Focus();
                return;
            }
            if (tbxSiteCode.Text.Trim() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("分点代码不能为空!");
                tbxSiteCode.Focus();
                return;
            }

            if (Convert.ToDouble(tbxInterval.Text.Trim()) < 30 || Convert.ToDouble(tbxInterval.Text.Trim()) > 1440)
            {
                ShowMessageHelper.ShowBoxMsg("接收时间间隔范围为[30-1440]!");
                tbxInterval.Focus();
                return;
            }

            DAConfig config = new DAConfig();
            config.Hospname = tbxHospName.Text;
            config.Address = tbxWebAddress.Text;
            config.Username = tbxUserName.Text;
            config.Password = tbxPassWrod.Text;
            config.Interval = tbxInterval.Text;
            config.Sitecode = tbxSiteCode.Text;
            config.DaConfigid = lblID.Text == string.Empty ? cid : Convert.ToDecimal(lblID.Text);
            try
            {
                bool b = new DAConfigBLL().SaveDAConfigInfo(config);
                if (!b) { ShowBox("保存失败,请重试！"); return; }
                ShowBox("保存成功！");
            }
            catch (Exception ex)
            {
                ShowBox("保存失败：" + ex.Message);
            }
        }

        //测试
        private void btnTest_Click(object sender, EventArgs e)
        {
            string sitecode = "gz";//tbxSiteCode.Text.ToString();//分点代码
            string strUrl = tbxWebAddress.Text.ToString();//"http://ky.daanlab.com:8000/NIP/webservice/lisService"; //tbxWebAddress.Text.ToString();//调用webservice地址
            string username =  tbxUserName.Text.ToString(); //登录用户名
            string password =  tbxPassWrod.Text.ToString(); //登录用户密码


            WebServiceUtils.SetIsUpdate(strUrl);

            //设置调用webservice登录方法的参数
            string[] par = new string[] { sitecode, username, password, "医院LIS服务" };

            //返回登录验证信息:1|SID,0|errorMsg
            string[] loginMsg = WebServiceUtils.ExecuteMethod("Login", par).Split('|');

            if (loginMsg[0] == "0") //登录失败     
            {
                ShowMessageHelper.ShowBoxMsg("连接失败!" + loginMsg[1].ToString());
                return;
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("连接成功!");
            }

        }
        private void tbxInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }
        #endregion

        #region >>>> zhouy 接收时间设置

        //关闭
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存
        private void btnSave2_Click(object sender, EventArgs e)
        {
            tbxTableName.Text = tbxTableName.Text.Trim();

            if (tbxTableName.Text != DefaultConfig.ERRORLOG && tbxTableName.Text != DefaultConfig.EXBARCODE)
            {
                ShowBox(string.Format("只能保存表名为[{0}] [{1}]的数据！", DefaultConfig.ERRORLOG, DefaultConfig.EXBARCODE)); return;
            }
            if (dtpLastDate.DateTime == DateTime.MinValue)
            {
                ShowBox("最后操作时间不能为空"); return;
            }
            if (dtpLastDate.DateTime > DateTime.Now)
            {
                ShowBox("最后操作时间不能大于当前时间"); return;
            }

            DATablelastdate lastdateinfo = new DATablelastdate();
            lastdateinfo.Tablename = tbxTableName.Text;
            lastdateinfo.Remark = tbxRemark.Text.Trim();
            lastdateinfo.Lastdate = dtpLastDate.DateTime;

            try
            {
                bool b = new DATablelastdateBLL().SaveDATablelastdateInfo(lastdateinfo);
                if (!b) { ShowBox("保存失败,请重试！"); return; }

                BindGridDate();
                ShowBox("保存成功！");

            }
            catch (Exception ex)
            {
                ShowBox("保存失败：" + ex.Message);
            }
        }

        //单击绑定数据
        private void gridLastDate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgsrc = this.gridLastDate.SelectedRows;
            if (dgsrc.Count == 0) { return; }

            DATablelastdate lastdateinfo = dgsrc[0].DataBoundItem as DATablelastdate;

            BindRowData(lastdateinfo);
        }

        //刷新数据
        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            BindGridDate();
        }

        #endregion

        #region >>>> zhouy 页面方法

        /// <summary>
        /// 绑定最后接收时间的GridView
        /// </summary>
        private void BindGridDate()
        {
            //设置不自动生成列
            gridLastDate.AutoGenerateColumns = false;

            DATablelastdateBLL tablelastdatebll = new DATablelastdateBLL();
            List<DATablelastdate> list = tablelastdatebll.SelectyDATablelastdateInfo();

            if (list.Count == 0) { return; }
            gridLastDate.DataSource = list;
            //默认绑定第一行数据
            BindRowData(list[0]);
        }

        /// <summary>
        /// 绑定对象数据到控件
        /// </summary>
        /// <param name="lastdateinfo"></param>
        private void BindRowData(DATablelastdate lastdateinfo)
        {
            if (lastdateinfo == null) { return; }
            tbxRemark.Text = lastdateinfo.Remark;
            tbxTableName.Text = lastdateinfo.Tablename;
            if (lastdateinfo.Lastdate != null)
            {
                if (lastdateinfo.Lastdate == DateTime.MinValue)
                {
                    lastdateinfo.Lastdate = DateTime.Now;
                }
                dtpLastDate.DateTime = lastdateinfo.Lastdate;
            }

        }

        /// <summary>
        /// 弹出消息
        /// </summary>
        /// <param name="msg"></param>
        void ShowBox(string msg)
        {
            ShowMessageHelper.ShowBoxMsg(msg);
        }



        #endregion










    }
}
