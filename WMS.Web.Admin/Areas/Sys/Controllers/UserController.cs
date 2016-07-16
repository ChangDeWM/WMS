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

        #region Edit
        public ActionResult Edit(int id)
        {
            var model = this.AccountService.GetUser(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.AccountService.GetUser(id);
            this.TryUpdateModel<UserClassInfo>(model);
            this.AccountService.SaveUser(model);

            return this.RefreshParent();
        }

        #endregion
        [HttpPost]
        public JsonResult Check(int id, bool status)
        {
            if (this.AccountService.CheckUser(id, status))
                return new JsonResult { Data = "OK" };
            else
                return new JsonResult { Data = "更新失败" };
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            this.AccountService.DeleteUser(new List<int> { id });
            return new JsonResult { Data = "OK" };
        }

        public JsonResult DeleteUser(string ids)
        {
            var strcc = ids.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);


            List<int> idlist = strcc.Select<string, int>(q => Convert.ToInt32(q)).ToList();
            this.AccountService.DeleteUser(idlist);
            return new JsonResult {  Data="OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}
