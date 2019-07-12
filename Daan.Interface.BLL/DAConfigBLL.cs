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
    public class DAConfigBLL
    {
        BaseService service = new BaseService();
        /// <summary>
        /// 保存设置信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SaveDAConfigInfo(DAConfig config)
        {
            bool b = true;
            //表中有记录
            if (SelectyDAConfigInfo(Convert.ToDecimal(config.DaConfigid)) == null)
            {
                InsertDAConfigInfo(config);
            }
            else
            {
                if (UpdateDAConfigInfo(config) == 0) { b = false; }
            }
            return b;
        }

        /// <summary>
        /// 添加设置信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object InsertDAConfigInfo(DAConfig config)
        {
            return service.insert("InsertDAConfig", config);
        }

        /// <summary>
        /// 修改设置信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateDAConfigInfo(DAConfig config)
        {
            return service.update("UpdateDAConfig", config);
        }

        /// <summary>
        /// 查询设置信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DAConfig SelectyDAConfigInfo(decimal da_configid)
        {
            return service.selectObj<DAConfig>("SelectDAConfig", da_configid);
        }

    }
}
