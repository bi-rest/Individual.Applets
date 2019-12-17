using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 商品评论表
    /// </summary>
    public class ShopComment : BaseEntity
    {
        /// <summary>
        /// 评论人Id
        /// </summary>
        public Guid UserKeyId { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public Guid ShopKeyId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }
    }
}
