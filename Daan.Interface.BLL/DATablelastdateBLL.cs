using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.Interface.Dao;
using Daan.Interface.Entity;
using System.Data;
using System.Collections;

namespace Daan.Interface.BLL
{
    public class DATablelastdateBLL
    {
        BaseService service = new BaseService();

        /// <summary>
        /// 保存设置信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SaveDATablelastdateInfo(DATablelastdate tablelastdate)
        {
            bool b = true;
            //表中有记录
            if (SelectyDATablelastdateInfoByTableName(tablelastdate.Tablename) == DateTime.MinValue)
            {
                InsertDATablelastdateInfo(tablelastdate);
            }
            else
            {
                b = UpdateDATablelastdateInfo(tablelastdate);
            }
            return b;
        }

        /// <summary>
        /// 添加接收时间信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object InsertDATablelastdateInfo(DATablelastdate tablelastdate)
        {
            return service.insert("InsertDATablelastdate", tablelastdate);
        }

        /// <summary>
        /// 修改接收时间信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateDATablelastdateInfo(DATablelastdate tablelastdate)
        {
            bool b = true;
            int i = service.update("UpdateDATablelastdate", tablelastdate);
            if (i == 0) { b = false; }
            return b;

        }

        /// <summary>
        /// 查询接收时间信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<DATablelastdate> SelectyDATablelastdateInfo()
        {
            return service.QueryList<DATablelastdate>("SelectDATablelastdate", null).ToList<DATablelastdate>();
        }
        /// <summary>
        /// 根据表名查询接收时间信息
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public List<DATablelastdate> SelectyDATablelastdateInfo(Hashtable ht)
        {
            return service.QueryList<DATablelastdate>("SelectDATablelastdate", ht).ToList<DATablelastdate>();
        }
        /// <summary>
        /// 查询反审核时间
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DateTime SelectyDATablelastdateInfoByTableName(string tablename)
        {
            return service.selectObj<DateTime>("SelectDATablelastdateByTableName", tablename);
        }
    }
}
