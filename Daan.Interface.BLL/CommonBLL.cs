using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using Daan.Interface.Dao;
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.Util;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Configuration;
using System.Net;
using System.Net.Sockets;
namespace Daan.Interface.BLL
{
    public class CommonBLL
    {
        BaseService service = new BaseService();

        DAMicorgresultBLL micorgresultbll = new DAMicorgresultBLL();//细菌
        DAResultBLL resultbll = new DAResultBLL();
        DAPathologyresultBLL pathologyresultbll = new DAPathologyresultBLL();

        #region >>>> zhouy 处理结果和报告

        /// <summary>
        /// 处理结果和报告 0 失败，3 部分获取，4 完整获取
        /// </summary>
        /// <param name="SID">SID</param>
        /// <param name="msglist">错误信息集合</param>
        /// <param name="requestcode">条码号</param>
        /// <param name="config">配置文件类</param>
        /// <returns></returns>
        public int TreatmentResultReport(string SID, List<string> msglist, string requestcode, string model)
        {
            //获取结果
            string[] strQueryResult = GetResult(SID, requestcode);

            int status = 0;

            if (strQueryResult[0] == "0")
            {
                msglist.Add(string.Format("获取结果失败:{1}", requestcode, strQueryResult[1]));
                return status;
            }

            //结果类型
            int itemtype = 0;
            //处理结果
            bool BResult = ImportResult(strQueryResult[1], msglist, ref itemtype, requestcode, model);

            //获取结果失败 不处理报告 ，直接返回
            if (!BResult) { return status; }

            //处理报告，更改状态
            status = InsertReportAddStatus(SID, msglist, requestcode, model, itemtype);

            return status;
        }

        #region >>>> zhouy 插入结果
        /// <summary>
        /// 插入结果
        /// </summary>
        /// <param name="resultxml">结果XML字符串</param>
        /// <returns></returns>
        private bool ImportResult(string resultxml, List<string> msglist, ref int itemtype, string requestcode, string model)
        {
            //执行的SQL集合
            SortedList SQLlist = new SortedList(new MySort());
            bool b = true;
            string errormsg = "";
            try
            {
                DataSet ds = XMLHelper.CXmlToDataSet(resultxml);
                DataTable dthead = ds.Tables["data_row"];//基本信息               

                //是否获得结果数据
                bool notdata = false;

                if (dthead != null)
                {
                    //获取结果类型
                    if (dthead.Columns.Contains("ItemType") && dthead.Rows[0]["ItemType"] != DBNull.Value)
                    {
                        itemtype = Convert.ToInt32(dthead.Rows[0]["ItemType"]);//更新条件
                    }

                    //组合对接
                    if (model == "1")
                    {
                        DataTable dtGroupTest = ds.Tables["BarcodeGroupTest"];//完成检验的组合项目

                        UpdateOutSpecimentest(SQLlist, dtGroupTest, dthead.Rows[0]);
                        notdata = dtGroupTest == null;
                    }//单项对接 操作明细
                    else
                    {
                        DataTable dtResults = ds.Tables["Testresults"];//常规
                        DataTable dtMicantiResults = ds.Tables["AntiResult"];//药敏-抗生素
                        DataTable dtMicorgResults = ds.Tables["OrgResult"];//细菌
                        DataTable dtPathologyResults = ds.Tables["PathologyResult"];//病理
                        DataTable dtImages = ds.Tables["Images"];//图片

                        InsertMicorgresult(SQLlist, dtMicorgResults, dtMicantiResults, dthead.Rows[0]);
                        InsertResult(SQLlist, dtResults, dthead.Rows[0]);
                        InsertPathologyResult(SQLlist, dtPathologyResults, dthead.Rows[0]);
                        InsertLisPicture(SQLlist, dtImages, dthead.Rows[0]);
                        notdata = dtResults == null && dtPathologyResults == null;
                    }

                    ds.Dispose();
                    //删除报告
                    SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAReportByRequestCode" } }, requestcode);
                    //改报告状态
                    Hashtable ht = new Hashtable();
                    ht.Add("RequestCode", requestcode);
                    ht.Add("Status", 2);
                    SQLlist.Add(new Hashtable() { { "UPDATE", "UpdateDAOutspecimenByRequestCode" } }, ht);

                    b = service.ExecuteSqlTran(SQLlist, ref errormsg);
                }


                //没有结果
                if (notdata) { throw new Exception("没有获取到结果数据"); }


            }
            catch (Exception ex)
            {
                b = false;
                errormsg = ex.Message;
            }
            //错误信息添加到集合
            if (!b) { msglist.Add(errormsg); }

            return b;
        }
        #endregion

