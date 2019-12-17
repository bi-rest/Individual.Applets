using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 企业征信
    /// </summary>
    public class Corporacredit : BaseEntity
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        [MaxLength(100), Required]
        public string TypeName { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(100), Required]
        public string Icon { get; set; }
        /// <summary>
        /// 公司总数量
        /// </summary>
        public int Count { get; set; }
    }
}
