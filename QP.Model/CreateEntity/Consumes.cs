using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// 消费表 
    /// </summary>
    public class Consumes
    {
        /// <summary>
        ///  消费ID
        /// </summary>
        public string ConsumesID { get; set; }
        /// <summary>
        ///  会员ID
        /// </summary>
        public string MemberID { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public string ProjectTypID { get; set; }
        /// <summary>
        ///  产品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        ///  消费价格
        /// </summary>
        public decimal SumPrice { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime ConsumesTime { get; set; }   

        public Members Members { get; set; }
         
        //public virtual List<Members> Enrollments { get; set; }
        //public virtual List<ProjectTypes> ProjectTypes { get; set; }
        //public virtual List<Products> Products { get; set; }     

    }
}
