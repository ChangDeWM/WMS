using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WMS.Web.Admin.Areas.Account.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Account/Auth/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return Redirect("/Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(string userAccount,string password)
        {
            return View();
        }
    }
}
