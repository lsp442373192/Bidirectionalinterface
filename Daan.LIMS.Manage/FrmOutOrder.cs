using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Daan.Interface.BLL;
using Daan.Interface.Entity;
using Daan.Interface.Util;
using FastReport;
using Daan.Interface.Dao;
using System.Configuration;
using Org.BouncyCastle.Utilities;

namespace Daan.LIMS.Manage
{
    //委外订单
    public partial class FrmOutOrder : FrmBase
    {
        //表头加checkBox
        CheckBox HeaderCheckBox = null;
        CommonBLL common = new CommonBLL();

        public FrmOutOrder()
        {
            InitializeComponent(); //初始化

            dtpEndDate.MaxDate = dtpBeginDate.MaxDate = DateTime.Now; //设置结束默认时间
            dtpBeginDate.Value = DateTime.Now;  //设置开始默认时间

            #region  >>> 定义订单状态对照颜色信息
            label18.BackColor = Color.BurlyWood;
            label19.Text = "报告已出";

            label16.BackColor = Color.CadetBlue;
            label17.Text = "部分报告";

            label13.BackColor = Color.PowderBlue;
            label14.Text = "已发送";
            label18.Text = label16.Text = label13.Text = "    ";


            #endregion


            if (!this.DesignMode)
            {
                //初始化CheckBox
                HeaderCheckBox = new CheckBox();
                HeaderCheckBox.Size = new Size(15, 15);
                this.dgvReport.Controls.Add(HeaderCheckBox);

                HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                dgvReport.CurrentCellDirtyStateChanged += new EventHandler(gvItemHospitalAndDaan_CurrentCellDirtyStateChanged);
                dgvReport.CellPainting += new DataGridViewCellPaintingEventHandler(gvItemHospitalAndDaan_CellPainting);
            }
        }

