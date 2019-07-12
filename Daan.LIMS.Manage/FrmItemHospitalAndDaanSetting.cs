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
    public partial class FrmItemHospitalAndDaanSetting : Form
    {
        #region property
        VDAListestsBLL dalisttestsBll = new VDAListestsBLL();
        DADicttestitemBLL dicttestitemBll = new DADicttestitemBLL();
        DATestmapBLL testmapBll = new DATestmapBLL();
        private string strColumnName = string.Empty;
        private string strOrderType = string.Empty;
        //医院项目
        private List<VDAListests> cacheVDAList = new List<VDAListests>();
        //达安项目
        private List<DADicttestitem> cacheDaList = new List<DADicttestitem>();
        //对照的达安项目
        private List<DADicttestitem> cacheInDaList = new List<DADicttestitem>();
        //项目对照表
        private List<DATestmap> cacheMapList = new List<DATestmap>();
        private string _testcode = string.Empty;
        public string Testcode
        {
            get { return _testcode; }
            set { _testcode = value; }
        }
        #endregion

        #region >>> fenghp 页面事件
        public FrmItemHospitalAndDaanSetting()
        {
            InitializeComponent();
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
            //初始化绑定数据
            BindDataHospital();
            BindDataDaan();
            //初始化选择行
            if (Testcode != string.Empty)
            {
                for (int i = 0; i < gvItemHospital.Rows.Count; i++)
                {
                    if (gvItemHospital.Rows[i].Cells["TestCode"].Value.ToString() == Testcode)
                    {
                        gvItemHospital.Rows[i].Selected = true;
                        gvItemHospital.FirstDisplayedScrollingRowIndex = i;
                    }
                }
            }
        }
        //定位:根据名称找到右上角对应的项目
        private void btnPosition_Click(object sender, EventArgs e)
        {
            if (gvItemHospital.Rows.Count <= 0)
            {
                ShowMessageHelper.ShowBoxMsg("请选择要定位的医院项目!");
                return;
            }
            DataGridViewRow selRow = gvItemHospital.SelectedRows[0];
            if (selRow == null)
            {
                ShowMessageHelper.ShowBoxMsg("请选择要定位的医院项目!");
                return;
            }
            if (selRow.Cells["TestName"].Value == null || selRow.Cells["TestName"].Value.ToString() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("无法定位相匹配的达安项目,医院项目名称为空!");
                return;
            }
            //获取要定位的项目名字
            string testnameStr = selRow.Cells["TestName"].Value.ToString();
            //获取最匹配的值
            decimal maxDe = 0;
            decimal[] array = new decimal[gvDaanItem.Rows.Count];
            for (int i = 0; i < gvDaanItem.Rows.Count; i++)
            {
                array[i] = GetSimilarityWith(testnameStr, gvDaanItem.Rows[i].Cells["gvDaanTestName"].Value.ToString());
                //获取数组最大值，则为最匹配值
                maxDe = array.Max();
            }

            //若最匹配值为0，则没有匹配项
            if (maxDe == 0)
            {
                ShowMessageHelper.ShowBoxMsg("无法定位相匹配的达安项目,请人工进行对照!");
                return;
            }
            //先清空再选中
            gvDaanItem.ClearSelection();
            for (int i = 0; i < array.Length; i++)
            {
                if (maxDe == array[i])
                {
                    gvDaanItem.Rows[i].Selected = true;
                    gvDaanItem.FirstDisplayedScrollingRowIndex = i;

                }
            }
        }
        //对照：把需要保存的匹配信息加到下面两个列表后，保存到数据库表DATestmap
        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证
            if (gvMapHospital.Rows.Count == 0 || gvMapDaan.Rows.Count == 0)
            {
                ShowMessageHelper.ShowBoxMsg("请选择要保存对照的项目!");
                return;
            }

            //单项只能对照一个单项
            if (gvMapHospital.Rows[0].Cells["gvMapHospitalGroup"].Value.ToString() =="0" && gvMapDaan.Rows.Count != 1)
            {
                ShowMessageHelper.ShowBoxMsg("医院单项只能对应一个达安单项!");
                return;
            }

            try
            {
                List<DATestmap> testmapList = new List<DATestmap>();
                for (int i = 0; i < gvMapDaan.Rows.Count; i++)
                {
                    DATestmap testmap = new DATestmap();
                    //已经存在对应 修改操作
                    //if (gvMapHospital.Rows[0].Cells[0].Value != null)
                    //{
                    //    testmap.Testmapid = Convert.ToDecimal(gvMapHospital.Rows[0].Cells[0].Value.ToString());
                    //}
                    //取出列表值，用于保存
                    testmap.Customertestcode = gvMapHospital.Rows[0].Cells["gvMapHoapitalTestCode"].Value.ToString();
                    testmap.Customertestname = gvMapHospital.Rows[0].Cells["gvMapHoapitalTestName"].Value.ToString();
                    testmap.Datestcode = gvMapDaan.Rows[i].Cells["gvMapDaanDaTestCode"].Value.ToString();
                    testmap.Datestname = gvMapDaan.Rows[i].Cells["gvMapDaanDaTestName"].Value.ToString();
                    testmap.Createtime = DateTime.Now;
                    testmapList.Add(testmap);
                }
                if (testmapBll.SaveDATestmapList(testmapList))
                {
                    ShowMessageHelper.ShowBoxMsg("保存对照成功!");
                    doFilter();
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("保存对照失败!");
                }
            }
            catch(Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg("保存对照出错:"+ex.Message);
            }
        }
        //取消：删除一条匹配信息
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //验证
            if (gvMapHospital.Rows.Count <= 0)
            {
                ShowMessageHelper.ShowBoxMsg("该记录不存在对照关系!");
                return;
            }
            try
            {
                //已经存在对应 删除操作
                if (gvMapHospital.Rows[0].Cells[0].Value != null)
                {
                    if (ShowMessageHelper.ShowBoxMsg("您是否要取消该项目的对照关系?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    string testmapId = gvMapHospital.Rows[0].Cells["gvMapHoapitalTestCode"].Value.ToString();
                    if (testmapBll.DelTestmapByID(testmapId) > 0)
                    {
                        ShowMessageHelper.ShowBoxMsg("取消对照成功!");
                        doFilter();
                    }
                    else
                    {
                        ShowMessageHelper.ShowBoxMsg("取消对照失败!");
                    }

                }
                else
                {
                    //清空左右下列表
                    gvMapHospital.Rows.Clear();
                    gvMapDaan.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                ShowMessageHelper.ShowBoxMsg("取消对照出错:"+ex.Message);
            }

        }
        //修改:启用按钮
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnPosition.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        //选择不同的项目把已经匹配好的信息填充到下面列表
        private void gvItemHospital_SelectionChanged(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection selRow = gvItemHospital.SelectedRows;
            if (selRow.Count < 1)
            {
                return;
            }
            //先清空列表行
            gvMapHospital.Rows.Clear();
            gvMapDaan.Rows.Clear();
            //从上面表格获取行值添加到下面表格
            if (selRow[0] != null && selRow[0].Cells[0].Value != null)
            {
                //添加一行
                DataGridViewRow rowAdd = gvMapHospital.Rows[gvMapHospital.Rows.Add()];
                foreach (DataGridViewColumn col in gvItemHospital.Columns)
                {
                    rowAdd.Cells[col.Index].Value = selRow[0].Cells[col.Index].Value;
                }
                //冻结首列
                gvMapHospital.Columns[0].Frozen = true;

                //根据医院项目代码获取对照表信息再绑定达安项目
                if (selRow[0].Cells["TestCode"].Value != null)
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("customertestcode", selRow[0].Cells["TestCode"].Value.ToString());
                    bsDaanIn.DataSource = cacheInDaList = dicttestitemBll.SelectDADicttestitemByHospCode(ht);
                }
            }

            #region by fenghp delete(2012.12.29) 修改医院项目可以对应多个达安项目，删除此段
            //if (selRow[0].Cells["DATESTCODE"].Value != null)
            //{
            //    Hashtable ht = new Hashtable();
            //    ht.Add("Datestcode", selRow[0].Cells["DATESTCODE"].Value.ToString());
            //    gvDaanItem.AutoGenerateColumns = false;
            //    List<DADicttestitem> lstTestitem = dicttestitemBll.SelectDADicttestitem(ht);
            //    if (lstTestitem != null && lstTestitem.Count > 0)
            //    {

            //        DADicttestitem testitem = lstTestitem[0];
            //        DataGridViewRow rowAdd = gvMapDaan.Rows[gvMapDaan.Rows.Add()];
            //        rowAdd.Cells["gvMapDaanDatestCode"].Value = testitem.Datestcode;
            //        rowAdd.Cells["gvMapDaanDatestitemId"].Value = testitem.Datestitemid;
            //        rowAdd.Cells["gvMapDaanDatestName"].Value = testitem.Datestname;
            //        rowAdd.Cells["gvMapDaanEnglishName"].Value = testitem.Englishname;
            //        rowAdd.Cells["gvMapDaanEngshortName"].Value = testitem.Engshortname;
            //        rowAdd.Cells["gvMapDaanFastCode"].Value = testitem.Fastcode;
            //        rowAdd.Cells["gvMapDaanIsGroup"].Value = testitem.Isgroup;
            //        //rowAdd.Cells["gvMapDaanTestType"].Value = testitem.Testtype;
            //        rowAdd.Cells["gvMapDaanTestMethod"].Value = testitem.Testmethod;
            //    }
            //}
            #endregion

            RefreshTips();
        }
        //双击项目往下面列表加入数据
        private void gvItemHospital_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //双击表头
            if (e.RowIndex == -1)
            {
                return;
            }
            if (gvMapHospital.Rows.Count > 0)
            {
                return;
            }
            DataGridViewRow selRow = gvItemHospital.SelectedRows[0];
            if (selRow != null)
            {
                //添加一行
                DataGridViewRow rowAdd = gvMapHospital.Rows[gvMapHospital.Rows.Add()];
                foreach (DataGridViewColumn col in gvItemHospital.Columns)
                {
                    rowAdd.Cells[col.Index].Value = selRow.Cells[col.Index].Value;
                }
            }
            RefreshTips();
        }
        //双击项目往下面列表加入数据
        private void gvDaanItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //双击表头
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow selRow = gvDaanItem.SelectedRows[0];
            if (selRow == null) return;
            DADicttestitem curItem = (DADicttestitem)bsDaan.Current;
            //检查双击的项目是否已经存在
            foreach (DADicttestitem item in cacheInDaList)
            {
                if (item.Datestcode == curItem.Datestcode)
                {
                    ShowMessageHelper.ShowBoxMsg("该项目已存在!");
                    return;
                }
            }
            //不存在添加一行
            bsDaanIn.Add(curItem);
            RefreshTips();
        }
        //双击删除当前匹配
        private void gvMapDaan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //双击表头
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow selRow = gvMapDaan.SelectedRows[0];
            if (selRow != null)
            {
                //删除一行
                gvMapDaan.Rows.Remove(selRow);

            }
            RefreshTips();
        }

        //全文检索
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            doFilter();
        }
        private void tbxDaanFilter_TextChanged(object sender, EventArgs e)
        {
            doDaanFilter();
        }
        //仅显示组合/套餐
        private void chkIsgroup_CheckedChanged(object sender, EventArgs e)
        {
            doFilter();
        }

        #region>>> fenghp 格式化列表显示值
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
        private void gvItemHospital_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvItemHospital.Columns[e.ColumnIndex];

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
            if (clmCurren.Name == "TESTMAPID")
            {
                if (e.Value != null)
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.PaleGreen;
                    gvItemHospital.Rows[e.RowIndex].DefaultCellStyle = d;
                }
            }
        }

        private void gvMapHospital_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvMapHospital.Columns[e.ColumnIndex];

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
        }

        private void gvMapDaan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvMapDaan.Columns[e.ColumnIndex];

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
        private void gvItemHospital_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvItemHospital.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvItemHospital.RowHeadersDefaultCellStyle.Font, rectangle, gvItemHospital.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //行头显示行号
        private void gvDaanItem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvDaanItem.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvDaanItem.RowHeadersDefaultCellStyle.Font, rectangle, gvDaanItem.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //行头显示行号
        private void gvMapHospital_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvMapHospital.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvMapHospital.RowHeadersDefaultCellStyle.Font, rectangle, gvMapHospital.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }
        //行头显示行号
        private void gvMapDaan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvMapDaan.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvMapDaan.RowHeadersDefaultCellStyle.Font, rectangle, gvMapDaan.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

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

        //改变窗体大小时调整提示的位置
        private void FrmItemHospitalAndDaanSetting_Resize(object sender, EventArgs e)
        {
            lblTips.Location = new System.Drawing.Point(gvMapDaan.Location.X, lblTips.Location.Y);
        }

        #endregion

        #region >>> fenghp 方法

        #region >>> fenghp 绑定左上角医院项目列表
        private void BindDataHospital()
        {
            Hashtable ht = new Hashtable();
            gvItemHospital.AutoGenerateColumns = false;
            #region 把存在对应关系的数据合并到序列里，再绑定
            //获取数据
            cacheVDAList = dalisttestsBll.GetDaListestsList(ht);
            List<VDAListests> List = cacheVDAList;
            cacheMapList = new DATestmapBLL().GetDATestmapList(ht);
            //保存多个对照的列表
            List<VDAListests> mulVL = new List<VDAListests>();
            int cacheCount = cacheVDAList.Count;
            for (int j = 0; j < cacheCount; j++)
            {
                VDAListests vdl = cacheVDAList[j];
                //选择存在对应关系的序列值
                var result = (from a in cacheMapList
                              where a.Customertestcode == vdl.Testcode
                              group a by new { a.Testmapid, a.Datestname, a.Datestcode, a.Customertestcode, a.Customertestname } into g
                              select new
                              {
                                  g.Key.Testmapid,
                                  g.Key.Datestname,
                                  g.Key.Datestcode,
                                  g.Key.Customertestcode,
                                  g.Key.Customertestname
                              }).ToArray();
                if (result.Length > 0)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        //if (i != 0)
                        //{
                        //    VDAListests dl = new VDAListests();
                        //    dl.Testmapid = vdl.Testmapid;
                        //    dl.Testcode = vdl.Testcode;
                        //    dl.Testname = vdl.Testname;
                        //    dl.Isgroup = vdl.Isgroup;
                        //    dl.Shortname = vdl.Shortname;
                        //    dl.Fastcode = vdl.Fastcode;
                        //    dl.Englishname = vdl.Englishname;
                        //    dl.Engshortname = vdl.Engshortname;
                        //    dl.Testtype = vdl.Testtype;
                        //    dl.Testmethod = vdl.Testmethod;
                        //    dl.Testmapid = result[i].Testmapid;
                        //    dl.Datestcode = result[i].Datestcode.ToString();
                        //    dl.Datestname = result[i].Datestname.ToString();
                        //    dl.Customertestcode = result[i].Customertestcode.ToString();
                        //    dl.Customertestname = result[i].Customertestname.ToString();
                        //    cacheVDAList.Add(dl);
                        //}
                        //else
                        //{
                        //    vdl.Testmapid = result[i].Testmapid;
                        //    vdl.Datestcode = result[i].Datestcode.ToString();
                        //    vdl.Datestname = result[i].Datestname.ToString();
                        //    vdl.Customertestcode = result[i].Customertestcode.ToString();
                        //    vdl.Customertestname = result[i].Customertestname.ToString();
                        //}

                        vdl.Testmapid = result[i].Testmapid;
                        vdl.Datestcode += i == result.Length - 1 ? result[i].Datestcode.ToString() : result[i].Datestcode.ToString() + " ,";
                        vdl.Datestname += i == result.Length - 1 ? result[i].Datestname.ToString() : result[i].Datestname.ToString() + " ,";
                        vdl.Customertestcode = result[i].Customertestcode.ToString();
                        vdl.Customertestname = result[i].Customertestname.ToString();
                    }
                }
            }
            #endregion
            //默认对序列按项目名字排序
            var v = from c in cacheVDAList orderby c.Testname select c;
            cacheVDAList = v.ToList();
            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<VDAListests> list = new BindingCollection<VDAListests>();
            foreach (VDAListests vdl in cacheVDAList)
            {
                list.Add(vdl);
            }
            bsItemHospital.DataSource = list;
            gvItemHospital.Columns[0].Frozen = true;
            gvItemHospital.Rows[0].Height = 25;
        }
        #endregion

        #region >>> fenghp 绑定右上角达安项目列表
        private void BindDataDaan()
        {
            Hashtable ht = new Hashtable();
            gvDaanItem.AutoGenerateColumns = false;
            cacheDaList = dicttestitemBll.SelectDADicttestitem(ht);
            //默认对序列按项目名字排序
            var v = from c in cacheDaList orderby c.Datestname select c;
            cacheDaList = v.ToList();
            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<DADicttestitem> list = new BindingCollection<DADicttestitem>();
            foreach (DADicttestitem testitem in cacheDaList)
            {
                list.Add(testitem);
            }
            bsDaan.DataSource = list;
        }
        #endregion

        #region >>> fenghp 左上角医院项目全文检索方法
        private void doFilter()
        {
            BindDataHospital();
            string exp = this.tbxFilter.Text.Trim();
            BindingCollection<VDAListests> newLst = new BindingCollection<VDAListests>();
            foreach (VDAListests item in bsItemHospital)
            {
                if (chkIsgroup.Checked == true)
                {
                    if ((((item.Datestcode != null && item.Datestcode.ToLower().Contains(exp.ToLower())) ||
                        (item.Englishname != null && item.Englishname.ToLower().Contains(exp.ToLower())) ||
                        (item.Datestname != null && item.Datestname.ToLower().Contains(exp.ToLower())) ||
                        (item.Testcode != null && item.Testcode.ToLower().Contains(exp.ToLower())) ||
                        (item.Testname != null && item.Testname.ToLower().Contains(exp.ToLower())) ||
                        (item.Fastcode != null && item.Fastcode.ToLower().Contains(exp.ToLower())))) &&
                        item.Isgroup != null && item.Isgroup == "1"
                        )
                    {
                        newLst.Add(item);
                    }
                }
                else
                {
                    if (((item.Datestcode != null && item.Datestcode.ToLower().Contains(exp.ToLower())) ||
                                           (item.Englishname != null && item.Englishname.ToLower().Contains(exp.ToLower())) ||
                                           (item.Datestname != null && item.Datestname.ToLower().Contains(exp.ToLower())) ||
                                           (item.Testcode != null && item.Testcode.ToLower().Contains(exp.ToLower())) ||
                                           (item.Testname != null && item.Testname.ToLower().Contains(exp.ToLower())) ||
                                           (item.Fastcode != null && item.Fastcode.ToLower().Contains(exp.ToLower())))
                                           )
                    {
                        newLst.Add(item);
                    }
                }
            }
            this.bsItemHospital.DataSource = newLst;
        }
        #endregion

        #region >>> fenghp 右上角达安项目全文检索方法
        private void doDaanFilter()
        {
            BindDataDaan();
            string exp = this.tbxDaanFilter.Text.Trim();
            BindingCollection<DADicttestitem> newLst = new BindingCollection<DADicttestitem>();
            foreach (DADicttestitem item in bsDaan)
            {
                if (((item.Fastcode != null && item.Fastcode.ToLower().Contains(exp.ToLower())) ||
                    (item.Datestcode != null && item.Datestcode.ToLower().Contains(exp.ToLower())) ||
                    (item.Englishname != null && item.Englishname.ToLower().Contains(exp.ToLower())) ||
                    (item.Datestname != null && item.Datestname.ToLower().Contains(exp.ToLower())) ||
                    (item.Fastcode != null && item.Fastcode.ToLower().Contains(exp.ToLower())))
                    )
                {
                    newLst.Add(item);
                }
            }
            this.bsDaan.DataSource = newLst;
        }
        #endregion

        #region >>>是否只显示组合
        private void IsgroupChang()
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[gvItemHospital.DataSource];
            if (chkIsgroup.Checked == true)
            {
                for (int i = 0; i < gvItemHospital.Rows.Count; i++)
                {
                    if (gvItemHospital.Rows[i].Cells["Group"].Value.ToString() == "0")
                    {
                        cm.SuspendBinding();//挂起数据的绑定,否则不能设置是否可见
                        gvItemHospital.Rows[i].Visible = false;
                        cm.ResumeBinding(); //恢复数据绑定

                    }
                }
            }
            else
            {
                doFilter();
            }
        }
        #endregion

        /// <summary>
        /// 获取两个字符串的相似度
        /// </summary>
        /// <param name="sourceString">第一个字符串</param>
        /// <param name="str">第二个字符串</param>
        /// <returns></returns>
        private decimal GetSimilarityWith(string sourceString, string str)
        {
            decimal Kq = 2;
            decimal Kr = 1;
            decimal Ks = 1;
            //将字符串转为Char数组进行比较
            char[] ss = sourceString.ToCharArray();
            char[] st = str.ToCharArray();

            //获取交集数量
            int q = ss.Intersect(st).Count();
            int s = ss.Length - q;
            int r = st.Length - q;

            return Kq * q / (Kq * q + Kr * r + Ks * s);
        }
        //右下角提示是否可见
        private void RefreshTips()
        {
            if (gvMapDaan.Rows.Count > 0)
            {
                lblTips.Visible = true;
            }
            else
            {
                lblTips.Visible = false;
            }
        }

        #endregion

        private void gvItemHospital_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 对第1列相同的行的相同单元格进行合并
            //if (e.ColumnIndex > 0 && e.ColumnIndex != 3 && e.ColumnIndex != 4 && e.RowIndex != -1)
            //{
            //    if (e.Value != null || e.RowIndex != gvItemHospital.RowCount)
            //    {
            //        string s = gvItemHospital.Rows[51].Cells["TestCode"].Value.ToString();
            //        string ss = gvItemHospital.Rows[50].Cells["TestCode"].Value.ToString();
            //        if (gvItemHospital.Rows[e.RowIndex].Cells[0].Value != null && gvItemHospital.Rows[e.RowIndex].Cells["TestCode"].Value == gvItemHospital.Rows[e.RowIndex + 1].Cells["TestCode"].Value)
            //        {
            //            using (
            //        Brush gridBrush = new SolidBrush(this.gvItemHospital.GridColor),
            //        backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            //            {
            //                using (Pen gridLinePen = new Pen(gridBrush))
            //                {
            //                    // 擦除原单元格背景
            //                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
            //                    /**/
            //                    ////绘制线条,这些线条是单元格相互间隔的区分线条,
            //                    ////因为我们只对列name做处理,所以datagridview自己会处理左侧和上边缘的线条
            //                    if (e.RowIndex != this.gvItemHospital.RowCount - 1)
            //                    {
            //                        try
            //                        {
            //                            if (e.Value.ToString() != this.gvItemHospital.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString())
            //                            {
            //                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
            //                                e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);//下边缘的线
            //                                //绘制值
            //                                if (e.Value != null)
            //                                {
            //                                    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
            //                                        Brushes.Crimson, e.CellBounds.X + 2,
            //                                        e.CellBounds.Y + 2, StringFormat.GenericDefault);
            //                                }
            //                            }
            //                        }
            //                        catch (Exception ex)
            //                        {

            //                        }
            //                    }
            //                    else
            //                    {
            //                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
            //                            e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);//下边缘的线
            //                        //绘制值
            //                        if (e.Value != null)
            //                        {
            //                            e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
            //                                Brushes.Crimson, e.CellBounds.X + 2,
            //                                e.CellBounds.Y + 2, StringFormat.GenericDefault);
            //                        }
            //                    }
            //                    //右侧的线
            //                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
            //                        e.CellBounds.Top, e.CellBounds.Right - 1,
            //                        e.CellBounds.Bottom - 1);
            //                    e.Handled = true;
            //                }
            //            }
            //        }
            //    }
            //}
        }

    }
}
