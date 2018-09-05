using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// // 权限表
    /// </summary>
    public class Authoritys
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        [Key]
        public string AuthorityID { get; set; } //权限ID//[MaxLength(50)]  
        /// <summary>
        /// 权限名称
        /// </summary>        
        public string AuthorityName { get; set; }//名称
        public string Roleds { get; set; } //角色ID

        /// <summary>
        /// 员工表
        /// </summary>
        //public Staffs Staffs { get; set; }
    }
}
