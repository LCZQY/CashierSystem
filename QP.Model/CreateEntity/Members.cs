using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{    /// <summary>
     /// //会员表
     /// </summary>
    public class Members
    {   //string mysql是text 【SQLserver  是nvarchar】
        //char mysql是 int 【SQLserver 是报错】 

        /// <summary>
        ///  会员ID
        /// </summary>
        public string MemberID { get; set; }
        /// <summary>
        /// 顾客姓名
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string ClientSex { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string ClientAdrees { get; set; }
        /// <summary>
        /// 号码
        /// </summary>
        public string ClientPhone { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime ClientBirth { get; set; }

        /// <summary>
        /// //default 'N',//生日类型 G:公厉 ,N :农历
        /// </summary>
        public string ClientBirthType { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string ClientIdentity { get; set; }

        /// <summary>
        /// 最近到店时间    
        /// </summary>
        public DateTime RecentConsumptionTime { get; set; }

        /// <summary>
        /// 项目欠款
        /// </summary>
        public decimal ProjectArrears { get; set; }

        /// <summary>
        /// 储存欠款
        /// </summary>
        public decimal StoredArrears { get; set; }

        /// <summary>
        /// 会员卡ID    
        /// </summary>
        public string MemberCardID { get; set; }
        /// <summary>
        /// 门店ID 
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 操作ID
        /// </summary>
        public string OperationID { get; set; }



        //public virtual List<Operation> Operations { get; set; }
        //public virtual List<CardMembers> CardMembers { get; set; }
        //public virtual List<Shops> Shops { get; set; }

    }
}
