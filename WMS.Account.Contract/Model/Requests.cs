using System;
using System.Collections.Generic;
using WMS.Common.Contract;

namespace WMS.Account.Contract
{
    public class UserRequest : Request
    {
        public string LoginAccount { get; set; }
        public string Mobile { get; set; }
        public string UserName { set; get; }
        public int? MgLevel { set; get; }
        public string OrderAsc { set; get; }
    }

    public class RoleRequest : Request
    {
        public string RoleName { get; set; }
    }
}