        #region >>>> zhouy 添加报告记录更改状态
        /// <summary>
        /// 添加报告记录更改状态
        /// </summary>
        /// <param name="SID"></param>
        /// <param name="msglist"></param>
        /// <param name="requestcode"></param>
        /// <param name="config"></param>
        /// <param name="itemtype"></param>
        /// <returns></returns>
        private int InsertReportAddStatus(string SID, List<string> msglist, string requestcode, string model, int itemtype)
        {
            //报告
            DataTable dtReports = GetReport(SID, msglist, requestcode);
            //获取报告失败 直接返回
            if (dtReports.Rows.Count == 0) { return 0; }
            //执行的SQL集合
            SortedList SQLlist = new SortedList(new MySort());


            string errormsg = string.Empty;
            int status = 3;
            try
            {
                bool breport = true;
                #region >>>> zhouy 添加报告
                for (int i = 0; i < dtReports.Rows.Count; i++)
                {
                    DataRow drreport = dtReports.Rows[i];

                    DAReport _report = new DAReport();
                    _report.Reportid = Convert.ToDecimal(drreport["Reportid"]);
                    _report.Requestcode = drreport["RequestCode"].ToString();
                    if (dtReports.Columns.Contains("HospSampleID") && drreport["HospSampleID"] != DBNull.Value)
                    {
                        _report.Hospsampleid = drreport["HospSampleID"].ToString();
                    }
                    if (dtReports.Columns.Contains("HospSampleNumber") && drreport["HospSampleNumber"] != DBNull.Value)
                    {
                        _report.Hospsamplenumber = drreport["HospSampleNumber"].ToString();
                    }
                    if (dtReports.Columns.Contains("ReportData") && drreport["ReportData"] != DBNull.Value && drreport["ReportData"].ToString() != string.Empty)
                    {
                        _report.Reportdata = Convert.FromBase64String(drreport["ReportData"].ToString());
                    }

                    if (_report.Reportdata.Length == 0)
                    {
                        breport = false;
                    }

                    if (dtReports.Columns.Contains("printcount") && drreport["printcount"] != DBNull.Value)
                    {
                        _report.Printcount = Convert.ToDecimal(drreport["printcount"]);
                    }
                    if (dtReports.Columns.Contains("printdate") && drreport["printdate"] != DBNull.Value)
                    {
                        _report.Printtime = Convert.ToDateTime(drreport["printdate"]);
                    }
                    if (dtReports.Columns.Contains("ReportType") && drreport["ReportType"] != DBNull.Value)
                    {
                        _report.Reporttype = drreport["ReportType"].ToString();
                    }
                    if (dtReports.Columns.Contains("status") && drreport["status"] != DBNull.Value)
                    {
                        _report.Status = drreport["status"].ToString();
                    }
                    if (dtReports.Columns.Contains("Papersize") && drreport["Papersize"] != DBNull.Value)
                    {
                        _report.Papersize = drreport["Papersize"].ToString();
                    }

                    SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAReport" } }, _report);
                }
                #endregion

                Hashtable ht = new Hashtable();
                ht.Add("RequestCode", requestcode);

                //组合对应模式
                if (model == "1")
                {
                    bool isfull = new DAOutSpecimentestBLL().SelectIsFullByRequestCode(requestcode);
                    status = isfull ? 4 : 3;
                }
                //组合单项全对应模式
                else
                {
                    if (breport)
                    {
                        //ItemType 0.普通项目，1.病理
                        if (itemtype == 0)
                        {
                            bool isfull = resultbll.SelectIsFullResultByRequestCode(requestcode);
                            status = isfull ? 4 : 3;
                        }
                        else
                        {
                            bool isfull = pathologyresultbll.SelectIsFullPathologyResultByRequestCode(requestcode);
                            status = isfull ? 4 : 3;
                        }
                    }
                }

                ht.Add("Status", status);
                SQLlist.Add(new Hashtable() { { "UPDATE", "UpdateDAOutspecimenByRequestCode" } }, ht);

                bool b = service.ExecuteSqlTran(SQLlist, ref errormsg);
                if (!b) { status = 0; }
            }
            catch (Exception ex)
            {
                status = 0;
                errormsg = ex.Message;
            }
            //错误信息添加到集合
            if (status == 0) { msglist.Add("插入报告更改失败:" + errormsg); }
            return status;
        }
        #endregion

        #region >>>> zhouy WebService获取结果
        /// <summary>
        /// WebService获取结果
        /// </summary>
        /// <param name="SID"></param>
        /// <returns></returns>
        private string[] GetResult(string SID, string RequestCode)
        {
            string[] objQueryResult = new string[] { SID, RequestCode };
            return WebServiceUtils.ExecuteMethod("QueryResult", objQueryResult).Split('|');
        }

        #endregion

