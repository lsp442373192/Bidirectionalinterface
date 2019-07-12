using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System;
using System.ComponentModel.Design;


namespace Daan.control
{
    public partial class LISPopSelect : UserControl
    {
        public ArrayList dtSource;
        protected bool canChange = false;
        protected String _searchStr = "";

        public Object selectRow;


        public delegate void afterSelected(Object sender, EventArgs e);
        public event afterSelected onAfterSelected;


        public delegate void afterChange(Object oldRow);
        public event afterChange onAfterChange;
        protected virtual void DoOnAterChange(object oldRow)
        {
            if (onAfterChange != null)
                onAfterChange(oldRow);
        }

        public delegate bool beforeFilter(Object item);
        public event beforeFilter onBeforeFilter;

        protected virtual DataGridView getGV()
        { return null; }

        protected virtual ArrayList getDataSource()
        { return null; }

        protected virtual List<String> getSearchCol()
        { return null; }

        protected virtual void AfterSelected(EventArgs e)
        {
            try
            {
                this.popupContainerEdit1.SelectionStart = this.popupContainerEdit1.Text.Length;
            }
            catch (Exception)
            {

            }

        }

        public void EndEdit()
        {
            closePopUp();
        }

        protected LISPop pop;
        public void showPopup()
        {
            try
            {
                if ((getGV().DataSource as ArrayList).Count == 0) return;
            }
            catch (Exception)
            {


            }
            pop.Show();
            this.popupContainerEdit1.Focus();
            this.popupContainerEdit1.SelectionLength = popupContainerEdit1.Text.Length;
        }

        public void closePopUp()
        {
            if (pop == null) return;
            if (!pop.bShow) return;
            pop.Close();
            // isSearched = true;
            try
            {
                if (this.onAfterSelected != null)
                {
                    this.onAfterSelected(this, new EventArgs());
                }

            }
            finally
            {
                this.getGV().DataSource = dtSource;
            }

        }

        public LISPopSelect(Object t)
        {

            InitializeComponent();
            this.Height = this.popupContainerEdit1.Height + 4;
        }

        public LISPopSelect()
        {
            InitializeComponent();
            this.Height = this.popupContainerEdit1.Height + 4;
        }


        private string _dataFromLocal = "0";
        [Browsable(true), Category("LISSelect"), Bindable(false), Description("数据来自本地文件还是服务器,0否，1是")]
        public string DataFromLocal
        {
            get { return _dataFromLocal; }
            set
            {
                _dataFromLocal = value;

            }
        }

