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
    public class DAMicantiresultBLL
    {
        BaseService service = new BaseService();


        /// <summary>
        /// 添加药敏结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object InsertDAMicantiresultInfo(DAMicantiresult config)
        {
            return service.insert("InsertDAMicantiresult", config);
        }

        /// <summary>
        /// 修改药敏结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateDAMicantiresultInfo(DAMicantiresult config)
        {
            return service.update("UpdateDAMicantiresult", config);
        }

        /// <summary>
        /// 删除药敏结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object DeleteDAMicantiresultBy(DAMicantiresult config)
        {
            return service.insert("DeleteDAMicantiresult", config);
        }


        /// <summary>
        /// 查询药敏结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DAMicantiresult SelectDAMicantiresultInfo()
        {
            return service.selectObj<DAMicantiresult>("SelectDAMicantiresult", null);
        }


    }
}
