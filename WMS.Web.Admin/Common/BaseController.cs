using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Common.Utility;
using WMS.Common.Contract;
using WMS.Common.Web;
using WMS.Account.Contract;
using WMS.Core.Log;
 
namespace WMS.Web.Admin.Common
{
    public abstract class BaseController : ControllerBase
    {
        //private const string AppSessionId = "wms_security_key";
        /// <summary>
        /// 重写分页Size
        /// </summary>
        public override int PageSize
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// 操作人，为了记录操作历史
        /// </summary>
        public override Operater Operater
        {
            get
            {
                return new Operater()
                {
                    Name = this.LoginInfo == null ? "" : this.LoginInfo.LoginAccount,
                    Token = this.LoginInfo == null ? Guid.Empty : this.LoginInfo.LoginToken,
                    UserId = this.LoginInfo == null ? 0 : this.LoginInfo.UserId,
                    Time = DateTime.Now,
                    IP = Fetch.UserIp
                };
            }
        }

        public virtual LoginInfo LoginInfo
        {
            get
            {
                var security_key = Cookie.GetValue(ConstStr.AppSessionId);
                if (String.IsNullOrEmpty(security_key)) return null;
                return UserContext.GetUserLoginInfo(security_key);
            }
        }

        /// <summary>
        /// 重写基类在Action之前执行的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var security_key = Cookie.GetValue(ConstStr.AppSessionId);

            //写日志
            Log4NetHelper.Info(LoggerType.WebExceptionLog, String.Format(" OnActionExecuting seckey:{0} URL:{1}",security_key,Request.FilePath.ToString()), null);

            if (String.IsNullOrEmpty(security_key))
            {
                //跳转登录，可跳转SSO
                filterContext.HttpContext.Response.Redirect("/Login");
                Response.End();
            }
            else
            {
                //获取分布式缓存中的用户信息
                var userClassInfo = UserContext.GetUserInfoByRedis(security_key);
                if (userClassInfo == null)
                {
                    Cookie.Remove(ConstStr.AppSessionId);//移除Cookie
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                    Response.End();
                }
                //更新Cookie过期时间，更新到2小时候过期
                Cookie.Save(ConstStr.AppSessionId, security_key, 2);

                ////判断是否有权限访问该页面
                //string encodeUrl = Server.UrlEncode(Request.Url.ToString());
                //string strUrl = Request.FilePath.ToString();
                //string[] ls = strUrl.Split('/');
                //string strAreaName=ls[0];
                //string strControllerName = ls[1];
                //string strActionName = (ls.Length >= 3 && ls[2].Trim().Length > 0) ? ls[2] : "Index";
                //strAreaName = ls.Length <= 2 ? "" : strAreaName;

                ////下面定义一组可能继承base.controller 但又无需权限验证的页面。参数对象 ActionName
                ////暂时注释，如果需要则启用
                ////string[] noActionNameList = { "Action1", "Action2", "Action3" };
                //if(!UserContext.CheckPermission(security_key,strActionName,strControllerName,strActionName))
                //{
                //    Response.Redirect("/Error/Index?code=NoPermission&url=" + encodeUrl);
                //    Response.End();
                //}
                //自动给每个页面加入ObjectAction列表对象
                //ViewData["ObjectList"] = BusinessRule.SysManage.SysPmsControlMgr.GetViewObject(CurrentUser.User_ID, strControllerName, strActionName);
            }
        }
    }
}
