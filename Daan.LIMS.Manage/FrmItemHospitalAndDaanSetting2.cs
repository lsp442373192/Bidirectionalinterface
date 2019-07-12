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
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.Util;

namespace Daan.LIMS.Manage
{
    public partial class FrmItemHospitalAndDaanSetting2 : Form
    {
        #region property
        VDAListestsBLL dalisttestsBll = new VDAListestsBLL();
        DADicttestitemBLL dicttestitemBll = new DADicttestitemBLL();
        DATestmapBLL testmapBll = new DATestmapBLL();
        //医院项目
        private List<VDAListests> cacheVDAList = new List<VDAListests>();
        //达安项目
        private List<DADicttestitem> cacheDaList = new List<DADicttestitem>();
        //对照的达安项目
        private List<DADicttestitem> cacheInDaList = new List<DADicttestitem>();
        //项目对照表
        private List<DATestmap> cacheMapList = new List<DATestmap>();
        //达安组合对明细
        private DataTable cacheGroupTestdetail = new DataTable();

        #endregion

        #region >>>> zhouy 页面事件
        public FrmItemHospitalAndDaanSetting2(DataTable _cacheGroupTestdetail)
        {
            InitializeComponent();


            cacheGroupTestdetail = _cacheGroupTestdetail;

            gvGroupHospital.AutoGenerateColumns = false;
            gvItemHospital.AutoGenerateColumns = false;
            gvGroupDaan.AutoGenerateColumns = false;
            gvItemDaan.AutoGenerateColumns = false;

            //获取基础数据
            cacheVDAList = dalisttestsBll.GetDaListestsList(null);
            cacheDaList = dicttestitemBll.SelectDADicttestitem(null);



        }

        private void FrmItemHospitalAndDaanSetting_Load(object sender, EventArgs e)
        {
            //获取当前用户编号
            if (SystemConfig.UserInfo != null)
            {
                //只有管理员可以对照
                if (SystemConfig.UserInfo.UserCode == "admin")
                {
                    btnEdit.Enabled = true;
                }
            }
            cacheMapList = new DATestmapBLL().GetDATestmapList(null);
            //初始化绑定数据
            BindDataHospitalGroup(string.Empty);
            BindDataHospitalItem(string.Empty);
            BindDataDaanGroup(string.Empty);
            BindDataDaanItem(string.Empty);
        }
        //对照组合
        private void btnSaveGroup_Click(object sender, EventArgs e)
        {
            //验证
            if (gvGroupHospital.SelectedRows.Count == 0) { ShowMessageHelper.ShowBoxMsg("请选择要保存对照的医院组合!"); return; }
            if (gvGroupDaan.SelectedRows.Count == 0) { ShowMessageHelper.ShowBoxMsg("请选择要保存对照的达安组合!"); return; }
            DataGridViewRow dr = gvGroupHospital.SelectedRows[0];
            int rowindex = dr.Index;
            if (Save(dr, gvGroupDaan.SelectedRows[0]))
            {
                BindDataHospitalGroup(string.Empty);
                gvGroupHospital.Rows[rowindex].Selected = true;
            }
        }
        //取消组合对照
        private void btnCancelGroup_Click(object sender, EventArgs e)
        {
            if (gvGroupHospital.SelectedRows.Count <= 0) { ShowMessageHelper.ShowBoxMsg("请选择要取消对照的医院组合!"); return; }
            VDAListests _test = gvGroupHospital.SelectedRows[0].DataBoundItem as VDAListests;
            if (!_test.IsSelect) { ShowMessageHelper.ShowBoxMsg("您选择的组合还没有对照!"); return; }
            int rowindex = gvGroupHospital.SelectedRows[0].Index;

            if (Cencel(_test))
            {
                BindDataHospitalGroup(string.Empty);
                bsHospitalGroup.Position = rowindex;
                gvGroupHospital.Rows[rowindex].Selected = false;
                gvGroupDaan.ClearSelection();
            }
        }
        //对照明细项目
        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证
            if (gvItemHospital.SelectedRows.Count == 0) { ShowMessageHelper.ShowBoxMsg("请选择要保存对照的医院项目!"); return; }
            if (gvItemDaan.SelectedRows.Count == 0) { ShowMessageHelper.ShowBoxMsg("请选择要保存对照的达安项目!"); return; }
            DataGridViewRow dr = gvItemHospital.SelectedRows[0];
            int rowindex = dr.Index;
            if (Save(dr, gvItemDaan.SelectedRows[0]))
            {
                BindDataHospitalItem(string.Empty);
                bsHospitalItem.Position = rowindex;
                gvItemHospital.Rows[rowindex].Selected = true;
            }
        }



