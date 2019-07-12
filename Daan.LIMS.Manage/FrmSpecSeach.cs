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
using System.IO;
using System.Configuration;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Daan.Interface.Util;
using System.Management;
using Daan.Interface.Entity;
using Daan.Interface.Dao;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using System.Threading;



namespace Daan.LIMS.Manage
{
    //委外订单综合管理
    public partial class FrmSpecSeach : FrmBase
    {
        //表头加checkBox
        CheckBox HeaderCheckBox = null;
        CommonBLL comonbll = new CommonBLL();
        //打印的PDF默认路径
        public static string FileOrPath = Application.StartupPath + "\\PDF打印\\";

        public FrmSpecSeach()
        {
            InitializeComponent();  //初始化
            dtpEndDate.MaxDate = dtpBeginDate.MaxDate = DateTime.Now;  //设置结束默认时间
            dtpBeginDate.Value = DateTime.Now.AddDays(-3);   //设置开始默认时间
            //SamplingdateBegin.Value = DateTime.Now.AddDays(-3); 

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
                this.dgvHospital.Controls.Add(HeaderCheckBox);

                HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                dgvHospital.CurrentCellDirtyStateChanged += new EventHandler(gvItemHospitalAndDaan_CurrentCellDirtyStateChanged);
                dgvHospital.CellPainting += new DataGridViewCellPaintingEventHandler(gvItemHospitalAndDaan_CellPainting);
                BindDrop();  //绑定下拉框
            }
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
            drType[0] = "-1";
            drType[1] = "全部";
            dtType.Rows.Add(drType);


            drType = dtType.NewRow();
            drType[0] = "0";
            drType[1] = "已申请";
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

            drType = dtType.NewRow();
            drType[0] = "6";
            drType[1] = "已打印";
            dtType.Rows.Add(drType);


            drType = dtType.NewRow();
            drType[0] = "7";
            drType[1] = "已生成图片";
            dtType.Rows.Add(drType);

            cbbReportStatus.DataSource = dtType;
            cbbReportStatus.DisplayMember = "Name";
            cbbReportStatus.ValueMember = "Value";
            cbbReportStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        #region   >>> 表头添加复选框 全选和全不选
        /// <summary>
        /// Grid表头添加checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvItemHospitalAndDaan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvHospital.CurrentCell is DataGridViewCheckBoxCell)
                dgvHospital.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
            System.Drawing.Rectangle oRectangle = this.dgvHospital.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
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
            foreach (DataGridViewRow Row in dgvHospital.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value = HCheckBox.Checked;
            }
            dgvHospital.RefreshEdit();
        }
        #endregion

