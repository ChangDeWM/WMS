﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Account.Contract;
using WMS.Account.DAL;
using WMS.Common.Utility;
using WMS.Common.Contract;
using WMS.Common.Reids;
using EntityFramework.Extensions;

using WMS.Core.Cache;
using WMS.Core.Config;

namespace WMS.Account.BLL
{
    public class AccountService : IAccountService
    {
        private readonly int _UserLoginTimeoutMinutes = CachedConfigContext.Current.SystemConfig.UserLoginTimeoutMinutes;
        private readonly string _LoginInfoKeyFormat = "LoginInfo_{0}";

        public LoginInfo GetLoginInfo(Guid token)
        {
            return CacheHelper.Get<LoginInfo>(string.Format(_LoginInfoKeyFormat, token), () =>
            {
                //using (var dbContext = new WmsDbContext())
                //{
                    ////如果有超时的，启动超时处理
                    //var timeoutList = dbContext.FindAll<LoginInfo>(p => EntityFunctions.DiffMinutes(DateTime.Now, p.LastAccessTime) > _UserLoginTimeoutMinutes);
                    //if (timeoutList.Count > 0)
                    //{
                    //    foreach (var li in timeoutList)
                    //        dbContext.LoginInfos.Remove(li);
                    //}

                    //dbContext.SaveChanges();


                    //var loginInfo = dbContext.FindAll<LoginInfo>(l => l.LoginToken == token).FirstOrDefault();
                    //if (loginInfo != null)
                    //{
                    //    loginInfo.LastAccessTime = DateTime.Now;
                    //    dbContext.Update<LoginInfo>(loginInfo);
                    //}

                    //return loginInfo;
                //}
                return new LoginInfo();
            });
        }

        public LoginInfo Login(string loginName, string password)
        {
            LoginInfo loginInfo = null;

            password = Encrypt.MD5(password);
            loginName = loginName.Trim();
            using(var db = new WmsDbContext())
            {
                var user = db.UserInfo.FirstOrDefault(n => n.UserAccount.Equals(loginName) && n.Password.Equals(password));
                if(user != null)
                {
                    var ip = Fetch.UserIp;
                    loginInfo = RedisCache.Get<LoginInfo>(String.Format("Login_{0}_{1}", user.Id, user.UserAccount));
                    if (loginInfo != null)
                    {
                        loginInfo.LastAccessTime = DateTime.Now;
                        RedisCache.Set<LoginInfo>(String.Format("Login_{0}_{1}", user.Id, user.UserAccount), loginInfo, 60 * 60 * 2);
                    }
                    else
                    {
                        loginInfo = new LoginInfo(user.Id, user.UserAccount);
                        loginInfo.ClientIP = ip;
                        RedisCache.Set<LoginInfo>(String.Format("Login_{0}_{1}", user.Id, user.UserAccount), loginInfo, 60 * 60 * 2);
                    }
                }
            }
            if(loginInfo != null)
            {
                //说明登录成功了,写入缓存
                RedisCache.Set<UserClassInfo>(String.Format("User_{0}", loginInfo.LoginToken), GetUser(loginInfo.UserId), 60 * 60 * 2);
            }
            return loginInfo;
        }

        public void Logout(Guid token)
        {
            //using (var dbContext = new AccountDbContext())
            //{
            //    var loginInfo = dbContext.FindAll<LoginInfo>(l => l.LoginToken == token).FirstOrDefault();
            //    if (loginInfo != null)
            //    {
            //        dbContext.Delete<LoginInfo>(loginInfo);
            //    }
            //}

            //CacheHelper.Remove(string.Format(_LoginInfoKeyFormat, token));
        }

        public void ModifyPwd(UserClassInfo user)
        {
            user.Password = Encrypt.MD5(user.Password);

            using (var dbContext = new WmsDbContext())
            {
                //if (dbContext.Users.Any(l => l.ID == user.ID && user.Password == l.Password))
                //{
                //    if (!string.IsNullOrEmpty(user.NewPassword))
                //        user.Password = Encrypt.MD5(user.NewPassword);

                //    dbContext.Update<User>(user);
                //}
                //else
                //{
                //    throw new BusinessException("Password", "原密码不正确！");
                //}
            }
        }