        //取消明细项目对照
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (gvItemHospital.SelectedRows.Count <= 0) { ShowMessageHelper.ShowBoxMsg("请选择要取消对照的医院项目!"); return; }
            VDAListests _test = gvItemHospital.SelectedRows[0].DataBoundItem as VDAListests;
            if (!_test.IsSelect) { ShowMessageHelper.ShowBoxMsg("您选择的项目还没有对照!"); return; }
            int rowindex = gvItemHospital.SelectedRows[0].Index;

            if (Cencel(_test))
            {
                BindDataHospitalItem(string.Empty);
                bsHospitalItem.Position = rowindex;
                gvItemHospital.Rows[rowindex].Selected = false;
                gvItemDaan.ClearSelection();
            }
        }

        private bool Cencel(VDAListests _test)
        {
            bool b = true;
            try
            {
                if (ShowMessageHelper.ShowBoxMsg("您是否要取消该项目的对照关系?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;
                if (testmapBll.DelTestmapByID(_test.Testcode) > 0)
                {
                    ShowMessageHelper.ShowBoxMsg("取消对照成功!");
                    cacheMapList = new DATestmapBLL().GetDATestmapList(null);
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("取消对照失败!");
                    b = false;
                }
            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg("取消对照出错:" + ex.Message);
                b = false;
            }
            return b;
        }

        /// <summary>对照项目
        /// 
        /// </summary>
        /// <param name="Hrow">医院选中行</param>
        /// <param name="Drow">达安选中行</param>
        /// <returns>是否成功</returns>
        private bool Save(DataGridViewRow Hrow, DataGridViewRow Drow)
        {
            bool b = true;
            try
            {
                VDAListests Hosptest = Hrow.DataBoundItem as VDAListests;
                DADicttestitem Daantest = Drow.DataBoundItem as DADicttestitem;
                List<DATestmap> testmapList = new List<DATestmap>();
                DATestmap testmap = new DATestmap();
                //取出列表值，用于保存
                testmap.Customertestcode = Hosptest.Testcode;
                testmap.Customertestname = Hosptest.Testname;
                testmap.Datestcode = Daantest.Datestcode;
                testmap.Datestname = Daantest.Datestname;
                testmapList.Add(testmap);
                if (testmapBll.SaveDATestmapList(testmapList))
                {
                    ShowMessageHelper.ShowBoxMsg("保存对照成功!");
                    cacheMapList = new DATestmapBLL().GetDATestmapList(null);
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("保存对照失败!");
                    b = false;
                }
            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg("保存对照出错:" + ex.Message);
                b = false;
            }
            return b;
        }
        //修改:启用按钮
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSaveGroup.Enabled = true;
            btnCancelGroup.Enabled = true;
        }

        #region >>>> zhouy  检索项目
        //搜索医院组合
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            string key = tbxFilter.Text.Trim();
            BindDataHospitalGroup(key.ToUpper());
        }
        //搜索达安组合
        private void tbxDaanFilter_TextChanged(object sender, EventArgs e)
        {
            string key = tbxDaanFilter.Text.Trim();
            BindDataDaanGroup(key.ToUpper());
        }
        //搜索医院明细项
        private void tbItemHospital_TextChanged(object sender, EventArgs e)
        {
            string key = tbItemHospital.Text.Trim();
            BindDataHospitalItem(key.ToUpper());
        }
        //搜索达安明细项
        private void tbItemDaan_TextChanged(object sender, EventArgs e)
        {
            string key = tbItemDaan.Text.Trim();
            BindDataDaanItem(key.ToUpper());
        }
        #endregion

        #region>>> fenghp 格式化列表显示值

        private void gvGruopHospital_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvGroupHospital.Columns[e.ColumnIndex];

            if (clmCurren.Name == "Group")
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
            if (clmCurren.Name == "IsSelect")
            {
                if ((bool)e.Value)
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.PaleGreen;
                    gvGroupHospital.Rows[e.RowIndex].DefaultCellStyle = d;
                }
            }
        }

        private void gvItemHospital_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvItemHospital.Columns[e.ColumnIndex];

            if (clmCurren.Name == "gvMapHospitalGroup")
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

            if (clmCurren.Name == "IsSelected")
            {
                if ((bool)e.Value)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.PaleGreen;
                    gvItemHospital.Rows[e.RowIndex].DefaultCellStyle = style;
                }
            }
        }

        private void gvGroupDaan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvGroupDaan.Columns[e.ColumnIndex];

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

        private void gvItemDaan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvItemDaan.Columns[e.ColumnIndex];

            if (clmCurren.Name == "gvMapDaanIsGroup")
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
        #endregion

        #region >>> fenghp 绘制行号
        //行头显示行号
        private void gvGroupHospital_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvGroupHospital.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvGroupHospital.RowHeadersDefaultCellStyle.Font, rectangle, gvGroupHospital.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //行头显示行号
        private void gvGroupDaan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvGroupDaan.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvGroupDaan.RowHeadersDefaultCellStyle.Font, rectangle, gvGroupDaan.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //行头显示行号
        private void gvItemHospital_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvItemHospital.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvItemHospital.RowHeadersDefaultCellStyle.Font, rectangle, gvItemHospital.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }
        //行头显示行号
        private void gvItemDaan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvItemDaan.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvItemDaan.RowHeadersDefaultCellStyle.Font, rectangle, gvItemDaan.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }
        //滚动时设置行头的宽度
        private void gvGroupHospital_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvGroupHospital.RowHeadersWidth = (gvGroupHospital.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }
        //滚动时设置行头的宽度
        private void gvGroupDaan_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvGroupDaan.RowHeadersWidth = (gvGroupDaan.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }

        //滚动时设置行头的宽度
        private void gvItemHospital_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvItemHospital.RowHeadersWidth = (gvItemHospital.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }
        //滚动时设置行头的宽度
        private void gvItemDaan_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvItemDaan.RowHeadersWidth = (gvItemDaan.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }
        #endregion


        #endregion

        #region >>>> zhouy 绑定gridview

        #region >>> fenghp 绑定医院组合列表
        /// <summary>
        /// 绑定医院组合列表
        /// </summary>
        /// <param name="Filter"></param>
        private void BindDataHospitalGroup(string Filter)
        {
            List<VDAListests> _list = cacheVDAList.FindAll(c => c.Isgroup == "1");
            if (Filter != "")
            {
                //过滤
                _list = _list.FindAll(
                    c => (c.Testcode != null && c.Testcode.ToUpper().Contains(Filter))
                        || (c.Testname != null && c.Testname.ToUpper().Contains(Filter))
                        || (c.Shortname != null && c.Shortname.ToUpper().Contains(Filter))
                        || (c.Engshortname != null && c.Engshortname.ToUpper().Contains(Filter)));
            }

            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<VDAListests> list = new BindingCollection<VDAListests>();
            foreach (VDAListests vdl in _list)
            {
                vdl.IsSelect = false;
                //存在对照表 则选中
                if (cacheMapList.FindIndex(c => c.Customertestcode == vdl.Testcode) > 0)
                {
                    vdl.IsSelect = true;
                }
                list.Add(vdl);


            }
            bsHospitalGroup.DataSource = list;
            //gvGroupHospital.DataSource = list;
            //gvGroupHospital.Columns[0].Frozen = true;
            ////gvGruopHospital.Rows[0].Height = 25;

            gvGroupHospital.ClearSelection();
            gvGroupHospital.TabStop = false;
        }
        #endregion

        #region >>> fenghp 绑定医院单项列表
        /// <summary>
        /// 绑定医院单项列表
        /// </summary>
        /// <param name="Filter"></param>
        private void BindDataHospitalItem(string Filter)
        {
            List<VDAListests> _list = new List<VDAListests>();

            //选中组合则在显示组合下的明细项
            //未选中组合则在所有明细项
            if (gvGroupHospital.SelectedRows.Count <= 0 || bsHospitalItem.DataSource == null)
            {
                _list = cacheVDAList.FindAll(c => c.Isgroup == "0");
            }
            else
            {
                gvGruopHospital_CellClick(null, null);

                _list = (bsHospitalItem.DataSource as BindingCollection<VDAListests>).ToList();
            }

            if (Filter != "")
            {
                _list = _list.FindAll(
                    c => (c.Testcode != null && c.Testcode.ToUpper().Contains(Filter))
                        || (c.Testname != null && c.Testname.ToUpper().Contains(Filter))
                        || (c.Shortname != null && c.Shortname.ToUpper().Contains(Filter))
                        || (c.Engshortname != null && c.Engshortname.ToUpper().Contains(Filter)));
            }

            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<VDAListests> list = new BindingCollection<VDAListests>();
            foreach (VDAListests vdl in _list)
            {
                //存在对照表 则选中
                if (cacheMapList.FindIndex(c => c.Customertestcode == vdl.Testcode) > 0)
                {
                    vdl.IsSelect = true;
                }
                list.Add(vdl);
            }
            bsHospitalItem.DataSource = list;

            //gvItemHospital.DataSource = list;
            //gvItemHospital.Columns[0].Frozen = true;
            ////gvItemHospital.Rows[0].Height = 25;

            gvItemHospital.ClearSelection();
            gvItemHospital.TabStop = false;
        }
        #endregion

        #region >>> fenghp 绑定右上角达安项目列表
        private void BindDataDaanGroup(string Filter)
        {
            List<DADicttestitem> _list = cacheDaList.FindAll(c => c.Isgroup == "1");
            if (Filter != "")
            {
                //过滤
                _list = _list.FindAll(
                    c => (c.Fastcode != null && c.Fastcode.ToUpper().Contains(Filter))
                    || (c.Datestcode != null && c.Datestcode.ToUpper().Contains(Filter))
                    || (c.Datestname != null && c.Datestname.ToUpper().Contains(Filter))
                    || (c.Engshortname != null && c.Engshortname.ToUpper().Contains(Filter))
                    || (c.Englishname != null && c.Englishname.ToUpper().Contains(Filter)));
            }

            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<DADicttestitem> list = new BindingCollection<DADicttestitem>();
            foreach (DADicttestitem testitem in _list) { list.Add(testitem); }
            bsDaGroup.DataSource = list;

            gvGroupDaan.ClearSelection();
            gvGroupDaan.TabStop = false;
        }
        #endregion

        #region >>> fenghp 绑定右下角角达安项目列表
        private void BindDataDaanItem(string Filter)
        {
            List<DADicttestitem> _list = new List<DADicttestitem>();
            //选中组合则在显示组合下的明细项
            //未选中组合则在所有明细项
            if (gvGroupDaan.SelectedRows.Count <= 0 || bsDaItem.DataSource == null)
            {
                _list = cacheDaList.FindAll(c => c.Isgroup == "0");
            }
            else
            {
                gvGroupDaan_CellClick(null, null);
                _list = (bsDaItem.DataSource as BindingCollection<DADicttestitem>).ToList();
            }
            if (Filter != "")
            {
                //过滤
                _list = _list.FindAll(
                    c => (c.Datestcode != null && c.Datestcode.ToUpper().Contains(Filter))
                    || (c.Datestname != null && c.Datestname.ToUpper().Contains(Filter))
                    || (c.Engshortname != null && c.Engshortname.ToUpper().Contains(Filter))
                    || (c.Englishname != null && c.Englishname.ToUpper().Contains(Filter)));
            }

            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<DADicttestitem> list = new BindingCollection<DADicttestitem>();
            foreach (DADicttestitem testitem in _list) { list.Add(testitem); }
            bsDaItem.DataSource = list;
            gvItemDaan.ClearSelection();
            gvItemDaan.TabStop = false;
        }
        #endregion


        #endregion

        #region >>>> zhouy 点击组合 显示明细/点击医院项目 对应达安项目
        /// 点击医院组合时，过滤出组合下的明细
        private void gvGruopHospital_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvGroupHospital.SelectedRows.Count <= 0) { return; }
            VDAListests grouptest = gvGroupHospital.SelectedRows[0].DataBoundItem as VDAListests;

            List<VDAListests> _list = new VDAListestsBLL().GetVDaListestsresultByCode(new Hashtable() { { "Testcode", grouptest.Testcode } });
            BindingCollection<VDAListests> list = new BindingCollection<VDAListests>();
            foreach (VDAListests item in _list)
            {
                item.Testcode = item.Subtestcode;
                item.Testname = item.Subtestname;
                item.Isgroup = "0";
                //存在对照表，勾选加底色
                if (cacheMapList.FindIndex(c => c.Customertestcode == item.Testcode) > 0) { item.IsSelect = true; }

                list.Add(item);
            }
            bsHospitalItem.DataSource = list;
            gvItemHospital.ClearSelection();

            //匹配组合对应
            gvGroupDaan.ClearSelection();
            if (!grouptest.IsSelect) { return; }//没有对照好

            List<DADicttestitem> _dalist = dicttestitemBll.SelectDADicttestitemByHospCode(new Hashtable() { { "customertestcode", grouptest.Testcode } });
            if (_dalist.Count <= 0) { return; }//找不到对照的项目

            BindingCollection<DADicttestitem> dalist = bsDaGroup.DataSource as BindingCollection<DADicttestitem>;
            if (dalist == null || dalist.Count <= 0) { return; }//列表中无项目

            int i = dalist.ToList().FindIndex(c => c.Datestcode == _dalist[0].Datestcode);
            if (i >= 0)
            {
                //索引相同bs的 Position就不会选中，改用gv的selected
                if (bsDaGroup.Position == i)
                {
                    gvGroupDaan.Rows[i].Selected = true;
                }
                else
                {
                    bsDaGroup.Position = i;
                }
            }

        }

        /// 点击达安组合时，过滤出组合下的明细
        private void gvGroupDaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvGroupDaan.SelectedRows.Count <= 0) { return; }
            string GroupCode = gvGroupDaan.SelectedRows[0].Cells["DaanGroupCode"].Value.ToString();
            DataRow[] drs = cacheGroupTestdetail.Select(string.Format("GroupCode='{0}'", GroupCode));
            BindingCollection<DADicttestitem> _list = new BindingCollection<DADicttestitem>();
            foreach (DataRow row in drs)
            {
                bool Exists = false;
                foreach (DADicttestitem test in cacheDaList)
                {
                    if (test.Datestcode == row["TestCode"].ToString())
                    {
                        _list.Add(test.Copy<DADicttestitem>());
                        Exists = true;
                        break;
                    }
                }
                //组合下的明细找不到则 添加一条新数据显示
                //提示此代码的项目不存在本地
                if (!Exists)
                {
                    DADicttestitem _test = new DADicttestitem();
                    _test.IsDelete = true;//不存在本地，红色底显示
                    _test.Isgroup = "0";
                    _test.Datestcode = row["TestCode"].ToString();
                    _test.Datestname = string.Format("项目[{0}]不存在本地，请先到【达安项目】页面[同步]项目", row["TestName"].ToString());
                    _list.Add(_test);
                }
            }

            bsDaItem.DataSource = _list;
            gvItemDaan.ClearSelection();
        }

        /// 选中医院明细项目，选中对应的达安明细项目,没有则不选中
        private void gvItemHospital_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gvItemDaan.ClearSelection();

            if (gvItemHospital.SelectedRows.Count <= 0) return;//无选中行

            VDAListests _listtest = gvItemHospital.SelectedRows[0].DataBoundItem as VDAListests;
            if (!_listtest.IsSelect) { return; }//没有对照好

            List<DADicttestitem> _list = dicttestitemBll.SelectDADicttestitemByHospCode(new Hashtable() { { "customertestcode", _listtest.Testcode } });
            if (_list.Count <= 0) { return; }//找不到对照的项目

            BindingCollection<DADicttestitem> list = bsDaItem.DataSource as BindingCollection<DADicttestitem>;
            if (list == null || list.Count <= 0) { return; }//列表中无项目

            int i = list.ToList().FindIndex(c => c.Datestcode == _list[0].Datestcode);
            if (i >= 0)
            {
                //索引相同bs的 Position就不会选中，改用gv的selected
                if (bsDaItem.Position == i)
                {
                    gvItemDaan.Rows[i].Selected = true;
                }
                else
                {
                    bsDaItem.Position = i;
                }
            }
        }
        #endregion

        #region >>>> zhouy 显示明细项目
        /// 显示医院所有明细项
        private void btnViewHospitalAll_Click(object sender, EventArgs e)
        {
            gvGroupHospital.ClearSelection();
            BindDataHospitalItem(string.Empty);
        }

        /// 显示达安所有明细项
        private void btnViewDaanAll_Click(object sender, EventArgs e)
        {
            gvGroupDaan.ClearSelection();
            BindDataDaanItem(string.Empty);
        }
        #endregion >>>> zhouy

        /// 检查对照项目
        private void btnCheckTest_Click(object sender, EventArgs e)
        {
            string str = "";
            List<DATestmap> map = new DATestmapBLL().GetDATestmapCheckList();
            if (map.Count == 0) { ShowMessageHelper.ShowBoxMsg("没找到异常的对照项目，请到同步【达安项目】窗口 点击[同步]之后再来确认查看"); return; }

            foreach (DATestmap item in map)
            {
                str += string.Format("医院项目 [{0}] 编码[{1}] 需要重新对应对照\n",item.Customertestname,item.Customertestcode);
            }
            ShowMessageHelper.ShowBoxMsg(str);
        }








    }
}
