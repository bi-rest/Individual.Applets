using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 企业征信公司详情
    /// </summary>
    public class Corpor : BaseEntity
    {
        /// <summary>
        /// 公司类别Id
        /// </summary>
        public Guid TypeKeyId { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [MaxLength(100), Required]
        public string CorporName { get; set; }
        /// <summary>
        /// 公司图标
        /// </summary>
        public string CorporIcon { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string PersonName { get; set; }
        /// <summary>
        /// 公司首页地址
        /// </summary>
        public string HomeUrl { get; set; }
        /// <summary>
        /// 公司传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 公司首页地址
        /// </summary>
        public string CorporHomeUrl { get; set; }
        /// <summary>
        /// 公司简介
        /// </summary>
        public string CorporInfo { get; set; }
        /// <summary>
        /// 最新地块信息
        /// </summary>
        public string NewPlotInfo { get; set; }
        /// <summary>
        /// 最新事件
        /// </summary>
        public string NewEvens { get; set; }
        /// <summary>
        /// 点评总数
        /// </summary>
        public int? ReviewsCount { get; set; }
    }
}