        #region >>>> zhouy WebService获取报告
        /// <summary>
        /// WebService获取结果
        /// </summary>
        /// <param name="SID"></param>
        /// <returns></returns>
        public DataTable GetReport(string SID, List<string> msglist, string RequestCode)
        {
            DataTable dt = new DataTable();
            string[] objReport = new string[] { SID, RequestCode };
            //string[] strReport = WebServiceUtils.Execute(config.Address, "GetReportAuto", objReport).Split('|');

            string[] strReport = WebServiceUtils.ExecuteMethod("GetReportAuto", objReport).Split('|');
            if (strReport[0] == "0")
            {
                msglist.Add(string.Format("获取报告失败:{0}", strReport[1]));
            }
            else
            {
                DataSet ds = XMLHelper.CXmlToDataSet(strReport[1]);
                if (ds.Tables.Count > 0) { dt = ds.Tables[0]; }
                else { msglist.Add("获取报告失败:没有报告数据"); }

            }
            return dt;
        }

        #endregion

        #region >>>> zhouy 添加 【细菌】和【药敏(抗生素)】 结果
        /// <summary>
        /// 添加 细菌 结果
        /// </summary>
        /// <param name="SQLlist"></param>
        private void InsertMicorgresult(SortedList SQLlist, DataTable dtMicorg, DataTable dtmicanti, DataRow dr)
        {


            //先删子表 再删主表
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAMicantiresultByRequestCode" } }, dr["RequestCode"]);
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAMicorgresultByRequestCode" } }, dr["RequestCode"]);

            //无数据返回
            if (dtMicorg == null) { return; }

            for (int i = 0; i < dtMicorg.Rows.Count; i++)
            {
                DataRow drmicorg = dtMicorg.Rows[i];

                DAMicorgresult _micorgresult = new DAMicorgresult();
                _micorgresult.Micorgresultid = micorgresultbll.GetMicorgResultID();
                _micorgresult.Requestcode = dr["RequestCode"].ToString();
                if (dr["HospSampleID"] != DBNull.Value && dr["HospSampleID"].ToString() != string.Empty)
                {
                    _micorgresult.Hospsampleid = dr["HospSampleID"].ToString();
                }
                else if (dr.Table.Columns.Contains("HospSampleNumber") && dr["HospSampleNumber"] != DBNull.Value && dr["HospSampleNumber"].ToString() != string.Empty)
                {
                    _micorgresult.Hospsamplenumber = dr["HospSampleNumber"].ToString();
                }
                if (dtMicorg.Columns.Contains("EngOrgName") && drmicorg["EngOrgName"] != DBNull.Value)
                {
                    _micorgresult.Engorgname = drmicorg["EngOrgName"].ToString();
                }
                if (dtMicorg.Columns.Contains("OrganismCode") && drmicorg["OrganismCode"] != DBNull.Value)
                {
                    _micorgresult.Organismcode = drmicorg["OrganismCode"].ToString();
                }
                if (dtMicorg.Columns.Contains("OrganismName") && drmicorg["OrganismName"] != DBNull.Value)
                {
                    _micorgresult.Organismname = drmicorg["OrganismName"].ToString();
                }
                if (dtMicorg.Columns.Contains("Tips") && drmicorg["Tips"] != DBNull.Value)
                {
                    _micorgresult.Tips = drmicorg["Tips"].ToString();
                }
                if (dtMicorg.Columns.Contains("Quantity") && drmicorg["Quantity"] != DBNull.Value)
                {
                    _micorgresult.Quantity = drmicorg["Quantity"].ToString();
                }
                if (dtMicorg.Columns.Contains("QuantityComment") && drmicorg["QuantityComment"] != DBNull.Value)
                {
                    _micorgresult.Quantitycomment = drmicorg["QuantityComment"].ToString();
                }
                if (dtMicorg.Columns.Contains("displayorder") && drmicorg["displayorder"] != DBNull.Value)
                {
                    _micorgresult.Displayorder = Convert.ToDecimal(drmicorg["displayorder"]);
                }
                if (dtMicorg.Columns.Contains("ReportOption") && drmicorg["ReportOption"] != DBNull.Value)
                {
                    _micorgresult.Reportoption = drmicorg["ReportOption"].ToString();
                }
                //获取细菌的药敏
                DataRow[] drs = dtmicanti.Select("dictorganismid=" + drmicorg["dictorganismid"]);
                InsertMicantiResult(SQLlist, drs, dr, _micorgresult.Micorgresultid);

                SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAMicorgresult" } }, _micorgresult);
            }

        }

