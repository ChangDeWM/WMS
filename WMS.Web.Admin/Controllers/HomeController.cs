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
            var user =  UserContext.GetUserInfoByRedis(this.LoginInfo.LoginToken);
            if(user != null)
            {
                //ViewData["User_EnterpriseName"] = user.EnterpriseName;
                //ViewData["User_DepartmentName"] = user.DepartmentName;
                //ViewData["User_NickName"] = user.NickName;
                //ViewData["User_Img"] = user.ImgUrl;

                return View(user);
            }
            else
            {
                RedirectToAction("Index", "Login");
            }
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
            var list = WMS.Common.Reids.RedisCache.Get<List<MenuModels>>("CommonCache_Menu");
            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
