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
        bool EditUserAttr(int userId, string filedName, object filedValue);
        bool CheckUser(int userId, bool checkStatus);
        void SaveTempUser();
        void DeleteUser(List<int> ids);

        Guid SaveVerifyCode(string verifyCodeText);
        bool CheckVerifyCode(string verifyCodeText, Guid guid);

        List<WMS.Account.Contract.MenuInfo> GetMenuList(int userId);
        List<WMS.Account.Contract.MenuInfo> GetSecondLevelMenu();

        #region  企业和部门
        IEnumerable<EnterpriseInfo> GetAllEnterpriseList();

        Dictionary<int, string> GetEnterpriseList();

        List<EnterpriseDepartmentInfo> GetEnterpriseDict();

        IList<DepartmentInfo> GetDptListByEnterpriseId(int enterpriseId);
        #endregion
    }
}