        /// <summary>
        /// 添加药敏(抗生素)结果
        /// </summary>
        /// <param name="SQLlist"></param>
        private void InsertMicantiResult(SortedList SQLlist, DataRow[] drs, DataRow dr, Decimal? Micorgresultid)
        {
            if (drs.Length == 0) { return; }

            for (int i = 0; i < drs.Length; i++)
            {

                DataRow drmicanti = drs[i];

                DAMicantiresult _micantiresult = new DAMicantiresult();

                _micantiresult.Micorgresultid = Micorgresultid;
                _micantiresult.Requestcode = dr["RequestCode"].ToString();
                if (dr["HospSampleID"] != DBNull.Value && dr["HospSampleID"].ToString() != string.Empty)
                {
                    _micantiresult.Hospsampleid = dr["HospSampleID"].ToString();
                }
                if (dr.Table.Columns.Contains("HospSampleNumber") && dr["HospSampleNumber"] != DBNull.Value && dr["HospSampleNumber"].ToString() != string.Empty)
                {
                    _micantiresult.Hospsamplenumber = dr["HospSampleNumber"].ToString();
                }
                if (drmicanti.Table.Columns.Contains("AntiCode") && drmicanti["AntiCode"] != DBNull.Value)
                {
                    _micantiresult.Anticode = drmicanti["AntiCode"].ToString();
                }
                if (drmicanti.Table.Columns.Contains("AntiName") && drmicanti["AntiName"] != DBNull.Value)
                {
                    _micantiresult.Antiname = drmicanti["AntiName"].ToString();
                }
                if (drmicanti.Table.Columns.Contains("EngAntiName") && drmicanti["EngAntiName"] != DBNull.Value)
                {
                    _micantiresult.Engantiname = drmicanti["EngAntiName"].ToString();
                }
                if (drmicanti.Table.Columns.Contains("displayorder") && drmicanti["displayorder"] != DBNull.Value)
                {
                    _micantiresult.Displayorder = Convert.ToDecimal(drmicanti["displayorder"]);
                }
                if (drmicanti.Table.Columns.Contains("ResultValue") && drmicanti["ResultValue"] != DBNull.Value)
                {
                    _micantiresult.Resultvalue = drmicanti["ResultValue"].ToString();
                }
                if (drmicanti.Table.Columns.Contains("result") && drmicanti["result"] != DBNull.Value)
                {
                    _micantiresult.Testresult = drmicanti["result"].ToString();
                }
                if (drmicanti.Table.Columns.Contains("srange") && drmicanti["srange"] != DBNull.Value)
                {
                    _micantiresult.Srange = Convert.ToDecimal(drmicanti["srange"]);
                }
                if (drmicanti.Table.Columns.Contains("rrange") && drmicanti["rrange"] != DBNull.Value)
                {
                    _micantiresult.Rrange = Convert.ToDecimal(drmicanti["srange"]);
                }

                SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAMicantiresult" } }, _micantiresult);
            }

        }

        #endregion

        #region >>>> zhouy 添加【病理】结果
        /// <summary>
        /// 添加病理结果
        /// </summary>
        /// <param name="SQLlist"></param>
        private void InsertPathologyResult(SortedList SQLlist, DataTable dt, DataRow dr)
        {
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDAPathologyresultByRequestCode" } }, dr["RequestCode"]);


            if (dt == null) { return; }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drpathology = dt.Rows[i];

                DAPathologyresult _pathologyresult = new DAPathologyresult();
                _pathologyresult.Requestcode = dr["RequestCode"].ToString();
                if (dr["HospSampleID"] != DBNull.Value && dr["HospSampleID"].ToString() != string.Empty)
                {
                    _pathologyresult.Hospsampleid = dr["HospSampleID"].ToString();
                }
                else if (dr["HospSampleNumber"] != DBNull.Value && dr["HospSampleNumber"].ToString() != string.Empty)
                {
                    _pathologyresult.Hospsamplenumber = dr["HospSampleNumber"].ToString();
                }
                if (dt.Columns.Contains("TestID") && drpathology["TestID"] != DBNull.Value)
                {
                    _pathologyresult.Testid = Convert.ToDecimal(drpathology["TestID"]);
                }
                if (dt.Columns.Contains("parentid") && drpathology["parentid"] != DBNull.Value)
                {
                    _pathologyresult.Parentid = Convert.ToDecimal(drpathology["parentid"]);
                }
                if (dt.Columns.Contains("treelevel") && drpathology["treelevel"] != DBNull.Value)
                {
                    _pathologyresult.Treelevel = Convert.ToDecimal(drpathology["treelevel"]);
                }
                if (dt.Columns.Contains("itemname") && drpathology["itemname"] != DBNull.Value)
                {
                    _pathologyresult.Itemname = drpathology["itemname"].ToString();
                }
                if (dt.Columns.Contains("result") && drpathology["result"] != DBNull.Value)
                {
                    _pathologyresult.Result = drpathology["result"].ToString();
                }
                if (dt.Columns.Contains("displayorder") && drpathology["displayorder"] != DBNull.Value)
                {
                    _pathologyresult.Displayorder = Convert.ToDecimal(drpathology["displayorder"]);
                }
                SQLlist.Add(new Hashtable() { { "INSERT", "InsertDAPathologyresult" } }, _pathologyresult);
            }
            #region >>>> qianz 修改病理标本DA
            DAResult _result = new DAResult();


