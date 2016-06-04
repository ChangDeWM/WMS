using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WMS.Web.Admin.Models;
using WMS.Core.Log;
using WMS.Common.Utility;
using WMS.Common.Contract;

namespace WMS.Web.Admin.ashx
{
    /// <summary>
    /// Sys_Ajax 的摘要说明
    /// </summary>
    public class Sys_Ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var serkey =Cookie.GetValue(ConstStr.AppSessionId);
            var userInfo = String.IsNullOrEmpty(serkey)?"无":JsonConvert.SerializeObject(UserContext.GetUserInfoByRedis(serkey));
            //写日志
            Log4NetHelper.Info(LoggerType.WebExceptionLog, String.Format(" SysAjax.ashx Cookie:{0} URL:{1}", serkey,userInfo), null);

            var menu = new List<MenuModels>();
            menu.Add(new MenuModels
            {
                id = "1",
                icon = "icon-cog",
                text = "系统设置",
                url = "",
                menus = new List<MenuModels>
                {
                    new MenuModels{id = "11",icon = "icon-glass",text = "测试页面",url = "/Home/Main"},
                    new MenuModels{id = "12",icon = "icon-list",text = "常德牌水表",url = "/Home/Test"}
                }
            });
            menu.Add(new MenuModels
            {
                id = "2",
                icon = "icon-user",
                text = "权限管理",
                url = "",
                menus = new List<MenuModels>
                {
                    new MenuModels{id = "21",icon = "icon-user",text = "用户管理",url = "/Sys/User/Index"},
                    new MenuModels{id = "22",icon = "icon-apple",text = "角色管理",url = "/Sys/Set/Role"}
                }
            });
            var jsonStr = JsonConvert.SerializeObject(menu);
            context.Response.Write(jsonStr);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}