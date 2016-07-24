using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Common.Utility;

namespace WMS.Account.Contract
{
    public enum EnumBusinessPermission
    {
        [EnumTitle("[无]", IsDisplay = false)]
        None = 0,
        /// <summary>
        /// 管理用户
        /// </summary>
        [EnumTitle("管理用户")]
        AccountManage_User = 101,

        /// <summary>
        /// 管理角色
        /// </summary>
        [EnumTitle("管理角色")]
        AccountManage_Role = 102,

        [EnumTitle("CMS管理文章")]
        CmsManage_Article = 201,

        [EnumTitle("CMS管理文章频道")]
        CmsManage_Channel = 202,


        [EnumTitle("CRM管理来访来电")]
        CrmManage_VisitRecord = 301,

        [EnumTitle("CRM客户管理")]
        CrmManage_Customer = 302,

        [EnumTitle("CRM项目管理")]
        CrmManage_Project = 303,

        [EnumTitle("CRM查看统计信息")]
        CrmManage_Analysis = 304,


        [EnumTitle("OA管理员工")]
        OAManage_Staff = 401,

        [EnumTitle("OA管理部门")]
        OAManage_Branch = 402,

        [EnumTitle("组织结构管理")]
        OAManage_Org = 403,
    }
    public class MenuInfo
    {
        public int Id { set; get; }
        public int PId { set; get; }
        public string MenuName { set; get; }
        public string ActionUrl { set; get; }
        public string AreaName { set; get; }
        public string ControllerName { set; get; }
        public string ActionName { set; get; }
        public bool IsShow { set; get; }
        public bool IsLeaf { set; get; }
        public int MenuLevel { set; get; }
        public int SortId { set; get; }
        public string IconCode { set; get; }
        public List<MenuInfo> ChildList { set; get; }
        public List<ActionInfo> ActionList { set; get; }
    }
    public class ActionInfo
    {
        public int Id { set; get; }
        public int MenuId { set; get; }
        public string ActionName { set; get; }
        public string ActionTag { set; get; }
        public string ActionMarks { set; get; }
    }
    public class MenuCollection
    {
        public int Id { set; get; }
        public int PId { set; get; }
        public string MenuName { set; get; }
        public string ActionUrl { set; get; }
        public string AreaName { set; get; }
        public string ControllerName { set; get; }
        public string ActionName { set; get; }
        public bool IsShow { set; get; }
        public bool IsLeaf { set; get; }
        public int MenuLevel { set; get; }
        public int SortId { set; get; }
        public string IconCode { set; get; }
    }

    public class ActionCollection
    {
        public int Id { set; get; }
        public int MenuId { set; get; }
        public string AreaName { set; get; }
        public string ControllerName { set; get; }
        public string ActionName { set; get; }
        public string ActionTag { set; get; }
    }

    #region 企业部门
    public class EnterpriseInfo
    {
        public int eId { set; get; }
        public string eName { set; get; }
        public List<DepartmentInfo> eDpt { set; get; }
    }


    public class DepartmentInfo
    {
        public int DptId { set; get; }
        public string DptName { set; get; }
        public int DptPId { set; get; }
    }
    #endregion
}