        #region   >>> 表头添加复选框 全选和全不选
        private void gvItemHospitalAndDaan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvReport.CurrentCell is DataGridViewCheckBoxCell)
                dgvReport.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void gvItemHospitalAndDaan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            Rectangle oRectangle = this.dgvReport.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point();
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;
            HeaderCheckBox.Location = oPoint;
        }


        /// <summary>
        /// 全选和反选
        /// </summary>
        /// <param name="HCheckBox"></param>
        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            foreach (DataGridViewRow Row in dgvReport.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value = HCheckBox.Checked;
            }
            dgvReport.RefreshEdit();
        }
        #endregion

        /// <summary>
        /// 新增 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //新增委外订单
            FrmOutOrdersDetails frm = new FrmOutOrdersDetails();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //退出当前窗体
            FrmOutOrder frmoutOrder = new FrmOutOrder();
            frmoutOrder.Dispose();
            this.Close();
        }


        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //当前GridView是否存在数据
            if (dgvReport.Rows.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有要删除的订单！");
                return;
            }
            //已经选择的记录   记录数为0 则不往下执行
            List<DAOutspecimen> SelectList = (bgSource.DataSource as BindingCollection<DAOutspecimen>).ToList<DAOutspecimen>().FindAll(c => c.IsSelect);
            if (SelectList.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有选择要删除的数据！");
                return;
            }
            if (MessageBox.Show("您确定要删除吗?", DefaultConfig.MSGTITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SortedList SQLlist = new SortedList(new MySort());
            StringBuilder sb = new StringBuilder();
            StringBuilder strb = new StringBuilder();
            StringBuilder bacode = new StringBuilder();
            for (int i = 0; i < SelectList.Count; i++)
            {
                //状态为已申请的可以删除，其它状态不能删除 (admin可以删除任何单据)
                if (SelectList[i].Status == "0" || (SystemConfig.UserInfo.UserCode == "admin"))
                {
                    sb.Append(SelectList[i].Outspecimenid); //获取主键信息
                    sb.Append(",");
                    strb.Append(SelectList[i].Requestcode); //获取达安条码信息
                    strb.Append(",");
                    //插入节点信息表
                    DAOperationlog daoperationlog = new DAOperationlog();
                    daoperationlog.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                    daoperationlog.Usercode = SystemConfig.UserInfo.UserCode;
                    daoperationlog.Username = SystemConfig.UserInfo.UserName;
                    daoperationlog.Usertype = SystemConfig.UserInfo.UserType.ToString();
                    daoperationlog.Optype = "删除订单信息";
                    daoperationlog.Createdate = DateTime.Now;
                    daoperationlog.Opcontent = "删除订单号：" + SelectList[i].Requestcode.ToString();
                    daoperationlog.Requestcode = SelectList[i].Requestcode.ToString();
                    daoperationlog.Hospsampleid = SelectList[i].Hospsampleid.ToString();
                    daoperationlog.Hospsamplenumber = SelectList[i].Hospsamplenumber;
                    SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAOperationlog" } }, daoperationlog);
                }
                else
                {

                    if (SelectList[i].Status != "0" && SystemConfig.UserInfo.UserCode == "admin")
                    {

                    }
                    else
                    {
                        bacode.Append(SelectList[i].Requestcode);
                        bacode.Append(",");
                    }

                }
            }
            if (strb.ToString() == "")
            {
                ShowMessageHelper.ShowBoxMsg("没有需要删除的数据！");
                return;
            }

            var library = new DAOutSpecimenBLL();
            //    SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAResult" } }, "'"+strb.ToString().TrimEnd(',').Replace(",","','")+"'");
            //    SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAOutspecimentest" } }, "'" + strb.ToString().TrimEnd(',').Replace(",", "','") + "'");
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAResult" } }, strb.ToString().TrimEnd(','));
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAOutspecimentest" } }, strb.ToString().TrimEnd(','));
            SQLlist.Add(new Hashtable() { { "DELETE", "Da.DeleteDAOutspecimen" } }, sb.ToString().TrimEnd(','));
            if (library.ExecuteSqlTran(SQLlist)) //删除3张表的订单相关信息
            {
                if (strb.ToString() != "")
                {
                    ShowMessageHelper.ShowBoxMsg(string.Format("{0}" + "条码成功删除", strb.ToString().TrimEnd(',')));
                }
                if (bacode.ToString() != "")
                {
                    ShowMessageHelper.ShowBoxMsg(string.Format("{0}" + "条码不能删除", bacode.ToString().TrimEnd(',')));
                }
                HeaderCheckBox.Checked = false;
                DataBind();

            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("数据删除失败！");
                HeaderCheckBox.Checked = false;
                DataBind();
            }


        }

        /// <summary>
        /// 发送订单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                #region >>>> zhouy 数据检查
                //当前GridView是否存在数据
                if (dgvReport.Rows.Count == 0)
                {
                    ShowMessageHelper.ShowBoxMsg("没有选择要发送的订单！");
                    return;
                }
                //选择要发送的订单条数
                List<DAOutspecimen> SelectList = (bgSource.DataSource as BindingCollection<DAOutspecimen>).ToList<DAOutspecimen>().FindAll(c => c.IsSelect);
                if (SelectList.Count == 0)
                {
                    ShowMessageHelper.ShowBoxMsg("没有选择要发送的订单！");
                    return;
                }
                if (SystemConfig.Config == null)
                {
                    ShowMessageHelper.ShowBoxMsg("获取系统配置失败,请重新登陆！");
                    return;
                }
                #endregion

                string strM = "";   //成功条码号
                string errorMessage = ""; //错误信息
                int num = 0; //记录符合发送状态的条码条数
                string bacode = "";


                //登录失败需要倒回上次一循环，不使用foreach
                for (int m = 0; m < SelectList.Count; m++)
                {
                    DAOutspecimen _outs = SelectList[m];

                    //记录发送失败或不能发送的条码信息
                    if (_outs.Status != "0" && _outs.Status != "2") { bacode += _outs.Requestcode + ","; continue; }

                    #region >>>> zhouy 发送订单
                    num++;
                    Hashtable ht = new Hashtable();
                    ht.Add("Requestcode", _outs.Requestcode);
                    DataTable dt = new DAOutSpecimenBLL().GetOutspecimenTable(ht); //基本信息
                    dt.TableName = "data_row";

                    /* 发送模式：1 组合发送， 0 单项发送
                     * 组合发送： 发送订单表OutSpecimen的数据
                     * (DATESTCODES AS NaturalItem,CUSTOMERTESTNAMES AS NaturalItemDesc,CUSTOMERTESTCODES AS HospItemCode)
                     * 
                     * 单项发送： 发送结果表da_result中的明细数据,获取Customertestcode,customertestname,
                     * 并根据Customertestcode获取对照表的datestcode
                     */
                    #region >>>> zhouy 发送项目拼装

                    string cuscode = "", cusname = "", daancode = "";
                    DataTable dtTest;
                    if (SystemConfig.Config.Model == "1")
                    {
                        dtTest = new DAOutSpecimentestBLL().SelectSendGruopCodeByRequestCode(_outs.Requestcode); //组合
                    }
                    else
                    {
                        dtTest = new DAResultBLL().SelectSendTestCodeByRequestCode(_outs.Requestcode); //明细
                    }

                    foreach (DataRow dr in dtTest.Rows)
                    {
                        //没有达安代码，则对照表没有对应
                        if (dr["datestcode"] == null || dr["datestcode"].ToString() == "")
                        {
                            errorMessage += string.Format("达安条码[{0}]中的医院项目[{1}({2})]未对应好数据,请到项目对照表中对应好\n"
                               , _outs.Requestcode, dr["customertestname"], dr["Customertestcode"]);
                        }

                        cuscode += dr["Customertestcode"] + ",";
                        cusname += dr["customertestname"] + ",";
                        daancode += dr["datestcode"] + ",";
                    }

                    dt.Rows[0]["HospItemCode"] = cuscode.TrimEnd(',');//医院项目代码
                    dt.Rows[0]["NaturalItemDesc"] = cusname.TrimEnd(',');//医院项目名称
                    if (daancode.TrimEnd(',') == "") //判断达安项目是否为空，也就是是否有对照
                    {
                        ShowMessageHelper.ShowBoxMsg("医院项目代码：" + cuscode.TrimEnd(',')+"没有和达安项目对照！");
                        return;
                    }
                    dt.Rows[0]["NaturalItem"] = daancode.TrimEnd(',');//达安代码

                    #endregion

                   // string str = StringToXML("<NewDataSet><data_row><Outspecimenid>31</Outspecimenid><RequestCode>440590096900</RequestCode><HospSampleid>1307261704</HospSampleid><HospSamplenumber>1307262509</HospSamplenumber><PatientNumber>01158055</PatientNumber><BedNumber /><SamplingDate>2013-07-26T16:33:07+08:00</SamplingDate><PatientName>王钊</PatientName><Sex>M</Sex><Age>7岁</Age><PatientTel /><SectionOffice>儿童保健科</SectionOffice><Doctor>程双喜</Doctor><DoctorTel /><Diagnostication /><Lmp /><Lmpdate /><BabyCount /><UnineVolumn /><Bodystyle /><Weight /><Height /><Bultrasonic /><Pregnant /><Programid>5</Programid><NaturalItem /><NaturalItemDesc>类胰岛素样生长因子测定</NaturalItemDesc><HospItemCode>09589</HospItemCode><Remark /><operateby>100191</operateby><userName>44170340</userName></data_row></NewDataSet>");
                    string[] obj = new string[2] { SystemConfig.UserInfo.SID, StringToXML(DataToXml.ConvertDataTableToXML(dt)) }; // StringToXML(DataToXml.ConvertDataTableToXML(dt)) 
                 
                    string strQueryResult = WebServiceUtils.ExecuteMethod("SendRequestInfo", obj);  //调用webService
                    //ShowMessageHelper.ShowBoxMsg("接口调试：" + strQueryResult);
                    #region >>>> zhouy  处理发送结果
                    if (strQueryResult.Contains("MSG0006")) //登陆超时
                    {
                        #region >>>> zhouy 登录超时，重新的登录
                        string strSideCode = SystemConfig.Config.Sitecode;
                        string strUrl = SystemConfig.Config.Address;//调用webservice地址
                        string username = SystemConfig.Config.Username == string.Empty ? "无" : SystemConfig.Config.Username; //登录用户名
                        string password = SystemConfig.Config.Password; //登录用户密码
                        //设置调用webservice登录方法的参数
                        string[] par = new string[] { strSideCode, username, password, SystemConfig.UserInfo.UserName };
                        //返回登录验证信息:1|SID,0|errorMsg
                        string[] loginMsg = WebServiceUtils.ExecuteMethod("Login", par).Split('|');
                        if (loginMsg[0] == "0") //登录失败     
                        {
                            ShowMessageHelper.ShowBoxMsg("登陆失败！" + loginMsg[1].ToString());
                            return;
                        }
                        else if (loginMsg[0] == "1")
                        {
                            SystemConfig.UserInfo.SID = loginMsg[1].ToString();
                            m--;//返回继续发送，不弹出消息 zhouy 
                            // ShowMessageHelper.ShowBoxMsg("发送条码[" + _outs.Requestcode + "]超时，请重新发送该条订单！");
                        }
                        #endregion
                    }
                    else if (strQueryResult.Contains("无法连接"))
                    {
                        ShowMessageHelper.ShowBoxMsg("操作连接超时！" + strQueryResult.ToString());
                        return;
                    }
                    //else if (strQueryResult.Contains("未上传任何达安代码！"))
                    //{
                    //    ShowMessageHelper.ShowBoxMsg("项目匹配有误：" + _outs.Requestcode +"条码"+ strQueryResult.ToString());
                    //    return;
                    //}
                    else
                    {
                        #region >>>> zhouy  发送成功记录成功日志，发送失败记录错误日志
                        string[] _messg = strQueryResult.TrimEnd(',').Split('|');
                        //0 为正常发送了
                        if (_messg[3] == "0")
                        {
                            DAOperationlog daoperationlog = new DAOperationlog();
                            daoperationlog.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                            daoperationlog.Usercode = SystemConfig.UserInfo.UserCode;
                            daoperationlog.Username = SystemConfig.UserInfo.UserName;
                            daoperationlog.Usertype = SystemConfig.UserInfo.UserType.ToString();
                            daoperationlog.Optype = "订单已发送";
                            daoperationlog.Createdate = DateTime.Now;
                            daoperationlog.Opcontent = "发送订单,订单号：" + _messg[0];
                            daoperationlog.Requestcode = _messg[0];  //达安条码
                            daoperationlog.Hospsampleid = _messg[1];  //医院条码
                            daoperationlog.Hospsamplenumber = _messg[2]; //医院样本号
                            if (new DAOperationlogBLL().SaveDAOperationlog(daoperationlog) == true)
                            {
                                Hashtable htstatus = new Hashtable();
                                htstatus.Add("Outspecimenid", _outs.Outspecimenid.ToString());
                                htstatus.Add("status", "2");//已发送 修改状态
                                new DAOutSpecimenBLL().UpdateStatus(htstatus);
                            }
                            strM += _messg[0] + ",";  //记录成功的达安条码号
                        }
                        else
                        {
                            errorMessage += string.Format("达安条码[{0}]:{1}\n", _messg[0], _messg[3]);
                            //记录失败的异常信息到日志表中
                            DAErrorlog error = new DAErrorlog();
                            error.Dictuserid = Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                            error.Createdate = DateTime.Now;
                            error.LastUpdateDate = DateTime.Now;
                            error.Opcontent = "订单发送异常信息: " + _messg[0];
                            error.Usercode = SystemConfig.UserInfo.UserCode;
                            error.Usertype = SystemConfig.UserInfo.UserType.ToString();
                            error.Username = SystemConfig.UserInfo.UserName;
                            error.Ipaddress = common.GetHostIP();//获取本机IP地址
                            error.Machinename = common.GetHostName();//获取本机机器名
                            new DAErrorLogBLL().SaveErrorLog(error);
                        }
                        #endregion
                    }
                    #endregion

                    #endregion

                }
                if (num == 0)  //记录符合发送状态的条码条数
                {
                    ShowMessageHelper.ShowBoxMsg(string.Format("达安条码[{0}]状态为报告已出或部分结果的条码不能发送！", bacode.TrimEnd(',')));
                    return;
                }
                if (bacode.ToString() != "")  //记录不能发送的条码号
                {
                    ShowMessageHelper.ShowBoxMsg(string.Format("达安条码[{0}]状态为报告已出或部分结果的条码不能发送！", bacode.TrimEnd(',')));
                }
                if (errorMessage != "")  //错误信息反馈
                {
                    ShowMessageHelper.ShowBoxMsg(errorMessage);
                }
                if (strM != "")
                {
                    ShowMessageHelper.ShowBoxMsg(string.Format("达安条码[{0}] 发送成功！", strM.TrimEnd(',')));
                    HeaderCheckBox.Checked = false;
                    DataBind();
                }
            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg(ex.Message);
            }
        }

       


        #region  >>>>  将结果在xml中关键字转义
        //将结果在xml中关键字转义
        private string StringToXML(object str)
        {
            return str.ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos; ").Replace("\"", "&quot;");
        }
        #endregion

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //当前GridView是否存在数据
            if (dgvReport.Rows.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有要打印的订单！");
                return;
            }
            //选择要打印的订单条数
            List<DAOutspecimen> SelectList = (bgSource.DataSource as BindingCollection<DAOutspecimen>).ToList<DAOutspecimen>().FindAll(c => c.IsSelect);
            if (SelectList.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有选择要打印的订单！");
                return;
            }
            SortedList SQLlist = new SortedList(new MySort());
            StringBuilder sb = new StringBuilder(); //医院条码号
            StringBuilder sbHospsamplenumber = new StringBuilder(); //医院样本号
            int num = 0;
            for (int i = 0; i < SelectList.Count; i++)
            {
                sb.Append(SelectList[i].Outspecimenid);  //主键ID
                sb.Append(",");
                num++; //标本数量

            }
            if (sb.ToString().TrimEnd(',').Length != 0)
            {
                //打印方法
                GetReport(sb.ToString().TrimEnd(','), num);
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("没有勾选需要打印的数据！");
            }

        }


        /// <summary>
        /// 打印方法
        /// </summary>
        /// <param name="Hospsample">医院条码</param>
        /// <param name="Hospsamplenumber">医院样本</param>
        /// <param name="count">条数</param>
        /// <returns></returns>
        public Report GetReport(string Outspecimenid, int count)
        {
            Report fReport = null;
            try
            {
                fReport = new Report();
                string reportpath = Application.StartupPath + "\\report\\HPVRep.frx"; //标本清单模板路径
                fReport.Load(@reportpath);
                DataTable dtUserName = new DataTable();
                dtUserName.TableName = "dtUserName";
                dtUserName.Columns.Add("dr", typeof(string));
                DataRow dr = dtUserName.NewRow();
                dr["dr"] = SystemConfig.UserInfo.UserName;
                dtUserName.Rows.Add(dr);
                fReport.RegisterData(dtUserName, "dtUserName"); //制单人
                if (SystemConfig.Config == null)
                {
                    ShowMessageHelper.ShowBoxMsg("获取系统配置失败,请重新登陆！");
                    return fReport;
                }
                DataTable dtTitle = new BaseService().selectDS("SelectDAConfig", SystemConfig.Config.DaConfigid).Tables[0];//取报告标题
                dtTitle.TableName = "dtTitle";
                fReport.RegisterData(dtTitle, "dtTitle"); //表头信息
                Hashtable ht = new Hashtable();
                ht.Add("Outspecimenid", Outspecimenid);
                DataTable dtCount = new BaseService().selectDS("Da.SelectDACountByHospsampleid", ht).Tables[0];//取标本数量
                dtCount.TableName = "dtCount";
                fReport.RegisterData(dtCount, "dtCount");//列表信息
                DataTable dtRepList = new BaseService().selectDS("Da.SelectDAOutspecimenByHospsampleid", ht).Tables[0];//取得列表
                if (dtRepList.Rows.Count > 0)
                {
                    for (int i = 0; i < dtRepList.Rows.Count; i++)
                    {
                        //转换列显示
                        if (dtRepList.Rows[i]["Sex"].ToString() == "F")
                        {
                            dtRepList.Rows[i]["Sex"] = "女";
                        }
                        else if (dtRepList.Rows[i]["Sex"].ToString() == "M")
                        {
                            dtRepList.Rows[i]["Sex"] = "男";
                        }
                        else
                        {
                            dtRepList.Rows[i]["Sex"] = "未知";
                        }
                        if (dtRepList.Rows[i]["Ageunit"].ToString() == "0")
                        {
                            dtRepList.Rows[i]["Ageunit"] = "岁";
                        }
                        else if (dtRepList.Rows[i]["Ageunit"].ToString() == "1")
                        {
                            dtRepList.Rows[i]["Ageunit"] = "月";
                        }
                        else if (dtRepList.Rows[i]["Ageunit"].ToString() == "2")
                        {
                            dtRepList.Rows[i]["Ageunit"] = "日";
                        }
                        else if (dtRepList.Rows[i]["Ageunit"].ToString() == "3")
                        {
                            dtRepList.Rows[i]["Ageunit"] = "小时";
                        }
                    }
                }
                dtRepList.TableName = "dtRepList";
                fReport.RegisterData(dtRepList, "dtRepList");//列表信息
                //fReport.Prepare(true);
                //fReport.PrintSettings.Printer =    "\\\\ROSS-PC\\HP LaserJet 1020"; //打印机信息 
                foreach (FastReport.ReportPage page in fReport.Pages)
                {
                    page.Landscape = false;
                }
                fReport.PrintSettings.ShowDialog = false;
                fReport.Print();
            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg(ex.Message);
            }
            return fReport;
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //开始时间是否大于结束时间
            if (this.dtpBeginDate.Value.Date > this.dtpEndDate.Value.Date) { ShowMessageHelper.ShowBoxMsg("结束时间应大于开始时间！"); return; }
            DataBind();
        }

        /// <summary>
        /// 查询绑定
        /// </summary>
        private void DataBind()
        {
            Hashtable ht = new Hashtable();
            ht.Add("dtpBeginDate", Convert.ToDateTime(this.dtpBeginDate.Value).ToString("yyyy-MM-dd")); //开始时间
            ht.Add("dtpEndDate", Convert.ToDateTime(this.dtpEndDate.Value.AddDays(1)).ToString("yyyy-MM-dd"));//结束时间
            ht.Add("Hospsampleid", this.txtHospsample.Text.Trim());//医院条码号
            ht.Add("Requestcode", this.txtSearchKey.Text.Trim());//达安条码号
            ht.Add("Patientname", this.txtName.Text.Trim());//姓名
            this.dgvReport.AutoGenerateColumns = false;
            //实现List排序,否则无法点击表头按列重新排序 
            BindingCollection<DAOutspecimen> list = new BindingCollection<DAOutspecimen>();
            foreach (DAOutspecimen vdalistests in new DAOutSpecimenBLL().GetOutspecimenList(ht))
            {
                list.Add(vdalistests);
            }
            if (list.Count > 0)
            {
                var daoutList = from da in list orderby da.Createdate descending select da;
                BindingCollection<DAOutspecimen> listback = new BindingCollection<DAOutspecimen>();
                foreach (DAOutspecimen vdalistests in daoutList)
                {
                    listback.Add(vdalistests);
                }
                this.bgSource.DataSource = listback;
            }
            else
            {
                this.bgSource.DataSource = list;
            }
            lblRecord.Text = string.Format("共 {0} 条记录", list.Count);

            dgvReport.ClearSelection();
            dgvReport.TabStop = false;
        }


        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;
            DataGridView view = (DataGridView)sender;
            //性别
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Sex") { e.Value = e.Value.ToString() == "M" ? "男" : (e.Value.ToString() == "F" ? "女" : (e.Value.ToString() == "U" ? "未知" : " ")); }
            //年龄单位
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Ageunit") { e.Value = e.Value.ToString() == "0" ? "岁" : (e.Value.ToString() == "1" ? "月" : (e.Value.ToString() == "2" ? "日" : (e.Value.ToString() == "3" ? "小时" : ""))); }
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Status")
            {
                if (e.Value.ToString() == "0")
                {
                    e.Value = "已申请";
                }
                else if (e.Value.ToString() == "1")
                {
                    e.Value = "已审核";
                }
                else if (e.Value.ToString() == "2")
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.PowderBlue;
                    dgvReport.Rows[e.RowIndex].DefaultCellStyle = d;
                    e.Value = "已发送";
                }
                else if (e.Value.ToString() == "3")
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.CadetBlue;
                    dgvReport.Rows[e.RowIndex].DefaultCellStyle = d;
                    e.Value = "部分报告";
                }
                else if (e.Value.ToString() == "4")
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.BurlyWood;
                    dgvReport.Rows[e.RowIndex].DefaultCellStyle = d;
                    e.Value = "报告已出";
                }
                else if (e.Value.ToString() == "5")
                {
                    e.Value = "传输完毕";
                }
                else if (e.Value.ToString() == "6")
                {
                    e.Value = "已打印";
                }
                else
                {
                    e.Value = "已生成图片";
                }
            }
        }
        //行头显示行号
        private void dgvReport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, dgvReport.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvReport.RowHeadersDefaultCellStyle.Font, rectangle, dgvReport.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void dgvReport_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                dgvReport.RowHeadersWidth = (dgvReport.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }

    }
}
