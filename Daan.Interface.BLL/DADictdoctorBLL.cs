using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.Interface.Dao;
using Daan.Interface.Entity;
using System.Collections;

namespace Daan.Interface.BLL
{
    public class DADictdoctorBLL : BaseService
    {
        BaseService service = new BaseService();

        #region >>> zhangwei
        /// <summary>
        /// 查询字典库
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public List<DADictdoctor> SelectDictdoctor(Hashtable ht)
        {
            return service.QueryList<DADictdoctor>("SelectDictdoctor", ht).ToList();
        }
        #endregion

        #region >>> zhangwei
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool SaveDictdoctor(DADictdoctor dictdoctor)
        {
            int nflag = 0;
            //新增
            if (dictdoctor.Dictdoctorid == 0 || dictdoctor.Dictdoctorid == null)
            {
                try
                {
                    // library.Outspecimenid = new BaseService().getSeqID("SEQ_DA_OUTSPECIMEN");
                    new BaseService().insert("InsertDictdoctor", dictdoctor);
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
                update("UpdateDictdoctor", dictdoctor);
                nflag = 1;
            }
            return nflag > 0;
        }
        #endregion

    }
}
