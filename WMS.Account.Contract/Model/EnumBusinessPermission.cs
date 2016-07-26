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
    #region 企业部门,行政级别
    public class EnterpriseInfo
    {
        public int EnterpriseId { set; get; }
        public string EnterpriseName { set; get; }

        public string EnterpriseAddress{set;get;}
        public string ContactUser { set; get; }
        public string ContactTel { set; get; }
        public int Status { set; get; }
    }
    public class EnterpriseDepartmentInfo
    {
        public int eId { set; get; }
        public string eName { set; get; }
        public IList<DepartmentInfo> eDpt { set; get; }
    }

    public class DepartmentInfo
    {
        public int DptId { set; get; }
        public string DptName { set; get; }
        public int DptPId { set; get; }

        public int DptLevel { get; set; }
        public IList<DepartmentInfo> DptChild { set; get; }
    }

    /// <summary>
    /// 行政级别，1 超级用户 2企业管理员 3部门经理 4部门主管 5管理自身数据
    /// </summary>
    public class ManageLevelInfo
    {
        public int LevelId { set; get; }
        public string LevelName { set; get; }
    }
    public enum EnumManageLevel
    {
        [EnumTitle("超级管理员", IsDisplay = false)]
        SuperUser=0,
        [EnumTitle("企业级管理员")]
        EnterpriseManager=1,
        [EnumTitle("部长级")]
        DepartmentManager=2,
        [EnumTitle("主任级")]
        DepartmentDirector=3,
        [EnumTitle("员工级")]
        Staff=4
    }
    #endregion
}
