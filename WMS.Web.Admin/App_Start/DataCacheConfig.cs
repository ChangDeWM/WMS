using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WMS.Web.Admin.Models;

namespace WMS.Web.Admin
{
    public class DataCacheConfig
    {
        public static void InitDataCache()
        {
            //Inti Menu Data
            WMS.Account.BLL.AccountService account = new WMS.Account.BLL.AccountService();
            var menuList = account.GetSecondLevelMenu();
            var menu = new List<MenuModels>();
            foreach(var m in menuList)
            {
                var mSingle =new MenuModels
                {
                    id = m.Id.ToString(),
                    icon = m.IconCode,
                    text = m.MenuName,
                    url = m.ActionUrl,
                    menus = new List<MenuModels>()
                };
                foreach(var l in m.ChildList)
                {
                    mSingle.menus.Add(new MenuModels{
                        id=l.Id.ToString(), icon=l.IconCode, text=l.MenuName, url=l.ActionUrl
                    });
                }
                menu.Add(mSingle);
            }
            WMS.Common.Reids.RedisCache.Set("CommonCache_Menu", JsonConvert.SerializeObject(menu));
        }
    }
}