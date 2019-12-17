using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    public class Shop : BaseEntity
    {
        /// <summary>
        /// 商品信息表
        /// </summary>
        [MaxLength(100), Required]
        public string ShopName { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal ShopPrice { get; set; }
        /// <summary>
        /// 标签类型
        /// </summary>
        public string TypeLableJson { get; set; }
        /// <summary>
        /// 内容类型
        /// video/books/zip/img
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 商品大小
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 商品详情内容
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// 商品等级
        /// </summary>
        public int Grade { get; set; }
        /// <summary>
        /// 热度
        /// </summary>
        public int HeatCount { get; set; }

    }
}
