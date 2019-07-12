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
    public class OutSpecimenBLL : BaseService
    {
        /// <summary>
        /// 列表查询全部
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<DAOutspecimen> GetOutspecimenList(Hashtable dt)
        {
            return this.QueryList<DAOutspecimen>("Da.SelectDAOutspecimen", dt).ToList();
        }

        public bool SaveDictlab(DAOutspecimen library)
        {
            int nflag = 0;
            //新增
            if (library.Outspecimenid == 0 || library.Outspecimenid == null)
            {
                try
                {
                    library.Outspecimenid = getSeqID("SEQ_DICTLAB");
                    insert("InsertDAOutspecimen", library);
                    nflag = 1;
                }
                catch (Exception ex)
                {
                    nflag = 0;
                    throw new Exception(ex.Message);
                }
            }
            return nflag > 0;
        }
       
    }
}
