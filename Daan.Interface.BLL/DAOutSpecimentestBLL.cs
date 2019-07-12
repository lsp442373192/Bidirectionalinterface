using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Daan.Interface.Dao;

namespace Daan.Interface.BLL
{
    public class DAOutSpecimentestBLL : BaseService
    {

      public DataTable GetOutspecimenTestTable(Hashtable dt)
      {
          DataSet ds = selectDS("SelectDAOutspecimentest", dt);
          return ds.Tables[0];
      }
      /// <summary>
      /// 根据条码号查询常规结果是否获取完毕 zhouy
      /// </summary>
      /// <param name="user"></param>
      /// <returns></returns>
      public bool SelectIsFullByRequestCode(string RequestCode)
      {
          bool b = false;

          object i = selectObj<object>("SelectIsFullByRequestCode", RequestCode);

          if (Convert.ToDecimal(i) > 0) { b = true; }

          return b;
      }

      /// <summary>
      /// 组合发送 查询要发送的代码 zhouy
      /// </summary>
      /// <param name="barcode">达安条码号</param>
      /// <returns></returns>
      public DataTable SelectSendGruopCodeByRequestCode(string barcode)
      {
          return new BaseService().selectDS("SelectSendGruopCodeByRequestCode", barcode).Tables[0];
      }
    }
}
