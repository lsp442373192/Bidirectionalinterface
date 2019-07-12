using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Daan.Interface.Util;
using Daan.Interface.Dao;

namespace Daan.Interface.BLL
{
   public class DADicustomerBLL
    {

       BaseService service = new BaseService();

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
       public bool DeleteDADicustomer(string strId)
        {
            bool result = false;
            var arrayId = strId.TrimEnd(',').Split(',');
            //oracle语句IN里面的数据不能超过1000个,不能用in子句删除不确定有多少条记录
            SortedList SQLlist = new SortedList(new MySort());
            for (int i = 0; i < arrayId.Length; i++)
            {
                SQLlist.Add(new Hashtable { { "DELETE", "DeleteDictcustomer" } }, arrayId[i]);
            }
            result = service.ExecuteSqlTran(SQLlist);
            return result;
        }
    }
}
