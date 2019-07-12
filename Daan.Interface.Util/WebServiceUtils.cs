using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Net;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Configuration;
using System.Linq;
using System.Xml.Serialization;
using WebService.Lis;
namespace Daan.Interface.Util
{
    public static class WebServiceUtils
    {
        static LisService _server;
        static bool isUpdate = false;
        static string URL = "";
        static string @namespace = "WebService.Lis";
        static string classname = "LisService";

        private static LisService Instance()
        {
            if (_server == null || isUpdate)
            {
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        _server = GetWebServiceInstance(URL) as LisService;
                        isUpdate = false;//还原状态
                        break;
                    }
                    catch (Exception e)
                    {
                        if (i == 2) { throw; }
                    }

                }
            }
            return _server;
        }

        /// <summary>
        /// 调用Webserver方法
        /// </summary>
        /// <param name="MethodName">要执行的方法名</param>
        /// <param name="arrstr">参数</param>
        /// <returns></returns>
        public static string ExecuteMethod(string MethodName, string[] arrstr)
        {
            string returnStr = "";
            try
            {
                LisService server = Instance();
                switch (MethodName)
                {
                    case "Login"://登录
                        returnStr = server.Login(arrstr[0], arrstr[1], arrstr[2], arrstr[3]);
                        break;
                   // case "GetExceptionBarcodes"://获取异常条码
                   //     returnStr = server.GetExceptionBarcodes(arrstr[0], Convert.ToDateTime(arrstr[1]));
                   //     break;
                    case "QueryResult"://获取结果
                        returnStr = server.QueryResult(arrstr[0], arrstr[1]);
                        break;
                    case "GetReportAuto"://获取报告
                        returnStr = server.GetReportAuto(arrstr[0], arrstr[1]);
                        break;
                    case "SendRequestInfo"://发送订单
                        returnStr = server.SendRequestInfo(arrstr[0], arrstr[1]);
                        break;
                    case "SendErrLog"://发送错误消息
                        returnStr = server.SendErrLog(arrstr[0], arrstr[1], arrstr[2]);
                        break;
                    case "GetUerInfo"://客户登录
                        returnStr = server.GetUerInfo(arrstr[0], arrstr[1], arrstr[2]);
                        break;
                   // case "UpdateReportPrintStatusAuto"://更新打印报告状态
                   //     returnStr = server.UpdateReportPrintStatusAuto(arrstr[0], Convert.ToDouble(arrstr[1]));
                   //     break;
                    case "GetDictTestItem"://获取项目
                        returnStr = server.GetDictTestItem(arrstr[0]);
                        break;
                    case "GetTestGroupDetail"://获取组合项目对应关系
                        returnStr = server.GetTestGroupDetail(arrstr[0]);
                        break;
                    default:
                        throw new Exception(string.Format("找不到需要调用的方法，方法名[{0}]", MethodName));
                }

            }
            catch (Exception ex)
            {
                returnStr = "0|" + ex.Message;
                _server = null;
            }
            return returnStr;
        }

        /// <summary>
        /// 设置更新webservice
        /// </summary>
        /// <param name="url">WevService地址</param>
        public static void SetIsUpdate(string url)
        {
            isUpdate = true;
            URL = url;
        }

        ///// <summary>
        ///// 执行调用webservice方法
        ///// </summary>
        ///// <param name="lab"></param>
        ///// <returns></returns>
        //public static string Execute(string URL, string methodname, object[] obj)
        //{
        //    return InvokeWebservice(URL, "WebService.Lis", "LisService", methodname, obj);
        //    // return GetWebServiceInstance(URL, methodname, obj).ToString();

        //}


        /// <summary> 
        /// 根据指定的信息，调用远程WebService方法 
        /// </summary> 
        /// <param name="url">WebService的http形式的地址</param> 
        /// <param name="namespace">欲调用的WebService的命名空间</param> 
        /// <param name="classname">欲调用的WebService的类名（不包括命名空间前缀）</param> 
        /// <param name="methodname">欲调用的WebService的方法名</param> 
        /// <param name="args">参数列表</param> 
        /// <returns>WebService的执行结果</returns> 
        /// <remarks> 
        /// 如果调用失败，将会抛出Exception。请调用的时候，适当截获异常。 
        /// 异常信息可能会发生在两个地方： 
        /// 1、动态构造WebService的时候，CompileAssembly失败。 
        /// 2、WebService本身执行失败。 
        /// </remarks> 
        /// <example> 
        /// <code> 
        /// object obj = InvokeWebservice("http://localhost/GSP_WorkflowWebservice/common.asmx","Genersoft.Platform.Service.Workflow","Common","GetToolType",new object[]{"1"}); 
        /// </code> 
        /// </example> 
        public static string InvokeWebservice(string url, string @namespace, string classname, string methodname, object[] args)
        {
            string str = string.Empty;
            WebClient wc = null;
            Stream stream = null;
            try
            {
                wc = new WebClient();
                stream = wc.OpenRead(url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);

                CSharpCodeProvider csc = new CSharpCodeProvider();
                //CodeDomProvider icc = csc.crete;

                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                CompilerResults cr = CodeDomProvider.CreateProvider("C#").CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
                Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                MethodInfo mi = t.GetMethod(methodname);
                csc.Dispose();

                str = (string)mi.Invoke(obj, args);


            }
            catch (Exception ex)
            {
                str = string.Format("0|{0} \r\n 请求地址：[ {1} ] \r\n  {2}", ex.Message, url, ex.InnerException == null ? "" : ex.InnerException.Message.Replace(",", "*"));
                //return string.Format("0|{0} \r\n 请求地址：[ {1} ] \r\n  {2}", ex.Message, url, ex.InnerException == null ? "" : ex.InnerException.Message);
                // throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
            finally
            {
                stream.Close();
                wc.Dispose();
                //回收
                GC.Collect();
            }
            return str;
        }

        /// <summary>
        /// 根据WebService的URL，生成一个本地的dll,并返回WebService的实例
        /// </summary>
        /// <param name="url">WebService的UR</param>
        /// <returns></returns>
        public static object GetWebServiceInstance(string url)
        {
            object obj = null;
            WebClient web = null;
            Stream stream = null;
            try
            {

                // 1. 使用 WebClient 下载 WSDL 信息。
                web = new WebClient();
                stream = web.OpenRead(url + "?WSDL");
                // 2. 创建和格式化 WSDL 文档。
                ServiceDescription description = ServiceDescription.Read(stream);
                // 3. 创建客户端代理代理类。
                ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
                importer.ProtocolName = "Soap"; // 指定访问协议。
                importer.Style = ServiceDescriptionImportStyle.Client; // 生成客户端代理。
                importer.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties | CodeGenerationOptions.GenerateNewAsync;
                importer.AddServiceDescription(description, null, null); // 添加 WSDL 文档。
                // 4. 使用 CodeDom 编译客户端代理类。
                CodeNamespace nmspace = new CodeNamespace(@namespace); // 为代理类添加命名空间，缺省为全局空间。
                CodeCompileUnit unit = new CodeCompileUnit();
                unit.Namespaces.Add(nmspace);
                ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit);
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                CompilerParameters parameter = new CompilerParameters();
                parameter.GenerateExecutable = false;
                parameter.OutputAssembly = "C://DBMS_Service.dll"; // 可以指定你所需的任何文件名。

                parameter.ReferencedAssemblies.Add("System.dll");
                parameter.ReferencedAssemblies.Add("System.XML.dll");
                parameter.ReferencedAssemblies.Add("System.Web.Services.dll");
                parameter.ReferencedAssemblies.Add("System.Data.dll");
                CompilerResults result = provider.CompileAssemblyFromDom(parameter, unit);
                if (result.Errors.HasErrors)
                {
                    // 显示编译错误信息
                    System.Text.StringBuilder sb = new StringBuilder();
                    foreach (CompilerError ce in result.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
                //生成代理实例
                System.Reflection.Assembly assembly = Assembly.Load("DBMS_Service");
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                obj = Activator.CreateInstance(t);

            }
            catch (Exception ex)
            {
                //  ShowMessageHelper.ShowBoxMsg("");
                throw new Exception(string.Format("{0} \r\n 请求地址：[ {1} ] \r\n  {2}", ex.Message, url, ex.InnerException == null ? "" : ex.InnerException.Message.Replace(",", "*")));
                //obj = string.Format("{0} \r\n 请求地址：[ {1} ] \r\n  {2}", ex.Message, url, ex.InnerException == null ? "" : ex.InnerException.Message.Replace(",", "*"));
                //return string.Format("0|{0} \r\n 请求地址：[ {1} ] \r\n  {2}", ex.Message, url, ex.InnerException == null ? "" : ex.InnerException.Message);
                // throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
            finally
            {
                web.Dispose();
                //回收
                GC.Collect();
            }
            return obj;

        }


    }
}