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
    public class DALispictureBLL
    {
        BaseService service = new BaseService();


        /// <summary>
        /// 添加图形记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object InsertDALispictureInfo(DALispicture config)
        {
            return service.insert("InsertDALisPicture", config);
        }

        /// <summary>
        /// 修改图形记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateDALispictureInfo(DALispicture config)
        {
            return service.update("UpdateDALisPicture", config);
        }

        /// <summary>
        /// 删除图形记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object DeleteDALispicture(string Requestcode)
        {
            return service.insert("DeleteDALisPictureByRequestcode", Requestcode);
        }


        /// <summary>
        /// 查询图形记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<DALispicture> SelectDALispictureInfo()
        {
            // return service.selectObj<DALispicture>("SelectDALisPicture", null);
            return service.QueryList<DALispicture>("SelectDALisPicture", null).ToList<DALispicture>();
        }


    }
}
