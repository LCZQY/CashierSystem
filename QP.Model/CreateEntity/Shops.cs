using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    ///  门店类
    /// </summary>
    public class Shops
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] //不需要自动增长
        public string ShopID { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Classify { get; set; }
        /// <summary>
        /// 门店名称        
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        ///  门店名称简称
        /// </summary>
        public string ShopAbbreviation { get; set; }

        /// <summary>
        ///  主要负责人
        /// </summary>
        public string ShopPrincipal { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ShopPhone { get; set; }
        /// <summary>
        ///截止投资时间
        /// </summary>
        public DateTime ShopDeadlineInvest { get; set; }

        /// <summary>
        /// 店铺说明
        /// </summary>
        public string ShopInstructions { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string ShopAddress { get; set; }

        /// <summary>
        ///子门店ID
        /// </summary>
        public string stringShopSonID { get; set; }



        //public Staffs Staffs { get; set; }
        //public Members Members { get; set; }

    }
}
