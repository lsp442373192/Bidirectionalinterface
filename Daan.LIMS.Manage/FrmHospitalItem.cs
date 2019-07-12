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
    public partial class FrmHospitalItem : FrmBase
    {
        VDAListestsBLL dalisttestsBll = new VDAListestsBLL();
        public FrmHospitalItem()
        {
            InitializeComponent();
        }
        #region >>> fenghp 页面事件
        private void FrmHospitalItem_Load(object sender, EventArgs e)
        {
            BindData();
        }
        //查找
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        //刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }
        //格式化列表值
        private void gvHospitalitem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvHospitalitem.Columns[e.ColumnIndex];

            if (clmCurren.Name == "IsGroup")
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

        private void KeyDown_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindData();
            }
        }
        //行头显示行号
        private void gvHospitalitem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y+1, gvHospitalitem.RowHeadersWidth - 4, e.RowBounds.Height); 
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvHospitalitem.RowHeadersDefaultCellStyle.Font, rectangle, gvHospitalitem.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void gvHospitalitem_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvHospitalitem.RowHeadersWidth = (gvHospitalitem.FirstDisplayedScrollingRowIndex+20).ToString().Length * 9 + 13;

            }
        }
        #endregion

        #region >>> fenghp 方法
        //数据绑定
        private void BindData()
        {
            Hashtable ht = new Hashtable();
            ht.Add("strKey", tbxSearchKey.Text.ToString());
            gvHospitalitem.AutoGenerateColumns = false;
            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<VDAListests> list = new BindingCollection<VDAListests>();
            foreach (VDAListests vdaListtest in dalisttestsBll.GetDaListestsList(ht))
            {
                list.Add(vdaListtest);
            }
            bsHospitalitem.DataSource = list;
            lblRecord.Text = string.Format("共 {0} 条记录", list.Count);
        }
        #endregion



    }
}
