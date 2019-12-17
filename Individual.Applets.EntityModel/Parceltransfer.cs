using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 地块转让信息
    /// </summary>
    public class Parceltransfer : BaseEntity
    {
        /// <summary>
        /// 地块名字
        /// </summary>
        [MaxLength(50), Required]
        public string PlotName { get; set; }
        /// <summary>
        /// 地块类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 所在地址
        /// </summary>
        [MaxLength(50), Required]
        public string Address { get; set; }
        /// <summary>
        /// 形式
        /// </summary>
        [MaxLength(20), Required]
        public string Shape { get; set; }
        /// <summary>
        /// 联系人名字
        /// </summary>
        [MaxLength(10), Required]
        public string ContactName { get; set; }
        /// <summary>
        /// 面积大小
        /// </summary>
        [MaxLength(20), Required]
        public string Square { get; set; }
        /// <summary>
        /// 报价价格
        /// </summary>
        [MaxLength(20), Required]
        public string Price { get; set; }
        /// <summary>
        /// 主页图片
        /// </summary>
        [MaxLength(500), Required]
        public string HomeImage { get; set; }
    }
}
