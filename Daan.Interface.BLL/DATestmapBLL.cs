using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.Dao;
using Daan.Interface.Util;

namespace Daan.Interface.BLL
{
    public class DATestmapBLL
    {
        BaseService service = new BaseService();
        /// <summary>
        /// 列表查询全部
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<DATestmap> GetDATestmapList(Hashtable dt)
        {
            return new BaseService().QueryList<DATestmap>("Da.SelectDATestmap", dt).ToList();
        }

        /// <summary>
        /// 检查对照，查询不合格的对照数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<DATestmap> GetDATestmapCheckList()
        {
            return new BaseService().QueryList<DATestmap>("Da.SelectDATestmapCheck", null).ToList();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool SaveDATestmapList(List<DATestmap> testmapList)
        {

            try
            {
                SortedList SQLlist = new SortedList(new MySort());
                SQLlist.Add(new Hashtable { { "DELETE", "DeleteDATestmap" } }, testmapList[0].Customertestcode);
                foreach (DATestmap testmap in testmapList)
                {
                    //testmap.Testmapid = service.getSeqID("SEQ_DA_TESTMAP");
                    testmap.Createtime = DateTime.Now;
                    SQLlist.Add(new Hashtable() { { "INSERT", "InsertDATestmap" } }, testmap);
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
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="testmapid"></param>
        /// <returns></returns>
        public int DelTestmapByID(string strId)
        {
            int nflag = 0;
            try
            {
                nflag = service.delete("DeleteDATestmap", strId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nflag;
        }
        /// <summary>
        /// 导入匹配信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public bool ImportDaTestmap(List<DATestmap> testmapList)
        {
            try
            {
                SortedList SQLlist = new SortedList(new MySort());
                foreach (DATestmap testmap in testmapList)
                {
                    //testmap.Testmapid = service.getSeqID("SEQ_DA_TESTMAP");
                    testmap.Createtime = DateTime.Now;
                    SQLlist.Add(new Hashtable() { { "INSERT", "InsertDATestmap" } }, testmap);
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
    }
}
