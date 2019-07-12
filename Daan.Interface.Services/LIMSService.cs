using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.Interface.BLL;
using System.IO;
using Daan.Interface.Entity;
using Daan.Interface.Util;
using System.Collections;
using System.Configuration;
using System.Xml;
using System.Threading;

namespace Daan.Interface.Services
{
    public partial class LIMSService : Form
    {
        //保存日志文件夹
        private static string LogFilePath = Application.StartupPath + "\\Log\\";
        //定义时间控件 获取结果
        private System.Timers.Timer timer = new System.Timers.Timer();
        //定义时间控件 发送订单
        private System.Timers.Timer sendtimer = new System.Timers.Timer();
        //上传系统日志时间控件 fenghp
        private System.Timers.Timer logtimer = new System.Timers.Timer();
        //默认配置文件
        private DAConfig config;
        //登录标识-GUID
        string SID = "";
        //admin 的用户信息，用于写获取结果日志
        DADictuser user = new DADictuser();

        CommonBLL commonbll = new CommonBLL();
        DAOutSpecimenBLL outspecimenbll = new DAOutSpecimenBLL();
        DATablelastdateBLL lastdatebll = new DATablelastdateBLL();
        DAErrorLogBLL errorlogbll = new DAErrorLogBLL();

        public LIMSService()
        {
            InitializeComponent();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            logtimer.Elapsed += new System.Timers.ElapsedEventHandler(logtimer_Elapsed);
            sendtimer.Elapsed += new System.Timers.ElapsedEventHandler(sendtimer_Elapsed);
            
            //打开程序则启动
            string isStart = ConfigurationManager.AppSettings["IsStart"];
            if (isStart == "1") { btnStart_Click(null, null); }
        }



        #region >>>> zhouy 1 间隔操作处理，上传 下载

        //服务处理
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DownResult();
        }

