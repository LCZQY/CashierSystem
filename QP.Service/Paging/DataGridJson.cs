using System;
using System.Collections.Generic;
using System.Text;

namespace QP.Cashier_Service.Paging
{

    /// <summary>    
    /// 所有分页实体，都要有这些基础属性
    /// </summary>
    public class DataGridJson
    {
        public int _rows { get; set; }
        public int _page { get; set; }
        public int _total { get; set; }
    }
}
