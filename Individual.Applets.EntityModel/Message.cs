using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 信息表
    /// </summary>
    public class Message : BaseEntity
    {
        /// <summary>
        /// 指定用户收到的信息
        /// </summary>
        public Guid? UserKeyId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contetx { get; set; }
        /// <summary>
        /// 是否已被查看
        /// </summary>
        [DataType("int")]
        public bool IsSee { get; set; }
        /// <summary>
        /// 消息链接地址
        /// </summary>
        public string UrlLink { get; set; }

    }
}
