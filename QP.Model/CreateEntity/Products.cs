using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// 产品表
    /// </summary>
    public class Products
    {
        /// <summary>
        /// 产品表ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 一次使用量
        /// </summary>
        public decimal UsageAmount { get; set; }
        /// <summary>
        /// 产品进价
        /// </summary>
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal ProductPrice { get; set; }
        /// <summary>
        /// 门店价格
        /// </summary>
        public decimal ShopPrice { get; set; }
        /// <summary>
        /// 物品规格(kg)
        /// </summary>
        public decimal PurchaseSpec { get; set; }

        /// <summary>
        /// 销售单位(ml)
        /// </summary>
        public string MarketingUnit { get; set; }
        /// <summary>
        /// 产品条码
        /// </summary>

        public string Productbarcode { get; set; }
        /// <summary>
        /// 库存ID
        /// </summary>
        public string InventorysID { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public string CategorysID { get; set; }
        /// <summary>
        /// 操作ID
        /// </summary>
        public string OperationID { get; set; }

        //public virtual List<Operation> Operations { get; set; }
        //public virtual List<Inventorys> Inventorys { get; set; }
        //public virtual List<Categorys> Categorys { get; set; }


    }
}
