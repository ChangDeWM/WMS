using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WMS.Account.Contract
{
    public class UserClassInfo
    {
        public int UserId { set; get; }
        public string LoginAccount { set; get; }
        public string NickName { set; get; }
        public string Password { set; get; }
        public string MenuString { get; set; }
        public string ActionString { get; set; }
        public List<WMS.Account.Contract.MenuCollection> MenuList
        {
            get
            {
                if (string.IsNullOrEmpty(MenuString))
                    return new List<MenuCollection>();
                else
                    return JsonConvert.DeserializeObject<List<MenuCollection>>(MenuString);
            }
            set
            {
                MenuString = JsonConvert.SerializeObject(value as List<MenuCollection>);
            }
        }
        public List<WMS.Account.Contract.ActionCollection> ActionList
        {
            get
            {
                if (string.IsNullOrEmpty(ActionString))
                    return new List<ActionCollection>();
                else
                    return JsonConvert.DeserializeObject<List<ActionCollection>>(MenuString);
            }
            set
            {
                MenuString = JsonConvert.SerializeObject(value as List<ActionCollection>);
            }
        } 
        //加入其它用户表相关数据
        public int? EnterpriseId { set; get; }
        public string EnterpriseName { set; get; }
        public int? DepartmentId { set; get; }
        public string DepartmentName { set; get; }
        public int? PostId { set; get; }
        public string PostName { set; get; }
        /// <summary>
        /// 管理数据级别 默认9最低
        /// </summary>
        public int ManageLevel { set; get; }
        public int Status { set; get; }
        public string Remarks { set; get; }

        public string Mobile { set; get; }
    }
}
