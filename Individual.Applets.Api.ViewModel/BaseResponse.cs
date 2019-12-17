using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.ViewModel
{
    /// <summary>
    /// 返回数据实体抽象类
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseResponse()
        {

        }
        /// <summary>
        /// 请求状态
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回错误参数
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 请求时长
        /// </summary>
        public long timeout { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public object result { get; set; }


    }
}
