using System;
using System.Collections.Generic;
using System.Text;

namespace QP.Cashier_Service.Paging
{    
    /// <summary>
    ///  分页参数
    /// </summary>
    public class StaffInfoparam : DataGridJson
    {
        /// <summary>
        /// 时间查询字段
        /// </summary>
        public string _queryName { set; get; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public  DateTime _startDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime _endDate { get; set; }
        /// <summary>
        /// 到处Execl 文件名
        /// </summary>
        public string _fileName { get; set; }

        /// <summary>
        /// 用户输入查询事件
        /// </summary>
        public string _selectVal { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string _inputVals { get; set; }

        /// <summary>
        ///  门店ID
        /// </summary>
        public string _shopID { get; set; }
    }
}

