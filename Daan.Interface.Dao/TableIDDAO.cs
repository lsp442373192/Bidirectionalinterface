
using System;
using IBatisNet.DataMapper.Exceptions;
using IBatisNet.DataMapper;
using Daan.Interface.Entity;


namespace Daan.Interface.Dao
{
    /// <summary>
    /// Summary description for SequenceSqlMapDao.
    /// </summary>
    public class TableIDDAO : BaseDAO
    {


        static object sync = new object();
        /// <summary>
        /// This is a generic sequence ID generator that is based on a database
        /// table called 'SEQUENCE', which contains two columns (NAME, NEXTID).
        /// </summary>
        /// <param name="name">name The name of the sequence.</param>
        /// <returns>The Next ID</returns>
        public int GetNextId(string name)
        {

            int tableID = -1;
            ISqlMapper sqlMap = this.getMapper();
            //oracle 获取序列
            if (Compare(mapper))
            {
                object obj = sqlMap.QueryForObject("Common.GetSeqID", name);
                tableID = (int)obj;
            }//Sqlserver 
            else
            {
                int maxRetry = 4;

                lock (sync)
                {
                    try
                    {
                        int retry = 0;
                        int i = 0;
                        while (i == 0 && retry++ < maxRetry)
                        {
                            object obj = sqlMap.QueryForObject("Common.GetID", name);
                            if (obj == null)
                            {
                                throw new DataMapperException("获取到空的序列 " + name + " sequence).");
                            }
                            tableID = int.Parse(obj.ToString()) + 1;
                            i = sqlMap.Update("Common.UpdateID", new TableID(name, tableID));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error executing :" + ex.Message, ex);
                    }
                }
            }
            return tableID;
        }







    }
}
