using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.control;
using Daan.Interface.Entity;
using Daan.Interface.BLL;
using System.Collections;
using Daan.Interface.Util;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.International.Converters.PinYinConverter;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using System.Collections.ObjectModel;
using Daan.Interface.Dao;

namespace Daan.LIMS.Manage
{
    public partial class FrmSampleInput : FrmBase
    {
        private List<string> instrumentTestItemID = new List<string>();
        private DADicttestitemBLL _dicttestitembll;
        private DADictLocationBLL dictlocationBll = new DADictLocationBLL();
        private DADictdoctorBLL dictdoctorbll = new DADictdoctorBLL();
        //错误提示消息
        string errorMessage = "";
        decimal? outspecimenid = 0;
        string requestcode = "";
        #region >>> 表头加checkBox
        CheckBox HeaderCheckBox = null;
        #endregion

        #region >>> 定义下拉列表框
        private ComboBox cmb_Temp = new ComboBox();
        #endregion

        #region >>> 初始化控件
        public FrmSampleInput()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                HeaderCheckBox = new CheckBox();
                HeaderCheckBox.Size = new Size(15, 15);
                this.dgvHospital.Controls.Add(HeaderCheckBox);

                HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                dgvHospital.CurrentCellDirtyStateChanged += new EventHandler(gvItemHospitalAndDaan_CurrentCellDirtyStateChanged);
                dgvHospital.CellPainting += new DataGridViewCellPaintingEventHandler(gvItemHospitalAndDaan_CellPainting);
                TestItemsControl.onAfterChange += TestItemsControlAfterSelector;
                //cmb_Temp.SelectedIndexChanged += new EventHandler(cmb_Temp_SelectedIndexChanged);
            }
        }
        #endregion

        #region >>> 表头添加复选框 全选和全不选
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
            Rectangle oRectangle = this.dgvHospital.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
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
                ((DataGridViewCheckBoxCell)Row.Cells["ischeck"]).Value = HCheckBox.Checked;
            }
            dgvHospital.RefreshEdit();
        }
        #endregion

        #region >>> 临时存储的项目列表集合
        BindingCollection<DADicttestitem> list = new BindingCollection<DADicttestitem>();
        #endregion

        #region >>> 输入项目
        private void TestItemsControlAfterSelector(object oldRow)
        {
            this.gvLisrequest.Controls.Add(cmb_Temp);
            //选择后项目
            if (!TestItemsControl.HasSelect) return;
            //读取项目id,名称，是否组合等局部变量
            string testid = TestItemsControl.valueMember == null ? "" : TestItemsControl.valueMember.ToString();
            if (testid == "") return;

            if (_dicttestitembll == null) _dicttestitembll = new DADicttestitemBLL();

            Hashtable ht = new Hashtable();
            ht.Add("Datestitemid", testid);
            List<DADicttestitem> dicttestlist = _dicttestitembll.SelectDADicttestitem(ht);
            if (dicttestlist.Count == 0) return;
            for (int i = 0; i < dicttestlist.Count; i++)
            {
                DADicttestitem datest = list.FirstOrDefault(item => item.Datestitemid == dicttestlist[i].Datestitemid);
                if (datest == null)
                {
                    list.Add(dicttestlist[i]);
                }
            }
            this.gvLisrequest.DataSource = list;
            //清除当前项目显示,准备下一个项目的增加
            TestItemsControl.valueMember = "";

            return;
        }
        #endregion

        #region >>> 绑定标本类别下拉框
        private void BindDrop()
        {
            #region >>> 标本类别
            Hashtable ht = new Hashtable();
            ht.Add("Librarytypecode", "bblb");
            List<DADictlibrary> dictlibrary = new DADictlibraryBLL().SelectDictlibrary(ht);

            DataTable dt = new DataTable("cart");
            DataColumn dc1 = new DataColumn("Libraryname", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("Dictlibraryid", Type.GetType("System.Int32"));
            dt.Columns.Add(dc1); dt.Columns.Add(dc2);
            DataRow drback = dt.NewRow();
            drback["Libraryname"] = "请选择";
            drback["Dictlibraryid"] = 0;
            dt.Rows.Add(drback);

            foreach (DADictlibrary dali in dictlibrary)
            {
                DataRow dr = dt.NewRow();
                dr["Libraryname"] = dali.Libraryname;
                dr["Dictlibraryid"] = dali.Dictlibraryid;
                dt.Rows.Add(dr);
            } //填充记录进去

            cmb_Temp.ValueMember = "Dictlibraryid";
            cmb_Temp.DisplayMember = "Libraryname";
            cmb_Temp.DataSource = dt;
            cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

            #region >>>性别
            DataTable dtType = new DataTable();
            dtType.Columns.Add("Value");
            dtType.Columns.Add("Name");
            DataRow drType;

            drType = dtType.NewRow();
            drType[0] = "0";
            drType[1] = "";
            dtType.Rows.Add(drType);


            drType = dtType.NewRow();
            drType[0] = "1";
            drType[1] = "男";
            dtType.Rows.Add(drType);


            drType = dtType.NewRow();
            drType[0] = "2";
            drType[1] = "女";
            dtType.Rows.Add(drType);

            drType = dtType.NewRow();
            drType[0] = "3";
            drType[1] = "未知";
            dtType.Rows.Add(drType);

            cbSex.DataSource = dtType;
            cbSex.DisplayMember = "Name";
            cbSex.ValueMember = "Value";

            cbSex.DropDownStyle = ComboBoxStyle.DropDownList;

            #endregion
        }
        #endregion

        #region >>> 加载事件
        private void FrmSampleInput_Load(object sender, EventArgs e)
        {

            this.dtpBeginDate.MaxDate = DateTime.Now;
            this.dtpEndDate.MaxDate = DateTime.Now;
            this.dtpBirthday.MaxDate = DateTime.Now;
            this.dtpSamplingDate.MaxDate = DateTime.Now;
            this.dtpReceivingDate.MaxDate = DateTime.Now;
            this.dtpBeginDate.Value = DateTime.Now.AddDays(-3);
            this.dtpEndDate.Value = DateTime.Now;
            this.dtpBirthday.Value = DateTime.Now;
            this.dtpSamplingDate.Value = DateTime.Now.AddDays(-3);
            this.dtpReceivingDate.Value = DateTime.Now;
            BindDrop();
            cmb_Temp.Visible = false;
            // 添加下拉列表框事件
            cmb_Temp.SelectedIndexChanged += new EventHandler(cmb_Temp_SelectedIndexChanged);
            // 将下拉列表框加入到DataGridView控件中
            this.gvLisrequest.Controls.Add(cmb_Temp);
            // AddEnterKeyDownEvent(this);

        }
        #endregion

        #region >>> Grid行更改时改变
        private void gvLisrequest_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (gvLisrequest.CurrentCell == null)
                    return;
                if (this.gvLisrequest.CurrentCell.ColumnIndex == 1)
                {
                    Rectangle rect = gvLisrequest.GetCellDisplayRectangle(gvLisrequest.CurrentCell.ColumnIndex, gvLisrequest.CurrentCell.RowIndex, false);
                    if (gvLisrequest.CurrentCell.Value != null && gvLisrequest.CurrentCell.Value.ToString() != "")
                    {
                        //设置下拉框的数据和样式
                        string sexValue = gvLisrequest.CurrentCell.Value.ToString();
                        cmb_Temp.Text = sexValue;
                        cmb_Temp.Left = rect.Left;
                        cmb_Temp.Top = rect.Top;
                        cmb_Temp.Width = rect.Width;
                        cmb_Temp.Height = rect.Height;
                        cmb_Temp.Visible = true;
                    }
                    else
                    {
                        //设置下拉框的数据和样式
                        cmb_Temp.Text = "请选择";
                        cmb_Temp.Left = rect.Left;
                        cmb_Temp.Top = rect.Top;
                        cmb_Temp.Width = rect.Width;
                        cmb_Temp.Height = rect.Height;
                        cmb_Temp.Visible = true;
                    }
                }
                else
                {
                    cmb_Temp.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region >>> 清空临时数据集合、文本框等控件数据
        /// <summary>清空临时数据集合、文本框等控件数据
        /// </summary>
        public void clear()
        {
            #region
            errorMessage = "";
            outspecimenid = 0;
            requestcode = "";
            this.txtBarcode.Text = string.Empty;
            this.dictCustomerSelect.popupContainerEdit1.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtBedNum.Text = string.Empty;
            this.txtPatientsource.Text = string.Empty;
            this.txtYears.Text = string.Empty;
            this.txtMonth.Text = string.Empty;
            this.txtDay.Text = string.Empty;
            this.dictLibrarySelect.popupContainerEdit1.Text = string.Empty;
            this.txtHeight.Text = string.Empty;
            this.txtWeight.Text = string.Empty;
            if (chbDoctor.Checked == false)
            {
                this.HeadLocationControl.popupContainerEdit1.Text = string.Empty;
                this.HeadDoctorControl.popupContainerEdit1.Text = string.Empty;
            }
            this.txtBultrasonic.Text = string.Empty;
            this.txtPregnant.Text = string.Empty;
            this.txtBabycount.Text = string.Empty;
            this.dtpBirthday.Value = DateTime.Now.AddHours(-1);
            this.txtLmp.Text = string.Empty;
            this.txtLmpDate.Text = string.Empty;
            if (chbSamplingDate.Checked == false)
            {
                this.dtpSamplingDate.Value = DateTime.Now.AddDays(-3);
            }
            if (chbReceivingDate.Checked == false)
            {
                this.dtpReceivingDate.Value = DateTime.Now.AddHours(-1);
            }
            this.txtDiagnostication.Text = string.Empty;
            this.txtRemark.Text = string.Empty;
            this.cbSex.Text = "";
            if (chbProject.Checked == false)
            {
                list.Clear();
                this.gvLisrequest.Controls.Remove(cmb_Temp);
            }
            this.TestItemsControl.popupContainerEdit1.Text = string.Empty;

            #endregion
        }
        #endregion

        #region >>> 项目列表属性值更改时发生
        private void gvLisrequest_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            cmb_Temp.Visible = false;
        }
        #endregion

        #region >>> 当用户选择下拉列表框时改变DataGridView单元格的内容
        private void cmb_Temp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            List<DADictlibrary> dictlibrary = new DADictlibraryBLL().SelectDictlibrary(ht);
            if (dictlibrary.Count > 0)
            {
                for (int i = 0; i < dictlibrary.Count; i++)
                {
                    if (((ComboBox)sender).Text == dictlibrary[i].Libraryname)
                    {
                        gvLisrequest.CurrentCell.Value = dictlibrary[i].Libraryname;
                        gvLisrequest.CurrentCell.Tag = dictlibrary[i].Dictlibraryid;
                    }
                }
            }


        }
        #endregion

        #region >>> 中文转换拼音
        /// <summary>将文本字符串转化为字符数组输出
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public char[] GetChars(string text)
        {
            char[] Cs = text.Trim().ToCharArray();
            return Cs;
        }
        /// <summary>中文转换拼音，取第一个字母，简称 
        /// </summary>
        /// <param name="controltext"></param>
        /// <returns></returns>
        private string ChineseConversion(string controltext)
        {
            int L = GetChars(controltext).Length;
            string Res = "";
            for (int i = 0; i < L; i++)
            {
                char C = GetChars(controltext)[i];

                if (ChineseChar.IsValidChar(C))
                {
                    ChineseChar CC = new ChineseChar(C);
                    //返回单个汉字拼音的所有集合，包括不同读音
                    ReadOnlyCollection<string> roc = CC.Pinyins;
                    //只获取第一个拼音
                    string Py = CC.Pinyins[0];
                    //去掉后面的数字，只截取拼音
                    Res += Py.Substring(0, Py.Length - (Py.Length - 1)) + ",";
                }
                //不是汉字返回输入的
                else { Res += C + ","; }
            }
            return Res;
        }
        #endregion

        #region >>> 保存科室
        private void btnLocation_Click(object sender, EventArgs e)
        {
            if (HeadLocationControl.popupContainerEdit1.Text != "")
            {
                string textname = "";
                Hashtable ht = new Hashtable();
                ht.Add("Locationname", HeadLocationControl.popupContainerEdit1.Text);
                //避免重复添加科室，有相同名称的就不添加
                List<DADictlocation> locationList = dictlocationBll.SelectDictlibrary(ht);
                if (locationList.Count == 0)
                {
                    string Res = ChineseConversion(HeadLocationControl.popupContainerEdit1.Text.Trim());
                    //去掉逗号
                    string[] text = Res.Split(',');
                    for (int i = 0; i < text.Length; i++)
                    {
                        textname += text[i];
                    }
                    DADictlocation location = new DADictlocation();
                    location.Locationname = HeadLocationControl.popupContainerEdit1.Text;
                    location.Active = "1";
                    location.Fastcode = textname;
                    bool falg = dictlocationBll.SaveDictLocation(location);
                    string name = "";
                    if (falg)
                    {
                        ShowMessageHelper.ShowBoxMsg("保存成功！");
                        name = HeadLocationControl.popupContainerEdit1.Text;
                        //重新初始化控件
                        HeadLocationControl.Dispose();
                        initHeadLocation();
                        list.Clear();
                    }
                    else
                    {
                        ShowMessageHelper.ShowBoxMsg("保存出错！");
                        return;
                    }
                    HeadLocationControl.popupContainerEdit1.Text = name;
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("已存在相同的科室名称！");
                    return;
                }
            }
        }
        #endregion

        #region >>> 保存医生
        private void btnDoctor_Click(object sender, EventArgs e)
        {
            if (HeadDoctorControl.popupContainerEdit1.Text != "")
            {
                Hashtable ht = new Hashtable();
                string textname = "";
                ht.Add("Doctorname", HeadDoctorControl.popupContainerEdit1.Text);
                //避免重复添加医生名称，有相同名称的就不添加
                List<DADictdoctor> dictdoctor = dictdoctorbll.SelectDictdoctor(ht);
                if (dictdoctor.Count == 0)
                {
                    string Res = ChineseConversion(HeadDoctorControl.popupContainerEdit1.Text.Trim());
                    //去掉逗号
                    string[] text = Res.Split(',');
                    for (int i = 0; i < text.Length; i++)
                    {
                        textname += text[i];
                    }
                    DADictdoctor doctor = new DADictdoctor();
                    doctor.Doctorname = HeadDoctorControl.popupContainerEdit1.Text;
                    doctor.Active = "1";
                    doctor.Doctorcode = textname;
                    doctor.Fastcode = textname;
                    bool falg = dictdoctorbll.SaveDictdoctor(doctor);
                    string name = "";
                    if (falg)
                    {
                        ShowMessageHelper.ShowBoxMsg("保存成功！");
                        name = HeadDoctorControl.popupContainerEdit1.Text;
                        //重新初始化控件
                        HeadDoctorControl.Dispose();
                        initHeadDoctorControl();
                    }
                    else
                    {
                        ShowMessageHelper.ShowBoxMsg("保存出错！");
                        return;
                    }
                    HeadDoctorControl.popupContainerEdit1.Text = name;
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("已存在相同的医生名字！");
                    return;
                }
            }
        }


        #endregion

        #region >>> 删除选择项目
        private void gvLisrequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (MessageBox.Show("您确定要删除吗?", DefaultConfig.MSGTITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DataGridViewRow dgr = gvLisrequest.Rows[e.RowIndex];
                int id = Convert.ToInt32(dgr.Cells[0].Value);
                //根据点击的行数据ID删除临时数据集中的这条数据
                list.Remove(list.FirstOrDefault(item => item.Datestitemid == id));
            }
        }
        #endregion

        #region >>> 新增
        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear();
        }
        #endregion

        #region >>> 验证输入的孕周孕日是否正确
        private String CheckPregnant(int min, int max, string val, string msg)
        {
            String msginfo = "";
            if (val.Contains("+"))
            {
                val = val.TrimEnd(new char[] { '+' });
            }
            try
            {
                if (int.Parse(val) < min || int.Parse(val) > max)
                { msginfo = msg; }
            }
            catch
            {
                // 孕周孕日可以输入加号
                msginfo = "孕周孕日必须是数字或带加号的数字";

            }
            return msginfo;
        }
        #endregion

        #region >>> 保存
        private void btnSend_Click(object sender, EventArgs e)
        {
            #region  >>> 非空验证
            //条码
            if (this.txtBarcode.Text == "" || this.txtBarcode.Text.Length != 12)
            {
                ShowMessageHelper.ShowBoxMsg("请核对达安条码为12位数字！");
                return;
            }
            Regex r = new Regex(@"^\d*00$|\:");  //正则12位数字尾数必须为0
            if (!r.IsMatch(this.txtBarcode.Text)) //达安条码为数字
            {
                ShowMessageHelper.ShowBoxMsg("请核对达安条码后两位为0的12位数字！");
                return;
            }
            Hashtable htdaoutlist = new Hashtable();
            htdaoutlist.Add("txtRequestcode", this.txtBarcode.Text);  //达安条码
            htdaoutlist.Add("Outspecimenid", outspecimenid);  //达安条码
            List<DAOutspecimen> daoutlist = new DAOutSpecimenBLL().GetOutspecimenList(htdaoutlist); //是否存在相同的达安条码
            if (daoutlist.Count > 0)
            {
                ShowMessageHelper.ShowBoxMsg("已存在相同的达安条码！");
                return;
            }
            //医院
            if (this.dictCustomerSelect.popupContainerEdit1.Text == "")
            {
                ShowMessageHelper.ShowBoxMsg("医院不能为空！");
                return;
            }
            //项目
            if (list.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("项目不能为空！");
                return;
            }
            //判断LMP孕周0-6
            if (this.txtLmp.Text.Trim() != "")
            {
                errorMessage = CheckPregnant(7, 20, txtLmp.Text.Trim(), "[LMP孕周] 必须在7~20之间\r\n");
                if (errorMessage.Length > 0)
                {
                    ShowMessageHelper.ShowBoxMsg(errorMessage);
                    return;
                }
            }
            //判断LMP孕日0-6
            if (this.txtLmpDate.Text.Trim() != "")
            {
                errorMessage = CheckPregnant(0, 6, txtLmpDate.Text.Trim(), "[LMP孕日] 必须在0~6之间\r\n");
                if (errorMessage.Length > 0)
                {
                    ShowMessageHelper.ShowBoxMsg(errorMessage);
                    return;
                }
            }
            //判断B超孕周7-20
            if (this.txtBultrasonic.Text.Trim() != "")
            {
                errorMessage = CheckPregnant(7, 20, txtBultrasonic.Text.Trim(), "[B超孕周] 必须在7~20之间\r\n");
                if (errorMessage.Length > 0)
                {
                    ShowMessageHelper.ShowBoxMsg(errorMessage);
                    return;
                }
            }
            //判断B超孕日0-6
            if (txtPregnant.Text.Trim() != "")
            {
                errorMessage = CheckPregnant(0, 6, txtPregnant.Text.Trim(), "[B超孕日] 必须在0~6之间\r\n");
                if (errorMessage.Length > 0)
                {
                    ShowMessageHelper.ShowBoxMsg(errorMessage);
                    return;
                }
            }
            //判断采样和接收时间
            if (dtpSamplingDate.Text != "" && dtpReceivingDate.Text != "")
            {
                if (this.dtpReceivingDate.Value.Date < this.dtpSamplingDate.Value.Date)
                {
                    errorMessage = "接收时间必须晚于采样时间 \r\n";
                    if (errorMessage.Length > 0)
                    {
                        ShowMessageHelper.ShowBoxMsg(errorMessage);
                        return;
                    }
                }
            }
            //简易录单
            if (this.chbSingle.Checked == false)
            {
                //姓名
                if (this.txtName.Text == "")
                {
                    ShowMessageHelper.ShowBoxMsg("客户姓名不能为空！");
                    return;
                }
                //标本状态
                if (this.dictLibrarySelect.popupContainerEdit1.Text == "")
                {
                    ShowMessageHelper.ShowBoxMsg("标本状态不能为空！");
                    return;
                }
                //院感项目
                if (chbTestItem.Checked == false)
                {
                    //性别
                    if (cbSex.Text == "")
                    {
                        ShowMessageHelper.ShowBoxMsg("性别不能为空！");
                        return;
                    }
                    //年龄
                    if (this.txtYears.Text == "" && this.txtMonth.Text == "" && this.txtDay.Text == "")
                    {
                        ShowMessageHelper.ShowBoxMsg("年龄不能为空！");
                        return;
                    }
                }
            }
            //年龄
            int yearsage = 0; //岁
            int monthage = 0; //月
            int dayage = 0;   //日
            try
            {
                if (this.txtYears.Text != "")
                {
                    yearsage = Convert.ToInt32(this.txtYears.Text);
                    try
                    {
                        if (int.Parse(txtYears.Text) > 200)
                        {
                            ShowMessageHelper.ShowBoxMsg("[年龄] 不能大于200！");
                            return;
                        }
                    }
                    catch
                    {

                    }
                }
                else if (this.txtMonth.Text != "" && this.txtYears.Text == "")
                {
                    monthage = Convert.ToInt32(this.txtMonth.Text);
                }
                else if (this.txtDay.Text != "" && this.txtMonth.Text == "")
                {
                    dayage = Convert.ToInt32(this.txtDay.Text);
                }
            }
            catch (Exception)
            {
                ShowMessageHelper.ShowBoxMsg("年龄错误，应为正整数字！");
                return;
            }
            #endregion

            if (SaveOutspecimen(yearsage, monthage, dayage))
            {
                ShowMessageHelper.ShowBoxMsg("保存成功！");
                DataBind();
                clear();
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("保存失败！");
                return;
            }

        }
        #endregion

        #region >>> 保存方法
        public bool SaveOutspecimen(int yearsage, int monthage, int dayage)
        {
            bool falg = true;
            SortedList SQLlist = new SortedList(new MySort());
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAOutspecimentest" } }, requestcode);
            //得到订单实体
            DAOutspecimen daoutspecimen = GetDaOutspecimen(yearsage, monthage, dayage);
            if (outspecimenid != 0)
            {
                falg = new DAOutSpecimenBLL().SaveDictlab(daoutspecimen);
                if (falg == false)
                {
                    return falg;
                }
            }
            else
            {
                SQLlist.Add(new Hashtable() { { "INSERT", "Da.InsertDAOutspecimen" } }, daoutspecimen);
            }
            //订单子项列表
            List<DAOutspecimentest> daoutspecimentestlist = GetOutspecimentest();
            for (int i = 0; i < daoutspecimentestlist.Count; i++)
            {
                SQLlist.Add(new Hashtable() { { "INSERT", "Da.InsertDAOutspecimentest" } }, daoutspecimentestlist[i]);
            }
            var library = new DAOutSpecimenBLL();
            if (library.ExecuteSqlTran(SQLlist))
            {
                falg = true;
            }
            else
            {
                falg = false;
            }
            return falg;
        }

        #region >>> 获取订单子项
        /// <summary>获取订单子项
        /// </summary>
        /// <returns></returns>
        private List<DAOutspecimentest> GetOutspecimentest()
        {
            List<DAOutspecimentest> daoutspecimentestList = new List<DAOutspecimentest>();
            for (int i = 0; i < list.Count; i++)
            {
                DAOutspecimentest daoutspecimentest = new DAOutspecimentest();
                daoutspecimentest.Requestcode = this.txtBarcode.Text.Trim();
                daoutspecimentest.Hospsampleid = "0";
                //daoutspecimentest.Customertestcode = list[i].Datestcode;
                //daoutspecimentest.Customertestname = list[i].Datestname;
                daoutspecimentest.Datestcode = list[i].Datestcode;
                daoutspecimentest.Datestname = list[i].Datestname;
                daoutspecimentest.SampleType = list[i].SampleType;
                daoutspecimentest.Createdate = DateTime.Now;
                daoutspecimentestList.Add(daoutspecimentest);
            }
            return daoutspecimentestList;
        }
        #endregion

        #region >>>获取订单实体
        /// <summary>获取订单实体</summary>
        /// <param name="yearsage"></param>
        /// <param name="monthage"></param>
        /// <param name="dayage"></param>
        /// <returns></returns>
        public DAOutspecimen GetDaOutspecimen(int yearsage, int monthage, int dayage)
        {
            DAOutspecimen daoutspecimen = new DAOutspecimen();
            daoutspecimen.Outspecimenid = outspecimenid;
            if (yearsage != 0)
            {
                daoutspecimen.Age = yearsage;
                daoutspecimen.Ageunit = "0";
            }
            else if (monthage != 0)
            {
                daoutspecimen.Age = monthage;
                daoutspecimen.Ageunit = "1";
            }
            else if (dayage != 0)
            {
                daoutspecimen.Age = dayage;
                daoutspecimen.Ageunit = "2";
            }
            daoutspecimen.Requestcode = this.txtBarcode.Text.Trim();
            daoutspecimen.Hospsampleid = "0";
            BaseService service = new BaseService();
            Hashtable param = new Hashtable();
            param["Customername"] = this.dictCustomerSelect.popupContainerEdit1.Text;
            IList lst = service.selectIList("SelectDictcustomer", param);
            foreach (DADictcustomer item in lst)//取医院code
            {
                daoutspecimen.Customercode = item.Customercode;
            }
            daoutspecimen.Patientname = this.txtName.Text.Trim();
            daoutspecimen.Sex = this.cbSex.Text.Trim() == "男" ? "M" : (this.cbSex.Text.Trim() == "女" ? "F" : (this.cbSex.Text.Trim() == "未知" ? "U" : "B"));
            daoutspecimen.Bednumber = this.txtBedNum.Text.Trim();
            daoutspecimen.Patientsource = this.txtPatientsource.Text.Trim();
            daoutspecimen.Samstate = this.dictLibrarySelect.popupContainerEdit1.Text.Trim();
            daoutspecimen.Height = this.txtHeight.Text.Trim();
            daoutspecimen.Weight = this.txtWeight.Text.Trim();
            daoutspecimen.Location = this.HeadLocationControl.popupContainerEdit1.Text;
            daoutspecimen.Doctor = this.HeadDoctorControl.popupContainerEdit1.Text;
            daoutspecimen.Bultrasonic = this.txtBultrasonic.Text.Trim();
            daoutspecimen.Pregnant = this.txtPregnant.Text.Trim();
            daoutspecimen.Babycount = this.txtBabycount.Text.Trim();
            daoutspecimen.Birthday = Convert.ToDateTime(this.dtpBirthday.Text.Trim());
            daoutspecimen.Lmp = this.txtLmp.Text.Trim();
            daoutspecimen.Lmpdate = this.txtLmpDate.Text.Trim();
            daoutspecimen.Samplingdate = Convert.ToDateTime(this.dtpSamplingDate.Text.Trim());
            daoutspecimen.Enterbydate = Convert.ToDateTime(this.dtpReceivingDate.Text.Trim());
            daoutspecimen.Diagnostication = this.txtDiagnostication.Text.Trim();
            daoutspecimen.Remark = this.txtRemark.Text.Trim();
            for (int i = 0; i < list.Count; i++)
            {
                //daoutspecimen.Customertestcodes += list[i].Datestcode + ",";
                //daoutspecimen.Customertestnames += list[i].Datestname + ",";
                daoutspecimen.Datestcodes += list[i].Datestcode + ",";
                daoutspecimen.Datestnames += list[i].Datestname + ",";
            }
            daoutspecimen.Enterby = SystemConfig.UserInfo.UserCode;  //"";//录单人
            daoutspecimen.Lastupdatedate1 = DateTime.Now;
            daoutspecimen.Createdate = DateTime.Now;
            daoutspecimen.Usertype = SystemConfig.UserInfo.UserType.ToString();
            daoutspecimen.Status = "0";
            return daoutspecimen;
        }
        #endregion

        #endregion

        #region >>> 当前插入订单的临时集合
        BindingCollection<DAOutspecimen> outspecimenlist = new BindingCollection<DAOutspecimen>();
        #endregion

        #region >>> 删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //当前GridView是否存在数据
            if (dgvHospital.Rows.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("没有要删除的订单！");
                return;
            }
            //已经选择的记录   记录数为0 则不往下执行  bgSource.DataSource  outspecimenlist
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
            var library = new DAOutSpecimenBLL();
            //同时删除2张表的订单信息
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAOutspecimentest" } }, strb.ToString().TrimEnd(','));
            SQLlist.Add(new Hashtable() { { "DELETE", "Da.DeleteDAOutspecimenByReauestCode" } }, strb.ToString().TrimEnd(','));
            if (library.ExecuteSqlTran(SQLlist))
            {

                if (daoutspecimenList.Count > 0)
                {
                    for (int i = 0; i < daoutspecimenList.Count; i++)
                    {
                        outspecimenlist.Remove(outspecimenlist.FirstOrDefault(item => item.Requestcode == daoutspecimenList[i].Requestcode));
                    }
                }
                ShowMessageHelper.ShowBoxMsg("数据成功删除！");
                HeaderCheckBox.Checked = false;
                DataBind();
                clear();
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("数据删除失败！");
                HeaderCheckBox.Checked = false;
                DataBind();
                clear();
            }
        }
        #endregion

        #region >>> 导出Excel
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ExportGridViewToExcel("订单", dgvHospital);
        }
        #endregion

        #region >>> 公用方法，将DataGridView显示的数据导出到EXCEL
        //参数一：导出的默认文件名
        //参数二：需要导出的数据对象
        public void ExportGridViewToExcel(string caption, DataGridView gr)
        {
            if (gr.Rows.Count <= 0)
            {
                ShowMessageHelper.ShowBoxMsg("当前列表没有数据可供导出！");
                return;
            }
            bool sucess = false;
            string fileName = caption + DateTime.Now.ToString("yyyyMMdd");
            try
            {
                CommonBLL export = new CommonBLL();
                //DataGridView grid = new DataGridView();
                //grid = gr;
                //for (int j = 0; j < grid.Rows.Count; j++)
                //{
                //    for (int i = 0; i < grid.Columns.Count; i++)
                //    {
                //        if (grid.Columns[i].HeaderCell.Value.ToString() == "性别")
                //        {
                //            grid.Rows[j].Cells[i].Value = grid.Rows[j].Cells[i].Value.ToString() == "M" ? "男" : (grid.Rows[j].Cells[i].Value.ToString() == "U" ? "女" : "未知");
                //        }
                //        if (grid.Columns[i].HeaderCell.Value.ToString() == "年龄单位")
                //        {
                //            grid.Rows[j].Cells[i].Value = grid.Rows[j].Cells[i].Value.ToString() == "0" ? "岁" : (grid.Rows[j].Cells[i].Value.ToString() == "1" ? "月" : (grid.Rows[j].Cells[i].Value.ToString() == "2" ? "日" : "小时"));
                //        }
                //        //if (grid.Columns[i].HeaderCell.Value.ToString() == "状态")
                //        //{
                //        //    grid.Rows[j].Cells[i].Value = grid.Rows[j].Cells[i].Value.ToString() == "0" ? "已发送" : (grid.Rows[j].Cells[i].Value.ToString() == "1" ? "已审核" : (grid.Rows[j].Cells[i].Value.ToString() == "2" ? "已发送" : (grid.Rows[j].Cells[i].Value.ToString() == "3" ? "部分报告" : "报告已出") ));
                //        //}
                //    }

                //}
                sucess = export.ExportExcel(fileName, gr);
            }
            catch (Exception err)
            {
                ShowMessageHelper.ShowBoxMsg("无法输出Excel！");
            }

            if (sucess) ShowMessageHelper.ShowBoxMsg("导出成功！");
        }
        #endregion

        #region >>> 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //开始时间是否大于结束时间
            if (this.dtpBeginDate.Value.Date > this.dtpEndDate.Value.Date) { ShowMessageHelper.ShowBoxMsg("结束时间应大于开始时间！"); return; }
            DataBind();
        }
        #endregion

        #region >>> 查询绑定
        /// </summary>
        private void DataBind()
        {
            Hashtable ht = new Hashtable();
            ht.Add("dtpBeginDate", Convert.ToDateTime(this.dtpBeginDate.Value).ToString("yyyy-MM-dd")); //开始时间
            ht.Add("dtpEndDate", Convert.ToDateTime(this.dtpEndDate.Value.AddDays(1)).ToString("yyyy-MM-dd"));//结束时间
            ht.Add("Requestcode", this.txtDaanBarcode.Text.Trim());//达安条码号
            ht.Add("Status", 0);
            ht.Add("txtHospsampleid", 0);
            this.dgvHospital.AutoGenerateColumns = false;
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
        }
        #endregion

        #region >>> 行绑定事件
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

            }
        }
        #endregion

        #region >>> 绘制行号
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
        private void gvLisrequest_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvLisrequest.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvLisrequest.RowHeadersDefaultCellStyle.Font, rectangle, gvLisrequest.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void gvLisrequest_Scroll(object sender, ScrollEventArgs e)
        {

            cmb_Temp.Visible = false;
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvLisrequest.RowHeadersWidth = (gvLisrequest.FirstDisplayedScrollingRowIndex + 15).ToString().Length * 9 + 13;
            }
        }
        #endregion

        #region >>> 回车键Tab效果
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.dictCustomerSelect.Focus();
            }

        }

        private void dictCustomerSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtName.Focus();
            }
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.cbSex.Focus();
            }
        }

        private void cbSex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtBedNum.Focus();
            }
        }

        private void txtBedNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtPatientsource.Focus();
            }
        }

        private void txtPatientsource_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtYears.Focus();
            }
        }

        private void txtYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtMonth.Focus();
            }
        }

        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtDay.Focus();
            }
        }

        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.dictLibrarySelect.Focus();
            }

        }

        private void dictLibrarySelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtHeight.Focus();
            }

        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtWeight.Focus();
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.HeadLocationControl.Focus();
            }

        }

        private void HeadLocationControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.HeadDoctorControl.Focus();
            }

        }

        private void HeadDoctorControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtBultrasonic.Focus();
            }
        }

        private void txtBultrasonic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtPregnant.Focus();
            }
        }

        private void txtPregnant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtBabycount.Focus();
            }
        }

        private void txtBabycount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.dtpBirthday.Focus();
            }
        }

        private void dtpBirthday_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtLmp.Focus();
            }
        }

        private void txtLmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtLmpDate.Focus();
            }
        }

        private void txtLmpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.dtpSamplingDate.Focus();
            }
        }

        private void dtpSamplingDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtDiagnostication.Focus();
            }

        }

        private void txtDiagnostication_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.dtpReceivingDate.Focus();
            }

        }

        private void dtpReceivingDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.txtRemark.Focus();
            }
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.TestItemsControl.Focus();
            }

        }

        private void TestItemsControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.btnSend.Focus();
                if (list.Count == 0)
                {
                    this.gvLisrequest.Controls.Remove(cmb_Temp);
                }
            }
        }

        #endregion

        #region >>> 绑定订单
        private void dgvHospital_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头 或者 选择框的列 
            if (e.RowIndex == -1 || e.ColumnIndex == 0)
                return;
            BindRightData((DAOutspecimen)dgvHospital.Rows[e.RowIndex].DataBoundItem);
        }

        /// <summary>
        /// 绑定订单信息
        /// </summary>
        /// <param name="dAOutspecimen"></param>
        private void BindRightData(DAOutspecimen dAOutspecimen)
        {
            list.Clear();
            this.gvLisrequest.Controls.Add(cmb_Temp);
            outspecimenid = dAOutspecimen.Outspecimenid;
            requestcode = dAOutspecimen.Requestcode;
            this.txtBarcode.Text = dAOutspecimen.Requestcode;
            BaseService service = new BaseService();
            Hashtable param = new Hashtable();
            param["Customercode"] = dAOutspecimen.Customercode;
            IList lst = service.selectIList("SelectDictcustomer", param);
            foreach (DADictcustomer item in lst)//取医院code
            {
                this.dictCustomerSelect.displayMember = item.Customername;
            }
            this.txtName.Text = dAOutspecimen.Patientname;
            this.cbSex.Text = dAOutspecimen.Sex == "M" ? "男" : (dAOutspecimen.Sex == "F" ? "女" : (dAOutspecimen.Sex == "U" ? "未知" : "B"));
            this.txtBedNum.Text = dAOutspecimen.Bednumber;
            this.txtPatientsource.Text = dAOutspecimen.Patientsource;
            if (dAOutspecimen.Ageunit == "0")
            {
                this.txtYears.Text = dAOutspecimen.Age.ToString();
            }
            else if (dAOutspecimen.Ageunit == "1")
            {
                this.txtMonth.Text = dAOutspecimen.Age.ToString();
            }
            else if (dAOutspecimen.Ageunit == "2")
            {
                this.txtDay.Text = dAOutspecimen.Age.ToString();
            }
            else
            {
                this.txtYears.Text = "";
                this.txtMonth.Text = "";
                this.txtDay.Text = "";
            }
            this.dictLibrarySelect.popupContainerEdit1.Text = dAOutspecimen.Samstate;
            this.txtHeight.Text = dAOutspecimen.Height;
            this.txtWeight.Text = dAOutspecimen.Weight;
            this.HeadLocationControl.popupContainerEdit1.Text = dAOutspecimen.Location;
            this.HeadDoctorControl.popupContainerEdit1.Text = dAOutspecimen.Doctor;
            this.txtBultrasonic.Text = dAOutspecimen.Bultrasonic;
            this.txtPregnant.Text = dAOutspecimen.Pregnant;
            this.txtLmp.Text = dAOutspecimen.Lmp;
            this.txtLmpDate.Text = dAOutspecimen.Lmpdate;
            this.txtBabycount.Text = dAOutspecimen.Babycount;
            this.dtpBirthday.Text = dAOutspecimen.Birthday.ToString();
            this.dtpSamplingDate.Text = dAOutspecimen.Samplingdate.ToString();
            this.dtpReceivingDate.Text = dAOutspecimen.Enterbydate.ToString();
            this.txtDiagnostication.Text = dAOutspecimen.Diagnostication;
            this.txtRemark.Text = dAOutspecimen.Remark;
            string testitemback = dAOutspecimen.Datestcodes.TrimEnd(',');
            string[] testitem = testitemback.Split(',');
            for (int i = 0; i < testitem.Count(); i++)
            {
                Hashtable ht = new Hashtable();
                ht.Add("Datestcode", testitem[i]);
                List<DADicttestitem> dicttestlist = new DADicttestitemBLL().SelectDADicttestitem(ht);
                if (dicttestlist.Count == 0) return;
                for (int j = 0; j < dicttestlist.Count; j++)
                {
                    DADicttestitem datest = list.FirstOrDefault(item => item.Datestitemid == dicttestlist[j].Datestitemid);
                    Hashtable httest = new Hashtable();
                    httest.Add("Requestcode", dAOutspecimen.Requestcode);
                    httest.Add("Datestcode", dicttestlist[j].Datestcode);
                    DataTable dt = new DAOutSpecimentestBLL().GetOutspecimenTestTable(httest);
                    if (dt.Rows.Count > 0)
                    {
                        dicttestlist[j].SampleType = dt.Rows[0]["SampleType"].ToString();
                    }
                    if (datest == null)
                    {
                        list.Add(dicttestlist[j]);
                    }
                }
            }

            this.gvLisrequest.DataSource = list;

        }

        #endregion

    }
}
