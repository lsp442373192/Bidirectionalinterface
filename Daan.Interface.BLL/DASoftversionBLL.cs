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
    public class DASoftversionBLL
    {
        BaseService service = new BaseService();
        /// <summary>
        /// 列表查询全部
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<DASoftversion> GetDASoftversionList(Hashtable dt)
        {
            return service.QueryList<DASoftversion>("SelectDASoftversion", dt).ToList();
        }
        /// <summary>
        /// 查询最大版本号
        /// </summary>
        /// <returns></returns>
        public DASoftversion GetLastSoftVersion()
        {
            return service.selectObj<DASoftversion>("SelectLastDASoftversion", null);
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool InsertDASoftversionList(DASoftversion softversion)
        {
            int nflag = 0;
            try
            {
                service.insert("InsertDASoftversion", softversion);
                nflag = 1;
            }
            catch (Exception ex)
            {
                nflag = 0;
                throw new Exception(ex.Message);
            }
            return nflag > 0 ? true : false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="testmapid"></param>
        /// <returns></returns>
        public int DelVersionByID(string strId)
        {
            int nflag = 0;
            try
            {
                nflag = service.delete("DeleteDASoftversion", strId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nflag;
        }
    }
}
