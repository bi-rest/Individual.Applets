using System;
using System.Collections.Generic;
using System.Text;

namespace WeChat.Developers.WxOpen.WxUserModel
{
    /// <summary>
    /// 
    /// </summary>
    public class UserOpenIdResponse
    {
        /// <summary>
        /// key
        /// </summary>
        public string session_key { get; set; }
        /// <summary>
        /// 用户OpenId
        /// </summary>
        public string openid { get; set; }

    }
}
