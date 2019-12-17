using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 系统轮播图
    /// </summary>
    public class SysCarousel : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string CarouselName { get; set; }
        /// <summary>
        /// 轮播图url地址
        /// </summary>
        public string CarouselUrl { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

    }
}
