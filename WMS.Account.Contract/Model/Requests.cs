﻿using System;
using System.Collections.Generic;
using WMS.Common.Contract;

namespace WMS.Account.Contract
{
    public class UserRequest : Request
    {
        public string LoginName { get; set; }
        public string Mobile { get; set; }
    }

    public class RoleRequest : Request
    {
        public string RoleName { get; set; }
    }
}
