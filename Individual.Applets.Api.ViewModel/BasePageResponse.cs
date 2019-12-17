using System;

namespace Individual.Applets.ViewModel
{
    /// <summary>
    /// 返回分页数据实体基类
    /// </summary>
    public abstract class BasePageResponse : BaseResponse
    {
        /// <summary>
        /// 总行数
        /// </summary>
        public int Count { get; set; }


    }
}
