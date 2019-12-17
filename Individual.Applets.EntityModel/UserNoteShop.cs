using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 用户关注的商品
    /// </summary>
    public class UserNoteShop : BoKeyId
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserKeyId { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid ShopKeyId { get; set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        public DateTime NoteTime { get; set; }
    }
}
