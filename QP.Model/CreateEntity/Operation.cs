using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// 操作表
    /// </summary>
    public sealed class Operation
    {
        /// <summary>
        /// //操作ID    
        /// </summary>
        public string OperationID { get; set; }
        /// <summary>
        ///  //创建时间
        /// </summary>
        public DateTime StaffCreateTime { get; set; }
        /// <summary>
        /// //创建用户
        /// </summary>        
        public string StaffCreator { get; set; }

        /// <summary>
        /// //修改时间
        /// </summary>
        public DateTime StaffUpdateTime { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string StaffModifyUser { get; set; }

        /// <summary>
        /// 会员卡表
        /// </summary>
        //public CardMembers CardMembers { get; set; }
        //public Staffs  Staffs { get; set; }
        //public Members Members  { get; set; }
    }
}
