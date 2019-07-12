using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;
using Daan.Interface.Entity;
using Daan.Interface.Dao;
using Daan.Interface.BLL;
using System.Net;
using System.Net.Sockets;
using Daan.Interface.Util;

namespace Daan.LIMS.Manage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            GlobalMutex();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //注册系统异常事件
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);


            string sendstring = ""; 
            if (args.Length  > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    sendstring += args[i];
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmSendString(sendstring));//"201211301100"
            }
            else
            {
                //启动登陆界面
                FrmLogon dlg = new FrmLogon();
                dlg.StartPosition = FormStartPosition.CenterScreen;
                DialogResult result = dlg.ShowDialog();
                dlg.Focus();
                if (DialogResult.OK == result)
                {
                    if (dlg.bLogin)
                    {
                        FrmMain frmMain = new FrmMain();
                        frmMain.StartPosition = FormStartPosition.CenterScreen;
                        Application.Run(frmMain);
                    }

                }
                dlg.Dispose();
            }
        }
        /// <summary>
        /// 调试时进去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ee = e.Exception;
            //string strMsg = "错误时间：" + DateTime.Now.ToString() + "\n错误消息：" + ee.Message + "\n" + (ee.InnerException == null ? "" : ee.InnerException.Message) + "\n错误方法：" + ee.TargetSite + "\n错误对象：" + ee.Source;
            string strMsg = ee.ToString();
            ShowMessageHelper.ShowBoxMsg(strMsg);
            saveErrorMsg(strMsg);
        }

        /// <summary>
        /// 程序运行时进去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ee = e.ExceptionObject as Exception;
            //string strMsg="错误时间：" + DateTime.Now.ToString() + "\n错误消息：" + ee.Message + "\n" + (ee.InnerException == null ? "" : ee.InnerException.Message) + "\n错误方法：" + ee.TargetSite + "\n错误对象：" + ee.Source;
            string strMsg = ee.ToString();
            ShowMessageHelper.ShowBoxMsg(strMsg);
            saveErrorMsg(strMsg);

        }

        /// <summary>
        /// 异常日志入库
        /// </summary>
        /// <param name="strMsg"></param>
        private static void saveErrorMsg(string strMsg)
        {
            CommonBLL common = new CommonBLL();
            if (SystemConfig.UserInfo != null)
            {
                DAErrorlog error = new DAErrorlog();
                error.Dictuserid = Convert.ToDecimal(SystemConfig.UserInfo.UserId);
                error.Createdate = DateTime.Now;
                error.LastUpdateDate = DateTime.Now;
                error.Opcontent = "系统异常信息: " + strMsg;
                error.Usercode = SystemConfig.UserInfo.UserCode;
                error.Usertype = SystemConfig.UserInfo.UserType.ToString();
                error.Username = SystemConfig.UserInfo.UserName;
                error.Ipaddress = common.GetHostIP();//获取本机IP地址
                error.Machinename = common.GetHostName();//获取本机机器名
                if (!new DAErrorLogBLL().SaveErrorLog(error))
                {
                    ShowMessageHelper.ShowBoxMsg("日志入库失败");
                }

            }
        }
        private static Mutex mutex = null;
        /// <summary>
        /// 判断是否已经运行了程序
        /// </summary>
        private static void GlobalMutex()
        {
            // 是否第一次创建mutex
            bool newMutexCreated = false;
            string mutexName = "Global\\" + "LIMS";
            try
            {
                mutex = new Mutex(false, mutexName, out newMutexCreated);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);
            }

            // 第一次创建mutex
            if (newMutexCreated)
            {
                Console.WriteLine("程序已启动");
                //todo:此处为要执行的任务
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("另一个窗口已在运行，不能重复运行。");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);//退出程序
            }
        }
        /// <summary>
        /// 关闭所有窗体
        /// </summary>
        /// <param name="mainDialog"></param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CloseALLForm(Form mainDialog)
        {

            foreach (Form form in mainDialog.MdiChildren)
            {
                form.Close();
            }

        }
    }
}
