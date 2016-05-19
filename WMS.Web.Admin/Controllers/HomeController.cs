using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Web.Admin.Common;
using WMS.Web.Admin.Models;

namespace WMS.Web.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["userAccount"] = this.LoginInfo.LoginAccount;
            return View(); 
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public JsonResult GetMenu()
        {
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
                    new MenuModels{id = "11",icon = "icon-user",text = "用户管理",url = "/Sys/Set/User"},
                    new MenuModels{id = "12",icon = "icon-apple",text = "角色管理",url = "/Sys/Set/Role"}
                }
            });
            return new JsonResult { Data = menu, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
