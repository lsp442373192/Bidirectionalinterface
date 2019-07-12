using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Daan.Interface.Util;
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.BLL;

namespace Daan.LIMS.Manage
{
    public partial class FrmSendString : Form
    {

        //打印的PDF默认路径
        public static string FileOrPath = Application.StartupPath + "\\PDF打印\\";
        //条码号
        string outsendstring = "";

        public FrmSendString(string sendstring)
        {
            InitializeComponent();
            outsendstring = sendstring;
        }

        /// <summary>预览</summary>
        /// <param name="sendstring"></param>
        private void BindWebBrower(string sendstring)
        {
            if (sendstring != "" && sendstring != null)
            {
                #region >>>> zhangw 显示报告
                //删除其他PDF文件 正在显示的不删除
                WinFileTransporter.DeleteFolder(FileOrPath);
                Createfile();//创建PDF文件夹
                string FilePath = FileOrPath;
                string filename = FilePath + " 预览：" + sendstring + ".pdf"; //打包后的PDF文件名称
                bool isA4 = true;
                ArrayList fileList = new ArrayList();
                Hashtable ha = new Hashtable();
                ha.Add("Hospsampleid", sendstring);   //达安条码
                List<DAReport> da = new DAReportBLL().SelectDAReportByRequestcode(ha); //是否存在多个报告单
                //显示报告控件
                this.webPdfReader.Visible = true;
                string PDFPath = string.Empty;
                if (da.Count == 0)
                {
                    #region 没有报告
                    this.webPdfReader.Visible = false;
                    ShowMessageHelper.ShowBoxMsg("没有报告预览！");
                    this.Close();
                    return;
                    #endregion
                }
                else if (da.Count == 1)
                {
                    #region 单个报告
                    string pdfFilePath = FileOrPath + sendstring + ".PDF";
                    //文件存在则更换名称
                    if (File.Exists(pdfFilePath))
                    {
                        pdfFilePath = FileOrPath + sendstring + "_1.PDF";
                    }
                    byte[] buff = da[0].Reportdata;
                    if (da[0].Reportdata == null)
                    {
                        this.webPdfReader.Visible = false;
                        ShowMessageHelper.ShowBoxMsg("没有报告预览！");
                        this.Close();
                        return;
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
        }

        /// <summary>  记录PDF文件夹
        /// 
        /// </summary>    
        public static void Createfile()
        {
            if (!Directory.Exists(FileOrPath))//若文件夹不存在则新建文件夹
            {
                Directory.CreateDirectory(FileOrPath); //新建文件夹
            }
        }

        /// <summary> 创建文件方法</summary>
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

        /// <summary> 加载事件 </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSendString_Load(object sender, EventArgs e)
        {
            BindWebBrower(outsendstring);
        }
    }
}
