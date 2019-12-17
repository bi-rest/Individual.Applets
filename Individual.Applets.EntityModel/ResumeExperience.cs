using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 工作经历表
    /// </summary>
    public class ResumeExperience : BoKeyId
    {
        /// <summary>
        /// 简历Id
        /// </summary>
        public Guid ResumeKeyId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [MaxLength(50), Required]
        public string CompanyName { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        [MaxLength(50), Required]
        public string Department { get; set; }
        /// <summary>
        /// 薪资
        /// </summary>
        [MaxLength(100), Required]
        public string Salary { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime OnboardTime { get; set; }

        /// <summary>
        /// 离职时间，空为至今
        /// </summary>
        public DateTime? LeaveTime { get; set; }
        /// <summary>
        /// 工作标签
        /// </summary>  
        [MaxLength(100)]
        public string WorklabelJson { get; set; }

        /// <summary>
        /// 完整周期项目
        /// </summary>
        public string CompleteProject { get; set; }
        /// <summary>
        /// 核心工作内容
        /// </summary>
        public string CoreWorkContent { get; set; }
        /// <summary>
        /// 参与的工作项目
        /// </summary>
        public string ProjectInvolved { get; set; }
        /// <summary>
        /// 工作成就
        /// </summary>
        public string WorkAchievement { get; set; }

    }
}
