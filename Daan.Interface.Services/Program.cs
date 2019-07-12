using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Daan.Interface.Util;
using System.Configuration;

namespace Daan.Interface.Services
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            GlobalMutex();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LIMSService());
        }

        /// <summary>
        /// 调试时进去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ee = e.Exception;
            ShowMessageHelper.ShowBoxMsg("错误时间：" + DateTime.Now.ToString() + "\n错误消息：" + ee.Message + "\n" + (ee.InnerException == null ? "" : ee.InnerException.Message) + "\n错误方法：" + ee.TargetSite + "\n错误对象：" + ee.Source);
        }

        /// <summary>
        /// 程序运行时进去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ee = e.ExceptionObject as Exception;
            ShowMessageHelper.ShowBoxMsg("错误时间：" + DateTime.Now.ToString() + "\n错误消息：" + ee.Message + "\n" + (ee.InnerException == null ? "" : ee.InnerException.Message) + "\n错误方法：" + ee.TargetSite + "\n错误对象：" + ee.Source);
        }
        private static Mutex mutex = null;
        /// <summary>
        /// 判断是否已经运行了程序
        /// </summary>
        private static void GlobalMutex()
        {
            // 是否第一次创建mutex
            bool newMutexCreated = false;
            string mutexName = "Global\\" + "Daan.Interface.Services";
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
                if (ConfigurationManager.AppSettings["IsRunMore"].ToString() == "0")
                {
                    ShowMessageHelper.ShowBoxMsg("另一个窗口已在运行，不能重复运行。");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(1);//退出程序
                }
            }
        }

    }
}
