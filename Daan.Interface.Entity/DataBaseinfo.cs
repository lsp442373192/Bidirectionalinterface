using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daan.Interface.Entity
{
    public class DataBaseinfo
    {

        public string databasetype { get; set; }//数据库类型 
        public string userid { get; set; }//登录名
        public string password { get; set; } //密码
        public string dataname { get; set; }//数据库名 or 服务名
        public string datasource { get; set; }//服务器IP
        public string port { get; set; } //端口号
        private string connectionstring;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connectionstring
        {
            get { return connectionstring; }
        }
        private string providerdb;
        /// <summary>
        /// 驱动名称
        /// </summary>
        public string Providerdb
        {
            get { return providerdb; }
        }

        public DataBaseinfo()
        {
            connectionstring = userid = password = dataname = datasource =port= string.Empty;

        }

        public bool init()
        {
            bool b = true;
            switch (databasetype)
            {
                case "1":
                    providerdb = DefaultConfig.SQLDB;
                    connectionstring = DefaultConfig.SQLCon_IP;
                    break;
                case "0":
                    providerdb = DefaultConfig.ORADB;
                    connectionstring = (datasource == string.Empty ? DefaultConfig.ORACon : DefaultConfig.ORACon_IP);
                    break;
                case "2":
                    providerdb = DefaultConfig.SQLDB;
                    connectionstring = DefaultConfig.MySQLCon;
                    connectionstring = connectionstring.Replace("${port}", port);
                    break;
                default:
                    b = false;
                    break;
            }
            connectionstring = connectionstring.Replace("${datasource}", datasource).Replace("${database}", dataname).Replace("${userid}", userid).Replace("${password}", password);


            return b;
        }
    }

}
