//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WMS.Account.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuInfo
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public int PId { get; set; }
        public int MenuLevel { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ActionUrl { get; set; }
        public string IconCode { get; set; }
        public bool IsShow { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsEnable { get; set; }
        public int SortId { get; set; }
        public string Remark { get; set; }
    }
}