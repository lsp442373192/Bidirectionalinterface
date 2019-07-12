using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.Interface.Dao;
using Daan.Interface.BLL;
using Daan.Interface.Util;
using System.Collections;
using Daan.Interface.Entity;
using System.Configuration;
using System.Xml;

namespace Daan.LIMS.Manage
{
    public partial class FrmDaanItem : FrmBase
    {
        #region property
        DAConfigBLL configBll = new DAConfigBLL();
        DADicttestitemBLL dicttestitemBll = new DADicttestitemBLL();
        BackgroundWorker worker;
        private bool isSync = false;
        //表头全选全不选CheckBox
        CheckBox HeaderCheckBox = null;
        #endregion

        public FrmDaanItem()
        {
            InitializeComponent();
            #region >>> fenghp 绘制表头全选反选CheckBox 注册事件
            if (!this.DesignMode)
            {
                //实例化一个CheckBox
                HeaderCheckBox = new CheckBox();
                HeaderCheckBox.Size = new Size(15, 15);
                //添加到列表
                this.gvDaanItem.Controls.Add(HeaderCheckBox);
                //当CheckBox有焦点时释放键时发生
                HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
                //单击CheckBox
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                //单元格状态变化时
                gvDaanItem.CurrentCellDirtyStateChanged += new EventHandler(gvDaanItem_CurrentCellDirtyStateChanged);
                //绘制单元格时发生
                gvDaanItem.CellPainting += new DataGridViewCellPaintingEventHandler(gvDaanItem_CellPainting);
            }
            #endregion

            #region >>> fenghp 注册异步事件
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            #endregion
        }
        #region >>> fenghp 事件
        private void FrmDaanItem_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnsynchro_Click(object sender, EventArgs e)
        {
            if (ShowMessageHelper.ShowBoxMsg("是否要同步数据?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //异步执行开始
            worker.RunWorkerAsync();

            //显示进度窗体
            FrmProgressBar frm = new FrmProgressBar(this.worker);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
            //异步处理完将改变isSync值，以弹出提示
            if (isSync)
            {
                ShowMessageHelper.ShowBoxMsg("数据同步成功!");
                isSync = false;
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("数据同步失败,请检查系统配置!");
            }
            BindData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow Row in gvDaanItem.Rows)
            {
                if (((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value != null)
                {
                    if (((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value.ToString() == "True")
                    {
                        sb.Append(int.Parse(Row.Cells["Id"].Value.ToString()));
                        sb.Append(",");
                    }
                }
            }
            if (sb.ToString() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("请选择要删除的行!");
                return;
            }
            try
            {
                if (ShowMessageHelper.ShowBoxMsg("是否要删除选定的数据?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                string idsStr = sb.ToString().TrimEnd(',');
                //删除表数据
                if (dicttestitemBll.DeleteDADicttestitem(idsStr))
                {
                    ShowMessageHelper.ShowBoxMsg("删除成功");
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("删除失败");
                }
                BindData();

            }
            catch
            {
                ShowMessageHelper.ShowBoxMsg("操作出错");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData();

        }
        //格式化列表值
        private void gvDaanItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvDaanItem.Columns[e.ColumnIndex];

            if (clmCurren.Name == "Isgroup")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "单项";
                    }
                    else
                    {
                        e.Value = "组合";
                    }

                }

            }
        }
        //按下enter时查找数据
        private void KeyDown_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindData();
            }
        }
        //行头显示行号
        private void gvDaanItem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvDaanItem.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvDaanItem.RowHeadersDefaultCellStyle.Font, rectangle, gvDaanItem.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void gvDaanItem_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvDaanItem.RowHeadersWidth = (gvDaanItem.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }
        #endregion

        #region >>> fenghp 数据绑定

        private void BindData()
        {
            Hashtable ht = new Hashtable();
            ht.Add("strKey", tbxSearchKey.Text.ToString());
            gvDaanItem.AutoGenerateColumns = false;
            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<DADicttestitem> list = new BindingCollection<DADicttestitem>();
            foreach (DADicttestitem testitem in dicttestitemBll.SelectDADicttestitem(ht))
            {
                list.Add(testitem);
            }
            bsDaanItem.DataSource = list;
            gvDaanItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //冻结首列
            gvDaanItem.Columns[0].Frozen = true;
            lblRecord.Text = string.Format("共 {0} 条记录", list.Count);
        }
        #endregion

        #region>>> fenghp 表头全选反选用到的方法
        private void gvDaanItem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvDaanItem.CurrentCell is DataGridViewCheckBoxCell)
                gvDaanItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            //当CheckBox有焦点时按下空格，选中或反选
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void gvDaanItem_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }
        //定位checkbox的位置
        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            Rectangle oRectangle = this.gvDaanItem.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point();
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;
            HeaderCheckBox.Location = oPoint;
        }
        //单击checkbox
        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            //循环所有记录，选中的变为不选未选的变为选中
            foreach (DataGridViewRow Row in gvDaanItem.Rows)
            {
                if ((bool)((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).EditedFormattedValue)
                {
                    ((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value = false;
                }
                else
                {
                    ((DataGridViewCheckBoxCell)Row.Cells["chkSelect"]).Value = true;
                }
            }
            gvDaanItem.RefreshEdit();
        }
        #endregion

        #region >>> fenghp 调用webservice接口同步数据

        /// <summary>
        /// 异步处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //需要执行的代码
            DoSynchro();
        }
        //开始同步
        private void DoSynchro()
        {
            try
            {
                if (SystemConfig.Config != null && SystemConfig.UserInfo != null)
                {
                    string strSideCode = SystemConfig.Config.Sitecode;
                    string strUrl = SystemConfig.Config.Address;//调用webservice地址
                    string username = SystemConfig.Config.Username; //登录用户名
                    string password = SystemConfig.Config.Password; //登录用户密码
                    string sid = SystemConfig.UserInfo.SID;
                    //如果SID为空，调用Login方法重新获取SID
                    if (sid == null || sid == string.Empty)
                    {
                        //设置调用webservice登录方法的参数
                        string[] par = new string[] { strSideCode, username, password, SystemConfig.UserInfo.UserName };
                        //返回登录验证信息:1|SID,0|errorMsg
                        string[] loginMsg = WebServiceUtils.ExecuteMethod("Login", par).Split('|');

                        if (loginMsg[0] == "0") //登录失败     
                        {
                            //ShowMessageHelper.ShowBoxMsg("同步失败,请检查系统配置!" + loginMsg[1].ToString());

                        }
                        sid = loginMsg[1].ToString();
                        //保存新的SID
                        LoginUserInfo loginuserInfo = new LoginUserInfo();
                        loginuserInfo = SystemConfig.UserInfo;
                        loginuserInfo.SID = sid;
                        SystemConfig.UserInfo = loginuserInfo;
                    }
                    //设置SID为调用webservice获取项目方法的参数
                    //返回信息
                    string[] testItemInfo = WebServiceUtils.ExecuteMethod("GetDictTestItem",new string[] { sid }).Split('|');
                    if (testItemInfo.Length == 1)
                    {
                        //ShowMessageHelper.ShowBoxMsg("同步失败,请检查系统配置!" + testItemInfo[1].ToString());

                    }
                    DataSet ds = XMLHelper.CXmlToDataSet(testItemInfo[1].ToString());

                    if (ds == null || ds.Tables.Count <= 0)
                    {
                        //return;
                    }
                    DataTable dtdatarow = ds.Tables["DATA_ROW"];
                    Hashtable ht = new Hashtable();
                    ht["DATA_ROW"] = dtdatarow;
                    bool result = dicttestitemBll.InsertDADicttestitem(ht);
                    if (result)
                    {
                        isSync = true;
                        //ShowMessageHelper.ShowBoxMsg("数据同步成功!");
                    }
                    else
                    {
                        //ShowMessageHelper.ShowBoxMsg("数据同步失败!");
                    }
                }
                else
                {
                    //ShowMessageHelper.ShowBoxMsg("同步失败,请检查服务端系统参数配置!");
                }
            }
            catch
            {
                //ShowMessageHelper.ShowBoxMsg("同步的过程中发生了异常!");
            }
        }
        #endregion


    }
}
