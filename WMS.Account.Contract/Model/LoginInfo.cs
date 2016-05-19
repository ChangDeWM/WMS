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
            LoginToken = Guid.NewGuid();
        }

        public LoginInfo(int userId, string loginAccount)
        {
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid();

            UserId = userId;
            LoginAccount = loginAccount;
        }

        public Guid LoginToken { get; set; }
        public DateTime LastAccessTime { get; set; }
        public int UserId { get; set; }
        public string LoginAccount { get; set; }
        public string ClientIP { get; set; }
        public EnumLoginInfo EnumLoginAccountType { get; set; }
    }
}



