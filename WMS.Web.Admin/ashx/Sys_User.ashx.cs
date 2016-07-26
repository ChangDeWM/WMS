using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.Web.Admin.ashx
{
    /// <summary>
    /// Sys_User 的摘要说明
    /// </summary>
    public class Sys_User : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                var actionName = context.Request.QueryString["action"].ToString();
                switch (actionName)
                {
                    case "GetDptList":
                        {
                            var eId = context.Request.QueryString["eid"].ToString();
                            var dptList = ServiceContext.Current.AccountService.GetDptListByEnterpriseId(Convert.ToInt32(eId));
                            var json = JsonConvert.SerializeObject(dptList);
                            context.Response.Write(json);
                        }
                        break;
                    default:
                        context.Response.Write("");
                        break;
                }
            }
            catch (Exception exp) { context.Response.Write(""); }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}