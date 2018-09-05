using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary> 
    /// 项目表
    /// </summary>
    public class ProjectTypes
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public string ProjectTypID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 成本值
        /// </summary>
        public string ValueAtcost { get; set; }

        /// <summary>
        /// 项目中要使用的产品
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        // 员工ID
        /// </summary>
        public string StaffID { get; set; }
        /// <summary>
        ///操作ID
        /// </summary>
        public string OperationID { get; set; }
        /// <summary>
        /// 项目类别
        /// </summary>
        public string CategorysID { get; set; }

        //public virtual List<Staffs> Staffs { get; set; }

        //public virtual List<Operation> Operation { get; set; }

        //public virtual List<Categorys> Categorys { get; set; }

        //public virtual List<Products> Products { get; set; }

    }
}
