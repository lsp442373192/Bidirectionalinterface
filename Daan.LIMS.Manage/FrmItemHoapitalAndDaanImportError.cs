using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.Interface.Entity;

namespace Daan.LIMS.Manage
{
    public partial class FrmItemHoapitalAndDaanImportError : Form
    {
        public FrmItemHoapitalAndDaanImportError()
        {
            InitializeComponent();
        }
        //错误信息
        private string _strfailed = string.Empty;
        public string StrFailed
        {
            get { return _strfailed; }
            set { _strfailed = value; }
        }
        //错误记录
        public List<DATestmap> testmapList = null;
        
        private void FrmItemHoapitalAndDaanImportError_Load(object sender, EventArgs e)
        {
            //绑定错误信息
            BindData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //绑定数据
        private void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TestCode");
            dt.Columns.Add("TestName");
            dt.Columns.Add("DaTestCode");
            dt.Columns.Add("DaTestName");
            dt.Columns.Add("Reason");
            string[] strs = StrFailed.Split(',');
            //把数组转换成datatable绑定到列表
            for (int i = 0; i < testmapList.Count;i++ )
            {
                DataRow row = dt.NewRow();
                row["TestCode"] = testmapList[i].Customertestcode;
                row["TestName"] = testmapList[i].Customertestname;
                row["DaTestCode"] = testmapList[i].Datestcode;
                row["DaTestName"] = testmapList[i].Datestname;
                row["Reason"] = strs[i];
                dt.Rows.Add(row);
            }
            gvItemHospitalAndDaan.DataSource = dt.DefaultView;
            gvItemHospitalAndDaan.Sort(gvItemHospitalAndDaan.Columns["Reason"], ListSortDirection.Descending);
            lblRecord.Text = string.Format("共 {0} 条记录", testmapList.Count);
        }
        //行头显示行号
        private void gvItemHospitalAndDaan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //定义一个矩形显示行号，放到行头
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y+1, gvItemHospitalAndDaan.RowHeadersWidth - 4, e.RowBounds.Height); 
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), gvItemHospitalAndDaan.RowHeadersDefaultCellStyle.Font, rectangle, gvItemHospitalAndDaan.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
       
        }
        //滚动时设置行头的宽度
        private void gvItemHospitalAndDaan_Scroll(object sender, ScrollEventArgs e)
        {
            //垂直滚动才重设置
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //每个字符9px，选择行时的指示标13px
                gvItemHospitalAndDaan.RowHeadersWidth = (gvItemHospitalAndDaan.FirstDisplayedScrollingRowIndex+20).ToString().Length * 9 + 13;

            }
        }

        private void gvItemHospitalAndDaan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridViewColumn clmCurren = gvItemHospitalAndDaan.Columns[e.ColumnIndex];
            if (clmCurren.Name == "Reason")
            {
                if (e.Value.ToString() != "导入成功")
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.LightCoral;
                    gvItemHospitalAndDaan.Rows[e.RowIndex].DefaultCellStyle = d;
                }
                else
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.PaleGreen;
                    gvItemHospitalAndDaan.Rows[e.RowIndex].DefaultCellStyle = d;
                }
            }
        }
    }
}
