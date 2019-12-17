using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.Api.ReceiveParameModel
{
    /// <summary>
    /// api接收api分页实体模型
    /// </summary>
    public abstract class BasePageReceive : BaseReceive
    {
        /// <summary>
        /// 起始页
        /// </summary>
        public int? index { get; set; } = 0;
        /// <summary>
        /// 查询条目
        /// </summary>
        public int? length { get; set; } = 50;
        /// <summary>
        /// 参数
        /// </summary>
        public string search { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string orderBy { get; set; }
        /// <summary>
        /// 倒序还是正序
        /// 默认倒叙排序
        /// </summary>
        public bool? desc { get; set; } = true;

    }
}
