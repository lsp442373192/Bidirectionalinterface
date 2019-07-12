using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daan.Interface.Entity
{
    public static class DefaultConfig
    {
        /// <summary>
        /// SQL连接
        /// </summary>
        public static readonly string SQLDB = "_SQL";

        /// <summary>
        /// Oracle连接
        /// </summary>
        public static readonly string ORADB = "_ORA";

        /// <summary>
        /// 反审核条码最后时间标识
        /// </summary>
        public static readonly string EXBARCODE = "ExBarCode";

        /// <summary>
        /// 日志最后时间标识
        /// </summary>
        public static readonly string ERRORLOG = "ErrorLog";


        /// <summary>
        /// 弹出框标题
        /// </summary>
        public static readonly string MSGTITLE = "达安双向对接管理系统";


        /// <summary>
        /// 默认接收间隔时间[ 半天 ]
        /// </summary>
        public static readonly double INTERVAL = 720;

        /// <summary>
        /// 默认配置ID
        /// </summary>
        public static readonly decimal DACONFIGID = 1;


        /// <summary>
        /// 数据库Mapconfig文件名称
        /// </summary>
        public static readonly string LISMap = "LISMap.config";

        /// <summary>
        /// 数据库配置文档名称
        /// </summary>
        public static readonly string DATABASENAME = "DatabaseConfiguration.xml";

        /// <summary>
        /// 视图数据库配置文档名称
        /// </summary>
        public static readonly string VIEWDATABASENAME = "DatabaseViewConfiguration.xml";

        /// <summary>
        /// SQL连接串
        /// </summary>      
        public static readonly string SQLCon_IP = "Data Source=${datasource};Initial Catalog=${database};User ID=${userid};Password=${password}";
        /// <summary>
        /// Oracle连接串 在本地配置服务名
        /// </summary>
        public static readonly string ORACon = "data source=${database};user id=${userid};password=${password};Unicode=True";
        /// <summary>
        /// Oracle连接串 使用oracle服务端的服务名和IP
        /// </summary>
        public static readonly string ORACon_IP = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=${datasource})(PORT=1521))(CONNECT_DATA=(SID=${database})));User Id=${userid};Password=${password};";

        /// <summary>
        /// MySQL连接串
        /// </summary>
        public static readonly string MySQLCon = "Host=${datasource};UserName=${userid};Password=${password};Database=${database};Port=${port};CharSet=utf8;Allow Zero Datetime=true";

        public static readonly string TestType_病理 = "临床病理学";
        public static readonly string TestType_微生物 = "临床微生物学";
        public static readonly string TestType_唐氏筛查 = "唐氏筛查";

    }
}
