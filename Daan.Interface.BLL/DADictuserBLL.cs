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
    public class DADictuserBLL
    {
        BaseService baseService = new BaseService();
        ///<summary>
        ///根据Usercode获取用户 fenghp
        ///</summary>
        ///<param name="DADictuser"></param>
        /// <returns></returns>
        public DADictuser GetDADictuserInfoByUserCode(DADictuser dictuser)
        {
            return baseService.selectObj<DADictuser>("GetDADictuserInfoByCode", dictuser);
        }
        ///<summary>
        ///获取用户信息 fenghp
        ///</summary>
        ///<param name="string"></param>
        /// <returns></returns>
        public List<DADictuser> GetDADictuserInfo(Hashtable ht)
        {
            return baseService.QueryList<DADictuser>("SelectDADictuser", ht).ToList();
        }
        /// <summary>
        /// 保存操作 fenghp
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Save(DADictuser user)
        {
            int nflag = 0;
            //新增
            if (user.Dictuserid == 0 || user.Dictuserid == null)
            {
                try
                {
                    //user.Dictuserid = new BaseService().getSeqID("SEQ_DA_DICTUSER");
                    new BaseService().insert("InsertDADictuser", user);
                    nflag = 1;
                }
                catch (Exception ex)
                {
                    nflag = 0;
                    throw new Exception(ex.Message);
                }
            }
            else//修改
            {
                try
                {
                    new BaseService().update("UpdateDADictuser", user);
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
        /// <summary>
        /// 删除 fenghp
        /// </summary>
        /// <param name="Dictuserid"></param>
        /// <returns></returns>
        public int DeleteDADictuser(string strId)
        {
            int nflag = 0;
            nflag = baseService.delete("DeleteDADictuser", strId);
            return nflag;
        }
    }
}
