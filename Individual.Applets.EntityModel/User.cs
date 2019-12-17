using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [MaxLength(100), Required]
        public string UserName { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        [MaxLength(1000), Required]
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [MaxLength(5), Required]
        public string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public string BodyWeight { get; set; }
        /// <summary>
        /// 户籍
        /// </summary>
        public string Household { get; set; }

        /// <summary>
        /// 注册城市
        /// </summary>
        public string RegisCity { get; set; }
        /// <summary>
        /// 注册省份
        /// </summary>
        public string RegispPovince { get; set; }
        /// <summary>
        /// 最近登录时间
        /// </summary>
        public string LastLoginTime { get; set; }
        /// <summary>
        /// 微信OpenId
        /// </summary>
        [MaxLength(100), Required]
        public string WxOpenId { get; set; }
    }
}
