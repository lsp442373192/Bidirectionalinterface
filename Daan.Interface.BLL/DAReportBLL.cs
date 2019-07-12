using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.Dao;
using Daan.Interface.Util;

namespace Daan.Interface.BLL
{
    public class DAReportBLL
    {
        BaseService service = new BaseService();


        /// <summary>
        /// 添加报告记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object InsertDAReportInfo(DAReport report)
        {
            return service.insert("InsertDAReport", report);
        }
        
        /// <summary>
        /// 修改报告记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateDAReportInfo(DAReport report)
        {
            return service.update("UpdateDAReport", report);
        }

        /// <summary>
        /// 删除报告记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object DeleteDAReportByRequestCode(string RequestCode)
        {
            return service.delete("DeleteDAReportByRequestCode", RequestCode);
        }


        /// <summary>
        /// 查询报告记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<DAReport> SelectDAReportInfo()
        {
            //return service.selectObj<DAReport>("SelectDAReport", null);
            return service.QueryList<DAReport>("SelectDAReport", null).ToList<DAReport>();
        }

        public List<DAReport> SelectDAReportByRequestcode(Hashtable ht)
        {
            return new BaseService().QueryList<DAReport>("SelectDAReportByRequestcode", ht).ToList();
        }
    }
}
