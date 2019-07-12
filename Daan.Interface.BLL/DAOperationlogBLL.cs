using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.Interface.Entity;
using System.Collections;
using Daan.Interface.Dao;

namespace Daan.Interface.BLL
{
  public   class DAOperationlogBLL
    {

      /// <summary>
      /// 根据达安条码查询节点信息 zhangwei
      /// </summary>
      /// <param name="ht"></param>
      /// <returns></returns>
      public List<DAOperationlog> GetDAOperationlogByRequestcode(Hashtable ht)
      {
          return new BaseService().QueryList<DAOperationlog>("Da.SelectDAOperationlogByRequestcode", ht).ToList();
      }

      /// <summary>
      /// 插入节点表信息 zhangwei
      /// </summary>
      /// <param name="library"></param>
      /// <returns></returns>
      public bool SaveDAOperationlog(DAOperationlog library)
      {
          int nflag = 0;
          //新增
          if (library.Operationlogid == 0 || library.Operationlogid == null)
          {
              try
              {
                  //library.Operationlogid = new BaseService().getSeqID("SEQ_DA_OPERATIONLOG");
                  new BaseService().insert("InsertDAOperationlog", library);
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
