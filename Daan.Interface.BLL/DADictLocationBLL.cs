using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.Interface.Dao;
using Daan.Interface.Entity;
using System.Collections;

namespace Daan.Interface.BLL
{
    public class DADictLocationBLL : BaseService
    {
        BaseService service = new BaseService();

        #region >>> zhangwei
        /// <summary>
       /// 查询字典库
       /// </summary>
       /// <param name="ht"></param>
       /// <returns></returns>
        public List<DADictlocation> SelectDictlibrary(Hashtable ht)
        {
            return service.QueryList<DADictlocation>("SelectDictlocation", ht).ToList();
        }
        #endregion

        #region >>> zhangwei
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool SaveDictLocation(DADictlocation location)
        {
            int nflag = 0;
            //新增
            if (location.Dictlocationid == 0 || location.Dictlocationid == null)
            {
                try
                {
                    // library.Outspecimenid = new BaseService().getSeqID("SEQ_DA_OUTSPECIMEN");
                    new BaseService().insert("InsertDictlocation", location);
                    nflag = 1;
                }
                catch (Exception ex)
                {
                    nflag = 0;
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                update("UpdateDictlocation", location);
                nflag = 1;
            }
            return nflag > 0;
        }
        #endregion
    }
}
