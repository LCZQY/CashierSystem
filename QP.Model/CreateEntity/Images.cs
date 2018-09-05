using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    ///  图片表
    /// </summary>
    public class Images
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public string ImageID { get; set; }
        /// <summary>
        /// -图片URL    
        /// </summary>
        public string ImagesUrl { get; set; }
        /// <summary>
        /// 描述
        /// </summary>      
        public string Describe { get; set; }

        /// <summary>
        /// 证书表
        /// </summary>
        //public Certificates Certificates { get; set; }

    }
}
