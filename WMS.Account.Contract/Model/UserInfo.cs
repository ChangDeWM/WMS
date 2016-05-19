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
    }
}
