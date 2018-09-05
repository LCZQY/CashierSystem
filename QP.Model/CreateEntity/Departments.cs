using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    ///  部门表
    /// </summary>
    public class Departments
    {
        /// <summary>
        ///  部门ID
        /// </summary>
        [StringLength(maximumLength: 36)]
        [Key]
        public string DepartmentID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        ///  部门人数
        /// </summary>
        public string irs { get; set; }

    }
}
