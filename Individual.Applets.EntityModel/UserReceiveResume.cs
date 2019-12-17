using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 用户收到的简历-暂不使用
    /// </summary>
    public class UserReceiveResume : BaseEntity
    {

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserKeyId { get; set; }
        /// <summary>
        /// 简历的Id
        /// </summary>
        public Guid ResumeKeyId { get; set; }

    }
}