        private bool _readOnly = false;
        [Browsable(true), Category("LISSelect"), Bindable(true), Description("设置控件是否只读")]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                this.popupContainerEdit1.ReadOnly = _readOnly;
            }
        }

        private String _colInCode;
        [Browsable(true), Category("LISSelect"), Bindable(true), Description("检索方式：输入码，一般是由由数字组成")]
        public String colInCode
        {
            get { return _colInCode; }
            set { _colInCode = value; }
        }

        private String _colDisplay;
        [Browsable(true), Category("LISSelect"), Bindable(true), Description("最终显示在输入框中的内容对应的字段")]
        public String colDisplay
        {
            get { return _colDisplay; }
            set { _colDisplay = value; }
        }

        public String _colValue;
        [Browsable(true), Category("LISSelect"), Bindable(true), Description("最终保存的值对应的字段")]
        public String colValue
        {
            get { return _colValue; }
            set { _colValue = value; }
        }

        public String _colExtend1;
        [Browsable(true), Category("LISSelect"), Bindable(true), Description("扩展检索字段，全模糊按需设置")]
        public String colExtend1
        {
            get { return _colExtend1; }
            set { _colExtend1 = value; }
        }

        public String _colExtend2;
        [Browsable(true), Category("LISSelect"), Bindable(true), Description("扩展检索字段，前匹配搜索按需设置")]
        public String colExtend2
        {
            get { return _colExtend2; }
            set { _colExtend2 = value; }
        }

        public String _colSeq = "";
        [Browsable(true), Category("LISSelect"), Bindable(true), Description("排序字段，按需设置")]
        public String colSeq
        {
            get { return _colSeq; }
            set { _colSeq = value; }
        }

        protected String _displayMember;
        [Browsable(true), Category("LISSelect"), Bindable(true)]
        public String displayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                this.popupContainerEdit1.TextChanged -= this.popupContainerEdit1_EditValueChanged;
                try
                {
                    this.popupContainerEdit1.Text = value;
                }
                finally
                {
                    this.popupContainerEdit1.TextChanged += this.popupContainerEdit1_EditValueChanged;
                }

            }
        }

        private Object _valueMember;
        [Browsable(true), Category("LISSelect"), Bindable(true)]
        public Object valueMember
        {
            get { return _valueMember; }
            set
            {

                _valueMember = value;
                this.selectRow = null;
                if (_valueMember == null || _valueMember.ToString() == "")
                {
                    if (_selectOnly)
                    {
                        this.popupContainerEdit1.Text = "";
                        _displayMember = "";
                    }

                }

                if (_lookup && dtSource != null && _valueMember != null && _valueMember.ToString() != "")
                {
                    //this.popupContainerEdit1.Text = "";
                    //_displayMember = "";
                    IEnumerator enumer = dtSource.GetEnumerator();
                    while (enumer.MoveNext())
                    {
                        Object dr = enumer.Current;
                        PropertyInfo pro = dr.GetType().GetProperty(_colValue);
                        Object sValue = pro.GetValue(dr, null);
                        String pValue = sValue == null ? "" : sValue.ToString();
                        if (_valueMember != null && _valueMember.ToString() != "" && pValue == _valueMember.ToString())//主键检索
                        {
                            this.popupContainerEdit1.Text = dr.GetType().GetProperty(_colDisplay).GetValue(dr, null).ToString();
                            _displayMember = this.popupContainerEdit1.Text;
                            this.selectRow = dr;
                            break;
                        }

                    }
                }



            }
        }

        private bool _lookup = true;
        [Browsable(true), Category("LISSelect")]
        public bool Lookup
        {
            get { return _lookup; }
            set
            {
                _lookup = value;


            }
        }

        //private bool _saveSourceID = false;
        //[Browsable(true), Category("LISSelect"), Description("为true返回字典表的source_id字段值,false返回字典表的主键")]
        //public bool SaveSourceID
        //{
        //    get { return _saveSourceID; }
        //    set
        //    {
        //        _saveSourceID = value;
        //    }
        //}

        private bool _enterClosePop = true;
        [Browsable(true), Category("LISSelect"), Description("回车是否关闭弹出网格")]
        public bool EnterColsePop
        {
            get { return _enterClosePop; }
            set
            {
                _enterClosePop = value;
            }
        }

        private bool _enterMoveNext = true;
        [Browsable(true), Category("LISSelect"), Description("回车是否焦点到下一个控件")]
        public bool EnterMoveNext
        {
            get { return _enterMoveNext; }
            set
            {
                _enterMoveNext = value;


            }
        }


        private bool _showDropButton = true;
        [Browsable(true), Category("LISSelect"), Description("控件是否显示下拉按钮")]
        public bool ShowDropButton
        {
            get { return _showDropButton; }
            set
            {
                _showDropButton = value;
                if (!_showDropButton) btnDropDown.Visible = false;
                else btnDropDown.Visible = true;
            }
        }


        private bool _selectOnly = true;
        [Browsable(true), Category("LISSelect"), Description("为true只能从列表选择,false可以不来自列表")]
        public bool SelectOnly
        {
            get { return _selectOnly; }
            set
            {
                _selectOnly = value;
            }
        }


        //protected bool _hasAll = false;
        //[Browsable(true), Category("LISSelect"), Description("为true自动添加一条名称为全部的记录，内码各控件自己设置")]
        //public bool HasAll
        //{
        //    get { return _hasAll; }
        //    set
        //    {
        //        _hasAll = value;
        //    }
        //}

        public void setDataSource(ArrayList dt)
        {
            this.getGV().DataSource = dtSource = dt;
        }

        private void popupContainerEdit1_Enter(object sender, EventArgs e)
        {
            this.popupContainerEdit1.SelectAll();
            //base.OnEnter( e);

        }

        public virtual void popupContainerEdit1_EditValueChanged(object sender, EventArgs e)
        {

            search();
            if (this.popupContainerEdit1.Text.Trim() == "")
            {
                selectRow = null;
                this.popupContainerEdit1.Text = "";
                _valueMember = null;
                DoOnAterChange(selectRow);
            }

        }

        private void search()
        {
            try
            {
                if (canChange)
                {
                    if (popupContainerEdit1.Text != null && popupContainerEdit1.Text.ToString() != "")
                    {
                        ArrayList dtt = new ArrayList();
                        if (popupContainerEdit1.Text.Trim() == "" && this.onBeforeFilter == null)
                        {
                            dtt.AddRange(this.dtSource);
                        }
                        else
                        {
                            _searchStr = popupContainerEdit1.Text.Trim();
                            ArrayList drs = this.setFilteredData();
                            dtt.AddRange(drs);
                        }

                        if (dtSource.Count > 0)
                        {
                            this.getGV().DataSource = dtt;
                            this.showPopup();
                        }
                        else
                        {
                            closePopUp();
                        }
                    }
                    else closePopUp();
                    //if (popupContainerEdit1.Text.Trim() == "")
                    //{
                    //    _valueMember = null;
                    //    _displayMember = null;
                    //    try
                    //    {
                    //        ((BindingSource)this.DataBindings["valueMember"].DataSource).EndEdit();
                    //    }
                    //    catch (Exception)
                    //    {

                    //    }
                    //}
                    //popupContainerEdit1.Focus();

                    ArrayList dt = new ArrayList();
                    if (popupContainerEdit1.Text.Trim() == "" && this.onBeforeFilter == null)
                    {
                        dt.AddRange(this.dtSource);
                    }
                    else
                    {
                        _searchStr = popupContainerEdit1.Text.Trim();
                        ArrayList drs = this.setFilteredData();
                        dt.AddRange(drs);
                    }

                    this.getGV().DataSource = dt;

                    if (dt.Count == 0)
                        pop.Close();

                    //this.popupContainerEdit1.SelectionStart = this.popupContainerEdit1.Text.Length;

                }
            }
            finally
            {
                this.canChange = false;
            }
        }

        /// <summary>
        /// 在lst中寻找匹配项
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        private ArrayList search(ArrayList lst)
        {
            ArrayList rLst = new ArrayList();
            IEnumerator enumer = lst.GetEnumerator();
            while (enumer.MoveNext())
            {
                Object dr = enumer.Current;
                PropertyInfo pro = dr.GetType().GetProperty(_colValue);
                Object sValue = pro.GetValue(dr, null);
                String pValue = sValue == null ? "" : sValue.ToString();
                //if (pValue.ToLower().StartsWith(_searchStr.ToLower()))//主键检索，前匹配


                //{
                //    rLst.Add(dr);
                //    continue;
                //}

                pro = dr.GetType().GetProperty(_colDisplay);
                sValue = pro.GetValue(dr, null);
                pValue = sValue == null ? "" : sValue.ToString();
                if (pValue.ToLower().Contains(_searchStr.ToLower()))//名称检索，全模糊
                {
                    rLst.Add(dr);
                    continue;
                }

                pro = dr.GetType().GetProperty(_colInCode);
                sValue = pro.GetValue(dr, null);
                pValue = sValue == null ? "" : sValue.ToString();
                if (pValue.ToLower().StartsWith(_searchStr.ToLower()))//输入码检索，前匹配
                {
                    rLst.Add(dr);
                    continue;
                }

                if (_colExtend1 == null) continue;
                pro = dr.GetType().GetProperty(_colExtend1);
                sValue = pro.GetValue(dr, null);
                pValue = sValue == null ? "" : sValue.ToString();
                if (pValue.ToLower().Contains(_searchStr.ToLower()))//扩展字段，全模糊
                {
                    rLst.Add(dr);
                    continue;
                }

                if (_colExtend2 == null) continue;
                pro = dr.GetType().GetProperty(_colExtend2);
                sValue = pro.GetValue(dr, null);
                pValue = sValue == null ? "" : sValue.ToString();
                if (pValue.ToLower().StartsWith(_searchStr.ToLower()))//扩展字段，前匹配
                {
                    rLst.Add(dr);
                    continue;
                }
            }
            return rLst;
        }

        private bool isSearched = false;//根据条件是否找到了匹配项
        /// <summary>
        /// 设置下拉表格显示的数据，默认为前匹配，名称全模糊，所有检索字段查询,
        /// </summary>
        /// <returns></returns>
        protected virtual ArrayList setFilteredData()
        {

            ArrayList lst = new ArrayList();
            if (this.onBeforeFilter != null)
            {
                foreach (Object obj in dtSource)
                {
                    if (this.onBeforeFilter(obj))
                    {
                        lst.Add(obj);
                    }
                }
                //this.onBeforeFilter(ref _searchStr);
                lst = this.search(lst);
            }
            else
            {
                lst = this.search(dtSource);
            }


            if (lst.Count == 0)
            {
                isSearched = false;
                _searchStr = "";
                //if (this.onBeforeFilter != null)
                //{
                //    //this.onBeforeFilter(ref _searchStr);
                //    _searchStr = _searchStr.Trim().TrimStart("and".ToCharArray());
                //}
                //lst = this.search(dtSource);
            }
            else
            {
                isSearched = true;
            }
            //if (drs.Length == 0) {

            //  dtSource.Copy().Rows.CopyTo(drs,0);
            //  //this.popupContainerEdit1.Text = "";
            //  //this._displayMember = "";
            //  //this._valueMember = "";
            //}
            return lst;
        }

        private void popupContainerEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if ((getGV().DataSource as ArrayList).Count > 0 && pop.bShow == true)
                {
                    this.getGV().Focus();
                    gridView1_PreviewKeyDown(this.getGV(), (new PreviewKeyDownEventArgs(Keys.Enter)));

                }
                if (_enterMoveNext) SendKeys.Send("{TAB}");
            }
            else
            {
                //选完后第二次输入会全选，所以选完后第二次输入的第二个字符会删除第一个字符
                //所以每当第一次输入字符时设SelectionLength=1取消全选状态
                if (this.popupContainerEdit1.Text.Trim() == "")
                {
                    popupContainerEdit1.SelectionLength = 1;
                }
            }
            // e.Handled = true;

        }

        protected virtual void popupContainerEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {

                return;
            }
            #region Keys.Down
            if (e.KeyCode == (Keys.Down))
            {
                if (pop.bShow)
                {
                    this.getGV().BindingContext[this.getGV().DataSource].Position++;
                }
                else
                {

                    {
                        ArrayList dt = new ArrayList();
                        if (this.dtSource.Count == 0) return;
                        if (this.onBeforeFilter != null)
                        {
                            _searchStr = "";

                            ArrayList lst = this.setFilteredData();

                            dt.AddRange(lst);
                            this.getGV().DataSource = dt;
                        }
                        else
                        {
                            dt.AddRange((ArrayList)this.dtSource.Clone());
                        }

                        // this.getGV().DataSource = dtSource;
                        showPopup();
                        if (NoSelect) return;
                        IEnumerator enumer = dt.GetEnumerator();
                        int i = 0;
                        while (enumer.MoveNext())
                        {
                            Object dr = enumer.Current;
                            PropertyInfo pro = dr.GetType().GetProperty(_colValue);
                            Object sValue = pro.GetValue(dr, null);
                            String pValue = sValue == null ? "" : sValue.ToString();
                            if (pValue.ToLower().Equals(_valueMember.ToString().ToLower()))//主键检索，前匹配
                            {

                                //DataGridViewCell cell = getGV()[1, i];
                                //getGV().CurrentCell = cell;
                                //getGV().FirstDisplayedScrollingRowIndex = i;

                                this.getGV().BindingContext[this.getGV().DataSource].Position = i;
                                this.getGV().FirstDisplayedScrollingRowIndex = i;
                                break; ;
                            }
                            i++;

                        }
                    }
                }

            }
            #endregion

            else if (e.KeyCode == (Keys.Up))
            {
                if (pop.bShow)
                {
                    this.getGV().BindingContext[this.getGV().DataSource].Position--;
                }
                else
                {
                    //this.popupContainerEdit1.ShowPopup();
                }


            }
            this.popupContainerEdit1.TextChanged -= this.popupContainerEdit1_EditValueChanged;
            try
            {
                if (e.KeyCode == (Keys.Up) || e.KeyCode == (Keys.Down))
                {
                    Object dr = this.getGV().CurrentRow == null ? null : this.getGV().CurrentRow.DataBoundItem;
                    if (dr != null)
                    {
                        String pDisplayValue = dr.GetType().GetProperty(_colDisplay).GetValue(dr, null).ToString();
                        // this.popupContainerEdit1.Text = pDisplayValue;
                        // this.popupContainerEdit1.SelectAll();

                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    _valueMember = "";
                    _displayMember = "";
                }
            }
            finally
            {
                this.popupContainerEdit1.TextChanged += this.popupContainerEdit1_EditValueChanged;
            }

            if (e.KeyCode == (Keys.Enter) && false)
            {

                //if (pop.bShow)
                {

                    Object dr = this.getGV().CurrentRow == null ? null : this.getGV().CurrentRow.DataBoundItem;
                    if (this.popupContainerEdit1.Text.Trim() == "" && !pop.bShow)
                    {

                        dr = null;
                    }
                    if (dr != null && pop.bShow)
                    {
                        this.popupContainerEdit1.Text = this.popupContainerEdit1.Text.Trim();
                        String pDisplayValue = dr.GetType().GetProperty(_colDisplay).GetValue(dr, null).ToString();
                        String pValue = dr.GetType().GetProperty(_colValue).GetValue(dr, null).ToString();
                        //if (!isSearched && !this.SelectOnly && this.popupContainerEdit1.Text.Trim() != "")
                        //{
                        //    _displayMember = this.popupContainerEdit1.Text.Trim();
                        //    _valueMember = null;
                        //}
                        //else
                        {
                            this.popupContainerEdit1.Text = pDisplayValue;
                            _displayMember = pDisplayValue;
                            _valueMember = pValue;
                        }
                        String selectValue = "";
                        if (selectRow != null)
                        {
                            selectValue = selectRow.GetType().GetProperty(_colValue).GetValue(selectRow, null).ToString();
                        }
                        if (selectRow == null || selectValue != pValue)
                        {
                            Object oldRow = selectRow;
                            this.selectRow = dr;
                            if (this.onAfterChange != null) this.onAfterChange(oldRow);

                        }


                    }
                    else if (dr == null)
                    {
                        _valueMember = null;
                        try
                        {
                            ((BindingSource)this.DataBindings["valueMember"].DataSource).EndEdit();
                        }
                        catch (Exception)
                        {

                            //  throw;
                        }
                        _displayMember = _selectOnly ? "" : this.popupContainerEdit1.Text.Trim();
                        //selectRow = null;
                        if (selectRow != null)
                        {
                            Object oldRow = selectRow;
                            this.selectRow = dr;
                            if (this.onAfterChange != null) this.onAfterChange(oldRow);

                        }
                    }

                    if (pop.bShow)
                    {
                        closePopUp();
                        //this.popupContainerEdit1.SelectionStart = this.popupContainerEdit1.Text.Length;


                        try
                        {
                            ((BindingSource)this.DataBindings["valueMember"].DataSource).EndEdit();
                        }
                        catch (Exception)
                        {

                            //  throw;
                        }
                        AfterSelected(new EventArgs());
                    }
                }
                if (!pop.bShow)
                {
                    if (_enterMoveNext) SendKeys.Send("{TAB}");
                }

            }

            else
            {

                this.canChange = true;
            }
            //  e.IsInputKey = false;
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    DataGridView.HitTestInfo hit = this.getGV().HitTest(e.X, e.Y);
                    if (hit.Type == DataGridViewHitTestType.Cell)
                    {
                        this.getGV().BindingContext[this.getGV().DataSource].Position = hit.RowIndex;
                        Object dr = this.getGV().CurrentRow == null ? null : this.getGV().CurrentRow.DataBoundItem;
                        if (dr != null)
                        {
                            String pDisplayValue = dr.GetType().GetProperty(_colDisplay).GetValue(dr, null).ToString();
                            String pValue = dr.GetType().GetProperty(_colValue).GetValue(dr, null).ToString();
                            _displayMember = pDisplayValue;
                            this.popupContainerEdit1.Text = pDisplayValue;
                            // this.popupContainerEdit1.SelectionStart = this.popupContainerEdit1.Text.Length;
                            _valueMember = pValue;
                            String selectValue = "";
                            if (selectRow != null)
                            {
                                selectValue = selectRow.GetType().GetProperty(_colValue).GetValue(selectRow, null).ToString();
                            }
                            if (selectRow == null || selectValue != pValue)
                            {
                                this.selectRow = dr;
                                if (this.onAfterChange != null) this.onAfterChange(this.selectRow);
                            }

                            closePopUp();

                            if (this.DataBindings["valueMember"] != null)
                                ((BindingSource)this.DataBindings["valueMember"].DataSource).EndEdit();


                            AfterSelected(new EventArgs());
                        }
                    }
                }
            }
            catch (Exception ex)
            {           
               
            }
        }


        private void gridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {

                if (e.KeyCode != Keys.Enter) return;

                int hit = this.getGV().CurrentRow.Index;
                if (true)
                {
                    this.getGV().BindingContext[this.getGV().DataSource].Position = hit;
                    Object dr = this.getGV().CurrentRow == null ? null : this.getGV().CurrentRow.DataBoundItem;
                    if (dr != null)
                    {
                        String pDisplayValue = dr.GetType().GetProperty(_colDisplay).GetValue(dr, null).ToString();
                        String pValue = dr.GetType().GetProperty(_colValue).GetValue(dr, null).ToString();
                        _displayMember = pDisplayValue;
                        this.popupContainerEdit1.Text = pDisplayValue;
                        // this.popupContainerEdit1.SelectionStart = this.popupContainerEdit1.Text.Length;
                        _valueMember = pValue;
                        String selectValue = "";
                        if (selectRow != null)
                        {
                            selectValue = selectRow.GetType().GetProperty(_colValue).GetValue(selectRow, null).ToString();
                        }
                        if (selectRow == null || selectValue != pValue)
                        {
                            this.selectRow = dr;
                            if (this.onAfterChange != null) this.onAfterChange(this.selectRow);
                        }

                        closePopUp();

                        try
                        {
                            ((BindingSource)this.DataBindings["valueMember"].DataSource).EndEdit();
                        }
                        catch (Exception)
                        {

                        }
                        AfterSelected(new EventArgs());
                    }
                }
            }
            catch (Exception)
            {
                
             
            }
        }


        private void popupContainerEdit1_Popup(object sender, EventArgs e)
        {
            ArrayList dt = new ArrayList();
            if (this.dtSource.Count == 0) return;
            if (this.onBeforeFilter != null)
            {
                _searchStr = "";

                ArrayList lst = this.setFilteredData();

                dt.AddRange(lst);
                this.getGV().DataSource = dt;
            }
            else
            {
                dt.AddRange((ArrayList)this.dtSource.Clone());
            }
            try
            {

                int i = 0;
                IEnumerator enumer = dt.GetEnumerator();
                while (enumer.MoveNext())
                {
                    Object dr = enumer.Current;
                    String pValue = dr.GetType().GetProperty(_colValue).GetValue(dr, null).ToString();
                    if (_valueMember != null && pValue == _valueMember.ToString())
                    {

                        break;
                    }
                    i++;
                }
                this.getGV().DataSource = dt;
                this.getGV().BindingContext[this.getGV().DataSource].Position = i;
                popupContainerEdit1.Focus();
            }
            finally
            {

            }

        }


        private void popupContainerEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) { e.Handled = true; }


        }

        int a = 0;
        private void HopePopSelect_Load(object sender, EventArgs e)
        {
            //if (!DesignMode)
            if (a == 0&&!DesignMode && System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {

                try
                {
                    this.getGV().DataSource = this.dtSource = getDataSource();
                    _colInCode = this.DataBindings["colInCode"].BindingMemberInfo.BindingField;
                    _colDisplay = this.DataBindings["colDisplay"].BindingMemberInfo.BindingField;
                    _colValue = this.DataBindings["colValue"].BindingMemberInfo.BindingField;
                    _colExtend1 = this.DataBindings["colExtend1"] == null ? _colExtend1 : this.DataBindings["colExtend1"].BindingMemberInfo.BindingField;
                    _colExtend2 = this.DataBindings["colExtend2"] == null ? _colExtend2 : this.DataBindings["colExtend2"].BindingMemberInfo.BindingField;
                    //this.getGV().DoubleClick += this.gridControl1_DoubleClick;
                    this.getGV().MouseDown += this.gridView1_MouseDown;
                    this.getGV().PreviewKeyDown += this.gridView1_PreviewKeyDown;
                    pop = new LISPop(getGV(), this);
                    this.Height = this.popupContainerEdit1.Height + 1;
                    this.getGV().Width = this.Width < 300 ? 300 : this.Width;

                   SetDataGridStyle(this.getGV());

                    //当前控件gridview不能获得焦点，否则控件回车会有问题
                    getGV().TabStop = false;
                    a++;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }



            }

        }
        /// <summary>
        /// 统一设置DataGridView的样式
        /// </summary>
        /// <param name="gr"></param>
        public static void SetDataGridStyle(DataGridView gr)
        {
            gr.AllowUserToAddRows = false;
            gr.AllowUserToResizeRows = false;
            gr.AutoGenerateColumns = false;
            gr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gr.RowHeadersWidth = 20;
            gr.RowTemplate.Height = 23;
            gr.ColumnHeadersHeight = 23;
            gr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gr.MultiSelect = false;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gr.RowsDefaultCellStyle = dataGridViewCellStyle;
        }

        //private void popupContainerEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == ButtonPredefines.Delete)
        //    {
        //        this.popupContainerEdit1.Text = "";
        //        _valueMember = null;
        //        _displayMember = null;
        //        try
        //        {
        //            ((BindingSource)this.DataBindings["valueMember"].DataSource).EndEdit();
        //        }
        //        catch (Exception)
        //        {

        //        }

        //        if (popupContainerEdit1.Properties.PopupControl.Visible)
        //        {
        //            this.popupContainerEdit1.ClosePopup();
        //        }
        //    }
        //    if (e.Button.Kind == ButtonPredefines.Combo)
        //    {


        //    }
        //}

        private void HopePopSelect_Resize(object sender, EventArgs e)
        {
            this.popupContainerEdit1.Width = this.Width - 15;
            this.btnDropDown.Left = this.Width - 15;
        }

        private void popupContainerEdit1_Leave(object sender, EventArgs e)
        {
            // leave();
        }

        private void leave()
        {
            bool canLeave = false;
            if (_selectOnly && this.popupContainerEdit1.Text.Trim() != "")
            {
                IEnumerator enumer = dtSource.GetEnumerator();
                while (enumer.MoveNext())
                {
                    Object dr = enumer.Current;
                    PropertyInfo pro = dr.GetType().GetProperty(_colDisplay);
                    Object sValue = pro.GetValue(dr, null);
                    String pValue = sValue == null ? "" : sValue.ToString();
                    if (this.popupContainerEdit1.Text != null && pValue.Trim() == this.popupContainerEdit1.Text.Trim())//检索
                    {
                        canLeave = true;
                        break;
                    }

                }
                if (!canLeave)
                {
                    popupContainerEdit1.Focus();
                }
                else closePopUp();
            }
            else { closePopUp(); }
            AfterSelected(new EventArgs());
        }

        private void popupContainerEdit1_DoubleClick(object sender, EventArgs e)
        {
            this.popupContainerEdit1.SelectAll();
        }


        //判断控件是否选择了值
        public bool NoSelect
        {
            get { return (_valueMember == null || _valueMember.ToString().Trim() == ""); }
        }

        public bool HasSelect
        {
            get { return !NoSelect; }
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            if (pop.bShow) { closePopUp(); }
            else
            {
                ArrayList dt = new ArrayList();
                if (this.dtSource.Count == 0) return;
                if (this.onBeforeFilter != null)
                {
                    _searchStr = "";

                    ArrayList lst = this.setFilteredData();

                    dt.AddRange(lst);
                    this.getGV().DataSource = dt;
                }
                else
                {
                    dt.AddRange((ArrayList)this.dtSource.Clone());
                }

                //this.getGV().DataSource = dtSource;
                showPopup();

                if (NoSelect)
                {
                    this.getGV().Focus();
                    return;
                }
                IEnumerator enumer = dt.GetEnumerator();
                int i = 0;
                while (enumer.MoveNext())
                {
                    Object dr = enumer.Current;
                    PropertyInfo pro = dr.GetType().GetProperty(_colValue);
                    Object sValue = pro.GetValue(dr, null);
                    String pValue = sValue == null ? "" : sValue.ToString();
                    if (pValue.ToLower().Equals(_valueMember.ToString().ToLower()))//主键检索，前匹配
                    {

                        //DataGridViewCell cell = getGV()[1, i];
                        //getGV().CurrentCell = cell;
                        //getGV().FirstDisplayedScrollingRowIndex = i;
                        try
                        {
                            //this.getGV().DataSource = dt; 选择其他列表没有的项目时，就会报异常
                            this.getGV().BindingContext[this.getGV().DataSource].Position = i;
                            this.getGV().FirstDisplayedScrollingRowIndex = i;
                            this.getGV().Focus();
                        }
                        catch { }


                        break; ;
                    }
                    i++;

                }
            }

        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    //如果用户单击Esc 键 
        //    switch (keyData)
        //    {
        //        //case Keys.Enter:                    //回车消息截获，屏蔽父容器回车光标跳转功能 
        //        //    return true;

        //        default:
        //            return base.ProcessCmdKey(ref msg, keyData);   //消息队列循环到下一个处理点
        //    }
        //}

        private void LISPopSelect_Leave(object sender, EventArgs e)
        {
            leave();
        }


    }
}
