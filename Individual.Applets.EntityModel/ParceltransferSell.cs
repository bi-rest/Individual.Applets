using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 地块转让信息-卖项目
    /// </summary>
    public class ParceltransferSell : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(50), Required]
        public string IntentTitle { get; set; }
        /// <summary>
        /// 信息类别类型
        /// </summary>
        public string LandType { get; set; }

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
        /// 详细地址
        /// </summary>
        [MaxLength(100), Required]
        public string Address { get; set; }
        /// <summary>
        /// 土地用途
        /// </summary>
        public string LandUse { get; set; }
        /// <summary>
        /// 使用年限
        /// </summary>
        public string UsefulLife { get; set; }
        /// <summary>
        /// 占地面积
        /// </summary>
        public string LandAcreage { get; set; }
        /// <summary>
        /// 规划占地面积
        /// </summary>
        public string PlannLandAcreage { get; set; }
        /// <summary>
        /// 建筑占地面积
        /// </summary>
        public string BuildLandAcreage { get; set; }
        /// <summary>
        /// 投资方式
        /// </summary>
        [MaxLength(50), Required]
        public string InvestMethod { get; set; }
        /// <summary>
        /// 项目转让类型
        /// </summary>
        [MaxLength(50), Required]
        public string TransferType { get; set; }
        /// <summary>
        /// 投资金额
        /// </summary>
        [MaxLength(20), Required]
        public string InvestAmount { get; set; }
        /// <summary>
        /// 项目描述
        /// </summary>
        public string ProjectDescrip { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImageJsonArr { get; set; }
        /// <summary>
        /// 企业名字
        /// </summary>
        [MaxLength(50), Required]
        public string BusinessName { get; set; }
        /// <summary>
        /// 联系人名字
        /// </summary>
        [MaxLength(10), Required]
        public string ContactName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        [MaxLength(15), Required]
        public string ContactMobilePhone { get; set; }
    }
}
