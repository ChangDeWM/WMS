using System;
using System.Collections.Generic;
using WMS.Common.Contract;

namespace WMS.Account.Contract
{
    public interface IAccountService
    {
        LoginInfo GetLoginInfo(Guid token);
        LoginInfo Login(string loginName, string password);
        void Logout(Guid token);
        void ModifyPwd(UserClassInfo user);
        UserClassInfo GetUser(int userId);
        IEnumerable<UserClassInfo> GetUserList(UserRequest request = null);
        void SaveUser(UserClassInfo user);
        void DeleteUser(List<int> ids);

        Guid SaveVerifyCode(string verifyCodeText);
        bool CheckVerifyCode(string verifyCodeText, Guid guid);

        List<WMS.Account.Contract.MenuInfo> GetMenuList(int userId);

    }
}
