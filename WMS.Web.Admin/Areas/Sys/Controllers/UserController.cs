using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft;
using WMS.Web.Admin.Common;
using WMS.Account.Contract;
using WMS.Common.Utility;
using WMS.Common.Web;

namespace WMS.Web.Admin.Areas.Sys.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Sys/User/ 
        // List
        public ActionResult Index(WMS.Account.Contract.UserRequest request)
        {
            var levelList = new Dictionary<int, string>
            {
                {(int) EnumManageLevel.EnterpriseManager, EnumHelper.GetEnumTitle(EnumManageLevel.EnterpriseManager)},
                {(int) EnumManageLevel.DepartmentManager, EnumHelper.GetEnumTitle(EnumManageLevel.DepartmentManager)},
                {(int) EnumManageLevel.DepartmentDirector, EnumHelper.GetEnumTitle(EnumManageLevel.DepartmentDirector)},
                {(int) EnumManageLevel.Staff, EnumHelper.GetEnumTitle(EnumManageLevel.Staff)},
            };
            ViewData["mgLevel"] = new SelectList(levelList, "Key", "Value", request.MgLevel);

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

        #region Edit Create View
        public ActionResult Create()
        {
            var user = UserContext.GetUserInfoByRedis(this.LoginInfo.LoginToken);
            ViewData["dllEnterprise"] = new SelectList(this.AccountService.GetAllEnterpriseList(), "EnterpriseId", "EnterpriseName", user.EnterpriseId);
            var levelList  = new Dictionary<int, string>
            {
                {(int) EnumManageLevel.EnterpriseManager, EnumHelper.GetEnumTitle(EnumManageLevel.EnterpriseManager)},
                {(int) EnumManageLevel.DepartmentManager, EnumHelper.GetEnumTitle(EnumManageLevel.DepartmentManager)},
                {(int) EnumManageLevel.DepartmentDirector, EnumHelper.GetEnumTitle(EnumManageLevel.DepartmentDirector)},
                {(int) EnumManageLevel.Staff, EnumHelper.GetEnumTitle(EnumManageLevel.Staff)},
            };
            ViewData["dllManageLevel"] = new SelectList(levelList, "Key", "Value", user.ManageLevel);

            var model = new UserClassInfo { Status = 1, Password="123456" };
            return View("Edit",model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new UserClassInfo { Status = 1, Password = "123456" };

            TryUpdateModel(model);

            this.AccountService.SaveUser(model);
            return this.RefreshParent();
        }

        public ActionResult Edit(int id)
        {
            var user = UserContext.GetUserInfoByRedis(this.LoginInfo.LoginToken);
            ViewData["dllEnterprise"] = new SelectList(this.AccountService.GetAllEnterpriseList(), "EnterpriseId", "EnterpriseName", user.EnterpriseId);
            var levelList = new Dictionary<int, string>
            {
                {(int) EnumManageLevel.EnterpriseManager, EnumHelper.GetEnumTitle(EnumManageLevel.EnterpriseManager)},
                {(int) EnumManageLevel.DepartmentManager, EnumHelper.GetEnumTitle(EnumManageLevel.DepartmentManager)},
                {(int) EnumManageLevel.DepartmentDirector, EnumHelper.GetEnumTitle(EnumManageLevel.DepartmentDirector)},
                {(int) EnumManageLevel.Staff, EnumHelper.GetEnumTitle(EnumManageLevel.Staff)},
            };
            ViewData["dllManageLevel"] = new SelectList(levelList, "Key", "Value", user.ManageLevel);

            this.ViewBag.RoleIds = new SelectList(levelList, "Key", "Value", user.ManageLevel);

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

        public ActionResult View(int id)
        {
            var eList = this.AccountService.GetEnterpriseDict();
            ViewData["eList"] = Newtonsoft.Json.JsonConvert.SerializeObject(eList);
            var levelList = new Dictionary<int, string>
            {
                {(int) EnumManageLevel.EnterpriseManager, EnumHelper.GetEnumTitle(EnumManageLevel.EnterpriseManager)},
                {(int) EnumManageLevel.DepartmentManager, EnumHelper.GetEnumTitle(EnumManageLevel.DepartmentManager)},
                {(int) EnumManageLevel.DepartmentDirector, EnumHelper.GetEnumTitle(EnumManageLevel.DepartmentDirector)},
                {(int) EnumManageLevel.Staff, EnumHelper.GetEnumTitle(EnumManageLevel.Staff)},
            };
            ViewData["mgLevel"] = Newtonsoft.Json.JsonConvert.SerializeObject(levelList);

            var enterpriseInfo = this.AccountService.GetEnterpriseList();
            ViewData["EnterpriseInfo"] = Newtonsoft.Json.JsonConvert.SerializeObject(enterpriseInfo).ToString();
            var model = this.AccountService.GetUser(id);
            return View(model);
        }
        [HttpPost]
        public JsonResult EidtAttr(int pk, FormCollection collection)
        {
            try
            {
                var filedName = collection["name"].ToString();
                var filedValue = collection["value"].ToString();
                //var id = collection["pk"].ToString();
                if (this.AccountService.EditUserAttr(pk, filedName, filedValue))
                {
                    var security_key = Cookie.GetValue(WMS.Common.Contract.ConstStr.AppSessionId);
                    UserContext.RefreshUserInfo(security_key, filedName, filedValue);
                    return new JsonResult { Data = "OK" };
                }
                else
                    return new JsonResult { Data = "更新失败！" };
            }
            catch (Exception exp) { return new JsonResult { Data = "更新失败："+exp.Message.ToString() }; }
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
