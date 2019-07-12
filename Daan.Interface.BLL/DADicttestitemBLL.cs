using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.Interface.Dao;
using Daan.Interface.Util;
using Daan.Interface.Entity;
using System.Data;
using System.Collections;


namespace Daan.Interface.BLL
{
    public class DADicttestitemBLL
    {
        BaseService service = new BaseService();
        /// <summary>
        /// 查询达安项目信息 fenghp
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public List<DADicttestitem> SelectDADicttestitem(Hashtable ht)
        {
            return service.QueryList<DADicttestitem>("SelectDADicttestitem", ht).ToList();
        }

        /// <summary>
        /// 根据医院代码获取对照好的达安项目 fenghp
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<DADicttestitem> SelectDADicttestitemByHospCode(Hashtable dt)
        {
            return new BaseService().QueryList<DADicttestitem>("SelectDADicttestitemByHospCode", dt).ToList();
        }
        /// <summary>
        /// 把数据批量插入到DADicttestitem表 fenghp
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public bool InsertDADicttestitem(Hashtable ht)
        {
            try
            {
                DataTable dtdatarow = (DataTable)ht["DATA_ROW"];
                SortedList SQLlist = new SortedList(new MySort());
                SQLlist.Add(new Hashtable { { "DELETE", "DeleteDADicttestitem" } }, string.Empty);
                for (int i = 0; i < dtdatarow.Rows.Count; i++)
                {
                    DADicttestitem library = new DADicttestitem();
                    //library.Datestitemid = service.getSeqID("SEQ_DA_DICTTESTITEM");
                    library.Datestcode = dtdatarow.Rows[i]["DATESTCODE"].ToString();
                    library.Datestname = dtdatarow.Rows[i]["DATESTNAME"].ToString();
                    library.Englishname = dtdatarow.Rows[i]["ENGLISHNAME"].ToString();
                    library.Engshortname=dtdatarow.Rows[i]["ENGSHORTNAME"].ToString();
                    library.Isgroup = dtdatarow.Rows[i]["ISGROUP"].ToString();
                    library.Testmethod = dtdatarow.Rows[i]["TESTMETHOD"].ToString();
                    library.Testtype=dtdatarow.Rows[i]["TESTTYPE"].ToString();
                    library.Createtime = DateTime.Now;
                    //library.Fastcode = dtdatarow.Rows[i]["FASTCODE"].ToString();
                    SQLlist.Add(new Hashtable() { { "INSERT", "InsertDADicttestitem" } },library);
                }

                bool result = service.ExecuteSqlTran(SQLlist);
                return result;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
        public bool Save(DADicttestitem library)
        {
            int nflag = 0;
            //新增
            if (library.Datestitemid == 0 || library.Datestitemid == null)
            {
                try
                {
                    //library.Datestitemid = new BaseService().getSeqID("SEQ_DA_DICTTESTITEM");
                    new BaseService().insert("InsertDADicttestitem", library);
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
        /// 删除 fenghp
        /// </summary>
        /// <param name="DaTestitemid"></param>
        /// <returns></returns>
        public bool DeleteDADicttestitem(string strId)
        {
            bool result = false;
            var arrayId = strId.TrimEnd(',').Split(',');
            //oracle语句IN里面的数据不能超过1000个,不能用in子句删除不确定有多少条记录
            SortedList SQLlist = new SortedList(new MySort());
            for (int i = 0; i < arrayId.Length; i++)
            {
                SQLlist.Add(new Hashtable { { "DELETE", "DeleteDADicttestitem" } },arrayId[i]);
            }
            result = service.ExecuteSqlTran(SQLlist);
            return result;
        }
    }
}