            if (dr["RequestCode"] != DBNull.Value)
            {
                _result.Requestcode = dr["RequestCode"].ToString();//更新条件
                _result.Testresult = dt.Rows[0]["result"].ToString();
                if (dt.Columns.Contains("ReleaseDate") && dt.Rows[0]["ReleaseDate"] != DBNull.Value)
                {
                    _result.Releasedate = Convert.ToDateTime(dt.Rows[0]["ReleaseDate"]);
                }
                if (dt.Columns.Contains("ReleaseByName") && dt.Rows[0]["ReleaseByName"] != DBNull.Value)
                {
                    _result.Releasebyname = dt.Rows[0]["ReleaseByName"].ToString();
                }
                if (dt.Columns.Contains("authorizedate") && dt.Rows[0]["authorizedate"] != DBNull.Value)
                {
                    _result.Authorizedate = Convert.ToDateTime(dt.Rows[0]["authorizedate"]);
                }
                if (dt.Columns.Contains("AuthorizeByName") && dt.Rows[0]["AuthorizeByName"] != DBNull.Value)
                {
                    _result.Authorizebyname = dt.Rows[0]["AuthorizeByName"].ToString();
                }
                if (dt.Columns.Contains("resultflag") && dt.Rows[0]["resultflag"] != DBNull.Value)
                {
                    _result.Resultflag = dt.Rows[0]["resultflag"].ToString();
                }
            }
            SQLlist.Add(new Hashtable() { { "UPDATE", "UpdateDAResultByRequestcodeBl" } }, _result);

            #endregion
        }
        #endregion

