using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 地块转让信息-找项目
    /// </summary>
    public class ParceltransferFind : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(50), Required]
        public string IntentTitle { get; set; }
        /// <summary>
        /// 一项投资地区
        /// </summary>
        [MaxLength(50), Required]
        public string RegionInterestJson { get; set; }
        /// <summary>
        /// 投资类型
        /// </summary>
        [MaxLength(200), Required]
        public string InvestTypeJson { get; set; }
        /// <summary>
        /// 用地面积
        /// </summary>
        [MaxLength(20), Required]
        public string LandArea { get; set; }
        /// <summary>
        /// 投资金额
        /// </summary>
        [MaxLength(20), Required]
        public string InvestAmount { get; set; }
        /// <summary>
        /// 投资方式
        /// </summary>
        [MaxLength(50), Required]
        public string InvestMethodJson { get; set; }
        /// <summary>
        /// 企业名字
        /// </summary>
        [MaxLength(50), Required]
        public string BusinessName { get; set; }
        /// <summary>
        /// 联系人名字
        /// </summary>
        [MaxLength(10), Required]
        public string ContactName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        [MaxLength(15), Required]
        public string ContactMobilePhone { get; set; }
    }
}
