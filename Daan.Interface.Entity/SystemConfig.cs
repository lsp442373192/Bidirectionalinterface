using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daan.Interface.Entity
{
    public class SystemConfig
    {
        /// <summary>
        /// 当前用户登录信息
        /// </summary>
        public static volatile LoginUserInfo UserInfo = null;
        /// <summary>
        /// 系统参数配置
        /// </summary>
        public static volatile DAConfig Config = null;
    }
}
