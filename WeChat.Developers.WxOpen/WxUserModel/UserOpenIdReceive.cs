using System;
using System.Collections.Generic;
using System.Text;

namespace WeChat.Developers.WxOpen.WxUserModel
{
    /// <summary>
    /// 根据Code获取用户OpenId
    /// </summary>
    public class UserOpenIdReceive 
    {
        /// <summary>
        /// 微信用户
        /// </summary>
        public string WxCode { get; set; }
        /// <summary>
        /// 微信小程序配置信息
        /// </summary>
        public BaseReceiveParame WxConfig { get; set; }
    }
}
