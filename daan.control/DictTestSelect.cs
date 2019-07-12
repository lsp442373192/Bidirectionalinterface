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
    public partial class DictTestSelect : LISPopSelect
    {
        private String _testType = "2";
        [Browsable(true), Category("LISSelect"), Description("项目类型'0- 单项 1-组合' 2-all项目;")]
        public String TestType
        {
            get { return _testType; }
            set { _testType = value; }
        }

        public DictTestSelect()
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
            if (_testType != "2") param["IsGroup"] = _testType;
            IList lst = service.selectIList("SelectDADicttestitem", param);
            //foreach (DADicttestitem item in lst)//记录如果不可用在其名称前面加上"(停用)"
            //{
            //    if (item.Active == "0")
            //    {
            //        item.Testname = "(停用)" + item.Testname;

            //    }
            //}

            return ArrayList.Adapter(lst);
        }

    }
}
