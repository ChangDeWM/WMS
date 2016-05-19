using System;
using WMS.Account.Contract;
using WMS.Core.Cache;
using WMS.Common.Contract;
using WMS.Common.Reids;
using System.Linq;

namespace WMS.Web
{
    public class UserContext
    {
        protected IAuthCookie authCookie;

        public UserContext(IAuthCookie authCookie)
        {
            this.authCookie = authCookie;
        }

        public LoginInfo LoginInfo
        {
            get
            {
                return CacheHelper.GetItem<LoginInfo>("LoginInfo", () =>
                {
                    if (authCookie.UserToken == Guid.Empty)
                        return null;
                    
                    var loginInfo = ServiceContext.Current.AccountService.GetLoginInfo(authCookie.UserToken);

                    if (loginInfo != null && loginInfo.UserId > 0 && loginInfo.UserId != this.authCookie.UserId)
                        throw new Exception("非法操作，试图通过网站修改Cookie取得用户信息！");

                    return loginInfo;
                });
            }
        }

        public static void RemoveAllUserInfo(string security_key)
        {
            var user = GetUserInfoByRedis(security_key);
            RedisCache.Remove(String.Format("User_{0}", security_key));
            RedisCache.Remove(String.Format("Login_{0}_{1}", user.UserId, user.LoginAccount));
        }
        public static void RemoveUserInfoByRedis(string security_key)
        {
            RedisCache.Remove(String.Format("User_{0}", security_key));
        }
        public static void RemoveLoginInfoByRedis(string security_key,string userId,string loginAccount)
        {
            RedisCache.Remove(String.Format("Login_{0}_{1}", userId, loginAccount));
        }
        public static bool SetUserInfoByRedis(string security_key, UserClassInfo userClassInfo)
        {
            return RedisCache.Set<UserClassInfo>(String.Format("User_{0}", security_key), userClassInfo, 60 * 60 * 2);
        }
        /// <summary>
        /// 根据Sec_Key 获取Cache UserInfo
        /// </summary>
        /// <param name="security_key"></param>
        /// <param name="chcheInfo"></param>
        /// <returns></returns>
        public static UserClassInfo GetUserInfoByRedis(string security_key)
        {
            return String.IsNullOrEmpty(security_key)?null:RedisCache.Get<UserClassInfo>(String.Format("User_{0}",security_key));
        }

        public static LoginInfo GetUserLoginInfo(string security_key)
        {
            var user = RedisCache.Get<UserClassInfo>(String.Format("User_{0}", security_key));
            if (user != null)
            {
                return RedisCache.Get<LoginInfo>(String.Format("Login_{0}_{1}", user.UserId, user.LoginAccount));
            }
            return null;
        }

        /// <summary>
        /// 根据链接地址判断是否有权
        /// </summary>
        /// <param name="security_key"></param>
        /// <param name="areaName"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public static bool CheckPermission(string security_key,string areaName,string controllerName,string actionName)
        {
            var userInfo = GetUserInfoByRedis(security_key);
            if(userInfo != null)
            {
                var ckMenu = userInfo.MenuList.Count(n => n.AreaName.Equals(areaName) && n.ControllerName.Equals(controllerName) && n.ActionName.Equals(actionName));
                if (ckMenu > 0) return true;
                ckMenu = userInfo.ActionList.Count(n => n.AreaName.Equals(areaName) && n.ControllerName.Equals(controllerName) && n.ActionName.Equals(actionName));
                if (ckMenu > 0) return true;
                return false;
            }
            return false;
        }
    }
}
