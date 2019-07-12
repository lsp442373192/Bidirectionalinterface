using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Daan.Interface.Entity;
using System.Collections;
using System.Configuration;
using System.Xml;
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Diagnostics;
using Daan.Interface.BLL;
using Daan.Interface.Util;
using System.Net;
using IBatisNet.DataMapper.Configuration.Sql.Dynamic.Elements;
using Daan.Interface.Dao;
using System.Data.SqlClient;






namespace Daan.PDFToImage
{
    public partial class LIMSService : Form
    {
        //PDF生成默认保存文件夹
        public static string FileOrPath = ConfigurationManager.AppSettings["PDF"];

        //PDF转换图片默认保存文件夹
        public static string FileOrPathImages = ConfigurationManager.AppSettings["PDFImage"];

        BaseService service = new BaseService();

        public LIMSService()
        {
            InitializeComponent();
            //timer控件可用
            this.timer1.Enabled = true;
            int dInterval = 0;
            //设置timer控件的Tick事件触发的时间间隔
            string sss = ConfigurationManager.AppSettings["ImageInterval"].ToString();
            int.TryParse(ConfigurationManager.AppSettings["ImageInterval"].ToString(), out dInterval);
            this.timer1.Interval = dInterval * 1000 * 60;

            //停止计时
            this.timer1.Stop();
            //打开程序则启动
            string isStart = ConfigurationManager.AppSettings["IsStart"];
            if (isStart == "1") { btnStart_Click(null, null); }
        }

        /// <summary>
        /// 服务开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            SetTB("服务开启!");
            int dInterval = 0;
            string sss = ConfigurationManager.AppSettings["ImageInterval"].ToString();
            int.TryParse(ConfigurationManager.AppSettings["ImageInterval"].ToString(), out dInterval);
            timer1.Interval = dInterval * 1000 * 60;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnStop.Focus();
            DownResult();
        }