        #region >>>> zhouy 修改【常规】结果
        /// <summary>
        /// 修改常规结果
        /// </summary>
        /// <param name="SQLlist"></param>
        private void InsertResult(SortedList SQLlist, DataTable dt, DataRow dr)
        {
            DAResult _resultRequestcode = new DAResult();
            if (dr["RequestCode"] != DBNull.Value)
            {
                _resultRequestcode.Requestcode = dr["RequestCode"].ToString();//更新条件
            }
            SQLlist.Add(new Hashtable() { { "UPDATE", "UpdateDAResultByRequestcode" } }, _resultRequestcode);

            if (dt == null) { return; }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drresult = dt.Rows[i];
                DAResult _result = new DAResult();
                if (dt.Columns.Contains("seqno") && drresult["seqno"] != DBNull.Value)
                {
                    _result.Seqno = drresult["seqno"].ToString();
                }
                if (dr["RequestCode"] != DBNull.Value)
                {
                    _result.Requestcode = dr["RequestCode"].ToString();//更新条件
                }
                if (dt.Columns.Contains("SingleItem") && drresult["SingleItem"] != DBNull.Value)
                {
                    _result.Datestcode = drresult["SingleItem"].ToString();//更新条件
                }
                //if (dt.Columns.Contains("Singleitemname") && drresult["Singleitemname"] != DBNull.Value)
                //{
                //    _result.Datestname = drresult["Singleitemname"].ToString();//更新条件
                //}
                if (dt.Columns.Contains("itemresult") && drresult["itemresult"] != DBNull.Value)
                {
                    _result.Testresult = drresult["itemresult"].ToString();
                }
                if (dt.Columns.Contains("unit") && drresult["unit"] != DBNull.Value)
                {
                    _result.Unit = drresult["unit"].ToString();
                }
                if (dt.Columns.Contains("hlflag") && drresult["hlflag"] != DBNull.Value)
                {
                    _result.Hlflag = drresult["hlflag"].ToString();
                }
                if (dt.Columns.Contains("resultcomment") && drresult["resultcomment"] != DBNull.Value)
                {
                    _result.Resultcomment = drresult["resultcomment"].ToString();
                }
                if (dt.Columns.Contains("Reference") && drresult["Reference"] != DBNull.Value)
                {
                    _result.Reference = drresult["Reference"].ToString();
                }
                if (dt.Columns.Contains("ReleaseDate") && drresult["ReleaseDate"] != DBNull.Value)
                {
                    _result.Releasedate = Convert.ToDateTime(drresult["ReleaseDate"]);
                }
                if (dt.Columns.Contains("ReleaseByName") && drresult["ReleaseByName"] != DBNull.Value)
                {
                    _result.Releasebyname = drresult["ReleaseByName"].ToString();
                }
                if (dt.Columns.Contains("authorizedate") && drresult["authorizedate"] != DBNull.Value)
                {
                    _result.Authorizedate = Convert.ToDateTime(drresult["authorizedate"]);
                }
                if (dt.Columns.Contains("AuthorizeByName") && drresult["AuthorizeByName"] != DBNull.Value)
                {
                    _result.Authorizebyname = drresult["AuthorizeByName"].ToString();
                }
                _result.Status = "1";
                if (dt.Columns.Contains("reportremark") && drresult["reportremark"] != DBNull.Value)
                {
                    _result.Reportremark = drresult["reportremark"].ToString();
                }
                if (dt.Columns.Contains("panicflag") && drresult["panicflag"] != DBNull.Value)
                {
                    _result.Panicflag = drresult["panicflag"].ToString();
                }

                SQLlist.Add(new Hashtable() { { "UPDATE", "UpdateDAResult" } }, _result);
            }
        }
        #endregion

        #region >>>> zhouy 修改订单明细对应结果已出状态
        /// <summary>
        /// 修改订单明细对应结果已出状态
        /// </summary>
        /// <param name="SQLlist"></param>
        private void UpdateOutSpecimentest(SortedList SQLlist, DataTable dt, DataRow dr)
        {
            DAOutspecimentest _outspecimentest = new DAOutspecimentest();
            if (dr["RequestCode"] != DBNull.Value)
            {
                _outspecimentest.Requestcode = dr["RequestCode"].ToString();//更新条件
                _outspecimentest.Status = "0";//更新条件
            }
            SQLlist.Add(new Hashtable() { { "UPDATE", "UpdateDAOutspecimentestStatus" } }, _outspecimentest);

            if (dt == null) { return; }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drresult = dt.Rows[i];
                DAOutspecimentest _test = new DAOutspecimentest();

                if (dr["RequestCode"] != DBNull.Value)
                {
                    _test.Requestcode = dr["RequestCode"].ToString();//更新条件
                }
                if (dt.Columns.Contains("testcode") && drresult["testcode"] != DBNull.Value)
                {
                    _test.Datestcode = drresult["testcode"].ToString();//更新条件
                }
                _test.Status = "1";
                SQLlist.Add(new Hashtable() { { "UPDATE", "UpdateDAOutspecimentestStatus" } }, _test);
            }
        }
        #endregion

        #region >>>> zhouy 添加图形记录
        /// <summary>
        /// 添加图形记录
        /// </summary>
        /// <param name="SQLlist"></param>
        private void InsertLisPicture(SortedList SQLlist, DataTable dt, DataRow dr)
        {
            SQLlist.Add(new Hashtable() { { "DELETE", "DeleteDALisPictureByRequestcode" } }, dr["RequestCode"]);
            if (dt == null) { return; }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drpicture = dt.Rows[i];

                DALispicture _lispicture = new DALispicture();
                _lispicture.Requestcode = dr["RequestCode"].ToString();
                if (dt.Columns.Contains("HospSampleID") && dr["HospSampleID"] != DBNull.Value)
                {
                    _lispicture.Hospsampleid = dr["HospSampleID"].ToString();
                }
                if (dt.Columns.Contains("HospSampleNumber") && dr["HospSampleNumber"] != DBNull.Value)
                {
                    _lispicture.Hospsamplenumber = dr["HospSampleNumber"].ToString();
                }
                if (dt.Columns.Contains("displayorder") && drpicture["displayorder"] != DBNull.Value)
                {
                    _lispicture.Indexno = Convert.ToDecimal(drpicture["displayorder"]);
                }
                if (dt.Columns.Contains("description") && drpicture["description"] != DBNull.Value)
                {
                    _lispicture.Description = drpicture["description"].ToString();
                }
                if (dt.Columns.Contains("IMAGEDATA") && drpicture["IMAGEDATA"] != DBNull.Value && drpicture["IMAGEDATA"].ToString() != string.Empty)
                {
                    _lispicture.Imagedata = Convert.FromBase64String(drpicture["IMAGEDATA"].ToString());
                }

                SQLlist.Add(new Hashtable() { { "INSERT", "InsertDALisPicture" } }, _lispicture);
            }

        }
        #endregion

        #endregion

        #region >>>> zhouy 1.1 WebService登录
        /// <summary>
        /// WebService登录
        /// </summary>
        /// <returns></returns>
        public string[] UserLogin(DAConfig config)
        {
            //当系统配置为空时，返回错误信息
            if (config == null)
            {
                return "0|系统配置信息获取失败".Split('|');
            }
            //登录
            string[] objLogin = new string[] { config.Sitecode, config.Username, config.Password, "医院LIS服务" };
            return WebServiceUtils.ExecuteMethod("Login", objLogin).Split('|');
        }
        #endregion

        #region >>>> fenghp 测试连接方法
        public bool IsConnect(DataBaseinfo info, string testsql)
        {
            bool istrue = false;
            //测试链接
            bool connetctionStatus = false;
            bool timeOut = false;
            TimeoutChecker timeout = new TimeoutChecker(
                    delegate
                    {
                        ISqlMapper mapper = null;
                        try
                        {
                            //获取ISqlMapper尝试连接
                            mapper = mapperobj.NewMapper(info);
                            DataSet ds = new DataSet();
                            mapper.OpenConnection();
                            IDbCommand command = mapper.LocalSession.CreateCommand(CommandType.Text);
                            command.CommandText = testsql;
                            mapper.LocalSession.CreateDataAdapter(command).Fill(ds);
                            connetctionStatus = true;
                            ShowMessageHelper.ShowBoxMsg("数据库连接成功!");
                            istrue = true;
                        }
                        catch(Exception ex)
                        {
                            WriteLog(ex.ToString());
                            //如果没有超时
                            if (!timeOut)
                            {
                                connetctionStatus = true;
                                ShowMessageHelper.ShowBoxMsg(ex.Message+"数据库不存在或用户名、密码错误,请重新输入!");
                            }
                        }
                    },
                    delegate
                    {
                        //如果没有链接上
                        if (!connetctionStatus)
                        {
                            timeOut = true;
                            ShowMessageHelper.ShowBoxMsg("连接超时");
                        }
                    });
            timeout.Wait(5000);
            return istrue;
        }
        #endregion

        #region >>> fenghp 更新数据库脚本（通过bat文件）
        private ArrayList fileList = new ArrayList();  //批处理文件集合
        /// <summary>
        /// 更新数据库脚本(通过执行bat文件)
        /// </summary>
        /// <param name="version">版本号</param>
        public bool ScriptUpdateByBat(DataBaseinfo baseinfo, double version, double newVersion)
        {
            bool istrue = false;
            string fileName = string.Empty;
            try
            {
                if (baseinfo.databasetype == "1")//SQL
                {
                    fileName = "\\VersionSql\\SQL";
                }
                else//ORACEL
                {
                    fileName = "\\VersionSql\\ORA";
                }
                string[] fileNames = Directory.GetFiles(Application.StartupPath + fileName);
                ArrayList versionList = new ArrayList();
                foreach (string fName in fileNames)
                {
                    string f = fName.Substring(0, fName.Length - 4);
                    f = f.Substring(f.LastIndexOf("\\") + 1, f.Length - f.LastIndexOf("\\") - 1);
                    if (version < Convert.ToDouble(f) && Convert.ToDouble(f) <= newVersion)
                    {
                        versionList.Add(Convert.ToDouble(f));
                    }
                }
                //排序
                versionList.Sort();
                for (int i = 0; i < versionList.Count; i++)
                {
                    //生成Bat文件(格式)
                    //OSQL /U sa /P sa -S 192.168.0.153 -d NorthWind -r -i b.sql -o a.txt
                    //Pause
                    if (!File.Exists(Application.StartupPath + "\\ExeScriptLog.txt"))
                    {
                        //创建Log文件
                        FileStream s = File.Create(Application.StartupPath + "\\ExeScriptLog.txt");
                        s.Close();
                    }

                    FileInfo fBat = new FileInfo(Application.StartupPath + "\\ExeScript" + i + ".bat");

                    //创建Bat文件
                    using (StreamWriter sw = fBat.CreateText())
                    {
                        if (baseinfo.databasetype == "1")//SQL
                        {
                            sw.WriteLine(string.Format("OSQL /U {2} /P {3} -S {0} -d {1} -r -i VersionSql\\SQL\\{4}.sql -o ExeScriptLog.txt",
                                baseinfo.datasource, baseinfo.dataname, baseinfo.userid, baseinfo.password, versionList[i].ToString().Length < 2 ? versionList[i].ToString() + ".0" : versionList[i].ToString()));
                            sw.WriteLine("Pause");
                        }
                        else//ORLCLE
                        {
                            sw.WriteLine(string.Format("sqlplus {0}/{1}@{2} @VersionSql\\ORA\\{3}.sql  >> ExeScriptLog.txt",
                                baseinfo.userid, baseinfo.password, baseinfo.dataname, versionList[i].ToString().Length < 2 ? versionList[i].ToString() + ".0" : versionList[i].ToString()));
                            sw.WriteLine("Pause");
                        }
                    }

                    //启动bat
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = Application.StartupPath;
                    process.StartInfo.FileName = "ExeScript" + i + ".bat";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardError = true;//开启出错返回信息
                    process.StartInfo.RedirectStandardOutput = true;//开启输出返回信息
                    process.Start();
                    string strOUT = process.StandardOutput.ReadToEnd();//用于捕捉返回信息。
                    string strERR = process.StandardError.ReadToEnd();//用于捕捉异常信息。

                    fileList.Add(process.StartInfo.FileName);

                    //更新版本信息
                    DASoftversion sv = new DASoftversion();
                    sv.Versioncode = Convert.ToDecimal(versionList[i]);
                    sv.Exceptionlog = strERR == "" ? "执行成功" : strERR;
                    sv.Updatedate = DateTime.Now;
                    new DASoftversionBLL().InsertDASoftversionList(sv);
                }

                if (versionList.Count == 0)//缺失脚本文件
                {
                    ShowMessageHelper.ShowBoxMsg("缺失脚本文件,请联系管理员!", MessageBoxButtons.OK);

                }
                else//执行脚本成功
                {
                    istrue = true;
                }

                //启动Bat文件删除线程
                Thread t = new Thread(new ThreadStart(DeleteBat));
                t.Start();
            }
            catch
            {
                istrue = false;
            }
            return istrue;
        }
        /// <summary>
        /// 删除Bat文件
        /// </summary>
        public void DeleteBat()
        {
            while (fileList.Count > 0)
            {
                Thread.Sleep(5000); //每个文件执行5秒钟，确保执行成功

                lock (fileList)
                {
                    File.Delete(Application.StartupPath + "\\" + fileList[0].ToString());

                    fileList.RemoveAt(0);
                }
            }
        }
        #endregion

        #region >>> fenghp 获取当前操作的主机名
        public string GetHostName()
        {
            return Dns.GetHostName();
        }
        #endregion

        #region  >>> fenghp 获取当前操作主机IP
        public string GetHostIP()
        {
            string stringIP = "";
            try
            {
                IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ip in arrIPAddresses)
                {
                    if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        stringIP = ip.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                stringIP = "IP地址获取出错:" + e.ToString();
            }
            return stringIP;
        }
        #endregion

        #region >>>  zhangwei 导出Excel
        public bool ExportExcel(string fileName, DataGridView dataGridview1)
        {
            if (dataGridview1.Rows.Count <= 0)
                return false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl  files  (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";

            DateTime now = DateTime.Now;
            saveFileDialog.FileName = fileName;// now.Year.ToString().PadLeft(2) + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0') + "-" + now.Hour.ToString().PadLeft(2, '0') + now.Minute.ToString().PadLeft(2, '0') + now.Second.ToString().PadLeft(2, '0');
            //  saveFileDialog.ShowDialog();
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.CreatePrompt = false;
            //  saveFileDialog.CheckFileExists = true;
            DialogResult result = saveFileDialog.ShowDialog();
            string saveFileName = saveFileDialog.FileName;

            //当保存文件名称不为空、保存弹出窗口响应OK    两个条件成立才执行导出
            if (!string.IsNullOrEmpty(fileName) && result == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
                string str = "";
                try
                {
                    //写标题    
                    for (int i = 0; i < dataGridview1.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            str += "\t";
                        }
                        str += dataGridview1.Columns[i].HeaderText;
                    }
                    sw.WriteLine(str);
                    //写内容 
                    for (int j = 0; j < dataGridview1.Rows.Count; j++)
                    {
                        string tempStr = "";
                        for (int k = 0; k < dataGridview1.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                tempStr += "\t";
                            }
                            if (dataGridview1.Rows[j].Cells[k].Value == null)
                            {
                                tempStr += "";
                            }
                            else
                            {
                                //alter bao 2012-09-13 去掉文字中的换行符

                                tempStr += dataGridview1.Rows[j].Cells[k].Value.ToString().Replace((char)13, (char)0).Replace((char)10, (char)0);
                            }
                        }
                        sw.WriteLine(tempStr);
                    }
                    sw.Close();
                    myStream.Close();
                    //  MessageBox.Show("导出成功");
                }
                catch (Exception e)
                {
                    return false;
                    // MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
                return true;
            }
            else
                return false;
        }
        #endregion

        public void WriteLog(string logInfo)
        {
            string datetime = DateTime.Now.ToString("yyyyMMdd");
            string logPath = Application.StartupPath +"\\log\\"+datetime+ "\\Log.txt";
            if (!Directory.Exists(Application.StartupPath + "\\log\\" + datetime))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\log\\" + datetime);
            }
            if (!File.Exists(logPath))
            {
                //创建Log文件
                File.Create(logPath);
                FileStream fs = new FileStream(logPath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.Write(string.Format("{0}-----{1}{2}", DateTime.Now, logInfo, Environment.NewLine));
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(logPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(string.Format("{0}-----{1}{2}", DateTime.Now, logInfo, Environment.NewLine), true, Encoding.Unicode);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
    }
}
