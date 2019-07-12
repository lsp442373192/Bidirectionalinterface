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

namespace Daan.control
{
    public partial class DictLocationSelect : LISPopSelect
    {
        public DictLocationSelect()
        {
            InitializeComponent();
        }

        protected override DataGridView getGV()
        {
            return this.dataGridView1;
        }

        protected override ArrayList getDataSource()
        {
            ArrayList lst = new ArrayList();
            BaseService service = new BaseService();
            Hashtable param = new Hashtable();
            param["FastCode"] = "";
            IList lst1 = service.selectIList("SelectDictlocation", param);
            foreach (DADictlocation item in lst1)//记录如果不可用在其名称前面加上"(停用)"
            {
                if (item.Active == "0")
                {
                    item.Locationname = "(停用)" + item.Locationname;

                }
            }

            return ArrayList.Adapter(lst1);
        }

      
    }
}
