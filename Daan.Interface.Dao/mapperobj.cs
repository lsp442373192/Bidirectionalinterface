using IBatisNet.DataMapper;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using System;
using System.Xml;
using Daan.Interface.Entity;
using Daan.Interface.Util;
using System.IO;

namespace Daan.Interface.Dao
{
    public class mapperobj
    {
        private static volatile ISqlMapper _mapper = null;

        //表与视图不同数据库时使用
        private static volatile ISqlMapper _newmapper = null;

        protected static void Configure(object obj)
        {
            _mapper = null;
        }
        /// <summary>
        /// 针对视图查询使用
        /// </summary>
        /// <param name="obj"></param>
        protected static void NewConfigure(object obj)
        {
            _newmapper = null;
        }

        //读取数据库xml文件 替换驱动
        public static XmlDocument readdatabase(string path)
        {
            DataBaseinfo baseinfo = XMLHelper.ReadDataBase(path);
            bool b = baseinfo.init();

            //替换数据库驱动
            XmlDocument XD = new XmlDocument();
            XD.Load(DefaultConfig.LISMap);
            if (baseinfo.databasetype == "2")
            {
                XD.InnerXml = XD.InnerXml.Replace("PROVIDER${type}", "PROVIDER_MySQL");
            }
            XD.InnerXml = XD.InnerXml.Replace("${type}", baseinfo.Providerdb).Replace("${connectionString}", baseinfo.Connectionstring);
            
            return XD;
        }


        protected static void InitMapper(string path)
        {

            XmlDocument XD = readdatabase(path);

            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            //_mapper = builder.ConfigureAndWatch(DefaultConfig.LISMap, handler);
            _mapper = builder.Configure(XD);
            //连接串解密
            // _mapper.DataSource.ConnectionString = _mapper.DataSource.ConnectionString.Replace(conn, new DESEncrypt().Decrypt(conn.Trim(), key));

            //  _mapper.DataSource.ConnectionString = info.Connectionstring;

        }

        /// <summary>
        /// 针对视图查询使用
        /// </summary>
        /// <returns></returns>
        protected static void NewInitMapper(string path)
        {

            XmlDocument XD = readdatabase(path);

            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            //_mapper = builder.ConfigureAndWatch(DefaultConfig.LISMap, handler);
            _newmapper = builder.Configure(XD);
            //连接串解密
            // _mapper.DataSource.ConnectionString = _mapper.DataSource.ConnectionString.Replace(conn, new DESEncrypt().Decrypt(conn.Trim(), key));

            //  _mapper.DataSource.ConnectionString = info.Connectionstring;

        }


        public static ISqlMapper Instance()
        {
            if (_mapper == null)
            {
                lock (typeof(SqlMapper))
                {
                    if (_mapper == null) // double-check
                    {
                        InitMapper(DefaultConfig.DATABASENAME);
                    }
                }
            }
            return _mapper;
        }

        public static ISqlMapper Get()
        {
            return Instance();
        }

        /// <summary>
        /// 针对视图查询使用
        /// </summary>
        /// <returns></returns>
        public static ISqlMapper NewInstance()
        {
            if (_newmapper == null)
            {
                lock (typeof(SqlMapper))
                {
                    if (_newmapper == null) // double-check
                    {
                        NewInitMapper(DefaultConfig.VIEWDATABASENAME);
                    }
                }
            }
            return _newmapper;
        }

        /// <summary>
        /// 针对视图查询使用
        /// </summary>
        /// <returns></returns>
        public static ISqlMapper NewGet()
        {
            return NewInstance();
        }


        public static ISqlMapper NewMapper(String _path)
        {
            DomSqlMapBuilder builder = new DomSqlMapBuilder();

            return builder.Configure(_path);
        }

        public string GetSql(string statementName, object paramObject)
        {
            string sql = "";
            try
            {
                IMappedStatement statement = _mapper.GetMappedStatement(statementName);
                if (!_mapper.IsSessionStarted)
                {
                    _mapper.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, _mapper.LocalSession);
                sql = scope.PreparedStatement.PreparedSql;
            }
            finally
            {
                try
                {
                    _mapper.CloseConnection();
                }
                catch (Exception)
                {

                }
            }

            return sql;
        }
        //获取配置文件 fenghp
        private static XmlDocument GetConfig(DataBaseinfo baseinfo)
        {
            //装载DataBaseInfo
            bool b = baseinfo.init();
            //替换数据库驱动
            XmlDocument XD = new XmlDocument();
            XD.Load(DefaultConfig.LISMap);
            //Mysql
            if (baseinfo.databasetype == "2")
            {
                XD.InnerXml = XD.InnerXml.Replace("PROVIDER${type}", "PROVIDER_MySQL");
            }
            XD.InnerXml = XD.InnerXml.Replace("${type}", baseinfo.Providerdb).Replace("${connectionString}", baseinfo.Connectionstring);

            //XD.Save(DefaultConfig.LISMap);
            return XD;
        }
        //根据数据库信息返回ISqlMapper fenghp
        public static ISqlMapper NewMapper(DataBaseinfo info)
        {
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            XmlDocument doc = GetConfig(info);
            ISqlMapper isqlMapper = builder.Configure(doc);
            isqlMapper.DataSource.ConnectionString = info.Connectionstring;
            return isqlMapper;
        }
        //释放_mapper缓存 fenghp
        public static void clearMapper()
        {
            _mapper = null;
            _newmapper = null;
        }
    
    }
}
