using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// 会员卡表
    /// </summary>

    public class CardMembers
    {
        /// <summary>
        ///会员卡ID
        /// </summary>        
        public string CardMemberID { get; set; }
        /// <summary>
        /// 会员卡名称
        /// </summary>
        public string CardMemberName { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// 开户时间
        /// </summary>
        public DateTime OpenAccountTime { get; set; }
        /// <summary>
        /// 卡户余额 
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        ///  会员卡积分    
        /// </summary>
        public int CardIntegral { get; set; }
        /// <summary>
        ///  //积分原因 （消费单号：CANB18052211105520029）
        /// </summary>
        public string IntegralReason { get; set; }
        /// <summary>
        ///  //积分时间
        /// </summary>
        public DateTime IntegralTime { get; set; }
        /// <summary>
        ///  //是否夸门店(Y/N)
        /// </summary>
        public string AcrossStore { get; set; }
        /// <summary>
        /// //操作ID
        /// </summary>
        public string OperationID { get; set; }

        /// <summary>
        /// 操作表
        /// </summary>         
        //public virtual List<Operation> Operations { get; set; }
    }
}
