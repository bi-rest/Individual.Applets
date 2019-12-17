using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.Domain.Interface
{
    /// <summary>
    /// 键值值对象
    /// </summary>
    public class ItemData
    {
        /// <summary>
        /// 值
        /// </summary>
        public Guid ItemValue { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ItemText { get; set; }
    }
}
