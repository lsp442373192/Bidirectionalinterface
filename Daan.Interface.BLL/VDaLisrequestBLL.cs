using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.Interface.Dao;
using System.Collections;
using Daan.Interface.Entity;

namespace Daan.Interface.BLL
{
    public class VDALisrequestBLL 
    {
        /// <summary>
        /// 列表查询全部 zhangwei
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<VDaLisrequest> GetVDaLisrequestList(Hashtable dt)
        {
            return new BaseService().ViewQueryList<VDaLisrequest>("Da.SelectVDaLisrequest", dt).ToList();
        }
    }
}
