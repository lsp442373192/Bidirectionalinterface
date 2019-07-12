using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;
using System.Collections;
using System.Threading;
//using IBatisNet.DataMapper;
//using IBatisNet.Common;
using System.Web;
using Daan.Interface.Dao;

namespace Daan.Interface.BLL
{
    public class BaseService
    {
        private BaseDAO dao;
        public delegate object transFunc(object _sqlmapper);

        protected BaseDAO baseDao
        {
            get
            {
                return dao == null ? new BaseDAO() : dao;
            }
        }

        #region >>>查询 DataSet
       

        public DataSet selectDS(string statementName, object param)
        {
            try
            {
                var str = baseDao.GetSql(statementName, param);
                DataSet ds = baseDao.SelectDS(statementName, param);
                return ds;
            }
            catch (Exception ex)
            {
                //return null;
                throw new Exception(ex.Message);
            }
        }

        public DataSet selectDS(string statementName, object param, object _sqlmapper)
        {
            return baseDao.SelectDS(statementName, param, _sqlmapper);
        }
        #endregion

        #region >>>查询 IList
        public IList selectIList(string statementName, object param)
        {
            var str = baseDao.GetSql(statementName, param);
            return baseDao.getMapper().QueryForList(statementName, param);
        }
        public IList selectIList(string statementName, object param, object _sqlmapper)
        {
            return (_sqlmapper as ISqlMapper).QueryForList(statementName, param);
        }
        public T selectObj<T>(string statementName, object param)
        {
            var str = baseDao.GetSql(statementName, param);
            return baseDao.getMapper().QueryForObject<T>(statementName, param);
        }
        /// <summary>
        /// 模板方法取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<T> QueryList<T>(string statementName, object param)
        {
            var str = baseDao.GetSql(statementName, param);
            return baseDao.getMapper().QueryForList<T>(statementName, param);
        }
        #endregion

        #region >>>编辑
        
        public int update(string statementName, object param)
        {
            try
            {
                return baseDao.getMapper().Update(statementName, param);
            }
            catch (Exception e)
            {
                throw new Exception("执行出错" + statementName + "' update.  错误描述: " + e.Message, e);
            }
        }
        public int update(string statementName, object param, object _sqlmapper)
        {
            try
            {
                return (_sqlmapper as ISqlMapper).Update(statementName, param);
            }
            catch (Exception e)
            {
                throw new Exception("执行出错" + statementName + "' update.  错误描述: " + e.Message, e);
            }
        }
       
        #endregion

        #region >>>新增
      
        public object insert(string statementName, object param)
        {

            try
            {
                return baseDao.getMapper().Insert(statementName, param);
            }
            catch (Exception e)
            {
                throw new Exception("执行出错" + statementName + "' Insert.  错误描述: " + e.Message, e);
            }
        }
      
        public object insert(string statementName, object param, object _sqlmapper)
        {
            try
            {
                return (_sqlmapper as ISqlMapper).Insert(statementName, param);
            }
            catch (Exception e)
            {
                throw new Exception("执行出错" + statementName + "' Insert.  错误描述: " + e.Message, e);
            }
        }
        #endregion

        #region >>>删除
        public int delete(string statementName, object param)
        {

            try
            {
                //var str = baseDao.GetSql(statementName, param);
                return baseDao.getMapper().Delete(statementName, param);
            }
            catch (Exception e)
            {
                throw new Exception("执行出错" + statementName + "' delete.  错误描述: " + e.Message, e);
            }
        }
        #endregion

        #region >>>事务
        public object runTrans(transFunc func)
        {
            ISqlMapper mapper = baseDao.getMapper();

            object result = null;
            try
            {
                using (IDalSession session = mapper.BeginTransaction())
                {

                    result = func(mapper);
                    session.Complete();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("出错:" + ex.ToString());
            }
            return result;

        }
        #endregion

        #region >>>获取ORACLE序列
        /// <summary>
        /// 获取ORACLE序列
        /// </summary>
        /// <param name="seq_name"></param>
        /// <returns></returns>
        public virtual int getSeqID(String seq_name)
        {
            object obj = baseDao.getMapper().QueryForObject("Common.GetSeqID", seq_name);
            int result = (int)obj;
            return result;
        }
        #endregion

        //#region >>>根据表最大ID获取下一个ID值
        //public int getNextId(string tableName)
        //{
        //    int id = -1;
        //    object o = runTrans(delegate(object _tableName) { return new TableIDDAO().GetNextId(tableName); });
        //    id = o == null ? -1 : int.Parse(o.ToString());
        //    return id;
        //}
        //#endregion

        #region >>>获取服务器时间
        public DateTime GetServerTime()
        {
            return baseDao.getMapper().QueryForObject<DateTime>("Common.GetServerTime", null);
        }
        #endregion >>>获取服务器时间


        
                


        public List<T> IListToList<T>(IList lst)
        {
            IEnumerator e = lst.GetEnumerator();
            List<T> list = new List<T>();
            while (e.MoveNext())
            {
                list.Add((T)e.Current);
            }
            return list;
        }
        
        /// <summary>
        /// 执行事务，返回执行出错的错误信息
        /// </summary>
        /// <param name="SQLlist"></param>
        /// <param name="error">传入接受错误信息的字符串</param>
        /// <returns></returns>
        public bool ExecuteSqlTran(SortedList SQLlist ,ref string error)
        {
            bool b = true;
            ISqlMapper mapper = baseDao.getMapper();
            try
            {
                //事务
                using (IDalSession session = mapper.BeginTransaction())
                {

                    //循环
                    foreach (DictionaryEntry myDE in SQLlist)
                    {
                        Hashtable ht = (Hashtable)myDE.Key;
                        if (ht["INSERT"] != null)
                        {
                            mapper.Insert(ht["INSERT"].ToString(), myDE.Value);
                        }
                        else if (ht["UPDATE"] != null)
                        {
                            mapper.Update(ht["UPDATE"].ToString(), myDE.Value);
                        }
                        else if (ht["DELETE"] != null)
                        {
                            mapper.Delete(ht["DELETE"].ToString(), myDE.Value);
                        }
                    }
                    //提交事务
                    session.Complete();
                }
            }
            catch (Exception e)
            {
                error = e.Message;
                b = false;
            }

            return b;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="SQLlist"></param>
        /// <returns></returns>
        public bool ExecuteSqlTran(SortedList SQLlist)
        {
            bool b = true;
            ISqlMapper mapper = baseDao.getMapper();
            try
            {
                //事务
                using (IDalSession session = mapper.BeginTransaction())
                {

                    //循环
                    foreach (DictionaryEntry myDE in SQLlist)
                    {
                        Hashtable ht = (Hashtable)myDE.Key;
                        if (ht["INSERT"] != null)
                        {
                            mapper.Insert(ht["INSERT"].ToString(), myDE.Value);
                        }
                        else if (ht["UPDATE"] != null)
                        {
                            mapper.Update(ht["UPDATE"].ToString(), myDE.Value);
                        }
                        else if (ht["DELETE"] != null)
                        {
                            mapper.Delete(ht["DELETE"].ToString(), myDE.Value);
                        }
                    }
                    //提交事务
                    session.Complete();
                }
            }
            catch (Exception e)
            {
                b = false;
            }

            return b;
        }
    }

}
