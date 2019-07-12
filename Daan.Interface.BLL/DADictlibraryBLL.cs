using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.Interface.Entity;
using System.Collections;
using Daan.Interface.Dao;

namespace Daan.Interface.BLL
{
    public class DADictlibraryBLL
    {
        BaseService service = new BaseService();
        public List<DADictlibrary> SelectDictlibrary(Hashtable ht)
        {
            return service.QueryList<DADictlibrary>("SelectDictlibrary", ht).ToList();
        }

    }
}