        delegate void ResultInvok();
        /// <summary>
        /// 下载结果
        /// </summary>
        void DownResult()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem((o) =>
            {
                //每次获取 重新更新一次
                WebServiceUtils.SetIsUpdate(config.Address);

                CoreHandle();
                GC.Collect();
            });

        }

        /// <summary>
        /// 核心处理
        /// </summary>
        private void CoreHandle()
        {
            try
            {


                if (timer.Enabled == false) { return; }

                //登录获取的SID
                string[] strlogin = commonbll.UserLogin(config);
                if (strlogin[0] == "0") { SetTB("登录失败:" + strlogin[1]); return; }
                SID = strlogin[1];

                DateTime _lasttime = DateTime.MinValue;

                DateTime barcodelasttime = lastdatebll.SelectyDATablelastdateInfoByTableName(DefaultConfig.EXBARCODE);

                if (barcodelasttime == DateTime.MinValue) { SetTB("获取反审核查询时间失败！默认当前时间"); barcodelasttime = DateTime.Now; }

                //获取反审核的条码号
                string[] BarCodeArry = GetExceptionBarcodes(barcodelasttime);
                List<string> ExBarCodeList = new List<string>();
                if (BarCodeArry[0] == "0") { SetTB("获取反审核条码异常：" + BarCodeArry[1]); }
                else
                {
                    if (BarCodeArry[1].Contains(','))
                    {
                        ExBarCodeList = BarCodeArry[1].Split(',').ToList<string>();

                        try { _lasttime = Convert.ToDateTime(ExBarCodeList[ExBarCodeList.Count - 1]); }
                        catch (Exception e) { SetTB("获取反审核条码时间格式不正确：" + e.Message); }

                        ExBarCodeList.RemoveAt(ExBarCodeList.Count - 1);
                    }

                }

                bool ExBarcode = TransactBarcode(ExBarCodeList, true);

                //反审核条码全部重新回去成功后更改时间
                if (ExBarcode && _lasttime != DateTime.MinValue) { UpdateLastDate(_lasttime); }

                //获取需要获取结果的条码号
                List<string> BarCodeList = outspecimenbll.SelectRequestCodeByGetResult();

                TransactBarcode(BarCodeList, false);

                if (ExBarCodeList.Count == 0 && BarCodeList.Count == 0) { SetTB("本次没有需要获取结果的条码......\r\n"); return; }

                SetTB("本次获取结果完毕，等待下次获取......\r\n");
            }
            catch (Exception ex)
            {

                SetTB("下载结果异常:" + ex.Message);
            }

        }

        /// <summary>
        /// 处理条码
        /// </summary>
        /// <param name="BarCodeList">条码列表</param>
        /// <param name="flag">是否反审核条码</param>
        private bool TransactBarcode(List<string> BarCodeList, bool flag)
        {
            bool b = true;
            for (int i = 0; i < BarCodeList.Count; i++)
            {
                if (timer.Enabled == false) { break; }
                //测试
                //if (BarCodeList[i] != "333336666600" && BarCodeList[i] != "666666666600")
                //{
                //    continue;
                //}
                if (flag)
                {
                    Hashtable hs = new Hashtable();
                    hs.Add("txtRequestcode", BarCodeList[i]);
                    List<DAOutspecimen> list = new DAOutSpecimenBLL().GetOutspecimenList(hs);
                    if (list.Count > 0 && list[0].Status == "5" && list[0].Status == "6" && list[0].Status == "7")
                    {
                        SetTB("条码号[" + BarCodeList[i] + "]:已经传输完毕不更新结果...");
                        continue;
                    }
                }

                //消息集合
                List<string> msglist = new List<string>();

                int status = commonbll.TreatmentResultReport(SID, msglist, BarCodeList[i], config.Model);

                string msg = string.Empty;
                for (int j = 0; j < msglist.Count; j++) { msg += msglist[j] + ","; }

                if (status == 0)
                {
                    SetTB("条码号[" + BarCodeList[i] + "]:" + msg.TrimEnd(','));
                    if (msg.Contains("MSG0006"))
                    {
                        SetTB("条码号[" + BarCodeList[i] + "]:正在重新获取...");
                        string[] strlogin = commonbll.UserLogin(config);
                        if (strlogin[0] == "0") { SetTB("登录失败:" + strlogin[1]); }
                        else { SID = strlogin[1]; }
                        i--;
                    }
                    ResultLog(false, BarCodeList[i], msg);
                    continue;
                }

                SetTB(string.Format("条码号[{0}]:获取结果完毕[{1}]", BarCodeList[i], status == 4 ? "完整获取" : "部分获取"));
                ResultLog(true, BarCodeList[i], status == 4 ? "完整获取" : "部分获取 " + msg);

                if (status < 4) { b = false; }
            }
            return b;
        }

        /// <summary>
        /// 更新最后获取反审核条码时间
        /// </summary>
        /// <param name="_lasttime"></param>
        private void UpdateLastDate(DateTime _lasttime)
        {
            DATablelastdate lastdateinfo = new DATablelastdate();
            lastdateinfo.Tablename = DefaultConfig.EXBARCODE;
            lastdateinfo.Lastdate = _lasttime;
            try
            {
                bool b = new DATablelastdateBLL().SaveDATablelastdateInfo(lastdateinfo);
                if (!b) { SetTB("反审核条码最后时间保存失败,请重试！"); return; }

            }
            catch (Exception ex)
            {
                SetTB("反审核条码最后时间保存失败：" + ex.Message);
            }
        }

        #region >>>> zhouy 1.3 WebService获取反审核的条码号

        /// <summary>
        /// 获取反审核的条码号
        /// </summary>
        /// <param name="LastDate"></param>
        /// <returns></returns>
        private string[] GetExceptionBarcodes(DateTime LastDate)
        {
            string[] objExceptionBarcode = new string[] { SID, LastDate.ToString("G") };
            return WebServiceUtils.ExecuteMethod("GetExceptionBarcodes", objExceptionBarcode).Split('|');
        }
        #endregion


        #endregion

        #region >>>> zhouy 2 开始服务 And 停止服务

        //开始服务
        private void btnStart_Click(object sender, EventArgs e)
        {
            decimal cid = DefaultConfig.DACONFIGID;
            decimal.TryParse(ConfigurationManager.AppSettings["DaConfigID"], out cid);
            //读取默认配置
            config = new DAConfigBLL().SelectyDAConfigInfo(cid);
            if (config == null) { SetTB("没有维护配置文件！"); return; }

            //设置间隔时间
            timer.Interval = config.IntervalToDouble;

            double dInterval = 0;
            //获取配置时间间隔,设置logtimer间隔时间 fenghp
            string sss = ConfigurationManager.AppSettings["ErrorLogInterval"].ToString();
            double.TryParse(ConfigurationManager.AppSettings["ErrorLogInterval"].ToString(), out dInterval);

            logtimer.Interval = dInterval * 1000 * 60;
            sendtimer.Interval = dInterval * 1000 * 60;

            //查询admin信息
            user.Usercode = "admin";
            user = new DADictuserBLL().GetDADictuserInfoByUserCode(user);

            //开启
            timer.Start();
            logtimer.Start();
            SetTB("服务开启!");

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnStop.Focus();

            //更新webservice
            WebServiceUtils.SetIsUpdate(config.Address);

            DownResult();

            // UploadLog();

            //自动上传订单
            string issend = ConfigurationManager.AppSettings["IsSend"];
            if (issend == "1")
            {
                sendtimer.Start();
                sendOrders();
            }


        }

        //停止服务
        private void btnStop_Click(object sender, EventArgs e)
        {

            SetTB("服务停止!");

            //暂停
            timer.Stop();
            logtimer.Stop();
            sendtimer.Stop();

            GC.Collect();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnStart.Focus();
        }

        #endregion

        #region >>>> zhouy 3 弹出【参数设置】框 And 弹出【数据库配置】框

        //参数设置
        private void btnParSet_Click(object sender, EventArgs e)
        {
            bool b = true;
            LIMSParameterSetting parset = new LIMSParameterSetting(ref b);
            if (b) { parset.ShowDialog(this); }
        }

        //数据库配置
        private void btnDataConfig_Click(object sender, EventArgs e)
        {
            LIMSDatabaseConfiguration dataconfig = new LIMSDatabaseConfiguration();
            dataconfig.ShowDialog(this);
        }

        #endregion

        #region >>>> zhouy 4 委托  写日志并输出消息  获取结果写日志

        private delegate void SetTBMethodInvok(string value);
        private void SetTB(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetTBMethodInvok(SetTB), value);
            }
            else
            {
                if (timer.Enabled == false) { return; }

                value = DateTime.Now.ToString() + ":" + value;
                rtbxMSG.Text += value + "\n";
                CreateErrorLog(value);

                if (rtbxMSG.Text.Length > 100000)
                {
                    string subs = rtbxMSG.Text.Substring(500);
                    rtbxMSG.Text = subs.Substring(subs.IndexOf("\n") + 1);
                }

                //有滚动条时 ，定位到textbox最下方
                this.rtbxMSG.SelectionStart = this.rtbxMSG.Text.Length;
                this.rtbxMSG.ScrollToCaret();
            }

        }

        // 记录日志至文本文件，每天保存一个日志文件   
        public static void CreateErrorLog(string message)
        {
            if (!Directory.Exists(LogFilePath))//若文件夹不存在则新建文件夹
            {
                Directory.CreateDirectory(LogFilePath); //新建文件夹
            }
            string FileName = LogFilePath + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StreamWriter sr = null;
            sr = File.Exists(FileName) ? File.AppendText(FileName) : File.CreateText(FileName);
            sr.WriteLine(message);
            sr.Close();
        }

        /// <summary>
        /// 写获取结果日志
        /// </summary>
        /// <param name="b">是否获取成功</param>
        /// <param name="barcode">条码号</param>
        /// <param name="msg">消息</param>
        public void ResultLog(bool b, string barcode, string msg)
        {
            try
            {
                //插入节点信息
                DAOperationlog daoperationlog = new DAOperationlog();
                daoperationlog.Dictuserid = user.Dictuserid;
                daoperationlog.Usercode = user.Usercode;
                daoperationlog.Username = user.Username;
                daoperationlog.Usertype = "1";//医院用户
                daoperationlog.Optype = b ? "接收结果成功" : "接收结果失败";
                daoperationlog.Createdate = DateTime.Now;
                daoperationlog.Opcontent = "条码号：[" + barcode + "]：" + msg;
                daoperationlog.Requestcode = barcode;  //达安条码
                daoperationlog.Hospsampleid = string.Empty;  //医院条码 默认不写
                daoperationlog.Hospsamplenumber = string.Empty; //医院样本号 默认不写
                new DAOperationlogBLL().SaveDAOperationlog(daoperationlog);
            }
            catch (Exception ex)
            {
                SetTB("写结果日志异常：" + ex.Message);
            }
        }



        #endregion

        #region >>>> zhouy 5 关闭窗口，并且关闭之前先停止服务

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //窗体关闭前
        private void LIMSService_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!   
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                //取消"关闭窗口"事件          
                this.WindowState = FormWindowState.Minimized;
                //使关闭时窗口向右下角缩小的效果             
                notifyIcon1.Visible = true;
                this.Hide();
                return;
            }

            //使用托盘退出，不用此处代码
            //if (this.btnStop.Enabled) { ShowMessageHelper.ShowBoxMsg("请先点击 [停止服务] 再 [关闭] ！"); e.Cancel = true; return; }

            //SetTB("服务关闭!");
        }

        #endregion

        #region >>>> fenghp 系统日志上传处理
        void logtimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UploadLog();
        }

        private delegate void LogInvok();
        /// <summary>
        /// 上传日志
        /// </summary>
        private void UploadLog()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new LogInvok(UploadLog));
            }
            else
            {
                LogHandle();
                GC.Collect();
            }

        }

        /// <summary>
        /// 系统日志处理
        /// </summary>
        private void LogHandle()
        {
            try
            {
                Hashtable lastht = new Hashtable();
                lastht.Add("Tablename", DefaultConfig.ERRORLOG);
                DATablelastdate lastdate = new DATablelastdate();
                List<DATablelastdate> lstlastdate = lastdatebll.SelectyDATablelastdateInfo(lastht);
                if (lstlastdate.Count > 0)
                {
                    lastdate = lstlastdate[0];
                }
                //从da_tablelastdate表获取最后上传系统日志时间
                DateTime lastSendTime = new DateTime();//lastdatebll.SelectyDATablelastdateInfoByTableName("ErrorLog");
                if (lastdate != null)
                {
                    lastSendTime = Convert.ToDateTime(lastdate.Lastdate);
                }
                //获取未上传的系统日志，转换为XML文件
                Hashtable ht = new Hashtable();
                ht.Add("Createdate", lastSendTime.ToString());
                List<DAErrorlog> listlog = errorlogbll.SelectDAErrorlogbyDate(ht);
                if (listlog.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.TableName = "data_row";
                    dt.Columns.Add("CUSTOMERCODE");
                    dt.Columns.Add("SITECODE");
                    dt.Columns.Add("ERRORLOGID");
                    dt.Columns.Add("USERCODE");
                    dt.Columns.Add("USERNAME");
                    dt.Columns.Add("CREATEDATE");
                    dt.Columns.Add("OPCONTENT");
                    dt.Columns.Add("USERTYPE");
                    dt.Columns.Add("IPADDRESS");
                    dt.Columns.Add("MACHINENAME");

                    foreach (DAErrorlog errorlog in listlog)
                    {
                        DataRow dr = dt.NewRow();
                        dr["CUSTOMERCODE"] = config.Username;
                        dr["SITECODE"] = config.Sitecode;
                        dr["ERRORLOGID"] = errorlog.Errorlogid;
                        dr["USERCODE"] = errorlog.Usercode;
                        dr["USERNAME"] = errorlog.Username;
                        dr["CREATEDATE"] = errorlog.Createdate;
                        dr["OPCONTENT"] = errorlog.Opcontent;
                        dr["USERTYPE"] = errorlog.Usertype;
                        dr["IPADDRESS"] = errorlog.Ipaddress;
                        dr["MACHINENAME"] = errorlog.Machinename;
                        dt.Rows.Add(dr);

                    }
                    string strxml = XMLHelper.CDataToXml(dt);
                    //登录获取的SID
                    //  string[] strlogin = comonbll.UserLogin(config);
                    // if (strlogin[0] == "0") { SetTB("登录失败:" + strlogin[1]); return; }
                    // string SID = strlogin[1];
                    string[] obj = new string[] { SID, config.Username, StringToXML(strxml) };

                    //调用webwervices方法上传系统日志
                    string strQueryResult = WebServiceUtils.ExecuteMethod("SendErrLog", obj);
                    if (strQueryResult.Split('|')[0] == "1")
                    {
                        //更新da_tablelastdate表最后上传系统日志时间
                        if (lastSendTime != DateTime.MinValue)
                        {
                            lastdate.Lastdate = DateTime.Now;
                            lastdatebll.UpdateDATablelastdateInfo(lastdate);

                        }
                        else
                        {
                            DATablelastdate datablelastdate = new DATablelastdate();
                            datablelastdate.Createdate = DateTime.Now;
                            datablelastdate.Lastdate = DateTime.Now;
                            datablelastdate.Tablename = DefaultConfig.ERRORLOG;
                            datablelastdate.Remark = "创建日志表操作信息";
                            lastdatebll.InsertDATablelastdateInfo(datablelastdate);
                        }
                        // SetTB("系统日志传送成功!");
                    }
                    else
                    {
                        // SetTB("系统日志传送失败! " + strQueryResult.Split('|')[1]);
                    }
                }

            }
            catch
            {
                SetTB("系统日志传送出现异常!");
            }

        }
        //将结果在xml中关键字转义
        private string StringToXML(object str)
        {
            return str.ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos; ").Replace("\"", "&quot;").Replace("DocumentElement", "NewDataSet");
        }
        #endregion

        void sendtimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sendOrders();
        }

        private delegate void sendOrdersInvok();
        /// <summary>
        /// 上传订单
        /// </summary>
        private void sendOrders()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new sendOrdersInvok(sendOrders));
            }
            else
            {
                SendOrdersHandle();
                GC.Collect();
            }

        }

        /// <summary>
        /// 上传订单处理
        /// </summary>
        private void SendOrdersHandle()
        {
            try
            {
                DAOutSpecimenBLL bll = new DAOutSpecimenBLL();
                //获取需要获取结果的条码号
                List<DAOutspecimen> BarCodeList = bll.SelectRequestCodeBySendOrders();
                if (BarCodeList.Count == 0) { SetTB("没有订单需要上传"); return; }

                //获取对照表
                List<DATestmap> datestmap = new DATestmapBLL().GetDATestmapList(null);
                for (int i = 0; i < BarCodeList.Count; i++)
                {
                    DAOutspecimen outspec = BarCodeList[i];
                    string barcode = outspec.Requestcode;
                    try
                    {

                        Hashtable ht = new Hashtable();
                        ht.Add("Requestcode", barcode);
                        DataTable dt = outspecimenbll.GetOutspecimenTable(ht); //基本信息
                        dt.TableName = "data_row";

                        /* 发送模式：1 组合发送， 0 单项发送(默认)
                         * 组合发送： 发送订单表OutSpecimen的数据
                         * (DATESTCODES AS NaturalItem,CUSTOMERTESTNAMES AS NaturalItemDesc,CUSTOMERTESTCODES AS HospItemCode)
                         * 
                         * 单项发送： 发送结果表da_result中的明细数据,获取Customertestcode,customertestname,
                         * 并根据Customertestcode获取对照表的datestcode
                         */
                        #region >>>> zhouy 发送项目拼装

                        string cuscode = "", cusname = "", daancode = "";
                        DataTable dtTest;
                        if (config.Model == "1")
                        {
                            dtTest = new DAOutSpecimentestBLL().SelectSendGruopCodeByRequestCode(outspec.Requestcode); //组合
                        }
                        else
                        {
                            dtTest = new DAResultBLL().SelectSendTestCodeByRequestCode(outspec.Requestcode); //明细
                        }

                        foreach (DataRow dr in dtTest.Rows)
                        {
                            //没有达安代码，则对照表没有对应
                            if (dr["datestcode"] == null || dr["datestcode"].ToString() == "")
                            {
                                //没对项目跳出进行下一个条码
                                throw new Exception(string.Format("中的医院项目[{0}({1})]未对应好数据,请到项目对照表中对应好"
                                       , dr["customertestname"], dr["Customertestcode"]));
                            }

                            cuscode += dr["Customertestcode"] + ",";
                            cusname += dr["customertestname"] + ",";
                            daancode += dr["datestcode"] + ",";
                        }

                        dt.Rows[0]["HospItemCode"] = cuscode.TrimEnd(',');//医院项目代码
                        dt.Rows[0]["NaturalItemDesc"] = cusname.TrimEnd(',');//医院项目名称

                        dt.Rows[0]["NaturalItem"] = daancode.TrimEnd(',');//达安代码

                        #endregion

                        string[] obj = new string[2] { SID, StringToXML(DataToXml.ConvertDataTableToXML(dt)) };
            
                        string strQueryResult = WebServiceUtils.ExecuteMethod("SendRequestInfo", obj);  //调用webService

                        if (strQueryResult.Contains("无法连接")) { throw new Exception("操作连接超时!" + strQueryResult); }
                        else if (strQueryResult.Contains("MSG0006"))
                        {
                            string[] strlogin = commonbll.UserLogin(config);
                            if (strlogin[0] == "0") { SetTB("登录失败:" + strlogin[1]); continue; }
                            else { SID = strlogin[1]; i--; }
                        }
                        else
                        {
                            #region >>>> zhouy  发送成功记录成功日志，发送失败记录错误日志
                            string msg = strQueryResult; //strQueryResult.TrimEnd(',').Split('|'); 2019.1.29该接口康源系统返回的格式和其他接口不同做特殊处理
                            //0 为正常发送了
                            if (msg.Contains("|0"))
                            {
                                DAOperationlog daoperationlog = new DAOperationlog();
                                daoperationlog.Dictuserid = user.Dictuserid;
                                daoperationlog.Usercode = user.Usercode;
                                daoperationlog.Username = user.Username;
                                daoperationlog.Usertype = "1";//系统自动上传  写成医院客户
                                daoperationlog.Optype = "订单已发送";
                                daoperationlog.Createdate = DateTime.Now;
                                daoperationlog.Opcontent = "发送订单,订单号：" + outspec.Requestcode;
                                daoperationlog.Requestcode = outspec.Requestcode;  //达安条码
                                daoperationlog.Hospsampleid = outspec.Hospsampleid;  //医院条码
                                daoperationlog.Hospsamplenumber = outspec.Hospsamplenumber; //医院样本号
                                if (new DAOperationlogBLL().SaveDAOperationlog(daoperationlog) == true)
                                {
                                    Hashtable htstatus = new Hashtable();
                                    htstatus.Add("Outspecimenid", outspec.Outspecimenid.ToString());
                                    htstatus.Add("status", "2");//已发送 修改状态
                                    new DAOutSpecimenBLL().UpdateStatus(htstatus);
                                }
                                //记录成功的达安条码号
                                SetTB(string.Format("达安条码[{0}]:发送成功", outspec.Requestcode));
                            }
                            else
                            {
                                SetTB(string.Format("达安条码[{0}]:{1}", outspec.Requestcode, msg));

                                //记录失败的异常信息到日志表中
                                DAErrorlog error = new DAErrorlog();
                                error.Dictuserid = user.Dictuserid;
                                error.Createdate = DateTime.Now;
                                error.LastUpdateDate = DateTime.Now;
                                error.Opcontent = "订单发送异常信息: " + msg;
                                error.Usercode = user.Usercode;
                                error.Usertype = "1";
                                error.Username = user.Username;
                                error.Ipaddress = commonbll.GetHostIP();//获取本机IP地址
                                error.Machinename = commonbll.GetHostName();//获取本机机器名
                                new DAErrorLogBLL().SaveErrorLog(error);
                            }
                            #endregion

                        }
                    }
                    catch (Exception e) { SetTB(string.Format("达安条码[{0}]:{1}", barcode, e.Message)); }
                }
            }
            catch (Exception e)
            {
                SetTB("发送订单出现异常:" + e.Message);
            }

        }

        //添加双击托盘图标事件（双击显示窗口）
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.Focus();
        }
        //系统托盘右键退出事件，打开验证密码窗体，输入密码正确，关闭主窗体
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.btnStop.Enabled)
            {
                ShowMessageHelper.ShowBoxMsg("请先点击 [停止服务] 再 [关闭] ！");
                notifyIcon1_MouseDoubleClick(null, null);
                return;
            }

            //this.Close();
            Exit ex = new Exit(notifyIcon1);
            ex.ShowDialog();
        }

        private void 显示服务窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(null, null);
        }
    }
}
