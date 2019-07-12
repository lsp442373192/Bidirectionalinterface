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
    public class DAPathologyresultBLL
    {
        BaseService service = new BaseService();


        /// <summary>
        /// 添加病理结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object InsertDAPathologyresultInfo(DAPathologyresult config)
        {
            return service.insert("InsertDAPathologyresult", config);
        }

        /// <summary>
        /// 修改病理结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateDAPathologyresultInfo(DAPathologyresult config)
        {
            return service.update("UpdateDAPathologyresult", config);
        }

        /// <summary>
        /// 删除病理结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object DeleteDAPathologyresult(DAPathologyresult config)
        {
            return service.insert("DeleteDAPathologyresult", config);
        }


        /// <summary>
        /// 查询病理结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<DAPathologyresult> SelectDAPathologyresultInfo()
        {
           // return service.selectObj<List<DAPathologyresult>>("SelectDAPathologyresult", null);
            return service.QueryList<DAPathologyresult>("SelectDAPathologyresult", null).ToList<DAPathologyresult>();
        }

        /// <summary>
        /// 根据条码号查询病理结果是否获取完毕 zhouy
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SelectIsFullPathologyResultByRequestCode(string RequestCode)
        {
            bool b = false;

            object i = service.selectObj<object>("SelectIsFullResultByRequestCode", RequestCode);

            if (Convert.ToDecimal(i) > 0) { b = true; }

            return b;
        }


    }
}
