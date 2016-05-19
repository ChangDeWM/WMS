using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.Web.Admin.Models
{
    public class data
    {
        public List<MenuModels> menuList { set; get; }
    }
    public class MenuModels
    {
        public string id { set; get; }
        public string text { set; get; }
        public string icon { set; get; }
        public string url { set; get; }
        public List<MenuModels> menus { set; get; }
    }
}
