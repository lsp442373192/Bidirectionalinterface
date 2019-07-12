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
using Daan.Interface.Dao;
using System.Text.RegularExpressions;
using System.Configuration;

namespace Daan.LIMS.Manage
{
    //新增委外订单
    public partial class FrmOutOrdersDetails : FrmBase
    {
        DADicttestitemBLL testitemBll = new DADicttestitemBLL();
        DAOutSpecimenBLL outspecimenbll = new DAOutSpecimenBLL();
        List<DADicttestitem> DaTestList;
        List<DATestmap> DaTestMap;

        //表头加checkBox
        CheckBox HeaderCheckBox = null;
        CheckBox DaHeaderCheckBox = null;
        CommonBLL common = new CommonBLL();

        public FrmOutOrdersDetails()
        {
            InitializeComponent(); //初始化
            dtpEndDate.MaxDate = dtpBeginDate.MaxDate = DateTime.Now; //设置结束默认时间
            dtpBeginDate.Value = DateTime.Now; //设置开始默认时间
            BindDrop();  //绑定下拉框
            if (!this.DesignMode)
            {
                //初始化CheckBox
                HeaderCheckBox = new CheckBox();
                HeaderCheckBox.Size = new Size(15, 15);
                this.gvList.Controls.Add(HeaderCheckBox);

                HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                gvList.CurrentCellDirtyStateChanged += new EventHandler(gvItemHospitalAndDaan_CurrentCellDirtyStateChanged);
                gvList.CellPainting += new DataGridViewCellPaintingEventHandler(gvItemHospitalAndDaan_CellPainting);

                //初始化CheckBox
                DaHeaderCheckBox = new CheckBox();
                DaHeaderCheckBox.Size = new Size(15, 15);
                this.gvDaLis.Controls.Add(DaHeaderCheckBox);

                DaHeaderCheckBox.KeyUp += new KeyEventHandler(DaHeaderCheckBox_KeyUp);
                DaHeaderCheckBox.MouseClick += new MouseEventHandler(DaHeaderCheckBox_MouseClick);
                gvDaLis.CurrentCellDirtyStateChanged += new EventHandler(gvDaLis_CurrentCellDirtyStateChanged);
                gvDaLis.CellPainting += new DataGridViewCellPaintingEventHandler(gvDaLis_CellPainting);
            }
            //获取所有项目列表            
            DaTestList = testitemBll.SelectDADicttestitem(null);
            DaTestMap = new DATestmapBLL().GetDATestmapList(null);
        }

