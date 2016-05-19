using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Common.Utility;

namespace WMS.Common.Contract
{
    public enum EnumLoginInfo
    {
        [EnumTitle("[无]", IsDisplay = false)]
        Guest = 0,
        /// <summary>
        /// 管理员
        /// </summary>
        [EnumTitle("管理员")]
        Administrator = 1
    }

    public enum EnumCacheInfo
    {
        RedisCache=0,
        WrapCache=1
    }

    public class ConstStr
    {
        public const string AppSessionId = "wms_security_key";
    }
}
