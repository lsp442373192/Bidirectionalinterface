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
    public partial class FrmSystemUser : FrmBase
    {
        DADictuserBLL userBll = new DADictuserBLL();
        private string curUserCode = string.Empty;
        public FrmSystemUser()
        {
            InitializeComponent();
        }
        #region >>> fenghp 页面事件
        private void FrmSystemUser_Load(object sender, EventArgs e)
        {
            //绑定列表
            BindData();
           
        }
        //查找
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        //新增
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmUserAdd frm = new FrmUserAdd();
            frm.StartPosition = FormStartPosition.CenterScreen; 
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindData();
            }
        }

        //编辑
        private void btnEdit_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection selRow = gvUser.SelectedRows;
            if (selRow.Count < 1)
            {
                ShowMessageHelper.ShowBoxMsg("请选择要编辑的数据!");
                return;
            }
            else
            {
                int userID = 0;
                int.TryParse(selRow[0].Cells["DictUserId"].Value.ToString(), out userID);
                string userCode = selRow[0].Cells["UserCode"].Value.ToString();
                FrmUserAdd frm = new FrmUserAdd();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Id = userID;
                frm.UserCode = userCode;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }
        //双击编辑数据
        private void gvUser_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection selRow = gvUser.SelectedRows;
            string userCode = selRow[0].Cells["UserCode"].Value.ToString();
            int userID = 0;
            int.TryParse(selRow[0].Cells["DictUserId"].Value.ToString(), out userID);
            FrmUserAdd frm = new FrmUserAdd();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Id = userID;
            frm.UserCode = userCode;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindData();
            }
        }

        //设置密码
        private void btnSetPwd_Click(object sender, EventArgs e)
        {
            FrmModifyPwd frm = new FrmModifyPwd();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        //删除选定项
        private void btnDel_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection selRow = gvUser.SelectedRows;
            if (selRow.Count < 1)
            {
                ShowMessageHelper.ShowBoxMsg("请选择要删除的数据!");
                return;
            }
            else
            {
                string userCode = selRow[0].Cells["UserCode"].Value.ToString();
                if (ShowMessageHelper.ShowBoxMsg("是否要删除选定的数据?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                int userID = 0;
                int.TryParse(selRow[0].Cells["DictUserId"].Value.ToString(), out userID);
                if (userBll.DeleteDADictuser(userID.ToString()) > 0)
                {
                    ShowMessageHelper.ShowBoxMsg("删除成功!");
                    BindData();
                }
                else
                {
                    ShowMessageHelper.ShowBoxMsg("删除失败");
                }
            }
        }
        private void gvUser_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selRow = gvUser.SelectedRows;
            if (selRow.Count > 0)
            {
                //获取当前用户编号
                if (SystemConfig.UserInfo != null)
                {
                    curUserCode = SystemConfig.UserInfo.UserCode;
                    if (curUserCode != "admin")//当前用户不是管理员，都不可用
                    {

                        btnAdd.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDel.Enabled = false;
                    }
                }

                string userCode = selRow[0].Cells["UserCode"].Value.ToString();
                if (userCode.ToLower()== curUserCode||curUserCode=="admin")//选择的是自己，可以编辑
                {
                    btnEdit.Enabled = true;
                }
                else
                {
                    btnEdit.Enabled = false;
                }

                
            }

        }
        //格式化列表值显示
        private void gvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvUser.Columns[e.ColumnIndex];
            if (clmCurren.Name == "IsActive")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "否";
                    }
                    else
                    {
                        e.Value = "是";
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
        private void gvUser_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 1, gvUser.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvUser.RowHeadersDefaultCellStyle.Font, rectangle, gvUser.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        //滚动时设置行头的宽度
        private void gvUser_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvUser.RowHeadersWidth = (gvUser.FirstDisplayedScrollingRowIndex + 20).ToString().Length * 9 + 13;

            }
        }
        #endregion

        #region >>> fenghp 绑定数据
        private void BindData()
        {
            Hashtable ht = new Hashtable();
            ht.Add("strKey", tbxSearchKey.Text.ToString());
            gvUser.AutoGenerateColumns = false;
            
            //实现List排序,否则无法点击表头按列重新排序
            BindingCollection<DADictuser> list = new BindingCollection<DADictuser>();
            foreach (DADictuser user in userBll.GetDADictuserInfo(ht))
            {
                list.Add(user);
            }
            bsUser.DataSource = list;
            lblRecord.Text = string.Format("共 {0} 条记录", list.Count);
        }
        #endregion



    }
}
