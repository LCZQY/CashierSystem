using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// 证书资质管理表
    /// </summary>
    public class Certificates
    {
        /// <summary>
        /// 证书资质表ID
        /// </summary>
       public string CertificateID { get; set; }
        /// <summary>
        /// 证书资质名字
        /// </summary>
        public string CertificateName { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime ExpireTime { get; set; }
        ///// <summary>
        ///// 图片ID
        ///// </summary>
        //public string ImageID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 图片表
        /// </summary>
        public Images Images { get; set; }
        /// <summary>
        /// 操作ID
        /// </summary>
        public string OperationID { get; set; }

       // public virtual ICollection<Operation> Operation { get; set; }

    }
}
