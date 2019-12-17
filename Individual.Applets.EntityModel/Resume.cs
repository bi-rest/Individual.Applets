using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 简历表
    /// </summary>
    public class Resume : BaseEntity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserKeyId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(10), Required]
        public string Name { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        [MaxLength(100), Required]
        public string WxAccount { get; set; }
        /// <summary>
        /// 毕业院校
        /// </summary>
        [MaxLength(100), Required]
        public string EaveSchool { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        [MaxLength(100), Required]
        public string Profession { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        [MaxLength(1000), Required]
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 期望省份
        /// </summary>
        [MaxLength(10), Required]
        public string Province { get; set; }
        /// <summary>
        /// 期望城市
        /// </summary>
        [MaxLength(20), Required]
        public string City { get; set; }
        /// <summary>
        /// 期望区
        /// </summary>
        [MaxLength(30), Required]
        public string Area { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        [MaxLength(100), Required]
        public string Education { get; set; }
        /// <summary>
        /// 工作经验
        /// </summary>
        [MaxLength(50), Required]
        public string WorkExperience { get; set; }
        /// <summary>
        /// 薪资开始
        /// </summary>
        [MaxLength(10), Required]
        public string StateSalary { get; set; }
        /// <summary>
        /// 薪资开始
        /// </summary>
        [MaxLength(10), Required]
        public string EndSalary { get; set; }
        /// <summary>
        /// 我的才艺
        /// </summary>
        public string MyTalent { get; set; }
    }
}
