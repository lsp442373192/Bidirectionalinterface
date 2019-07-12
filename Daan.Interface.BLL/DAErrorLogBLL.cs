using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Daan.Interface.Entity;
using Daan.Interface.Dao;

namespace Daan.Interface.BLL
{
   public  class DAErrorLogBLL
    {
       public bool SaveErrorLog(DAErrorlog library)
       {
           int nflag = 0;
           //新增
           if (library.Errorlogid == 0 || library.Errorlogid == null)
           {
               try
               {
                   //library.Errorlogid = new BaseService().getSeqID("SEQ_DA_ERRORLOG");
                   new BaseService().insert("Da.InsertDAErrorlog", library);
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

           }
           return nflag > 0;
       }
       /// <summary>
       /// 查询日志信息
       /// </summary>
       /// <param name="string"></param>
       /// <returns></returns>
       public List<DAErrorlog> SelectDAErrorlogbyDate(Hashtable ht)
       {
           return new BaseService().QueryList<DAErrorlog>("Da.SelectDAErrorlogByDate", ht).ToList();
       }
       
    }
}
