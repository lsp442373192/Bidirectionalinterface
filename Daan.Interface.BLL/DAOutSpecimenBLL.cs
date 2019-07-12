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
    public class DAOutSpecimenBLL : BaseService
    {
        /// <summary>
        /// 列表查询全部  zhangwei
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<DAOutspecimen> GetOutspecimenList(Hashtable dt)
        {
            return new BaseService().QueryList<DAOutspecimen>("Da.SelectDAOutspecimen", dt).ToList();
        }

        /// <summary>
        /// 广西玉林pdf转图片专用
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<DAOutspecimen> GetOutspecimenListTwo(Hashtable dt)
        {
            return new BaseService().QueryList<DAOutspecimen>("Da.SelectDAOutspecimen", dt).ToList();
        }


        public DataTable GetOutspecimenListExcel(string str)
        {
            DataSet ds = selectDS("Da.GetOutspecimenListExcel", str);
            return ds.Tables[0];
        }

        public DataTable GetOutspecimenListExcelLCT(string str)
        {
            DataSet ds = selectDS("Da.GetOutspecimenListExcelLCT", str);
            return ds.Tables[0];
        }
        


        /// <summary>
        /// 发送订单基本信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetOutspecimenTable(Hashtable dt)
        {
            DataSet ds = selectDS("Da.SelectDAOutspecimenTable", dt);
            return ds.Tables[0];
        }


        ///// <summary>
        ///// 发送订单明细
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public DataTable SelectDAOutspecimenGrouptesTable(Hashtable dt)
        //{
        //    DataSet ds = selectViewDS("Da.SelectDAOutspecimenGrouptesTable", dt);
        //    return ds.Tables[0];
        //}

        /// <summary>
        /// 查询需要获取结果的 RequestCode
        /// </summary>
        /// <returns></returns>
        public List<string> SelectRequestCodeByGetResult()
        {
            return QueryList<string>("SelectRequestCodeByGetResult", null).ToList();
        }

        /// <summary>
        /// 查询需要发送订单
        /// </summary>
        /// <returns></returns>
        public List<DAOutspecimen> SelectRequestCodeBySendOrders()
        {
            return QueryList<DAOutspecimen>("SelectRequestCodeBySendOrders", null).ToList();
        }


        public bool SaveDictlab(DAOutspecimen library)
        {
            int nflag = 0;
            //新增
            if (library.Outspecimenid == 0 || library.Outspecimenid == null)
            {
                try
                {
                   // library.Outspecimenid = new BaseService().getSeqID("SEQ_DA_OUTSPECIMEN");
                    new BaseService().insert("Da.InsertDAOutspecimen", library);
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
                update("Da.UpdateDAOutspecimen", library);
                nflag = 1;
            }
            return nflag > 0;
        }

        public bool UpdateStatus(Hashtable ht)
        {
            return update("Da.UpdateDAOutspecimenByID", ht) > 0;
        }

        public bool UpdateDAOutspecimenByRequestCode(Hashtable ht)
        {
            return update("UpdateDAOutspecimenByRequestCode", ht) > 0;
        }

        /// <summary>
        /// 根据医院条码更新状态 zhangwei
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public bool UpdateDAOutspecimenByHospsampleid(Hashtable ht)
        {
            return update("UpdateDAOutspecimenByHospsampleid", ht) > 0;
        }
    }
}
