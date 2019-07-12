//Create by fenghaipiao
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Daan.Interface.Util
{
    /**/
    /// <summary>
    /// winform形式的文件传输类
    /// </summary>
    public class WinFileTransporter
    {
        /**/
        /// <summary>
        /// WebClient上传文件至服务器，默认不自动改名
        /// </summary>
        /// <param name="fileNamePath">文件名，全路径格式</param>
        /// <param name="uriString">服务器文件夹路径</param>
        public bool UpLoadFile(string fileNamePath, string uriString, out string newUriString)
        {
            return UpLoadFile(fileNamePath, uriString, out newUriString, false);
        }
        /**/
        /// <summary>
        /// WebClient上传文件至服务器
        /// </summary>
        /// <param name="fileNamePath">文件名，全路径格式</param>
        /// <param name="uriString">服务器文件夹路径</param>
        /// <param name="IsAutoRename">是否自动按照时间重命名</param>
        public bool UpLoadFile(string fileNamePath, string uriString, out string newUriString, bool IsAutoRename)
        {
            string fileName = fileNamePath.Substring(fileNamePath.LastIndexOf("\\") + 1);
            string NewFileName = fileName;
            if (IsAutoRename)
            {
                NewFileName = DateTime.Now.ToString("yyMMddhhmmss") + DateTime.Now.Millisecond.ToString() + fileNamePath.Substring(fileNamePath.LastIndexOf("."));
            }

            string fileNameExt = fileName.Substring(fileName.LastIndexOf(".") + 1);
            if (uriString.EndsWith("/") == false) uriString = uriString + "/";

            uriString = uriString + NewFileName;
            newUriString = uriString;
            // Utility.LogWriter log = new Utility.LogWriter();
            //log.AddLog(uriString, "Log");
            //log.AddLog(fileNamePath, "Log");
            /**/
            /**/
            /**/
            /// 创建WebClient实例
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            // 要上传的文件
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            //FileStream fs = OpenFile();
            BinaryReader r = new BinaryReader(fs);
            byte[] postArray = r.ReadBytes((int)fs.Length);
            Stream postStream = myWebClient.OpenWrite(uriString, "PUT");


            try
            {

                //使用UploadFile方法可以用下面的格式
                //myWebClient.UploadFile(uriString,"PUT",fileNamePath);


                if (postStream.CanWrite)
                {
                    postStream.Write(postArray, 0, postArray.Length);
                    postStream.Close();
                    fs.Dispose();
                    //  log.AddLog("上传日志文件成功！", "Log");
                }
                else
                {
                    postStream.Close();
                    fs.Dispose();
                    //  log.AddLog("上传日志文件失败，文件不可写！", "Log");
                }
                return true;
            }
            catch (Exception err)
            {
                postStream.Close();
                fs.Dispose();
                //Utility.LogWriter log = new Utility.LogWriter();
                //  log.AddLog(err, "上传日志文件异常！", "Log");
                throw err;

                return false;
            }
            finally
            {
                postStream.Close();
                fs.Dispose();
            }
        }


        /**/
        /**/
        /**/
        /// <summary>
        /// 下载服务器文件至客户端

        /// </summary>
        /// <param name="URL">被下载的文件地址，绝对路径</param>
        /// <param name="Dir">另存放的目录</param>
        public void Download(string URL, string Dir)
        {
            WebClient client = new WebClient();
            string fileName = URL.Substring(URL.LastIndexOf("\\") + 1);  //被下载的文件名

            string Path = Dir + fileName;   //另存为的绝对路径＋文件名
            // Utility.LogWriter log = new Utility.LogWriter();
            try
            {
                WebRequest myre = WebRequest.Create(URL);
            }
            catch (Exception err)
            {
                //ShowMessageHelper.ShowBoxMsg(exp.Message,"Error"); 
                //  log.AddLog(err, "下载日志文件异常！", "Log");
            }

            try
            {
                client.DownloadFile(URL, fileName);
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(fs);
                byte[] mbyte = r.ReadBytes((int)fs.Length);

                FileStream fstr = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);

                fstr.Write(mbyte, 0, (int)fs.Length);
                fstr.Close();

            }
            catch (Exception err)
            {
                //ShowMessageHelper.ShowBoxMsg(exp.Message,"Error");
                // log.AddLog(err, "下载日志文件异常！", "Log");
            }
        }
        /// <summary>
        /// 删除文件夹及其下所有文件
        /// </summary>
        /// <param name="dir">文件夹的完整物理路径</param>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir))
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                    {
                        //直接删除其中的文件 删除失败不处理 	
                        try { File.Delete(d); }
                        catch (Exception) { }
                    }
                }
            }
        }
    }

}
