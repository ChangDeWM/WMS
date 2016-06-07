using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Web.Admin.Common;
using WMS.Account.Contract;

namespace WMS.Web.Admin.Areas.Sys.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Sys/User/ 
        // List
        public ActionResult Index(WMS.Account.Contract.UserRequest request)
        {
            var list = this.AccountService.GetUserList(request);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_partialUser", list);
            }
            return View(list);
        }

        public ActionResult UserList(WMS.Account.Contract.UserRequest request)
        {
            var list = this.AccountService.GetUserList(request);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_partialUser", list);
            }
            return View(list);
        }
    }
}
