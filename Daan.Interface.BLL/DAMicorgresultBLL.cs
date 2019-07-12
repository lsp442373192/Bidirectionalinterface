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

    public class DAMicorgresultBLL
    {
        BaseService service = new BaseService();

        /// <summary>
        /// 获取序列 主表序列 ，SQl中表名为Ora中序列名
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int GetMicorgResultID()
        {
            TableIDDAO tableid = new TableIDDAO();
            return tableid.GetNextId("SEQ_DA_MICORGRESULT");
        }

        /// <summary>
        /// 添加细菌结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object InsertDAMicorgresultInfo(DAMicorgresult config)
        {
            return service.insert("InsertDAMicorgresult", config);
        }

        /// <summary>
        /// 修改细菌结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateDAMicorgresultInfo(DAMicorgresult config)
        {
            return service.update("UpdateDAMicorgresult", config);
        }

        /// <summary>
        /// 删除细菌结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object DeleteDAMicorgresult(DAMicorgresult config)
        {
            return service.insert("DeleteDAMicorgresult", config);
        }


        /// <summary>
        /// 查询细菌结果记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DAMicorgresult SelectDAMicorgresultInfo()
        {
            return service.selectObj<DAMicorgresult>("SelectDAMicorgresult", null);
        }


    }
}