        public UserClassInfo GetUser(int userId)
        {
            using (var dbContext = new WmsDbContext())
            {
                IQueryable<UserClassInfo> users = from n in dbContext.UserInfo
                                                  join en in dbContext.Enterprise on n.EnterpriseId equals en.Id into JoinedEmpEnterprise
                                                  from en in JoinedEmpEnterprise.DefaultIfEmpty()
                                                  join dpt in dbContext.Department on n.DepId equals dpt.Id into JoinedEmpDept
                                                  from dpt in JoinedEmpDept.DefaultIfEmpty()
                                                  where n.Id.Equals(userId) && !n.Status.Equals(1)
                                                  select new UserClassInfo
                                                  {
                                                      DepartmentName = dpt != null ? dpt.DepName : null,
                                                      EnterpriseName = en != null ? en.EnterpriseName : null,
                                                      DepartmentId = n.DepId,
                                                      EnterpriseId = n.EnterpriseId,
                                                      LoginAccount = n.UserAccount,
                                                      ManageLevel = n.ManageLevel,
                                                      NickName = n.NickName,
                                                      PostId = n.PostId,
                                                      PostName = "",
                                                      Remarks = n.Remarks,
                                                      Status = n.Status,
                                                      UserId = n.Id,
                                                      Mobile = n.Telephone
                                                  };
                return users.FirstOrDefault();
            }
            //using (var dbContext = new WmsDbContext())
            //{
            //    //return dbContext.UserInfo.FirstOrDefault(u=>u.Id.Equals(id));
            //    //组合权限后生成UserClassInfo
            //    return new UserClassInfo();
            //}
        }

