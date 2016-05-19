using System;
using System.Collections.Generic;
using WMS.Account.Contract;
using WMS.Core.Cache;
using WMS.Core.Service;

namespace WMS.Web
{
    public class ServiceContext
    {
        public static ServiceContext Current
        {
            get
            {
                return CacheHelper.GetItem<ServiceContext>("ServiceContext", () => new ServiceContext());
            }
        }
        
        public IAccountService AccountService
        {
            get
            {
                return ServiceHelper.CreateService<IAccountService>();
            }
        }
    }
}
