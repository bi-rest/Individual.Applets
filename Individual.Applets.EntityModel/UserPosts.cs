using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 用户投递的职位
    /// </summary>
    public class UserPosts : BaseEntity
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
        /// 职位创建者Id
        /// </summary>
        public Guid CreateJobUserId { get; set; }
        /// <summary>
        /// 投递信息状态
        /// </summary>
        public int Statuz { get; set; }
        /// <summary>
        /// HR反馈信息
        /// </summary>
        public string Feedback { get; set; }

    }
}
