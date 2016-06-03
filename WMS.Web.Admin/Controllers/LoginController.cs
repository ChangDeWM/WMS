using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Common.Utility;
using WMS.Common.Contract;
using WMS.Account.Contract;
using WMS.Web.Admin.Common;

namespace WMS.Web.Admin.Controllers
{
    public class LoginController : ControllerBase
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View(); 
        }

        public ActionResult Logout()
        {
            var security_key = Cookie.GetValue(ConstStr.AppSessionId);
            //清除Cache
            UserContext.RemoveAllUserInfo(security_key);
            //清除Cookie
            Cookie.Remove(ConstStr.AppSessionId);
            return Redirect("/Login");
        }

        //[HttpPost]
        public ActionResult CheckUserLogin(string username, string password)
        {
            try
            {
                //if (String.IsNullOrEmpty(username)) return Content("0|请输入登录账号");
                //if (String.IsNullOrEmpty(password)) return Content("0|请输入您的密码");
                var msg = "0|登录失败";
                var loginInfo = this.AccountService.Login(username, password);

                if (loginInfo != null)
                {
                    //写日志
                    WMS.Core.Log.Log4NetHelper.Info(WMS.Core.Log.LoggerType.WebExceptionLog,
                        String.Format(" CheckUserLogin username:{0} password:{1} Token:{2}", username, password, loginInfo.LoginToken.ToString()), null);
                    //写入Cookie
                    Cookie.Save(ConstStr.AppSessionId, loginInfo.LoginToken.ToString(), 60 * 60 * 2);
                    Session[ConstStr.AppSessionId] = loginInfo.LoginToken.ToString();
                    UserContext.SetUserInfoByRedis(loginInfo.LoginToken.ToString(), new UserClassInfo { UserId = loginInfo.UserId, LoginAccount = loginInfo.LoginAccount, EnterpriseId=1, EnterpriseName="常德自来水", DepartmentId=1, DepartmentName="信息部", NickName="易建新" });
                    //return RedirectToAction("Index", "Home");
                    return Content("1");
                }
                else
                {
                    msg = "0|用户名或密码不正确";
                }
                return Content(msg);
            }
            catch(Exception exp)
            {
                return Content("0|登录失败，系统异常<br />失败原因："+exp.Message.ToString());
            }
        }
    }
}
