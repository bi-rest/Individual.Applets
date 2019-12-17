using System;
using System.Collections.Generic;
using System.Text;

namespace WeChat.Developers.WxOpen
{
    /// <summary>
    /// 请求wx方法基类
    /// </summary>
    public class BaseReceiveParame
    {
        /// <summary>
        /// * 小程序Appid
        /// </summary>
        public string Appid { get; set; }

        /// <summary>
        /// * 小程序Secret
        /// </summary>
        public string Secret { get; set; }
    }
}
