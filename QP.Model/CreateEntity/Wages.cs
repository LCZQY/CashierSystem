using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// 工资表
    /// </summary>
    public class Wages
    {
        /// <summary>
        ///  --工资表ID
        /// </summary>
        public string WagesID { get; set; }
        
        ///// <summary>
        /////  员工ID
        ///// </summary>
        //public string StaffID { get; set; }

        /// <summary>
        /// 底薪
        /// </summary>
        public decimal BasicSalary { get; set; }

        /// <summary>
        /// 提成 
        /// </summary>
        public decimal PushMoney { get; set; }
        /// <summary>
        /// 扣款
        /// </summary>
        public decimal Withhold { get; set; }
        /// <summary>
        /// -扣款原因
        /// </summary>
        public decimal WithholdCause { get; set; }

       // public Staffs Staffs { get; set; }  

    }
}
