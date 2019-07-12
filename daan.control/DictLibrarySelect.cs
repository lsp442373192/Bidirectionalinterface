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
    public partial class DictLibrarySelect : LISPopSelect
    {
        private String _dictLibraryTypeCode = "bbzt";
        [Browsable(true), Category("LISSelect"), Description("基本字典类型代码")]
        public String DictLibraryTypeCode
        {
            get { return _dictLibraryTypeCode; }
            set { _dictLibraryTypeCode = value; }
        }

        public DictLibrarySelect()
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
            param["Librarytypecode"] = _dictLibraryTypeCode;
            IList lst = service.selectIList("SelectDictlibrary", param);
            foreach (DADictlibrary item in lst)//记录如果不可用在其名称前面加上"(停用)"
            {
                if (item.Active == "0")
                {
                    item.Librarytypename = "(停用)" + item.Librarytypename;

                }
            }
 
            return ArrayList.Adapter(lst);
        }


    }
}
