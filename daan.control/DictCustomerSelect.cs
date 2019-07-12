using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Daan.Interface.Dao;
using Daan.Interface.Entity;
using Daan.control;

namespace daan.control
{
    public partial class DictCustomerSelect : LISPopSelect
    { 
        public DictCustomerSelect()
        {
            InitializeComponent();
        }

        protected override DataGridView getGV()
        {
            return this.dataGridView1;
        }

        protected override ArrayList getDataSource()
        { 
            BaseService service = new BaseService();
            Hashtable param = new Hashtable();
            param["FastCode"] = "";
            IList lst = service.selectIList("SelectDictcustomer", param);
            //foreach (DADictcustomer item in lst)//记录如果不可用在其名称前面加上"(停用)"
            //{
            //    if (item.IsActive == false)
            //    {
            //        item.UserName = "(停用)" + item.UserName;

            //    }
            //}
            return ArrayList.Adapter(lst);
        }


    }
}
