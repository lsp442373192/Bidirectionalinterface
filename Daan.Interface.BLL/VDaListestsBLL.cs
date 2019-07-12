using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.Interface.Dao;
using System.Collections;
using Daan.Interface.Entity;
using System.Data;

namespace Daan.Interface.BLL
{
    public class VDAListestsBLL
    {
        BaseService baseService = new BaseService();
        /// <summary>
        /// 获取医院项目信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public List<VDAListests> GetDaListestsList(Hashtable ht)
        {
            return baseService.ViewQueryList<VDAListests>("SelectVDaListestsresult", ht).ToList();
        }

        /// <summary>
        /// 根据testCode查询插入da_reauet需要的数据   张巍
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public List<VDAListests> GetVDaListestsresultByCode(Hashtable ht)
        {
            return baseService.ViewQueryList<VDAListests>("Da.GetVDaListestsresultList", ht).ToList();
        }


        /// <summary>
        /// 根据testCode查找匹配的医院和达安项目
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataTable GetVDaListestsresultListTable(Hashtable ht)
        {
            DataSet ds = baseService.selectViewDS("Da.GetVDaListestsresultListTable", ht);
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取医院项目关联项目匹配表信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public List<VDAListests> GetDaListestsTestMapList(Hashtable ht)
        {
            return baseService.ViewQueryList<VDAListests>("SelectVDaListestTestMapsresult", ht).ToList();
        }

        /// <summary>
        /// 发送订单明细
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<VDaSubtest> GetSutestList()
        {
            return baseService.ViewQueryList<VDaSubtest>("Da.GetSutestList", null).ToList();

        }

    }
}
