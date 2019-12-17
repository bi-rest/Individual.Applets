using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 用户收藏的职位
    /// </summary>
    public class UserNotePosts : BoKeyId
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserKeyId { get; set; }
        /// <summary>
        /// 职位Id
        /// </summary>
        public Guid PostjobKeyId { get; set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        public DateTime NoteTime { get; set; }
    }
}
