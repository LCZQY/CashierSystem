using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    ///  库存表
    /// </summary>
    public class Inventorys
    {
        /// <summary>
        /// 库存ID        
        /// </summary>
        public string InventoryID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public string InventoryNumber { get; set; }

    }
}
