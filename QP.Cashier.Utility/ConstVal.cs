using System;

namespace QP.Cashier.Utility
{
    /// <summary>
    ///  角色分配
    /// </summary>
    public static class ConstVal
    {
        /// <summary>
        /// 一般管理员（店长、地区经理、总监、副总角色）
        /// </summary>
        public static readonly string RoleAdmin = "admin";
        /// <summary>
        /// 超级管理员（数据库DBA，系统调试员,System,老板）
        /// </summary>
        public static readonly string RoleSystem = "System";
        /// <summary>
        /// 收银员（一线业务员，角色独立）
        /// </summary>
        public static readonly string RoleCasher = "Casher";


        public static string Roles { get; set; }
    }
}
