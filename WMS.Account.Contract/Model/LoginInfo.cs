using System;
using System.Linq;
using WMS.Common.Contract;
using System.Collections.Generic;
using WMS.Common.Utility;
//using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WMS.Account.Contract
{
    [Serializable]
    public class LoginInfo //: ModelBase
    {
        public LoginInfo()
        {
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid().ToString("N");
        }

        public LoginInfo(int userId, string loginAccount)
        {
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid().ToString("N");

            UserId = userId;
            LoginAccount = loginAccount;
        }

        public string LoginToken { get; set; }
        public DateTime LastAccessTime { get; set; }
        public int UserId { get; set; }
        public string LoginAccount { get; set; }
        public string ClientIP { get; set; }
        public EnumLoginInfo EnumLoginAccountType { get; set; }
    }
}



