using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.Dao;

namespace Daan.Interface.BLL
{
    public class VDALisrequesttestBLL 
    {

        /// <summary>
        /// 列表查询全部 zhangwei
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<VDaLisrequesttest> GetVDaLisrequesttestList(Hashtable dt)
        {
            return new BaseService().ViewQueryList<VDaLisrequesttest>("Da.SelectVDaLisrequesttest", dt).ToList();
        }

        /// <summary>
        /// 查询医院和达安项目代码 zhangwei
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<VDaLisrequesttest> GetSelectVDaLisrequesttestList(Hashtable dt)
        {
            return new BaseService().ViewQueryList<VDaLisrequesttest>("Da.SelectVDaLisrequesttestList", dt).ToList();
        }
    }
}
