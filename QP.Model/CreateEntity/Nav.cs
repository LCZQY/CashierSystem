using System;
using System.Collections.Generic;
using System.Text;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// 导航表
    /// </summary>
    public class Navs
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 父级导航ID
        /// </summary>
        public string Parentid { get; set; }
        /// <summary>
        /// 导航名
        /// </summary>
        public string NavName { get; set; }
        /// <summary>
        /// 对应区域
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 对应控制器
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// 对应控制器动作
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 该方法使用的访问方式，Mvc当中只能为get,post,api中可以有put,delete
        /// </summary>
        public string Method { get; set; } = "get";
        /// <summary>
        /// 是否为隐藏方法
        /// </summary>
        public bool IsHiddenMethod { get; set; }
        /// <summary>
        /// 是否作为导航菜单
        /// </summary>
        public bool IsNavi { get; set; }
        /// <summary>
        ///  是否可用
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 导航栏创建时间
        /// </summary>
        //public DateTime CreateDate { get; set; }

        /// <summary>
        /// 图标样式
        /// </summary>
        public string IcoCss { get; set; }      

        /// <summary>
        /// 角色
        /// </summary>
        public string Roles { get; set; }
    }
}
