using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using WMS.Account.Contract;
using WMS.Common.Web;
//using WMS.Common.Contract;
using WMS.Core.Log;

namespace WMS.Web
{
    public abstract class ControllerBase : WMS.Common.Web.ControllerBase
    {
        public virtual IAccountService AccountService
        {
            get
            {
                return ServiceContext.Current.AccountService;
            }
        }

        protected override void LogException(Exception exception, 
            WebExceptionContext exceptionContext = null)
        {
            base.LogException(exception);

            var message = new
            {
                exception = exception.Message,
                exceptionContext = exceptionContext,
            };

            Log4NetHelper.Error(LoggerType.WebExceptionLog, message, exception);
        }

        public IDictionary<string, object> CurrentActionParameters { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
