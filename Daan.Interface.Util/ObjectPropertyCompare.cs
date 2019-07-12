//Create by fenghaipiao
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Daan.Interface.Util
{
    /**/
    /// <summary>
    /// 对象属性比较器
    /// </summary>
    public class ObjectPropertyCompare<T> : System.Collections.Generic.IComparer<T>
    {
        //提供类上的属性的抽象化
        private PropertyDescriptor property;
        //排序方式
        private ListSortDirection direction;

        public ObjectPropertyCompare(PropertyDescriptor property, ListSortDirection direction)
        {
            this.property = property;
            this.direction = direction;
        }

        #region IComparer<T>

        /// <summary>
        /// 比较方法
        /// </summary>
        /// <param name="x">相对属性x</param>
        /// <param name="y">相对属性y</param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            //获取两个属性的值
            object xValue = x.GetType().GetProperty(property.Name).GetValue(x, null);
            object yValue = y.GetType().GetProperty(property.Name).GetValue(y, null);
            //反回两个属性的比较结果 如果返回-1，表示它小于参数，如果大于参数则返回1，如果两者相等则返回0
            int returnValue;
            //比较
            if (xValue == null || yValue == null)//如果其中一个参数为null值的比较
            {
                if (xValue == null && yValue != null)
                {
                    returnValue = -1;
                }
                else if (xValue != null && yValue == null)
                {
                    returnValue = 1;
                }
                else
                {
                    returnValue = 0;
                }
            }
            else if (xValue is IComparable)
            {
                returnValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (xValue.Equals(yValue))//两等
            {
                returnValue = 0;
            }
            else
            {
                returnValue = xValue.ToString().CompareTo(yValue.ToString());
            }

            if (direction == ListSortDirection.Ascending)//根据排列方式取反值
            {
                return returnValue;
            }
            else
            {
                return returnValue * -1;
            }
        }

        #endregion
    }
}
