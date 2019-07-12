using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Daan.Interface.Util;
using Daan.Interface.Dao;
using Daan.Interface.BLL;
using System.Collections;
using Daan.Interface.Entity;
using System.Net;

namespace Daan.LIMS.Manage
{
    public partial class FrmItemHospitalAndDaan : FrmBase
    {
        VDAListestsBLL dalisttestsBll = new VDAListestsBLL();
        DATestmapBLL testmapBll = new DATestmapBLL();
        DADicttestitemBLL testitemBll = new DADicttestitemBLL();
        //医院项目
        private List<VDAListests> cacheVDAList = new List<VDAListests>();
        //达安项目
        private List<DADicttestitem> cacheDaList = new List<DADicttestitem>();
        //对照的达安项目
        private List<DADicttestitem> cacheInDaList = new List<DADicttestitem>();
        //项目对照表
        private List<DATestmap> cacheMapList = new List<DATestmap>();
        public FrmItemHospitalAndDaan()
        {
            InitializeComponent();
        }
        #region>>>事件
        private void FrmItemHospitalAndDaan_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //弹出设置窗体
            FrmItemHospitalAndDaanSetting settingFrm = new FrmItemHospitalAndDaanSetting();
            settingFrm.StartPosition = FormStartPosition.CenterParent;
            //if (gvItemHospitalAndDaan.SelectedRows.Count > 0)
            //{
            //    settingFrm.Testcode = gvItemHospitalAndDaan.SelectedRows[0].Cells["TestCode"].Value.ToString();
            //}
            //settingFrm.WindowState = FormWindowState.Maximized;
            settingFrm.ShowDialog();
            BindData();
        }
        //private void gvItemHospitalAndDaan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    //弹出设置窗体
        //    FrmItemHospitalAndDaanSetting2 settingFrm = new FrmItemHospitalAndDaanSetting2();
        //    settingFrm.StartPosition = FormStartPosition.CenterParent;
        //    settingFrm.Testcode = gvItemHospitalAndDaan.SelectedRows[0].Cells["TestCode"].Value.ToString();
        //    //settingFrm.WindowState = FormWindowState.Maximized;
        //    settingFrm.ShowDialog();
        //    BindData();
        //}
        //下载EXCEL模版
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            DownLoad();
        }
        //从EXCEL导入
        private void btnimport_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }
        //格式化列表值
        private void gvItemHospitalAndDaan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn clmCurren = gvItemHospitalAndDaan.Columns[e.ColumnIndex];

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
            if (clmCurren.Name == "TESTMAPID")
            {
                if (e.Value!=null)
                {
                    DataGridViewCellStyle d = new DataGridViewCellStyle();
                    d.BackColor = Color.PaleGreen;
                    gvItemHospitalAndDaan.Rows[e.RowIndex].DefaultCellStyle = d;
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
        #endregion

        #region>>>方法
        //数据绑定
        private void BindData()
        {
            Hashtable ht = new Hashtable();
            ht.Add("strKey", tbxSearchKey.Text.ToString());
            gvItemHospitalAndDaan.AutoGenerateColumns = false;
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
            bsItemHospitalAndDaan.DataSource = list;
            gvItemHospitalAndDaan.Columns[0].Frozen = true;
            lblRecord.Text = string.Format("共 {0} 条记录", list.Count);
        }
        /// <summary>
        /// 下载EXCEL导入模版
        /// </summary>
        private void DownLoad()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls|(*.xlsx)|*.xlsx";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            //dlg.CreatePrompt = true;
            dlg.Title = "保存为Excel文件";
            dlg.FileName = "项目对照导入模版";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //下载路径
                string path = Application.StartupPath + "\\importtemplate\\项目对照模版.xls";
                string fileName = path.Substring(path.LastIndexOf("\\") + 1);
                try
                {
                    WebRequest request = WebRequest.Create(path);
                }
                catch
                {
                    ShowMessageHelper.ShowBoxMsg("项目对照导入模版下载失败!");
                    return;
                }

                try
                {
                    //通过WebClient下载
                    WebClient client = new WebClient();
                    client.DownloadFile(path, "项目对照导入模版");
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] myByte = br.ReadBytes((int)fs.Length);

                    string strFilePath = dlg.FileName;
                    FileStream fsStr = new FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                    fsStr.Write(myByte, 0, (int)fs.Length);
                    fsStr.Close();

                    if (ShowMessageHelper.ShowBoxMsg("模版下载完成, 是否打开模版文件?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //打开文件
                        System.Diagnostics.Process.Start(strFilePath);
                    }
                }
                catch
                {
                    ShowMessageHelper.ShowBoxMsg("项目对照导入模版下载失败!");
                    return;
                }
            }
        }
        //从Excel导入数据
        private void ImportExcel()
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filter = "Execl files (*.xls)|*.xls|(*.xlsx)|*.xlsx";
            openDialog.FilterIndex = 0;
            openDialog.RestoreDirectory = true;
            openDialog.Title = "打开Excel文件";

            string fileName = string.Empty;//要上传的文件名
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                WinFileTransporter wFile = new WinFileTransporter();

                fileName = openDialog.FileName;
                string uriFiles = string.Empty;//保存到服务器路径
                string folderName = Application.StartupPath + "\\importFiles";

                if (!Directory.Exists(folderName))//如果路径不存在则创建
                {
                    Directory.CreateDirectory(folderName);
                }

                try
                {
                    if (wFile.UpLoadFile(fileName, folderName, out uriFiles, true))
                    {
                        DataTable dt = new DataTable();
                        string errorStr = string.Empty;
                        AsposeExcelTools.ExcelFileToDataTable(uriFiles, out dt, out errorStr);//读取表格数据，转换为datatable
                        List<DATestmap> errorList = new List<DATestmap>();
                        List<DATestmap> testmapList = new List<DATestmap>();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DATestmap testmap = new DATestmap();
                                testmap.Customertestcode = dt.Rows[i]["医院项目代码(项目导入唯一标识)"].ToString().Trim();
                                testmap.Customertestname = dt.Rows[i]["医院项目名称(作为对应参考,不做导入标识)"].ToString().Trim();
                                testmap.Datestcode = dt.Rows[i]["达安项目代码(项目导入唯一标识)"].ToString().Trim();
                                testmap.Datestname = dt.Rows[i]["达安项目名称(作为对应参考,不做导入标识)"].ToString().Trim();
                                if (testmap.Customertestcode == string.Empty )
                                {
                                    errorList.Add(testmap);
                                    errorStr += "导入错误:医院项目代码为空,";
                                    continue;
                                }
                                if (testmap.Datestcode == string.Empty)
                                {
                                    errorList.Add(testmap);
                                    errorStr += "导入错误:达安项目代码为空,";
                                    continue;
                                }
                                if (testmap.Customertestname == string.Empty )
                                {
                                    errorList.Add(testmap);
                                    errorStr += "导入错误:医院项目名称为空,";
                                    continue;
                                }
                                if (testmap.Datestname == string.Empty)
                                {
                                    errorList.Add(testmap);
                                    errorStr += "导入错误:达安项目名称为空,";
                                    continue;
                                }
                                if (!IsExistHosp(testmap.Customertestcode,testmap.Customertestname))
                                {
                                    errorList.Add(testmap);
                                    errorStr += "导入错误:医院项目信息不存在,";
                                    continue;
                                }
                                if (!IsExistDaan(testmap.Datestcode,testmap.Datestname))
                                {
                                    errorList.Add(testmap);
                                    errorStr += "导入错误:达安项目信息不存在,";
                                    continue;
                                }
                                //如果在testmap表已经存在医院项目代码的记录，记录对象及错误信息
                                //if (IsExist(testmap.Customertestcode))
                                //{
                                //    errorList.Add(testmap);
                                //    errorStr += "导入失败:该医院项目已存在对应的匹配信息,";
                                //    continue;
                                //}
                                errorList.Add(testmap);
                                errorStr += "导入成功,";
                                
                                testmapList.Add(testmap);
                            }
                            //if (testmapBll.ImportDaTestmap(testmapList))
                            if (testmapBll.SaveDATestmapList(testmapList))
                            {
                                //弹出错误信息
                                //if (errorList != null)
                                //{
                                    FrmItemHoapitalAndDaanImportError errorFrm = new FrmItemHoapitalAndDaanImportError();
                                    errorFrm.StrFailed = errorStr;
                                    errorFrm.testmapList = errorList;
                                    errorFrm.StartPosition = FormStartPosition.CenterScreen;
                                    errorFrm.ShowDialog();
                                    BindData();
                                //}
                                //else
                                //{
                                //    ShowMessageHelper.ShowBoxMsg("导入成功!");
                                //}
                            }
                            else
                            {
                                ShowMessageHelper.ShowBoxMsg("导入失败!");
                            }
                            
                        }
                        else
                        {
                           ShowMessageHelper.ShowBoxMsg("没有数据导入!");
                        }
                    }
                }
                catch(Exception e)
                {
                    ShowMessageHelper.ShowBoxMsg("导入的过程中发生了异常:"+e.Message);
                }

                finally
                {

                    //删除文件
                    if (File.Exists(uriFiles))
                    {
                        File.Delete(uriFiles);
                    }
                }
            }
        }
        
        /// <summary>
        /// 检查是否已经存在项目匹配信息
        /// </summary>
        /// <param name="testcode"></param>
        /// <returns></returns>
        private bool IsExist(string testcodeStr)
        {
            bool isexist = false;
            Hashtable ht = new Hashtable();
            ht.Add("Customertestcode", testcodeStr);
            List<DATestmap> list=testmapBll.GetDATestmapList(ht);
            if (list.Count>0)
            {
                isexist = true;
            }
            return isexist;

        }
        /// <summary>
        /// 检查是否存在医院项目
        /// </summary>
        /// <param name="Testcode"></param>
        /// <returns></returns>
        private bool IsExistHosp(string testcodeStr, string testnameStr)
        {
            bool isexist = false;
            Hashtable ht = new Hashtable();
            ht.Add("Testcode", testcodeStr.Trim());
            //名称只作为对应参考
           // ht.Add("Testname", testnameStr.Trim());
            if (dalisttestsBll.GetDaListestsList(ht).Count>0)
            {
                isexist = true;
            }
            return isexist;

        }
        /// <summary>
        /// 检查是否存在达安项目
        /// </summary>
        /// <param name="Datestcode"></param>
        /// <returns></returns>
        private bool IsExistDaan(string testcodeStr,string testnameStr)
        {
            bool isexist = false;
            Hashtable ht = new Hashtable();
            ht.Add("Datestcode", testcodeStr.Trim());
            //名称只作为对应参考
            //ht.Add("Datestname", testnameStr.Trim());
            if (testitemBll.SelectDADicttestitem(ht).Count>0)
            {
                isexist = true;
            }
            return isexist;

        }
        #endregion

        private void gvItemHospitalAndDaan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            //// 对第1列相同的行的相同单元格进行合并
            //if (e.ColumnIndex > 0 && e.ColumnIndex != 3 && e.ColumnIndex != 4 && e.RowIndex != -1)
            //{
            //    if (e.Value != null || e.RowIndex != gvItemHospitalAndDaan.RowCount)
            //    {
            //        string s = gvItemHospitalAndDaan.Rows[51].Cells["TestCode"].Value.ToString();
            //        string ss = gvItemHospitalAndDaan.Rows[50].Cells["TestCode"].Value.ToString();
            //        if (gvItemHospitalAndDaan.Rows[e.RowIndex].Cells[0].Value != null && gvItemHospitalAndDaan.Rows[e.RowIndex].Cells["TestCode"].Value == gvItemHospitalAndDaan.Rows[e.RowIndex + 1].Cells["TestCode"].Value)
            //        {
            //            using (
            //        Brush gridBrush = new SolidBrush(this.gvItemHospitalAndDaan.GridColor),
            //        backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            //            {
            //                using (Pen gridLinePen = new Pen(gridBrush))
            //                {
            //                    // 擦除原单元格背景
            //                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
            //                    /**/
            //                    ////绘制线条,这些线条是单元格相互间隔的区分线条,
            //                    ////因为我们只对列name做处理,所以datagridview自己会处理左侧和上边缘的线条
            //                    if (e.RowIndex != this.gvItemHospitalAndDaan.RowCount - 1)
            //                    {
            //                        try
            //                        {
            //                            if (e.Value.ToString() != this.gvItemHospitalAndDaan.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString())
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

        private void button1_Click(object sender, EventArgs e)
        {
            #region >>>> zhouy 获取组合对应关系
            DataTable cacheGroupTestdetail = new DataTable();

            string[] testItemInfo = WebServiceUtils.ExecuteMethod("GetTestGroupDetail",
                new string[] { SystemConfig.UserInfo.SID }).Split('|');
            if (testItemInfo[0] == "0")
            {
                string[] par = new string[] { SystemConfig.Config.Sitecode, SystemConfig.Config.Username, SystemConfig.Config.Password, SystemConfig.UserInfo.UserName };
                //返回登录验证信息:1|SID,0|errorMsg
                string[] loginMsg = WebServiceUtils.ExecuteMethod("Login", par).Split('|');

                if (loginMsg[0] == "0") //登录失败     
                {
                    ShowMessageHelper.ShowBoxMsg("登录达安服务器失败" + loginMsg[1].ToString());
                }
                else
                {
                    SystemConfig.UserInfo.SID = loginMsg[1];
                    testItemInfo = WebServiceUtils.ExecuteMethod("GetTestGroupDetail",
                                    new string[] { SystemConfig.UserInfo.SID }).Split('|');
                }

            }
            if (testItemInfo[0] == "1")
            {
                cacheGroupTestdetail = XMLHelper.CXmlToDataSet(testItemInfo[1]).Tables[0];
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("远程连接失败,不能设置！");
                return;
            }
            #endregion

            //弹出设置窗体
            FrmItemHospitalAndDaanSetting2 settingFrm = new FrmItemHospitalAndDaanSetting2(cacheGroupTestdetail);
            settingFrm.StartPosition = FormStartPosition.CenterParent;
            settingFrm.ShowDialog();
            BindData();
        }



        

    }
}
