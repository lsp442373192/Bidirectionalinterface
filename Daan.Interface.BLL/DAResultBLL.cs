using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.Dao;
using Daan.Interface.Util;
using System.Data;

namespace Daan.Interface.BLL
{
    public class DAResultBLL
    {
        BaseService service = new BaseService();


        /// <summary>
        /// 添加常规结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object InsertDAResultInfo(DAResult config)
        {
            return service.insert("InsertDAResult", config);
        }

        /// <summary>
        /// 修改常规结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateDAResultInfo(DAResult config)
        {
            return service.update("UpdateDAResult", config);
        }

        /// <summary>
        /// 删除常规结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object DeleteDAResult(DAResult config)
        {
            return service.delete("DeleteDAResult", config);
        }

        /// <summary>
        /// 删除常规结果记录
        /// </summary>
        /// <param name="resultid">拼接resultid 逗号隔开</param>
        /// <returns></returns>
        public bool DeleteDAResult(string resultid)
        {
            if (resultid == "") { return false; }
            return service.delete("DeleteDAResultById", resultid) > 0;
        }

        /// <summary>
        /// 查询常规结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<DAResult> SelectDAResultInfo()
        {
            //   return service.selectObj<DAResult>("SelectDAResult", null);
            return service.QueryList<DAResult>("SelectDAResult", null).ToList<DAResult>();
        }

        /// <summary>
        /// 根据达安条码或医院条码、样本号查询结果
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public List<DAResult> GetDAResultList(Hashtable ht)
        {
            return new BaseService().QueryList<DAResult>("Da.SelectDAResultByCode", ht).ToList();
        }

        /// <summary>
        /// 根据条码号查询常规结果是否获取完毕 zhouy
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SelectIsFullResultByRequestCode(string RequestCode)
        {
            bool b = false;

            object i = service.selectObj<object>("SelectIsFullResultByRequestCode", RequestCode);

            if (Convert.ToDecimal(i) > 0) { b = true; }

            return b;
        }

        /// <summary>
        /// 单项发送 查询要发送的代码 zhouy
        /// </summary>
        /// <param name="barcode">达安条码号</param>
        /// <returns></returns>
        public DataTable SelectSendTestCodeByRequestCode(string barcode)
        {
            return new BaseService().selectDS("SelectSendTestCodeByRequestCode", barcode).Tables[0];
        }



    }
}