        /// <summary>绑定下拉框
        /// </summary>
        public void BindDrop()
        {
            DataTable dtType = new DataTable();
            dtType.Columns.Add("Value");
            dtType.Columns.Add("Name");
            DataRow drType;

            drType = dtType.NewRow();
            drType[0] = "BBAH00010130";
            drType[1] = "液基细胞学检测(LCT)";
            dtType.Rows.Add(drType);


            drType = dtType.NewRow();
            drType[0] = "BBAF00010132";
            drType[1] = "脱落细胞学检查与诊断";
            dtType.Rows.Add(drType);


            drType = dtType.NewRow();
            drType[0] = "2";
            drType[1] = "已发送";
            dtType.Rows.Add(drType);

            drType = dtType.NewRow();
            drType[0] = "3";
            drType[1] = "部分报告";
            dtType.Rows.Add(drType);

            drType = dtType.NewRow();
            drType[0] = "4";
            drType[1] = "报告已出";
            dtType.Rows.Add(drType);
            drType = dtType.NewRow();

            drType[0] = "5";
            drType[1] = "传输完毕";
            dtType.Rows.Add(drType);

            //cbbReportStatus.DataSource = dtType;
            //cbbReportStatus.DisplayMember = "Name";
            //cbbReportStatus.ValueMember = "Value";
            //cbbReportStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        #region     >>>  表头添加复选框 全选和全不选

        private void gvItemHospitalAndDaan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvList.CurrentCell is DataGridViewCheckBoxCell)
                gvList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        void gvDaLis_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvDaLis.CurrentCell is DataGridViewCheckBoxCell)
                gvDaLis.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender, gvList);
        }

        void DaHeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                DaHeaderCheckBoxClick((CheckBox)sender, gvDaLis);
        }

        void DaHeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            DaHeaderCheckBoxClick((CheckBox)sender, gvDaLis);
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender, gvList);
        }

        private void gvItemHospitalAndDaan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }
        void gvDaLis_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetDaHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            Rectangle oRectangle = this.gvList.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point();
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;
            HeaderCheckBox.Location = oPoint;
        }
        private void ResetDaHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            Rectangle oRectangle = this.gvDaLis.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point();
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;
            DaHeaderCheckBox.Location = oPoint;
        }


        /// <summary>
        /// 全选和反选
        /// </summary>
        /// <param name="HCheckBox"></param>
        private void HeaderCheckBoxClick(CheckBox HCheckBox, DataGridView gv)
        {
            foreach (DataGridViewRow Row in gv.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value = HCheckBox.Checked;
                //if ((bool)((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).EditedFormattedValue)
                //{
                //    ((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value = false;
                //}
                //else
                //{
                //    ((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value = true;
                //}
            }
            gv.RefreshEdit();
        }
        /// <summary>
        /// 全选和反选
        /// </summary>
        /// <param name="HCheckBox"></param>
        private void DaHeaderCheckBoxClick(CheckBox HCheckBox, DataGridView gv)
        {
            foreach (DataGridViewRow Row in gv.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["IsSelect"]).Value = HCheckBox.Checked;
            }
            gv.RefreshEdit();
        }

        #endregion

        //关闭
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 扫描医院条码 显示匹配信息
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //是否回车  
            if (e.KeyChar != (char)Keys.Enter) return;

            string cusbarcode = string.Empty;
            if (this.dtpBeginDate.Value.Date > this.dtpEndDate.Value.Date) { ShowMessageHelper.ShowBoxMsg("结束时间应大于开始时间！"); return; }
            cusbarcode = this.txtBarcode.Text.Trim();
            if (cusbarcode == "") { ShowMessageHelper.ShowBoxMsg("医院条码或样本号不能为空！"); return; }
            this.txtBarcode.Text = string.Empty;
            Hashtable ht = new Hashtable();
            if (chxHosNumer.Checked == false)
            {
                ht.Add("Hospsampleid", cusbarcode);
            }
            else
            {
                ht.Add("dtpBeginDate", Convert.ToDateTime(this.dtpBeginDate.Value).ToString("yyyy-MM-dd"));
                ht.Add("dtpEndDate", Convert.ToDateTime(this.dtpEndDate.Value.AddDays(+1)).ToString("yyyy-MM-dd"));
                ht.Add("Hospsamplenumber", cusbarcode);
            }

            //是否输入条码值
            // if (message == "") { return; }

            //绑定医院条码相关信息
            //实现List排序,否则无法点击表头按列重新排序 fenghp
            BindingCollection<VDaLisrequest> list = new BindingCollection<VDaLisrequest>();

            foreach (VDaLisrequest lst in new VDALisrequestBLL().GetVDaLisrequestList(ht)) { list.Add(lst); }

            if (list.Count == 0) { ShowMessageHelper.ShowBoxMsg("无医院条码或样本信息！"); return; }

            this.bgSource1.DataSource = list;

            VDaLisrequest vda = (VDaLisrequest)gvLisrequest.Rows[gvLisrequest.CurrentCell.RowIndex].DataBoundItem;

            BindRightData(vda);
        }

        private void BindRightData(VDaLisrequest vda)
        {
            //绑定医院项目信息
            //实现List排序,否则无法点击表头按列重新排序 fenghp
            BindingCollection<VDaLisrequesttest> list2 = new BindingCollection<VDaLisrequesttest>();

            Hashtable htCode = new Hashtable();
            htCode.Add("Hospsampleid", vda.Hospsampleid);
            List<VDaLisrequesttest> VtestList = new VDALisrequesttestBLL().GetVDaLisrequesttestList(htCode);



            //显示校验医院项目是否与达安项目匹配
            Hashtable htmap = new Hashtable();

            foreach (VDaLisrequesttest vdl in VtestList)
            {

                //解决病理常有两个项目一起做，LIS病理项目必须单独条码，所以扫描时需要去掉其中一个勾选，重复操作两次，等待解决
                //if (txtCode.Text.Trim() == "")
                //{
                //    vdl.IsSelect = cbIsSelect.Checked;
                //}
                //else if (txtCode.Text.Trim() == vdl.Testcode)
                //{
                //    vdl.IsSelect = true;
                //}
                //else
                //{
                //    vdl.IsSelect = false;
                //}

                vdl.IsSelect = cbIsSelect.Checked;

                //选择存在对应关系的序列值
                var result = (from a in DaTestMap
                              where a.Customertestcode == vdl.Testcode
                              group a by new { a.Datestname, a.Datestcode } into g
                              select new
                              {
                                  g.Key.Datestname,
                                  g.Key.Datestcode,

                              }).ToArray();
                string dacode = "", daname = "";
                //一对多则 拼接多个项目
                foreach (var item in result)
                {
                    dacode += item.Datestcode.Trim() + ",";
                    daname += item.Datestname.Trim() + ",";
                }
                vdl.Datestcode = dacode.TrimEnd(',');
                vdl.Datestname = daname.TrimEnd(',');

                #region >>>> zhouy  按照医学专业组过滤标本类型
                if (result.Length > 0)
                {
                    string strtype = "";

                    var type = (from a in DaTestList
                                where a.Datestcode.Trim() == result[0].Datestcode.Trim()
                                group a by new { a.Testtype } into g
                                select new { g.Key.Testtype }).ToArray();
                    if (type.Length == 0) { ShowMessageHelper.ShowBoxMsg(string.Format("请检查医院代码为[{0}]的项目对照！", vdl.Testcode)); return; }

                    strtype = type[0].Testtype;
                    //病理
                    if (radioButton2.Checked)
                    {
                        vdl.IsDelete = DefaultConfig.TestType_病理 != strtype;
                    }//微生物
                    else if (radioButton3.Checked)
                    {
                        vdl.IsDelete = DefaultConfig.TestType_微生物 != strtype;
                    }//糖筛
                    else if (radioButton4.Checked)
                    {
                        vdl.IsDelete = DefaultConfig.TestType_唐氏筛查 != strtype;
                    }//常规
                    else
                    {
                        vdl.IsDelete = DefaultConfig.TestType_病理 == strtype || DefaultConfig.TestType_微生物 == strtype || DefaultConfig.TestType_唐氏筛查 == strtype;
                    }


                }

                #endregion
            }
            List<VDaLisrequesttest> VtestList2 = VtestList.FindAll(c => !c.IsDelete);

            foreach (VDaLisrequesttest lst in VtestList2) { list2.Add(lst); }

            this.bgSource2.DataSource = list2;

            DaHeaderCheckBox.Checked = cbIsSelect.Checked;

            StringBuilder str = new StringBuilder();
            if (VtestList2.Count > 0)
            {
                str.Append("项目没有对照：");
                int num = 0;
                for (int i = 0; i < VtestList2.Count; i++)
                {
                    if (VtestList2[i].Datestcode == "" || VtestList2[i].Datestname == "")
                    {
                        str.Append("项目编码：" + VtestList2[i].Testcode + "[" + VtestList2[i].Testname + "],");
                        num++;
                    }
                }
                if (num > 0)
                {
                    //写项目匹配错误日志
                    this.lblMessage.Text = str.ToString().TrimEnd(',');
                    DAErrorlog eaerror = new DAErrorlog();
                    eaerror.Dictuserid = Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                    eaerror.Createdate = DateTime.Now;
                    eaerror.LastUpdateDate = DateTime.Now;
                    eaerror.Opcontent = this.lblMessage.Text;
                    eaerror.Usercode = SystemConfig.UserInfo.UserCode;
                    eaerror.Usertype = SystemConfig.UserInfo.UserType.ToString();
                    eaerror.Ipaddress = common.GetHostIP();//获取本机IP地址
                    eaerror.Machinename = common.GetHostName();//获取本机机器名
                    new DAErrorLogBLL().SaveErrorLog(eaerror);
                }
                else
                {
                    this.lblMessage.Text = "";
                    this.txtDaanBarcode.Focus();
                }

            }

            gvDaLis.ClearSelection();
            gvDaLis.TabStop = false;
        }

        // 扫描达安条码 插入订单
        private void txtDaanBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //是否回车键
            if (e.KeyChar != (char)Keys.Enter) { return; }
            string barcode = this.txtDaanBarcode.Text.Trim();
            this.txtDaanBarcode.Text = string.Empty;
            if (barcode == "") { ShowMessageHelper.ShowBoxMsg("达安条码不能为空！"); return; }
            Regex r = new Regex(@"^\d*00$|\:");  //正则12位数字尾数必须为0
            //达安条码为12位
            if (barcode.Length != 12) { ShowMessageHelper.ShowBoxMsg("请核对达安条码为12位数字！"); return; }
            //达安条码为数字

            if (!r.IsMatch(barcode)) { ShowMessageHelper.ShowBoxMsg("请核对达安条码后两位为0的12位数字！"); return; }


            if (gvLisrequest.RowCount == 0) { ShowMessageHelper.ShowBoxMsg("无医院相关信息！"); return; }

            BindingSource TestData = gvDaLis.DataSource as BindingSource;

            if (TestData.Count == 0) { ShowMessageHelper.ShowBoxMsg("没有项目,不能添加！"); return; }

            try
            {
                #region >>>> zhouy  添加过滤
                //选中的当前行
                VDaLisrequest vda = (VDaLisrequest)gvLisrequest.Rows[gvLisrequest.CurrentCell.RowIndex].DataBoundItem;
                //是否存在相同的达安条码
                List<DAOutspecimen> daoutlist = outspecimenbll.GetOutspecimenList(new Hashtable() { { "txtRequestcode", barcode } });

                if (daoutlist.Count > 0) { ShowMessageHelper.ShowBoxMsg("已存在相同的达安条码！"); return; }


                #endregion

                #region  >>>插入订单主表、从表、结果表


                //项目列表 取列表项目，可见见即可得
                List<VDaLisrequesttest> VTestList = ((BindingCollection<VDaLisrequesttest>)TestData.List).ToList().FindAll(c => c.IsSelect);
                //项目是否匹配
                if (VTestList.FindAll(c => c.Datestcode == "").Count != 0) { ShowMessageHelper.ShowBoxMsg("项目不匹配，数据添加失败！"); return; }
                SortedList SQLlist = new SortedList(new MySort());

                #region >>>> zhouy 申请单
                DAOutspecimen daoutspecimen = new DAOutspecimen();
                int age = 0;
                if (vda.Age != null && vda.Age != "")
                {
                    if (!int.TryParse(vda.Age, out age)) { ShowMessageHelper.ShowBoxMsg("年龄格式不对！"); return; }
                    //如果年龄大于200岁
                    if (age > 200 && age < 0 && vda.Ageunit == "0") { ShowMessageHelper.ShowBoxMsg("年龄不能大于200岁！"); return; }
                }

                daoutspecimen.Age = age;
                daoutspecimen.Requestcode = barcode;
                daoutspecimen.Hospsampleid = vda.Hospsampleid;
                //  if (chxHosNumer.Checked) { 
                daoutspecimen.Hospsamplenumber = vda.Hospsamplenumber;
                //  }
                daoutspecimen.Customercode = SystemConfig.Config.Username;
                daoutspecimen.Remark = "";
                daoutspecimen.Patientnumber = vda.Patientnumber;
                daoutspecimen.Bednumber = vda.Bednumber;
                daoutspecimen.Samplingdate = vda.Samplingdate;
                daoutspecimen.Patientsource = vda.Patientnumber;
                daoutspecimen.Patientname = vda.Pname;
                daoutspecimen.Bodystyle = vda.Bodystyle;
                daoutspecimen.Sex = vda.Sex;
                daoutspecimen.Patienttel = vda.Patienttel;
                daoutspecimen.Location = vda.Sectionoffice;
                daoutspecimen.Doctor = vda.Doctor;
                daoutspecimen.Doctortel = vda.Doctortel;
                daoutspecimen.Birthday = vda.Birthday;
                daoutspecimen.Ageunit = vda.Ageunit;
                daoutspecimen.Diagnostication = vda.Diagnostication;
                daoutspecimen.Status = "0";
                daoutspecimen.Babycount = vda.Babycount;
                daoutspecimen.Lmp = vda.Lmp;
                daoutspecimen.Lmpdate = vda.Lmpdate;
                daoutspecimen.Uninevolumn = vda.Uninevolumn.ToString();
                daoutspecimen.Weight = vda.Weight.ToString();
                daoutspecimen.Height = vda.Height.ToString();
                daoutspecimen.Bultrasonic = vda.Bultrasonic;
                daoutspecimen.Pregnant = vda.Pregnant;
                daoutspecimen.Enterby = SystemConfig.UserInfo.UserCode;  //"";//录单人
                daoutspecimen.Enterbydate = DateTime.Now;
                daoutspecimen.Lastupdatedate1 = DateTime.Now;
                daoutspecimen.Createdate = DateTime.Now;
                daoutspecimen.Usertype = SystemConfig.UserInfo.UserType.ToString();
                #endregion

                //显示校验医院项目是否与达安项目匹配
                List<string> strCoustomercode = new List<string>(); //客户项目代码
                List<string> strCoustomername = new List<string>(); //客户项目名称
                List<string> strDatecode = new List<string>();//达安项目代码
                List<string> strDatename = new List<string>();//达安项目名称

                //查询系统中 医院中的所有项目
                Hashtable ht = new Hashtable();
                ht.Add("Hospsampleid", daoutspecimen.Hospsampleid);
                List<DAResult> _daresult = new DAResultBLL().GetDAResultList(ht);   //显示基本信息

                foreach (VDaLisrequesttest vdl in VTestList)
                {
                    string[] dacodearr = vdl.Datestcode.Split(',');

                    #region >>>> 申请单项目表

                    for (int i = 0; i < dacodearr.Length; i++)
                    {
                        string dacode = dacodearr[i].Trim();
                        string daname = "";
                        IEnumerable<string> IEdaname = from a in DaTestList
                                                       where a.Datestcode.Trim() == dacode
                                                       select a.Datestname;

                        if (IEdaname.Count() == 0)
                        {
                            //dacode = daname = "";
                            ShowMessageHelper.ShowBoxMsg(string.Format("达安项目中不存在编号为[{0}]的项目！", dacode)); return;
                        }
                        //  else { daname = IEdaname.First(); }



                        DAOutspecimentest daouttest = new DAOutspecimentest();
                        daouttest.Hospsampleid = vda.Hospsampleid;
                        //if (chxHosNumer.Checked) {
                        daouttest.Hospsamplenumber = vda.Hospsamplenumber;
                        //  }
                        daouttest.Requestcode = barcode;
                        daouttest.Customertestcode = vdl.Testcode;
                        daouttest.Customertestname = vdl.Testname;
                        daouttest.Datestcode = dacode;
                        daouttest.Datestname = daname;
                        daouttest.Createdate = DateTime.Now;
                        SQLlist.Add(new Hashtable() { { "INSERT", "Da.InsertDAOutspecimentest" } }, daouttest);


                    }

                    #endregion

                    //保存重复过的项目名称
                    string testnamelist = "";

                    #region >>>> 插入结果表

                    List<VDAListests> vdalisttest = new VDAListestsBLL().GetVDaListestsresultByCode(new Hashtable() { { "Testcode", vdl.Testcode } });

                    foreach (VDAListests item in vdalisttest)
                    {

                        DAResult daResult = new DAResult();
                        daResult.Requestcode = barcode;
                        daResult.Hospsampleid = vda.Hospsampleid;
                        //if (chxHosNumer.Checked) { 
                        daResult.Hospsamplenumber = vda.Hospsamplenumber;
                        //  }
                        daResult.Testtype = item.Testtype;
                        daResult.Customergroupcode = item.CustomerGroupCode;  //医院组合代码
                        daResult.Customergroupname = item.CustomerGroupName; //医院组合名称
                        daResult.Customertestcode = item.Subtestcode;//医院单项代码
                        daResult.Customertestname = item.Subtestname;//医院单项名称
                        //不存在单项名 取组合名 
                        if (item.Subtestcode == null || item.Subtestcode == "")
                        {
                            daResult.Customertestcode = item.CustomerGroupCode;//医院单项代码
                            daResult.Customertestname = item.CustomerGroupName;//医院单项名称
                        }

                        //如果已经插入系统的项目 再次扫描不允许插入
                        if (_daresult.FindAll(c => c.Customertestcode.Trim() == daResult.Customertestcode.Trim()).Count > 0)
                        {
                            testnamelist += daResult.Customertestname + ",";
                            continue;
                        }


                        daResult.Dagroupcode = string.Empty;
                        daResult.Dagroupname = string.Empty;
                        daResult.Datestcode = string.Empty;    //达安单项代码
                        daResult.Datestname = string.Empty;   //达安单项名称
                        SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAResult" } }, daResult);
                    }
                    #endregion

                    //同意医院条码有重复项目
                    if (testnamelist != "")
                    {
                        ShowMessageHelper.ShowBoxMsg(
                            string.Format("送检人【{0}】医院条码[{1}]的项目[{2}]已经添加到系统中,分开条码请先删除已添加的项目，或者去掉勾选",
                            daoutspecimen.Patientname, daoutspecimen.Hospsampleid, testnamelist.TrimEnd(',')));
                        return;
                    }
                    daoutspecimen.Customertestcodes += vdl.Testcode + ",";
                    daoutspecimen.Customertestnames += vdl.Testname + ",";
                    daoutspecimen.Datestcodes += vdl.Datestcode + ",";
                    daoutspecimen.Datestnames += vdl.Datestname + ",";
                }

                daoutspecimen.Customertestcodes = daoutspecimen.Customertestcodes.TrimEnd(',');
                daoutspecimen.Customertestnames = daoutspecimen.Customertestnames.TrimEnd(',');
                daoutspecimen.Datestcodes = daoutspecimen.Datestcodes.TrimEnd(',');
                daoutspecimen.Datestnames = daoutspecimen.Datestnames.TrimEnd(',');
                SQLlist.Add(new Hashtable() { { "INSERT", "Da.InsertDAOutspecimen" } }, daoutspecimen);

                #region >>>> 写操作日志

                DAOperationlog daoperationlog = new DAOperationlog();
                daoperationlog.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                daoperationlog.Usercode = SystemConfig.UserInfo.UserCode;
                daoperationlog.Username = SystemConfig.UserInfo.UserName;
                daoperationlog.Usertype = SystemConfig.UserInfo.UserType.ToString();
                daoperationlog.Optype = "新增订单信息";
                daoperationlog.Createdate = DateTime.Now;
                daoperationlog.Opcontent = "生成订单号：" + barcode;
                daoperationlog.Requestcode = barcode;
                daoperationlog.Hospsampleid = vda.Hospsampleid;
                //  if (chxHosNumer.Checked) { 
                daoperationlog.Hospsamplenumber = vda.Hospsamplenumber;
                //  }
                SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAOperationlog" } }, daoperationlog);

                #endregion


                string errmsg = "";
                if (!outspecimenbll.ExecuteSqlTran(SQLlist, ref errmsg)) { ShowMessageHelper.ShowBoxMsg("添加失败！:" + errmsg); return; }

                DataBind(daoutspecimen);
                this.txtBarcode.Focus();

                #endregion
            }
            catch (Exception Ex)
            {
                ShowMessageHelper.ShowBoxMsg("添加订单异常:" + Ex.Message);
                return;
            }


        }
        //当前插入订单的集合
        BindingCollection<DAOutspecimen> list = new BindingCollection<DAOutspecimen>();
        /// <summary>
        /// 绑定信息
        /// </summary>
        private void DataBind(DAOutspecimen daoutspecimen)
        {

            this.gvList.AutoGenerateColumns = false;
            //实现List排序,否则无法点击表头按列重新排序 
            if (daoutspecimen != null)
                list.Add(daoutspecimen);
            if (list.Count > 0)
            {
                var daoutList = from da in list orderby da.Createdate descending select da;
                this.bgSource3.DataSource = daoutList;
                lblRecord.Text = string.Format("共 {0} 条记录", list.Count);
            }
            else
            {
                this.bgSource3.DataSource = list;
                lblRecord.Text = string.Format("共 {0} 条记录", list.Count);
            }

            gvList.ClearSelection();
            gvList.TabStop = false;
        }

        // 删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //当前GridView是否存在数据
            if (gvList.Rows.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有要删除的订单！");
                return;
            }
            //已经选择的记录   记录数为0 则不往下执行
            List<DAOutspecimen> SelectList = (list as BindingCollection<DAOutspecimen>).ToList<DAOutspecimen>().FindAll(c => c.IsSelect);
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
            List<DAOutspecimen> daoutspecimenList = new List<DAOutspecimen>();
            for (int i = 0; i < SelectList.Count; i++)
            {
                if (SelectList[i].Status == "0")  //状态为已申请的可以删除，其它状态不能删除
                {
                    strb.Append(SelectList[i].Requestcode.ToString());
                    strb.Append(",");
                    DAOperationlog daoperationlog = new DAOperationlog();
                    daoperationlog.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                    daoperationlog.Usercode = SystemConfig.UserInfo.UserCode;
                    daoperationlog.Username = SystemConfig.UserInfo.UserName;
                    daoperationlog.Usertype = SystemConfig.UserInfo.UserType.ToString();
                    daoperationlog.Optype = "删除订单信息";
                    daoperationlog.Createdate = DateTime.Now;
                    daoperationlog.Opcontent = "删除订单号：" + SelectList[i].Requestcode;
                    daoperationlog.Requestcode = SelectList[i].Requestcode;
                    daoperationlog.Hospsampleid = SelectList[i].Hospsampleid;
                    daoperationlog.Hospsamplenumber = SelectList[i].Hospsamplenumber;
                    SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAOperationlog" } }, daoperationlog);
                    DAOutspecimen daoutspecimen = new DAOutspecimen();
                    daoutspecimen.Requestcode = SelectList[i].Requestcode.ToString();
                    daoutspecimenList.Add(daoutspecimen);
                }
            }
            // var library = new DAOutSpecimenBLL();
            //同时删除3张表的订单信息
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAResult" } }, strb.ToString().TrimEnd(','));
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAOutspecimentest" } }, strb.ToString().TrimEnd(','));
            SQLlist.Add(new Hashtable() { { "DELETE", "Da.DeleteDAOutspecimenByReauestCode" } }, strb.ToString().TrimEnd(','));
            if (outspecimenbll.ExecuteSqlTran(SQLlist))
            {

                if (daoutspecimenList.Count > 0)
                {
                    for (int i = 0; i < daoutspecimenList.Count; i++)
                    {
                        list.Remove(list.FirstOrDefault(item => item.Requestcode == daoutspecimenList[i].Requestcode));
                    }
                }
                ShowMessageHelper.ShowBoxMsg("数据成功删除！");
                HeaderCheckBox.Checked = false;
                DataBind(null);
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("数据删除失败！");
                HeaderCheckBox.Checked = false;
                DataBind(null);
            }
        }

        // checkBox选择事件
        private void chxHosNumer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chxHosNumer.Checked == true) //选中则录入医院样本号
            {
                this.dtpBeginDate.Enabled = true;
                this.dtpEndDate.Enabled = true;
                label6.Text = "录入样本号：";
            }
            else  //未选中则录入医院条码
            {
                this.dtpBeginDate.Enabled = false;
                this.dtpEndDate.Enabled = false;
                label6.Text = "扫描医院条码：";
            }
        }

        // 行绑定
        private void gvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;
            DataGridView view = (DataGridView)sender;
            object originalValue = e.Value;
            //转换字段显示
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Sex") { e.Value = e.Value.ToString() == "M" ? "男" : (e.Value.ToString() == "F" ? "女" : (e.Value.ToString() == "U" ? "未知" : "")); }
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Ageunit") { e.Value = e.Value.ToString() == "0" ? "岁" : (e.Value.ToString() == "1" ? "月" : (e.Value.ToString() == "2" ? "日" : (e.Value.ToString() == "3" ? "小时" : ""))); }
        }

        // 行绑定转换字段显示
        private void gvLisrequest_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;
            DataGridView view = (DataGridView)sender;
            object originalValue = e.Value;
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Sex") { e.Value = e.Value.ToString() == "M" ? "男" : (e.Value.ToString() == "F" ? "女" : (e.Value.ToString() == "U" ? "未知" : "")); }
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Ageunit") { e.Value = e.Value.ToString() == "0" ? "岁" : (e.Value.ToString() == "1" ? "月" : (e.Value.ToString() == "2" ? "日" : (e.Value.ToString() == "3" ? "小时" : ""))); }
        }

        // 医院条码或样本信息行点击事件
        private void gvLisrequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头 或者 选择框的列 
            if (e.RowIndex == -1 || e.ColumnIndex == 0)
                return;
            BindRightData((VDaLisrequest)gvLisrequest.Rows[e.RowIndex].DataBoundItem);
        }

        /// <summary>绑定右边相关数据
        /// 绑定右边相关数据
        /// </summary>
        /// <param name="rowindex"></param>
        //private void BindRightData(VDaLisrequest vdalis)
        //{
        //    BindingCollection<VDaLisrequesttest> list2 = new BindingCollection<VDaLisrequesttest>();
        //    //VDaLisrequest vda = (VDaLisrequest)gvLisrequest.Rows[gvLisrequest.CurrentCell.RowIndex].DataBoundItem;
        //    Hashtable htCode = new Hashtable();
        //    htCode.Add("Hospsampleid", vdalis.Hospsampleid);
        //    foreach (VDaLisrequesttest lst in new VDALisrequesttestBLL().GetVDaLisrequesttestList(htCode))
        //    {
        //        list2.Add(lst);
        //    }
        //    this.bgSource2.DataSource = list2;
        //    List<VDaLisrequesttest> vdalist = new VDALisrequesttestBLL().GetVDaLisrequesttestList(htCode);
        //    //Hashtable htmap = new Hashtable();
        //    //List<DATestmap> datestmap = new DATestmapBLL().GetDATestmapList(htmap);
        //    foreach (VDaLisrequesttest vdl in vdalist)
        //    {
        //        //选择存在对应关系的序列值
        //        var result = (from a in DaTestMap
        //                      where a.Customertestcode == vdl.Testcode
        //                      group a by new { a.Datestname, a.Datestcode } into g
        //                      select new
        //                      {
        //                          g.Key.Datestname,
        //                          g.Key.Datestcode,

        //                      }).ToArray();
        //        if (result.Length > 0)
        //        {
        //            vdl.Datestcode = result[0].Datestcode.ToString();
        //            vdl.Datestname = result[0].Datestname.ToString();
        //        }
        //    }
        //    StringBuilder str = new StringBuilder();
        //    if (vdalist.Count > 0)
        //    {
        //        str.Append("项目没有对照：");
        //        int num = 0;
        //        for (int i = 0; i < vdalist.Count; i++)
        //        {
        //            if (vdalist[i].Datestcode == null || vdalist[i].Datestname == null)
        //            {
        //                str.Append("项目编码：" + vdalist[i].Testcode + "[" + vdalist[i].Testname + "],");
        //                num++;
        //            }
        //        }
        //        if (num > 0)
        //        {
        //            //写项目匹配错误日志
        //            this.lblMessage.Text = str.ToString().TrimEnd(',');
        //            DAErrorlog eaerror = new DAErrorlog();
        //            eaerror.Dictuserid = Convert.ToDecimal(SystemConfig.UserInfo.UserId);
        //            eaerror.Createdate = DateTime.Now;
        //            eaerror.LastUpdateDate = DateTime.Now;
        //            eaerror.Opcontent = this.lblMessage.Text;
        //            eaerror.Usercode = SystemConfig.UserInfo.UserCode;
        //            eaerror.Usertype = SystemConfig.UserInfo.UserType.ToString();
        //            eaerror.Ipaddress = common.GetHostIP();//获取本机IP地址
        //            eaerror.Machinename = common.GetHostName();//获取本机机器名
        //            new DAErrorLogBLL().SaveErrorLog(eaerror);
        //        }
        //        else
        //        {
        //            this.lblMessage.Text = "";
        //            this.txtDaanBarcode.Focus();
        //        }
        //    }
        //    else
        //    {
        //        this.lblMessage.Text = "";
        //        this.txtDaanBarcode.Focus();
        //    }

        //}
        //行头显示行号
        private void gvLisrequest_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvLisrequest.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvLisrequest.RowHeadersDefaultCellStyle.Font, rectangle, gvLisrequest.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //行头显示行号
        private void gvDaLis_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvDaLis.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvDaLis.RowHeadersDefaultCellStyle.Font, rectangle, gvDaLis.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //行头显示行号
        private void gvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvList.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvList.RowHeadersDefaultCellStyle.Font, rectangle, gvList.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void gvLisrequest_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvLisrequest.RowHeadersWidth = (gvLisrequest.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }
        //滚动时设置行头的宽度
        private void gvDaLis_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvDaLis.RowHeadersWidth = (gvDaLis.FirstDisplayedScrollingRowIndex.ToString() + 20).Length * 9 + 13;

            }
        }
        //滚动时设置行头的宽度
        private void gvList_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvList.RowHeadersWidth = (gvList.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton2.Checked == true)
            //{
            //    cbbReportStatus.Visible = true;
            //    label5.Visible = true;
            //}
            //else
            //{
            //    cbbReportStatus.Visible = false;
            //    label5.Visible = false;
            //}
        }

    }
}
