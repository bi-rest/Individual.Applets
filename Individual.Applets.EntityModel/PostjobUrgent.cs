using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 紧急岗位
    /// </summary>
    public class PostjobUrgent : BaseEntity
    {
        /// <summary>
        /// 岗位Id
        /// </summary>
        public Guid PostjobKeyId { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }

    }
}
