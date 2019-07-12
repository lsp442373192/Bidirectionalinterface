using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using System.Data;
using IBatisNet.DataMapper.Scope;
using System.Data.OracleClient;
using System.Data.SqlClient;
using Daan.Interface.Entity;

namespace Daan.Interface.Dao
{

    public class BaseDAO
    {

        public ISqlMapper mapper = mapperobj.Get();

        public DataSet QueryForDataSet(string statementName, object paramObject)
        {
            DataSet ds = new DataSet();
            try
            {
                IMappedStatement statement = mapper.GetMappedStatement(statementName);
                if (!mapper.IsSessionStarted)
                {
                    mapper.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, mapper.LocalSession);
                statement.PreparedCommand.Create(scope, mapper.LocalSession, statement.Statement, paramObject);

                IDbCommand command = mapper.LocalSession.CreateCommand(CommandType.Text);
                command.CommandText = scope.IDbCommand.CommandText;

                foreach (IDataParameter pa in scope.IDbCommand.Parameters)
                {
                    if (Compare(mapper))
                    {
                        command.Parameters.Add(new OracleParameter(pa.ParameterName, pa.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter(pa.ParameterName, pa.Value));
                    }


                }
                mapper.LocalSession.CreateDataAdapter(command).Fill(ds);
            }
            finally
            {
                try
                {
                    mapper.CloseConnection();
                }
                catch (Exception)
                {

                }
            }

            return ds;
        }


        public string GetSql(string statementName, object paramObject)
        {
            string sql = "";
            try
            {
                IMappedStatement statement = mapper.GetMappedStatement(statementName);
                if (!mapper.IsSessionStarted)
                {
                    mapper.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, mapper.LocalSession);
                sql = scope.PreparedStatement.PreparedSql;
            }
            finally
            {
                try
                {
                    mapper.CloseConnection();
                }
                catch (Exception)
                {

                }
            }

            return sql;
        }


        public ISqlMapper getMapper()
        {
            return mapperobj.Get();
        }

        /// <summary>
        /// 针对视图查询使用
        /// </summary>
        /// <returns></returns>
        public ISqlMapper getNewMapper()
        {
            return mapperobj.NewGet();
        }


        public int Delete(string sqlId, object parameterObject)
        {
            return mapper.Delete(sqlId, parameterObject);
        }

        public object Insert(string sqlId, object parameterObject)
        {
            return mapper.Insert(sqlId, parameterObject);
        }

        public int Update(string sqlId, object parameterObject)
        {
            return mapper.Update(sqlId, parameterObject);
        }



        public object QueryForObject(string sqlId, object parameterObject)
        {
            return mapper.QueryForObject(sqlId, parameterObject);
        }


        /// <summary>
        /// 根据序列号得到主键,用于新增操作主键的获取
        /// </summary>
        /// <param name="seq_name">对应数据库序列的名称，不区分大小写</param>
        /// <returns></returns>
        public double getLongID(String seq_name)
        {
            object obj = mapper.QueryForObject("Common.GetSeqID", seq_name);
            return Convert.ToDouble(obj);
        }


        public DataSet SelectDS(string statementName, object paramObject, object _sqlmapper)
        {
            DataSet ds = new DataSet();
            ISqlMapper _mapper = _sqlmapper as ISqlMapper;
            try
            {

                IMappedStatement statement = _mapper.GetMappedStatement(statementName);
                if (!_mapper.IsSessionStarted)
                {
                    _mapper.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, _mapper.LocalSession);
                statement.PreparedCommand.Create(scope, _mapper.LocalSession, statement.Statement, paramObject);

                IDbCommand command = _mapper.LocalSession.CreateCommand(CommandType.Text);
                command.CommandText = scope.IDbCommand.CommandText;

                foreach (IDataParameter pa in scope.IDbCommand.Parameters)
                {
                    if (Compare(mapper))
                    {
                        command.Parameters.Add(new OracleParameter(pa.ParameterName, pa.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter(pa.ParameterName, pa.Value));
                    }
                }
                _mapper.LocalSession.CreateDataAdapter(command).Fill(ds);
            }
            finally
            {
                _mapper.CloseConnection();
            }
            return ds;
        }


        public DataSet SelectDS(string statementName, object paramObject)
        {
            DataSet ds = new DataSet();
            try
            {
                IMappedStatement statement = mapper.GetMappedStatement(statementName);
                if (!mapper.IsSessionStarted)
                {
                    mapper.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, mapper.LocalSession);
                statement.PreparedCommand.Create(scope, mapper.LocalSession, statement.Statement, paramObject);

                IDbCommand command = mapper.LocalSession.CreateCommand(CommandType.Text);
                command.CommandText = scope.IDbCommand.CommandText;

                foreach (IDataParameter pa in scope.IDbCommand.Parameters)
                {
                    if (Compare(mapper))
                    {
                        command.Parameters.Add(new OracleParameter(pa.ParameterName, pa.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter(pa.ParameterName, pa.Value));
                    }
                }
                mapper.LocalSession.CreateDataAdapter(command).Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                try
                {
                    mapper.CloseConnection();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return ds;
        }

        /// <summary>
        /// 判断是否Oracel数据库
        /// </summary>
        /// <returns></returns>
        protected bool Compare(ISqlMapper mapper)
        {
            return mapper.DataSource.DbProvider.Name.Contains(DefaultConfig.ORADB);
        }

    }
}
