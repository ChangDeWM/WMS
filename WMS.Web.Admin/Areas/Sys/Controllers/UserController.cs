using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Web.Admin.Common;

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
            return View(list);
        }

    }
}
