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
    public partial class DictDoctorSelect : LISPopSelect
    {
        //private bool canChange = false;

        protected override void DoOnAterChange(object oldRow)
        {
            base.DoOnAterChange(oldRow);
        }

        public DictDoctorSelect()
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
            IList lst = service.selectIList("SelectDictdoctor", param);
            foreach (DADictdoctor item in lst)//记录如果不可用在其名称前面加上"(停用)"
            {
                if (item.Active == "0")
                {
                    item.Doctorname = "(停用)" + item.Doctorname;

                }
            }

            return ArrayList.Adapter(lst);
        }

        public override void popupContainerEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (canChange)
                {
                    _displayMember = popupContainerEdit1.Text;

                    if (popupContainerEdit1.Text != null && popupContainerEdit1.Text.ToString() != "")
                        this.showPopup();
                    else closePopUp();

                    popupContainerEdit1.Focus();
                    ArrayList dt = new ArrayList();
                    if (popupContainerEdit1.Text.Trim() == "")
                    {
                        dt.AddRange(this.dtSource);
                    }
                    else
                    {
                        _searchStr = popupContainerEdit1.Text.Trim();
                        ArrayList drs = this.setFilteredData();
                        dt.AddRange(drs);
                    }

                    if (dt.Count == 0)
                        pop.Close();
                    else
                        this.getGV().DataSource = dt;
                    this.popupContainerEdit1.SelectionStart = this.popupContainerEdit1.Text.Length;


                    Object dr = this.getGV().CurrentRow == null ? null : this.getGV().CurrentRow.DataBoundItem;
                    if (dr != null)
                    {
                        int i = 0;
                        //查找输入的医生名称在列表中是否存在
                        foreach (DataGridViewRow row in this.dataGridView1.Rows)
                        {
                            if (row.Cells[1].Value.ToString() == popupContainerEdit1.Text)
                                break;
                            else
                                i++;
                        }

                        //如果未能找到医生，则把DictDoctorid设置为0
                        if (i == this.dataGridView1.Rows.Count)
                        {
                            DADictdoctor doctor = new DADictdoctor();
                            doctor.Dictdoctorid = 0;
                            doctor.Doctorname = popupContainerEdit1.Text;
                            this.selectRow = doctor;
                            DoOnAterChange(this.selectRow);
                        }
                        else
                        {
                            DADictdoctor doctor = (DADictdoctor)dr;
                            doctor.Doctorname = popupContainerEdit1.Text;
                            this.selectRow = doctor;
                            DoOnAterChange(this.selectRow);
                        }
                    }
                }
            }
            finally
            {
                canChange = false;
            }
        }


    }
}
