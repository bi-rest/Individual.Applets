using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 职位表
    /// </summary>
    public class Postjob : BaseEntity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserKeyId { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        [MaxLength(100), Required]
        public string JobName { get; set; }
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
        /// 岗位省份
        /// </summary>
        [MaxLength(10), Required]
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [MaxLength(20), Required]
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        [MaxLength(30), Required]
        public string Area { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        [MaxLength(100), Required]
        public string Address { get; set; }
        /// <summary>
        /// 联系手机号码
        /// </summary>
        [MaxLength(20), Required]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 工作内容
        /// </summary>
        public string WorkContent { get; set; }


    }
}