        delegate void ResultInvok();
        /// <summary>
        /// 下载结果
        /// </summary>
        void DownResult()
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
            //ThreadPool.QueueUserWorkItem((o) =>
            //{
            CoreHandle();
            GC.Collect();
            //});

        }

        /// <summary>
        /// 核心处理
        /// </summary>
        private void CoreHandle()
        {
            try
            {


                if (timer1.Enabled == false) { return; }
                //获取需要转换的条码报告  状态为：4
                Hashtable ht = new Hashtable();
                ht.Add("Status", "4");
                List<DAOutspecimen> outSpecimenList = new DAOutSpecimenBLL().GetOutspecimenListTwo(ht);
                if (outSpecimenList.Count == 0)
                {
                    SetTB("没有需要转换图片的条码！");
                    return;
                }

                //for (int i = 0; i < outSpecimenList.Count; i++)
                //{

                //}

                // List<DAOutspecimen> outNewlis = outSpecimenList.Distinct(new item_collection_DistinctBy_item1()).ToList();

                foreach (var DAOutspecimen in outSpecimenList)
                {                  
                    BindRightData(DAOutspecimen.Hospsampleid, DAOutspecimen.Requestcode);
                }
                SetTB("本次图片转换完毕，等待下次转换......\r\n");
            }
            catch (Exception ex)
            {

                SetTB("查询数据异常:" + ex.Message);
            }

        }

        //过滤重复的医院条码
        class item_collection_DistinctBy_item1 : IEqualityComparer<DAOutspecimen>
        {
            public bool Equals(DAOutspecimen x, DAOutspecimen y)
            {
                if (x.Hospsampleid == y.Hospsampleid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public int GetHashCode(DAOutspecimen obj)
            {
                return 0;
            }
        }





        //添加双击托盘图标事件（双击显示窗口）
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.Focus();
        }
        //系统托盘右键退出事件，打开验证密码窗体，输入密码正确，关闭主窗体
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.btnStop.Enabled)
            {
                ShowMessageHelper.ShowBoxMsg("请先点击 [停止服务] 再 [关闭] ！");
                notifyIcon1_MouseDoubleClick(null, null);
                return;
            }

            //this.Close();
            Exit ex = new Exit(notifyIcon1);
            ex.ShowDialog();
        }

        //窗体关闭前
        private void LIMSService_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!   
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                //取消"关闭窗口"事件          
                this.WindowState = FormWindowState.Minimized;
                //使关闭时窗口向右下角缩小的效果             
                notifyIcon1.Visible = true;
                this.Hide();
                return;
            }

            //使用托盘退出，不用此处代码
            //if (this.btnStop.Enabled) { ShowMessageHelper.ShowBoxMsg("请先点击 [停止服务] 再 [关闭] ！"); e.Cancel = true; return; }

            //SetTB("服务关闭!");
        }

        private void 显示服务窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(null, null);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SetTB("服务停止!");

            //暂停
            timer1.Stop();
            // logtimer.Stop();
            //sendtimer.Stop();

            GC.Collect();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnStart.Focus();
        }

        private delegate void SetTBMethodInvok(string value);
        private void SetTB(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetTBMethodInvok(SetTB), value);
            }
            else
            {
                if (timer1.Enabled == false) { return; }

                value = DateTime.Now.ToString() + ":" + value;
                rtbxMSG.Text += value + "\n";

                if (rtbxMSG.Text.Length > 100000)
                {
                    string subs = rtbxMSG.Text.Substring(500);
                    rtbxMSG.Text = subs.Substring(subs.IndexOf("\n") + 1);
                }

                //有滚动条时 ，定位到textbox最下方
                this.rtbxMSG.SelectionStart = this.rtbxMSG.Text.Length;
                this.rtbxMSG.ScrollToCaret();
            }

        }


        //生成PDF转换成image
        public void BindRightData(string Hospsampleid, string requestcode)
        {

            Createfile();//创建PDF文件夹
            string FilePath = FileOrPath;
            string filename = FilePath + "" + Hospsampleid + "_" + requestcode + ".pdf"; //打包后的PDF文件名称
            bool isA4 = true;
            ArrayList fileList = new ArrayList();
            ArrayList fileListrequestcode = new ArrayList();
            Hashtable ha = new Hashtable();
            ha.Add("Requestcode", requestcode);   //达安条码
            ha.Add("Hospsampleid", Hospsampleid);
            List<DAReport> da = new DAReportBLL().SelectDAReportByRequestcode(ha); //是否存在多个报告单
            string PDFPath = string.Empty;
            if (da.Count == 0)
            {
                #region 没有报告
                return;
                #endregion
            }
            else if (da.Count == 1)
            {
                #region 单个报告
                string pdfFilePath = FileOrPath + Hospsampleid + "_" + requestcode + ".PDF";
                //文件存在则更换名称
                if (File.Exists(pdfFilePath))
                {
                    pdfFilePath = FileOrPath + Hospsampleid + "_" + requestcode + "_1.PDF";
                }
                byte[] buff = da[0].Reportdata;
                if (da[0].Reportdata == null)
                {

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
                    fileList.Add(da[i].Hospsampleid + "_" + requestcode + "_" + i);

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
                                if (fileList[i].ToString() == da[m].Hospsampleid + "_" + requestcode + "_" + m)
                                {
                                    path = FilePath + da[m].Hospsampleid + "_" + requestcode + "_" + m + ".PDF";
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
            bool falg = ConvertPDF2Image(PDFPath, FileOrPathImages, Hospsampleid + "_" + requestcode, Hospsampleid, 1, 15, ImageFormat.Jpeg, 5);
            bool test;
            if (falg)
            {
                Hashtable ht = new Hashtable();
                ht.Add("Status", 5);
                ht.Add("Hospsampleid", Hospsampleid);
                ht.Add("requestcode", requestcode);
                test = new DAOutSpecimenBLL().UpdateDAOutspecimenByHospsampleid(ht);
                if (test)
                {
                    SetTB("医院条码：" + Hospsampleid + "， 达安条码：" + requestcode + "转换成功！");
                }

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


        /// <summary>
        /// PDF转Image
        /// </summary>
        /// <param name="pdfInputPath">PDF文件</param>
        /// <param name="imageOutputPath">图片文件路径</param>
        /// <param name="imageName">图片名称</param>
        /// <param name="startPageNum">从第几页开始</param>
        /// <param name="endPageNum">到第几页结束</param>
        /// <param name="imageFormat">生成图片类型</param>
        /// <param name="resolution">显示倍数</param>
        public bool ConvertPDF2Image(string pdfInputPath, string imageOutputPath,
            string imageName, string Hospsampleid, int startPageNum, int endPageNum, ImageFormat imageFormat, double resolution)
        {

            bool falg = true;
            List<string> Sqllst = new List<string>();
            //执行的SQL集合
            string errormsg = "";
            SortedList SQLlist = new SortedList(new MySort());
            int errcount = 0; //标记当前pdf每页是否都已经转图片成功

            Acrobat.CAcroPDDoc pdfDoc = (Acrobat.CAcroPDDoc)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.PDDoc", "");
            Acrobat.CAcroPDPage pdfPage = null;
            Acrobat.CAcroRect pdfRect = null;
            Acrobat.CAcroPoint pdfPoint = null;
            try
            {        
                  //yhl 2017.3.22pdf转图片之前先清空粘贴板信息，防止图片信息没清空，下个条码存了上个条码的信息
                  //IDataObject clipboardData1 = Clipboard.GetDataObject();
                  //if (clipboardData1.GetDataPresent(DataFormats.Bitmap))
                  //{
                      Clipboard.Clear();
                 // }               
                // Create the document (Can only create the AcroExch.PDDoc object using late-binding)
                // Note using VisualBasic helper functions, have to add reference to DLL
                // pdfDoc = (Acrobat.CAcroPDDoc)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.PDDoc", "");//.CreateObject("AcroExch.PDDoc", "");
                //var CreatePdf = Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.PDDoc", "");
                // pdfDoc = (Acrobat.CAcroPDDoc)CreatePdf;

                // pdfPage.CopyToClipboard(pdfRect, 0, 0, 100);
                // validate parameter
                if (!pdfDoc.Open(pdfInputPath)) { throw new FileNotFoundException(); }
                if (!Directory.Exists(imageOutputPath)) { Directory.CreateDirectory(imageOutputPath); }
                if (startPageNum <= 0) { startPageNum = 1; }
                if (endPageNum > pdfDoc.GetNumPages() || endPageNum <= 0) { endPageNum = pdfDoc.GetNumPages(); }
                if (startPageNum > endPageNum) { int tempPageNum = startPageNum; startPageNum = endPageNum; endPageNum = startPageNum; }
                if (imageFormat == null) { imageFormat = ImageFormat.Jpeg; }
                if (resolution <= 0) { resolution = 1; }

                // start to convert each page
                for (int i = startPageNum; i <= endPageNum; i++)
                {
                    pdfPage = (Acrobat.CAcroPDPage)pdfDoc.AcquirePage(i - 1);
                    pdfPoint = (Acrobat.CAcroPoint)pdfPage.GetSize();
                    pdfRect = (Acrobat.CAcroRect)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.Rect", "");

                    int imgWidth = (int)((double)pdfPoint.x * resolution);
                    int imgHeight = (int)((double)pdfPoint.y * resolution);

                    pdfRect.Left = 0;
                    pdfRect.right = (short)imgWidth;
                    pdfRect.Top = 0;
                    pdfRect.bottom = (short)imgHeight;

                    pdfPage.CopyToClipboard(pdfRect, 0, 0, (short)(100 * resolution));

                    IDataObject clipboardData = Clipboard.GetDataObject();
                    if (clipboardData.GetDataPresent(DataFormats.Bitmap))
                    {

                        Bitmap pdfBitmap = (Bitmap)clipboardData.GetData(DataFormats.Bitmap);
                        pdfBitmap.Save(Path.Combine(imageOutputPath, imageName) + "_" + i + ".jpg", imageFormat);
                        pdfBitmap.Dispose();
                    }

                    string imgpath = Path.Combine(imageOutputPath, imageName) + "_" + i + ".jpg";
                    if (!File.Exists(imgpath) || File.ReadAllBytes(imgpath).Count()<= 0)
                    {
                        errcount++;
                    }

                    string imageAddress = getImageString(Path.Combine(imageOutputPath, imageName) + "_" + i + ".jpg");
                    int maxid = new TableIDDAO().GetNextId("DAAN_LIS_REPORT");
                    DAAN_LIS_REPORT dalisReport = new DAAN_LIS_REPORT();
                    dalisReport.DAAN_ID = maxid.ToString();
                    dalisReport.DAAN_JPG = Convert.FromBase64String(imageAddress);
                    dalisReport.DAAN_BAR_CODE = Hospsampleid;
                    SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAAN_LIS_REPORT" } }, dalisReport);                   
                }

                pdfDoc.Close();
                Marshal.ReleaseComObject(pdfPage);
                Marshal.ReleaseComObject(pdfRect);
                Marshal.ReleaseComObject(pdfDoc);
                Marshal.ReleaseComObject(pdfPoint);
                falg = service.ExecuteSqlTran(SQLlist,ref errormsg);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                SetTB(imageName + "条码转换失败！" + ex.Message);
                falg = false;
                errcount++;

                pdfDoc.Close();
                Marshal.ReleaseComObject(pdfPage);
                Marshal.ReleaseComObject(pdfRect);
                Marshal.ReleaseComObject(pdfDoc);
                Marshal.ReleaseComObject(pdfPoint);
            }

            if (errcount > 0)
                falg = false;
            return falg;
        }



        public static string  getImageString(string str)
        {
            string returnstr = string.Empty;
            string imageAddress = str;
            WebClient my = new WebClient();
            byte[] mybyte;
            try
            {
                //imageAddress = "http://202.116.104.149:333/F.jpg";
                mybyte = my.DownloadData(imageAddress);
                returnstr = byteToBase64string(mybyte);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("访问图片[{0}]异常：{1}", imageAddress, ex.Message));
            }
            return returnstr;
        }

        /// <summary>将文件流转换成Base64编码。
        /// 将文件流转换成Base64编码。
        /// </summary>0
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string byteToBase64string(byte[] stream)
        {
            string str = Convert.ToBase64String(stream);
            return str;
        }

        /// <summary>记录PDF文件夹
        /// </summary>
        public static void Createfile()
        {
            if (!Directory.Exists(FileOrPath))//若文件夹不存在则新建文件夹
            {
                Directory.CreateDirectory(FileOrPath); //新建文件夹
            }
            if (!Directory.Exists(FileOrPathImages))//若文件夹不存在则新建文件夹
            {
                Directory.CreateDirectory(FileOrPathImages); //新建文件夹
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DownResult();
            //删除X天前的备份文件.pdf文件
            double day = Convert.ToDouble(ConfigurationManager.AppSettings["Day"]);
            string FilePdfPath = FileOrPath;
            string[] fileRar = Directory.GetFiles(FilePdfPath, "*.pdf");
            for (int i = 0; i < fileRar.Length; i++)
            {
                FileInfo fi = new FileInfo(fileRar[i]);
                if (fi.LastWriteTime < DateTime.Now.AddDays(-day))
                {
                    Console.WriteLine(DateTime.Now + "-=|删除:" + fileRar[i]);
                    fi.Delete();
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string path = "D:\\生成PDF图片";
        //    DataTable dt = DbHelperSQL.GetDataTable("select DAAN_JPG from dbo.DAAN_LIS_REPORT   where DAAN_BAR_CODE = '201308295600'");
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string pathmath = path;
        //             byte[] _ImageByte =(byte[])dt.Rows[i]["DAAN_JPG"];
        //             pathmath += "\\201308295600" + "_" + i + ".jpg";
        //             CreatPath(pathmath, _ImageByte);
        //            //BinaryWriter bw = new BinaryWriter(new FileStream(pathmath, FileMode.Create));
        //            //bw.Write(_ImageByte);
        //            //bw.Close();
        //        }
        //    }
            
        //}

    }
}