        /// <summary>查询</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //开始时间是否大于结束时间
            if (this.dtpBeginDate.Value.Date > this.dtpEndDate.Value.Date) { ShowMessageHelper.ShowBoxMsg("结束时间应大于开始时间！"); return; }
            //if (this.SamplingdateBegin.Value.Date > this.SamplingdateEnd.Value.Date) { ShowMessageHelper.ShowBoxMsg("采样结束时间应大于开始时间！"); return; }
            DataBind();
        }

        /// <summary>查询绑定方法
        /// </summary>
        private void DataBind()
        {
            Hashtable ht = new Hashtable();
            if (rbCdate.Checked)
            {
            ht.Add("dtpBeginDate", Convert.ToDateTime(this.dtpBeginDate.Value).ToString("yyyy-MM-dd")); //开始时间
            ht.Add("dtpEndDate", Convert.ToDateTime(this.dtpEndDate.Value.AddDays(+1)).ToString("yyyy-MM-dd")); //结束时间
            }
                else
                {
                       ht.Add("SamplingdateEnd", Convert.ToDateTime(this.dtpEndDate.Value.AddDays(+1)).ToString("yyyy-MM-dd"));    //采样时间
            ht.Add("SamplingdateBegin", Convert.ToDateTime(this.dtpBeginDate.Value).ToString("yyyy-MM-dd"));   //采样时间
                }
            ht.Add("Patientsource", this.txtHospital.Text.Trim()); //住院门诊号
            ht.Add("Requestcode", this.txtDaanBarcode.Text.Trim()); //达安条码
            ht.Add("Patientname", this.txtName.Text.Trim()); //姓名
            ht.Add("Hospsampleid", this.txtHospitalBarcode.Text.Trim());   //医院条码
            ht.Add("HospsampleidEnd", this.txtHospitalBarcodeEnd.Text.Trim());   //医院条码
            ht.Add("HospsamplenumberBegin", this.HospsamplenumberBegin.Text.Trim());   //医院样本号
           ht.Add("HospsamplenumberEnd", this.HospsamplenumberEnd.Text.Trim());   //医院样本号
          
            if (cbbReportStatus.SelectedValue.ToString() != "-1")
                ht.Add("Status", cbbReportStatus.SelectedValue);
            this.dgvHospital.AutoGenerateColumns = false;
            //实现List排序,否则无法点击表头按列重新排序 
            BindingCollection<DAOutspecimen> list = new BindingCollection<DAOutspecimen>();
            foreach (DAOutspecimen lst in new DAOutSpecimenBLL().GetOutspecimenList(ht))
            {
                list.Add(lst);
            }
            if (list.Count > 0)
            {
                var daoutList = from da in list orderby da.Createdate descending select da;
                BindingCollection<DAOutspecimen> listBack = new BindingCollection<DAOutspecimen>();
                foreach (DAOutspecimen lst in daoutList)
                {
                    listBack.Add(lst);
                }
                this.bgSource1.DataSource = listBack;
            }
            else
            {
                this.bgSource1.DataSource = list;
            }
            lblRecord.Text = string.Format("共 {0} 条记录", list.Count);
        }

        /// <summary> 行点击绑定相关信息 </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvHospital_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头 或者 选择框的列 
            if (e.RowIndex == -1 || e.ColumnIndex == 0)
                return;
            BindRightData((DAOutspecimen)dgvHospital.Rows[e.RowIndex].DataBoundItem);
        }

        /// <summary>绑定右边相关数据</summary>
        /// <param name="rowindex"></param>
        private void BindRightData(DAOutspecimen daoutaback)
        {
            #region >>>> zhangw 绑定基本信息
            string code = daoutaback.Requestcode;  //达安条码
            string name = daoutaback.Patientname;   //姓名
            string sex = daoutaback.Sex; //性别
            string age = daoutaback.Age.ToString();  //年龄
            string ageuint = daoutaback.Ageunit; //年龄单位
            string location = daoutaback.Location; //科室
            string patientsource = daoutaback.Patientsource;//门诊
            string time = daoutaback.Samplingdate == DateTime.MinValue ? "" : daoutaback.Samplingdate.ToShortDateString(); //采样时间
            ageuint = ageuint == "0" ? "岁" : (ageuint == "1" ? "月" : (ageuint == "2" ? "日" : "小时"));
            this.lbAge.Text = age + ageuint;
            this.lbDate.Text = time;
            this.lbLotacion.Text = location;
            this.lbName.Text = name;
            this.lbPatientsource.Text = patientsource;
            this.lbSex.Text = sex == "F" ? "女" : (sex == "M" ? "男" : (sex == "U" ? "未知" : " "));

            bindResultData(code);

            #endregion
            #region >>>> zhangw 绑定节点信息
            Hashtable htUserCode = new Hashtable();
            htUserCode.Add("Requestcode", code);
            List<DAOperationlog> operationlog = new DAOperationlogBLL().GetDAOperationlogByRequestcode(htUserCode); //显示节点信息
            //实现List排序,否则无法点击表头按列重新排序 fenghp
            BindingCollection<DAOperationlog> list = new BindingCollection<DAOperationlog>();
            foreach (DAOperationlog lst in operationlog)
            {
                list.Add(lst);
            }
            var daoutList = from daout in list orderby daout.Createdate descending select daout;
            this.bgSource3.DataSource = daoutList;
            #endregion
            #region >>>> zhangw 显示报告

            //删除其他PDF文件 正在显示的不删除
            WinFileTransporter.DeleteFolder(FileOrPath);

            Createfile();//创建PDF文件夹
            string FilePath = FileOrPath;
            string filename = FilePath + " 预览：" + daoutaback.Requestcode + ".pdf"; //打包后的PDF文件名称
            bool isA4 = true;
            ArrayList fileList = new ArrayList();
            Hashtable ha = new Hashtable();
            ha.Add("Requestcode", daoutaback.Requestcode);   //达安条码
            List<DAReport> da = new DAReportBLL().SelectDAReportByRequestcode(ha); //是否存在多个报告单
            //显示报告控件
            this.webPdfReader.Visible = true;
            string PDFPath = string.Empty;
            if (da.Count == 0)
            {
                #region 没有报告
                this.webPdfReader.Visible = false;
                //没有报告 选中预览报告Tab页才弹框
                if (tabControl1.SelectedIndex == 2) { ShowMessageHelper.ShowBoxMsg("没有报告预览！"); }
                return;
                #endregion
            }
            else if (da.Count == 1)
            {
                #region 单个报告
                string pdfFilePath = FileOrPath + daoutaback.Requestcode + ".PDF";
                //文件存在则更换名称
                if (File.Exists(pdfFilePath))
                {
                    pdfFilePath = FileOrPath + daoutaback.Requestcode + "_1.PDF";
                }
                byte[] buff = da[0].Reportdata;
                if (da[0].Reportdata == null)
                {
                    this.webPdfReader.Visible = false;
                }
                CreatPath(pdfFilePath, buff);
                PDFPath = pdfFilePath;
                #endregion
            }
            else if (da.Count > 1)
            {
                #region 多份报告 合并
                for (int i = 0; i < da.Count; i++)
                {
                    fileList.Add(da[i].Requestcode + "_" + i);
                }
                String[] files = new string[fileList.Count];
                for (int i = 0; i < fileList.Count; i++)
                {
                    #region
                    // string FilePath = Application.StartupPath + "\\PDF打印\\";;   //设置PDF路径
                    files[i] = FilePath + fileList[i].ToString() + ".PDF";   //设置PDF文件名称
                    string path = files[i];   //打开PDF路径
                    if (fileList[i].ToString().Contains("_"))  //设置路径是否包含多个
                    {
                        if (da.Count > 1)
                        {
                            for (int m = 0; m < da.Count; m++)
                            {
                                if (fileList[i].ToString() == da[m].Requestcode + "_" + m)
                                {
                                    path = FilePath + da[m].Requestcode + "_" + m + ".PDF";
                                    byte[] buff = da[m].Reportdata;
                                    CreatPath(path, buff);
                                }
                            }
                        }
                        else
                        {
                            byte[] buff = da[0].Reportdata;
                            CreatPath(path, buff);
                        }
                    }
                    else
                    {
                        if (da.Count != 0)
                        {
                            byte[] buff = da[0].Reportdata;
                            CreatPath(path, buff);
                        }
                    }
                    #endregion
                }
                mergePDFFiles(files, filename, isA4);
                PDFPath = filename;
                #endregion
            }
            this.webPdfReader.Navigate(PDFPath);  //预览PDF



            #endregion
        }

        // 行绑定事件
        private void dgvHospital_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;
            DataGridView view = (DataGridView)sender;
            object originalValue = e.Value;
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Sex") { e.Value = e.Value.ToString() == "M" ? "男" : (e.Value.ToString() == "F" ? "女" : (e.Value.ToString() == "U" ? "未知" : " ")); }
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
                    dgvHospital.Rows[e.RowIndex].DefaultCellStyle = d;
                    e.Value = "已发送";
                }
                else if (e.Value.ToString() == "3")
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.CadetBlue;
                    dgvHospital.Rows[e.RowIndex].DefaultCellStyle = d;
                    e.Value = "部分报告";
                }
                else if (e.Value.ToString() == "4")
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.BurlyWood;
                    dgvHospital.Rows[e.RowIndex].DefaultCellStyle = d;
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

        // 接收结果 
        private void btnResults_Click(object sender, EventArgs e)
        {
            //当前GridView是否存在数据
            if (dgvHospital.Rows.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有要接收的数据！");
                return;
            }
            //已经选择的记录   记录数为0 则不往下执行
            List<DAOutspecimen> SelectList = (bgSource1.DataSource as BindingCollection<DAOutspecimen>).ToList<DAOutspecimen>().FindAll(c => c.IsSelect);
            if (SelectList.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有选择要接收结果的条码！");
                return;
            }

            List<string> returntitle = new List<string>(); //弹出条码号

            string errorMessage = ""; //反馈信息
            string code = ""; //条码号
            List<string> OutspecimenidList = new List<string>(); //主键ID
            List<string> BarCodeList = new List<string>();  //达安条码
            List<string> Hospsampleid = new List<string>();   //医院条码
            List<string> Hospsamplenumber = new List<string>(); //医院样本号
            for (int i = 0; i < SelectList.Count; i++)
            {
                if (SelectList[i].Status == "5" && SystemConfig.Config.Username == "44021450")
                {
                    returntitle.Add(SelectList[i].Hospsampleid);
                    continue;
                }
                OutspecimenidList.Add(SelectList[i].Outspecimenid.ToString()); //主键
                BarCodeList.Add(SelectList[i].Requestcode.ToString()); //达安条码号
                Hospsampleid.Add(SelectList[i].Hospsampleid);//医院条码
                Hospsamplenumber.Add(SelectList[i].Hospsamplenumber); //医院样本号
            }
            //登录获取的SID
            string[] strlogin = new CommonBLL().UserLogin(SystemConfig.Config);
            if (strlogin[0] == "0")
            {
                ShowMessageHelper.ShowBoxMsg(strlogin[1] + "登陆失败！");
                return;
            }
            string SID = strlogin[1];
            bool flag = true;
            for (int m = 0; m < BarCodeList.Count; m++)
            {

                //消息集合
                List<string> msglist = new List<string>();
                int num = comonbll.TreatmentResultReport(SID, msglist, BarCodeList[m], SystemConfig.Config.Model);
                for (int j = 0; j < msglist.Count; j++)
                {
                    //插入节点信息
                    DAOperationlog daoperationlog = new DAOperationlog();
                    daoperationlog.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                    daoperationlog.Usercode = SystemConfig.UserInfo.UserCode;
                    daoperationlog.Username = SystemConfig.UserInfo.UserName;
                    daoperationlog.Usertype = SystemConfig.UserInfo.UserType.ToString();
                    daoperationlog.Optype = "结果接收错误";
                    daoperationlog.Createdate = DateTime.Now;
                    daoperationlog.Opcontent = "错误订单号：" + BarCodeList[m] + "错误码：" + msglist[j];
                    daoperationlog.Requestcode = BarCodeList[m];  //达安条码
                    daoperationlog.Hospsampleid = Hospsampleid[m];  //医院条码
                    daoperationlog.Hospsamplenumber = Hospsamplenumber[m]; //医院样本号
                    flag = new DAOperationlogBLL().SaveDAOperationlog(daoperationlog);
                    errorMessage += "条码号[" + BarCodeList[m] + "]" + msglist[j] + "\n";
                }
                if (num == 0) //未能获取到数据
                {
                    continue;
                }
                else if (num == 3)
                {
                    Hashtable htstatus = new Hashtable();
                    htstatus.Add("Outspecimenid", OutspecimenidList[m]);
                    htstatus.Add("status", "3");//部分获取 修改状态
                    bool result = new DAOutSpecimenBLL().UpdateStatus(htstatus);
                }
                else if (num == 4)
                {
                    Hashtable htstatus = new Hashtable();
                    htstatus.Add("Outspecimenid", OutspecimenidList[m]);
                    htstatus.Add("status", "4");//全部获取 修改状态
                    bool result = new DAOutSpecimenBLL().UpdateStatus(htstatus);
                }
                string message = num == 4 ? "完整获取" : "部份获取";
                code += BarCodeList[m] + "," + message;
                DAOperationlog daoperationlogBack = new DAOperationlog();
                daoperationlogBack.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                daoperationlogBack.Usercode = SystemConfig.UserInfo.UserCode;
                daoperationlogBack.Username = SystemConfig.UserInfo.UserName;
                daoperationlogBack.Usertype = SystemConfig.UserInfo.UserType.ToString();
                daoperationlogBack.Optype = "结果接收成功";
                daoperationlogBack.Createdate = DateTime.Now;
                daoperationlogBack.Opcontent = "成功订单号：" + code;
                daoperationlogBack.Requestcode = BarCodeList[m];  //达安条码
                daoperationlogBack.Hospsampleid = Hospsampleid[m];  //医院条码
                daoperationlogBack.Hospsamplenumber = Hospsamplenumber[m]; //医院样本号
                flag = new DAOperationlogBLL().SaveDAOperationlog(daoperationlogBack);
            }

            if (returntitle.Count > 0)
            {
                ShowMessageHelper.ShowBoxMsg("条码[" + string.Join(",", returntitle.ToArray()) + "]数据已下载到瑞格尔Lis系统中，无法进行修改！");
            }
            if (errorMessage != "" && code != "") //条码获取结果
            {
                ShowMessageHelper.ShowBoxMsg(string.Format("条码号[{0}]获取结果完毕！", code.TrimEnd(',')) + string.Format("{0}", errorMessage));
                HeaderCheckBox.Checked = false;
                DataBind();
            }
            else if (errorMessage != "" || code != "")
            {
                if (errorMessage != "")
                {

                    ShowMessageHelper.ShowBoxMsg(string.Format("{0}", errorMessage));
                    HeaderCheckBox.Checked = false;
                    DataBind();
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg(string.Format("条码号[{0}]获取结果完毕！", code.TrimEnd(',')));
                    HeaderCheckBox.Checked = false;
                    DataBind();
                }
            }
            BindRightData((DAOutspecimen)dgvHospital.SelectedRows[0].DataBoundItem);
        }

        /// <summary> 打印报告</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //当前GridView存不存在信息
            if (dgvHospital.Rows.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有要打印的数据！");
                return;
            }
            //已经选择的记录   记录数为0 则不往下执行
            List<DAOutspecimen> SelectList = (bgSource1.DataSource as BindingCollection<DAOutspecimen>).ToList<DAOutspecimen>().FindAll(c => c.IsSelect);
            if (SelectList.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有选择要打印的条码！");
                return;
            }
            try
            {
                int reportNum = 0; //报告总条数
                int successReportNum = 0; //报告改变状态成功条数
                bool falg = true;
                //删除其他PDF文件 正在显示的不删除
                WinFileTransporter.DeleteFolder(FileOrPath);
                Createfile();//创建PDF文件夹
                string filename = Application.StartupPath + "\\PDF打印\\" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".pdf"; //打包后的PDF文件名称
                bool isA4 = true;
                ArrayList fileList = new ArrayList();
                SortedList SQLlist = new SortedList(new MySort());
                List<string> OutspecimenidList = new List<string>(); //主键ID
                List<string> RequestcodeList = new List<string>();   //达安条码
                string reportMessage = "";
                #region //存在的报告添加节点信息
                if (dgvHospital.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < SelectList.Count; i++)
                    {

                        OutspecimenidList.Add(SelectList[i].Outspecimenid.ToString()); //主键
                        RequestcodeList.Add(SelectList[i].Requestcode.ToString());
                        #region
                        Hashtable ht = new Hashtable();
                        ht.Add("Requestcode", SelectList[i].Requestcode.ToString());  //达安条码
                        List<DAReport> da = new DAReportBLL().SelectDAReportByRequestcode(ht); //是否存在多个报告单
                        if (da.Count > 1)
                        {
                            #region
                            for (int k = 0; k < da.Count; k++)
                            {
                                if (da[k].Reportdata == null)
                                    continue;
                                reportNum++;
                                fileList.Add(da[k].Requestcode + "_" + k);   //多个报告单格式：条码号+_编号(0)
                                string[] obj = new string[] { SystemConfig.UserInfo.SID, da[k].Reportid.ToString() };
                                reportMessage = WebServiceUtils.ExecuteMethod("UpdateReportPrintStatusAuto", obj); //更新打印报告状态
                                string strsp = reportMessage.Substring(0, reportMessage.ToString().ToLower().IndexOf("|") + "|".Length - 1);
                                if (strsp == "1")
                                {
                                    successReportNum++;
                                }
                            }
                            DAOperationlog daoperationlog = new DAOperationlog();
                            daoperationlog.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                            daoperationlog.Usercode = SystemConfig.UserInfo.UserCode;
                            daoperationlog.Username = SystemConfig.UserInfo.UserName;
                            daoperationlog.Usertype = SystemConfig.UserInfo.UserType.ToString();
                            daoperationlog.Optype = "打印订单信息";
                            daoperationlog.Createdate = DateTime.Now;
                            daoperationlog.Opcontent = "报告已打印,订单号：" + SelectList[i].Requestcode;
                            daoperationlog.Requestcode = SelectList[i].Requestcode;
                            daoperationlog.Hospsampleid = SelectList[i].Hospsampleid; //医院条码
                            daoperationlog.Hospsamplenumber = SelectList[i].Hospsamplenumber;  //ToString(); //医院样本号
                            SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAOperationlog" } }, daoperationlog);
                            #endregion
                        }
                        else if (da.Count == 1)
                        {
                            #region
                            if (da[0].Reportdata == null)
                                continue;
                            fileList.Add(SelectList[i].Requestcode.ToString());
                            //打印的报告单号写入节点信息表
                            DAOperationlog daoperationlog = new DAOperationlog();
                            daoperationlog.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                            daoperationlog.Usercode = SystemConfig.UserInfo.UserCode;
                            daoperationlog.Username = SystemConfig.UserInfo.UserName;
                            daoperationlog.Usertype = SystemConfig.UserInfo.UserType.ToString();
                            daoperationlog.Optype = "打印订单信息";
                            daoperationlog.Createdate = DateTime.Now;
                            daoperationlog.Opcontent = "报告已打印,订单号：" + SelectList[i].Requestcode;
                            daoperationlog.Requestcode = SelectList[i].Requestcode; //达安条码
                            daoperationlog.Hospsampleid = SelectList[i].Hospsampleid; //医院条码
                            daoperationlog.Hospsamplenumber = SelectList[i].Hospsamplenumber;  //ToString(); //医院样本号
                            SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAOperationlog" } }, daoperationlog);
                            string[] obj = new string[] { SystemConfig.UserInfo.SID, da[0].Reportid.ToString() };
                            if (SystemConfig.Config == null)
                            {
                                ShowMessageHelper.ShowBoxMsg("获取系统配置失败,请重新登陆！");
                                return;
                            }
                            reportMessage = WebServiceUtils.ExecuteMethod("UpdateReportPrintStatusAuto", obj); //更新打印报告状态
                            string strsp = reportMessage.Substring(0, reportMessage.ToString().ToLower().IndexOf("|") + "|".Length - 1);
                            if (strsp == "1")
                            {
                                successReportNum++;
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                else
                {
                    return;
                }
                #endregion
                String[] files = new string[fileList.Count];
                if (files.Count() == 0)
                {
                    ShowMessageHelper.ShowBoxMsg("没找到要打印的PDF报告文件！");
                    return;
                }
                for (int i = 0; i < fileList.Count; i++)
                {
                    #region
                    string FilePath = Application.StartupPath + "\\PDF打印\\";   //设置PDF路径
                    files[i] = FilePath + fileList[i].ToString() + ".PDF";   //设置PDF文件名称
                    string path = files[i];   //打开PDF路径
                    if (fileList[i].ToString().Contains("_"))  //设置路径是否包含多个
                    {
                        //截取有多份报告的条码号去掉编号
                        string requestcode = fileList[i].ToString().Substring(0, fileList[i].ToString().ToString().ToLower().IndexOf("_") + "_".Length - 1);
                        Hashtable ht = new Hashtable();
                        ht.Add("Requestcode", requestcode);
                        List<DAReport> da = new DAReportBLL().SelectDAReportByRequestcode(ht);
                        //如果存在多份报告
                        if (da.Count > 1)
                        {
                            for (int m = 0; m < da.Count; m++)
                            {
                                if (da[m].Reportdata == null)
                                    continue;
                                if (fileList[i].ToString() == da[m].Requestcode + "_" + m)
                                {
                                    path = FilePath + da[m].Requestcode + "_" + m + ".PDF";
                                    byte[] buff = da[m].Reportdata;
                                    CreatPath(path, buff); //创建PDF
                                }
                            }
                        }
                        else
                        {
                            //单份报告
                            string pdfFilePath = FileOrPath + da[0].Requestcode + ".PDF";
                            //文件存在则更换名称
                            if (File.Exists(pdfFilePath))
                            {
                                pdfFilePath = FileOrPath + da[0].Requestcode + "_1.PDF";
                            }
                            byte[] buff = da[0].Reportdata;
                            CreatPath(pdfFilePath, buff);  //创建PDF
                        }
                    }
                    else
                    {
                        //单份报告
                        Hashtable ht = new Hashtable();
                        ht.Add("Requestcode", fileList[i].ToString());
                        List<DAReport> da = new DAReportBLL().SelectDAReportByRequestcode(ht);
                        if (da.Count != 0)
                        {
                            if (da[0].Reportdata == null)
                                continue;
                            string pdfFilePath = FileOrPath + da[0].Requestcode + ".PDF";
                            //文件存在则更换名称
                            if (File.Exists(pdfFilePath))
                            {
                                pdfFilePath = FileOrPath + da[0].Requestcode + "_1.PDF";
                            }
                            byte[] buff = da[0].Reportdata;
                            CreatPath(pdfFilePath, buff); //创建PDF
                        }
                    }
                    #endregion
                }
                mergePDFFiles(files, filename, isA4); //打包PDF
                #region //设置默认打印机
                //string PrinterName = "\\\\ROSS-PC\\HP LaserJet 1020";
                //ManagementObjectSearcher query;
                //ManagementObjectCollection queryCollection;
                //string _classname = "SELECT * FROM Win32_Printer";
                //query = new ManagementObjectSearcher(_classname);
                //queryCollection = query.Get();
                //foreach (ManagementObject mo in queryCollection)
                //{
                //    if (string.Compare(mo["Name"].ToString(), PrinterName, true) == 0)
                //    {
                //        mo.InvokeMethod("SetDefaultPrinter", null);
                //        break;
                //    }
                //}
                //foreach (ManagementObject mo in queryCollection)
                //{
                //    Console.WriteLine(mo["Name"].ToString());
                //}
                //Console.ReadLine();
                #endregion
                #region //设置打印进程，打印PDF
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                Process processInstance = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.Verb = "Print"; //设置打印
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = @"/p /h " + filename + pd.PrinterSettings.PrinterName + "";  //设置文件名和打印机名称 
                startInfo.FileName = filename; //文件名称
                processInstance.StartInfo = startInfo;
                processInstance.Start();//启动进程
                #endregion
                var library = new DAOutSpecimenBLL();
                if (library.ExecuteSqlTran(SQLlist))
                {
                    if (reportNum == successReportNum)
                    {
                        //ShowMessageHelper.ShowBoxMsg("报告条数："+successReportNum+"条打印状态成功更新！");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg(ex.Message);
            }
        }

        /// <summary> 基本信息高低值绑定提示 颜色信息 </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDaan_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= dgvDaan.Rows.Count)
                return;
            DataGridViewRow dgr = dgvDaan.Rows[e.RowIndex];
            if (dgr.Cells[4].Value == null)
                return;
            if (dgr.Cells[4].Value.ToString() == "L")  //偏低绿色
            {
                this.dgvDaan.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Green;
            }
            else if (dgr.Cells[4].Value.ToString() == "H")  //偏高红色
            {
                this.dgvDaan.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Red;
            }
        }

        /// <summary> 合併PDF檔(集合) </summary>   
        /// <param name="fileList">欲合併PDF檔之集合(一筆以上)</param>  
        /// <param name="outMergeFile">合併後的檔名</param>   
        ///     /// <param name="isA4">A5纸张转A4</param>  
        public static void mergePDFFiles(string[] fileList, string outMergeFile, bool isA4)
        {
            iTextSharp.text.pdf.PdfReader reader, reader1;
            Document document;
            if (isA4) //是否使用A4纸
            {
                //全用A4
                document = new Document();
            }
            else
            {
                reader1 = new PdfReader(fileList[0]);
                document = new Document(reader1.GetPageSizeWithRotation(1));
            }
            try
            {
                //删除已有文件
                bool b = true;
                if (File.Exists(outMergeFile))
                {
                    try { File.Delete(outMergeFile); }
                    catch (Exception) { b = false; }

                }
                if (b)
                {
                    //如果文件存在则覆盖，如果不存在则创建
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
                    document.Open();
                    PdfContentByte cb = writer.DirectContent;
                    PdfImportedPage newPage;
                    //合并PDF文档
                    for (int i = 0; i < fileList.Length; i++)
                    {
                        reader = new iTextSharp.text.pdf.PdfReader(fileList[i]);
                        int iPageNum = reader.NumberOfPages;
                        for (int j = 1; j <= iPageNum; j++)
                        {
                            if (!isA4)
                            {
                                document.SetPageSize(reader.GetPageSizeWithRotation(1));
                            }
                            else
                            {
                                document.SetPageSize(reader.GetPageSizeWithRotation(1));
                            }
                            document.NewPage();
                            newPage = writer.GetImportedPage(reader, j);
                            int rotation = reader.GetPageRotation(1);
                            if (rotation == 90 || rotation == 270)
                            {
                                if (isA4)
                                {
                                    cb.AddTemplate(newPage, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(1).Height);
                                }
                                else
                                {
                                    cb.AddTemplate(newPage, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(1).Height);
                                }
                            }
                            else
                            {
                                cb.AddTemplate(newPage, 1f, 0, 0, 1f, 0, 0);
                            }
                        }
                    }
                }
            }
            finally
            {
                document.Close();
            }
        }

        /// <summary>创建文件方法 </summary>
        /// <param name="path"></param>
        /// <param name="buff"></param>
        private void CreatPath(string path, byte[] buff)
        {
            if (buff != null)
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.SetLength(buff.Length);
                fs.Write(buff, 0, buff.Length);  //将二进制文件写到指定目录
                fs.Close();
                fs.Dispose();
            }
        }

        /// <summary>记录PDF文件夹
        /// </summary>
        public static void Createfile()
        {
            if (!Directory.Exists(FileOrPath))//若文件夹不存在则新建文件夹
            {
                Directory.CreateDirectory(FileOrPath); //新建文件夹
            }
        }

        #region >>> fenghp 绘制行号
        //行头显示行号
        private void dgvHospital_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, dgvHospital.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvHospital.RowHeadersDefaultCellStyle.Font, rectangle, dgvHospital.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void dgvHospital_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                dgvHospital.RowHeadersWidth = (dgvHospital.FirstDisplayedScrollingRowIndex + 15).ToString().Length * 9 + 13;

            }
        }
        //行头显示行号
        private void dgvDaan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, dgvDaan.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvDaan.RowHeadersDefaultCellStyle.Font, rectangle, dgvDaan.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void dgvDaan_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                dgvDaan.RowHeadersWidth = (dgvDaan.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }
        //行头显示行号
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                dataGridView1.RowHeadersWidth = (dataGridView1.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }
        #endregion


        //删除项目
        private void 删除选中项目谨慎操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection drs = dgvDaan.SelectedRows;
            if (drs.Count == 0) { return; }

            if (drs.Count == dgvDaan.Rows.Count) { ShowMessageHelper.ShowBoxMsg("项目不能全部删除"); return; }

            string resultids = "";
            string testname = "";
            foreach (DataGridViewRow dr in drs)
            {
                DAResult result = dr.DataBoundItem as DAResult;
                if (result.Testresult == null || result.Testresult == "")
                {
                    resultids += result.Resultid + ",";
                    testname += result.Customertestname + "(" + result.Customertestcode + ")" + ",";
                }

            }

            resultids = resultids.TrimEnd(',');
            DAResult _result = drs[0].DataBoundItem as DAResult;

            if (resultids == "") { return; }

            if (new DAResultBLL().DeleteDAResult(resultids))
            {
                DAOperationlog daoperationlog = new DAOperationlog();
                daoperationlog.Dictuserid = SystemConfig.UserInfo.UserId == "" ? 0 : Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                daoperationlog.Usercode = SystemConfig.UserInfo.UserCode;
                daoperationlog.Username = SystemConfig.UserInfo.UserName;
                daoperationlog.Usertype = SystemConfig.UserInfo.UserType.ToString();
                daoperationlog.Optype = "删除项目";
                daoperationlog.Createdate = DateTime.Now;
                daoperationlog.Opcontent = string.Format("删除项目[{0}]", testname.TrimEnd(','));
                daoperationlog.Requestcode = _result.Requestcode;  //达安条码
                daoperationlog.Hospsampleid = _result.Hospsampleid;  //医院条码
                daoperationlog.Hospsamplenumber = _result.Hospsamplenumber; //医院样本号
                new DAOperationlogBLL().SaveDAOperationlog(daoperationlog);

                bindResultData(_result.Requestcode);
            }



        }

        /// <summary>
        /// 绑定结果数据
        /// </summary>
        /// <param name="barcode">达安条码号</param>
        private void bindResultData(string barcode)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Requestcode", barcode);
            List<DAResult> daresult = new DAResultBLL().GetDAResultList(ht);   //显示基本信息
            //实现List排序,否则无法点击表头按列重新排序 fenghp
            BindingCollection<DAResult> listSort = new BindingCollection<DAResult>();
            foreach (DAResult lst in daresult)
            {
                listSort.Add(lst);
            }
            this.bgSource2.DataSource = listSort;

            dgvDaan.ClearSelection();
            dgvDaan.TabStop = false;
        }

        /// <summary>
        /// 控制报告不弹出来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webPdfReader_NewWindow(object sender, CancelEventArgs e)
        {
            WebBrowser webBrowser_temp = (WebBrowser)sender;
            string newUrl = webBrowser_temp.Document.ActiveElement.GetAttribute("href");
            webPdfReader.Url = new Uri(newUrl);
            e.Cancel = true;
        }

        private void btnExcell_Click(object sender, EventArgs e)
        {

            string strdaanCode = "";
            List<DAOutspecimen> SelectList = (bgSource1.DataSource as BindingCollection<DAOutspecimen>).ToList<DAOutspecimen>().FindAll(c => c.IsSelect);
            if (SelectList.Count > 0)
            {
                for (int i = 0; i < SelectList.Count; i++)
                {
                    strdaanCode += "'"+SelectList[i].Hospsampleid.ToString()+"',";
                }

                if (strdaanCode.Length > 0)
                    strdaanCode = strdaanCode.Substring(0, strdaanCode.Length - 1);
                dg1.DataSource = new DAOutSpecimenBLL().GetOutspecimenListExcel(strdaanCode);
                dg1.Columns[0].HeaderText = "瑞格尔项目代码";
                dg1.Columns[1].HeaderText = "达安项目代码";
                dg1.Columns[2].HeaderText = "结果值";
                dg1.Columns[3].HeaderText = "体检流水号";
                dg1.Columns[4].HeaderText = "医院条码号";
                dg1.Columns[5].HeaderText = "姓名";
                dg1.Columns[6].HeaderText = "达安项目名称";
                CommonFuncLibClient.ExportGridViewToExcel("", dg1);

            }




        }

        private void btn_expbl_Click(object sender, EventArgs e)
        {
            string strdaanCode = "";
            List<DAOutspecimen> SelectList = (bgSource1.DataSource as BindingCollection<DAOutspecimen>).ToList<DAOutspecimen>().FindAll(c => c.IsSelect);
            if (SelectList.Count > 0)
            {
                for (int i = 0; i < SelectList.Count; i++)
                {
                    strdaanCode += "'" + SelectList[i].Hospsampleid.ToString() + "',";
                }

                if (strdaanCode.Length > 0)
                    strdaanCode = strdaanCode.Substring(0, strdaanCode.Length - 1);
                dg1.DataSource = new DAOutSpecimenBLL().GetOutspecimenListExcelLCT(strdaanCode);

                dg1.Columns[4].HeaderText = "ID号";
                dg1.Columns[9].HeaderText = "TCT结果";
                CommonFuncLibClient.ExportGridViewToExcel("", dg1);

            }
        }



    }
}
