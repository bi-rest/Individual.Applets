using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 公司点评列表
    /// </summary>
    public class CorporComment : BaseEntity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserKeyId { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>

        public Guid CorporKeyId { get; set; }

        /// <summary>
        /// 企业规模
        /// </summary>
        public int CorporSize { get; set; }
        /// <summary>
        /// 薪资福利
        /// </summary>
        public int SalaryBenefits { get; set; }
        /// <summary>
        /// 领导才能
        /// </summary>
        public int Leadership { get; set; }
        /// <summary>
        /// 工作环境
        /// </summary>
        public int WorkingEnviron { get; set; }
        /// <summary>
        /// 公司管理
        /// </summary>
        public int CorporManagement { get; set; }
        /// <summary>
        /// 土地储备
        /// </summary>
        public int LandBank { get; set; }
        /// <summary>
        /// 销售业绩
        /// </summary>
        public int SalesPerfor { get; set; }
        /// <summary>
        /// 融资能力
        /// </summary>
        public int FinancingCapacity { get; set; }
        /// <summary>
        /// 数据体系
        /// </summary>
        public int DataSystem { get; set; }
        /// <summary>
        /// 产品创新
        /// </summary>
        public int ProductInnovation { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public int Label { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public int Comment { get; set; }

    }
}