        public IEnumerable<UserClassInfo> GetUserList(UserRequest request = null)
        {
            request = request ?? new UserRequest();

            using (var dbContext = new WmsDbContext())
            {
                IQueryable<UserClassInfo> users = from n in dbContext.UserInfo
                                                  join en in dbContext.Enterprise on n.EnterpriseId equals en.Id into JoinedEmpEnterprise
                                                  from en in JoinedEmpEnterprise.DefaultIfEmpty()
                                                  join dpt in dbContext.Department on n.DepId equals dpt.Id into JoinedEmpDept
                                                  from dpt in JoinedEmpDept.DefaultIfEmpty()
                                                  //where !n.Status.Equals(1)
                                                  select new UserClassInfo
                                                  {
                                                      DepartmentName = dpt != null ? dpt.DepName : null,
                                                      EnterpriseName = en != null ? en.EnterpriseName : null,
                                                      DepartmentId = n.DepId,
                                                      EnterpriseId = n.EnterpriseId,
                                                      LoginAccount = n.UserAccount,
                                                      ManageLevel = n.ManageLevel,
                                                      NickName = n.UserName + "(" + n.NickName + ")",
                                                      PostId = n.PostId,
                                                      PostName = "",
                                                      Remarks = n.Remarks,
                                                      Status = n.Status,
                                                      UserId = n.Id,
                                                      Mobile = n.Telephone
                                                  };
                if (!string.IsNullOrEmpty(request.LoginAccount))
                    users = users.Where(u => u.LoginAccount.Contains(request.LoginAccount));

                if (!string.IsNullOrEmpty(request.Mobile))
                    users = users.Where(u => u.Mobile.Contains(request.Mobile));

                if (!string.IsNullOrEmpty(request.UserName))
                    users = users.Where(u => u.NickName.Contains(request.UserName));

                if (!string.IsNullOrEmpty(request.OrderAsc) && request.OrderAsc.Equals("00"))
                    return users.OrderBy(n => n.LoginAccount).ToPagedList(request.PageIndex, request.PageSize);

                return users.OrderByDescending(u => u.UserId).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveUser(UserClassInfo user)
        {
            using (var dbContext = new WmsDbContext())
            {
                //if (user.ID > 0)
                //{
                //    dbContext.Update<User>(user);

                //    var roles = dbContext.Roles.Where(r => user.RoleIds.Contains(r.ID)).ToList();
                //    user.Roles = roles;
                //    dbContext.SaveChanges();
                //}
                //else
                //{
                //    var existUser = dbContext.FindAll<User>(u => u.LoginName == user.LoginName);
                //    if (existUser.Count > 0)
                //    {
                //        throw new BusinessException("LoginName", "此登录名已存在！");
                //    }
                //    else
                //    {
                //        dbContext.Insert<User>(user);

                //        var roles = dbContext.Roles.Where(r => user.RoleIds.Contains(r.ID)).ToList();
                //        user.Roles = roles;
                //        dbContext.SaveChanges();
                //    }
                //}
            }
        }

        public bool CheckUser(int userId,bool checkStatus)
        {
            int stauts = checkStatus ? 0 : 1;
            using (var dbContext = new WmsDbContext())
            {
                var rows = dbContext.UserInfo.FirstOrDefault(n => n.Id.Equals(userId));
                if(rows != null)
                {
                    rows.Status = stauts;
                }
                return dbContext.SaveChanges()>0;
                //dbContext.UserInfo.Update(n => n.Id.Equals(userId), u => new UserInfo{ u.Status = stauts});
            }
        }

        public void SaveTempUser()
        {
            using (var dbContext = new WmsDbContext())
            {
                for (var j = 1; j < 100; j++)
                {
                    for (var i = 1; i < 500; i++)
                    {
                        var us = String.Format("USER_{0}_{1}",j,i);
                        dbContext.UserInfo.Add(
                            new UserInfo { DepId = 1001, EnterpriseId = 1, ManageLevel = 3, NickName = us, Password = "E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E", PostId = 0, Status = 0, Telephone = "18773187585", UserAccount = us, UserName = "Json No." + us, Remarks = "system" });
                    }
                    dbContext.SaveChanges();
                }
            }
        }
        public void DeleteUser(List<int> ids)
        {
            using (var dbContext = new WmsDbContext())
            {
                dbContext.UserInfo.Where(n => ids.Contains(n.Id)).Delete();                
                //dbContext.SaveChanges();
            }
        }

        public Guid SaveVerifyCode(string verifyCodeText)
        {
            if (string.IsNullOrWhiteSpace(verifyCodeText))
                throw new BusinessException("verifyCode", "输入的验证码不能为空！");

            using (var dbContext = new WmsDbContext())
            {
                var verifyCode = new VerifyCode(){VerifyText = verifyCodeText, Guid = Guid.NewGuid()};
                //dbContext.Insert<VerifyCode>(verifyCode);
                return verifyCode.Guid;
            }
        }

        public bool CheckVerifyCode(string verifyCodeText, Guid guid)
        {
            using (var dbContext = new WmsDbContext())
            {
                var verifyCode = "";// dbContext.FindAll<VerifyCode>(v => v.Guid == guid && v.VerifyText == verifyCodeText).LastOrDefault();
                if (verifyCode != null)
                {
                    //dbContext.VerifyCodes.Remove(verifyCode);
                    //dbContext.SaveChanges();

                    //清除验证码大于2分钟还没请求的
                    //var expiredTime = DateTime.Now.AddMinutes(-2);
                    //dbContext.VerifyCodes.Where(v => v.CreateTime < expiredTime).Delete();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<WMS.Account.Contract.MenuInfo> GetMenuList(int userId)
        {
            using(var dbContext = new WmsDbContext())
            {
                try
                {
                    var list = (from n in dbContext.MenuInfo
                               where n.PId.Equals(0)
                               select new WMS.Account.Contract.MenuInfo
                               {
                                   Id = n.Id,
                                   IconCode = n.IconCode,
                                   PId = n.PId,
                                   MenuName = n.MenuName,
                                   MenuLevel = n.MenuLevel,
                                   ActionUrl = n.ActionUrl,
                                   IsLeaf = n.IsLeaf,
                                   IsShow = n.IsShow,
                                   SortId = n.SortId
                               }).OrderBy(n=>n.SortId).ToList();

                    return list.ToList();
                }
                catch { return null; }
            }
        }


        #region 授权
        
        #endregion
    }
}
