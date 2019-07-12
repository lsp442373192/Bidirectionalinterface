using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.ComponentModel;

namespace Daan.Interface.Entity
{
  
    [Serializable]
    public class BaseDomain
    {
        public long? SequenceId { get; set; }
        protected DateTime _lastUpdateDate;
        protected bool isChanged;
        public virtual bool IsChange
        {
            get { return isChanged; }
            //set { IsChange = value; }
        }

        protected bool isDeleted;

        public virtual bool IsDelete
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }


        /// <summary>
        /// 最后更新日期，公式维护最后修改时间
        /// </summary>
        public DateTime LastUpdateDate
        {
            get { return _lastUpdateDate; }
            set
            {
                isChanged |= (_lastUpdateDate != null); _lastUpdateDate = value;
            }
        }


        protected bool isNew;

        public virtual bool IsNew
        {
            get { return isNew; }
            // set { isNew = value; }
        }
        /// <summary>
        /// 返回一个复制的对象
        /// </summary>
        /// <returns></returns>
        public T Copy<T>()
        {
            return (T)this.MemberwiseClone();
        }


        /// <summary>
        /// 从一个hashtable中复制和属性名相同的key对应的值，不区分大小写
        /// </summary>
        /// <param name="ht"></param>
        public void Copy(Hashtable ht)
        {
            Type t = this.GetType();
            foreach (PropertyInfo p in t.GetProperties())
            {
                IEnumerator e = ht.Keys.GetEnumerator();
                while (e.MoveNext())
                {
                    if (e.Current.ToString().ToLower() == p.Name.ToLower())
                    {
                        p.SetValue(this, ht[e.Current.ToString()], null);
                        break;
                    }

                }
            }
        }


        /// <summary>
        /// 标记为要删除的项目
        /// </summary>
        /// <param name="_bool"></param>
        public void SetIsDelete( bool _bool)
        {
            isDeleted = true; 
        }

        public void SetIsChanged(bool _bool)
        {
            isChanged = _bool;
        }

        public void SetIsNew(bool _bool)
        {
            isNew = _bool;
        }

    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class LogInfoAttribute : System.Attribute
    {
        public const string LOGFIELDOPTION = "LogField"; //属性描述，表示此属性需要进行记录到日志中

        public string Caption;
        public String Memo;
        /// <summary>
        /// normal一般字段，notNull必填字段
        /// </summary>
        public String option = "normal";

        public string LinkField; // 内容描述使用的字段名称, 此属性记录日志保存内容使用的字段

        public LogInfoAttribute(string _caption)
        {
            this.Caption = _caption;
            this.Memo = "";
        }
        public LogInfoAttribute(string _caption, string _option)
        {
            this.Caption = _caption;
            this.option = _option;
        }
        public LogInfoAttribute(string _caption, string _option, String _memo)
        {
            this.Caption = _caption;
            this.Memo = _memo;
        }

        public LogInfoAttribute(string _caption, string _option, String _memo, string _linkfield) 
        {
            this.Caption = _caption;
            this.option = _option;
            this.LinkField = _linkfield;
            this.Memo = _memo;
        }




    }


    public class SortList<T> : BindingList<T>
    {
        private bool isSortedCore = true;
        private ListSortDirection sortDirectionCore = ListSortDirection.Ascending;
        private PropertyDescriptor sortPropertyCore = null;
        private string defaultSortItem;

        public SortList() : base() { }

        public SortList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return isSortedCore; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirectionCore; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortPropertyCore; }
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (Equals(prop.GetValue(this[i]), key)) return i;
            }
            return -1;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            isSortedCore = true;
            sortPropertyCore = prop;
            sortDirectionCore = direction;
            Sort();
        }

        protected override void RemoveSortCore()
        {
            if (isSortedCore)
            {
                isSortedCore = false;
                sortPropertyCore = null;
                sortDirectionCore = ListSortDirection.Ascending;
                Sort();
            }
        }

        public string DefaultSortItem
        {
            get { return defaultSortItem; }
            set
            {
                if (defaultSortItem != value)
                {
                    defaultSortItem = value;
                    Sort();
                }
            }
        }

        private void Sort()
        {
            List<T> list = (this.Items as List<T>);
            list.Sort(CompareCore);
            ResetBindings();
        }

        private int CompareCore(T o1, T o2)
        {
            int ret = 0;
            if (SortPropertyCore != null)
            {
                ret = CompareValue(SortPropertyCore.GetValue(o1), SortPropertyCore.GetValue(o2), SortPropertyCore.PropertyType);
            }
            if (ret == 0 && DefaultSortItem != null)
            {
                PropertyInfo property = typeof(T).GetProperty(DefaultSortItem, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase, null, null, new Type[0], null);
                if (property != null)
                {
                    ret = CompareValue(property.GetValue(o1, null), property.GetValue(o2, null), property.PropertyType);
                }
            }
            if (SortDirectionCore == ListSortDirection.Descending) ret = -ret;
            return ret;
        }

        private static int CompareValue(object o1, object o2, Type type)
        {
            //这里改成自己定义的比较 
            if (o1 == null) return o2 == null ? 0 : -1;
            else if (o2 == null) return 1;
            else if (type.IsPrimitive || type.IsEnum) return Convert.ToDecimal(o1).CompareTo(Convert.ToDecimal(o2));
            else if (type == typeof(DateTime)) return Convert.ToDateTime(o1).CompareTo(o2);
            else return String.Compare(o1.ToString().Trim(), o2.ToString().Trim());
        }
    } 


}


