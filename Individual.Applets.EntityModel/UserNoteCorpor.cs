using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 用户关注的企业征信公司
    /// </summary>
    public class UserNoteCorpor : BoKeyId
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserKeyId { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid CorporKeyId { get; set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        public DateTime NoteTime { get; set; }
    }
}
