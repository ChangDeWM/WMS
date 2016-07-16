using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WMS.Web.Admin.Common
{
    public class CommonContext
    {
        public static string GetAllMenuJson()
        {
            var jsonStr = WMS.Common.Reids.RedisCache.Get<String>("CommonCache_Menu");
            if(String.IsNullOrEmpty(jsonStr))
            {
                var menu = DataCacheConfig.GetMenuData();
                return (menu != null) ?JsonConvert.SerializeObject(menu):"";
            }
            return jsonStr;
        }
    }
}