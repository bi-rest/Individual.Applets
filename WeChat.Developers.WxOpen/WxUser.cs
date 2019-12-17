using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using WeChat.Developers.WxOpen.WxUserModel;

namespace WeChat.Developers.WxOpen
{
    /// <summary>
    /// 请求微信官方Api获取用户信息接口
    /// </summary>
    public class WxUser
    {
        /// <summary>
        /// 根据wxCode获取小程序OpenId
        /// </summary>
        /// <param name="parame"></param>
        /// <returns></returns>
        public static UserOpenIdResponse FindGetUserOpenId(UserOpenIdReceive parame)
        {
            string serviceAddress = $"{BaseConstUrl.headerAddress}/jscode2session?appid={parame.WxConfig.Appid}&secret={parame.WxConfig.Secret}&js_code={parame.WxCode}&grant_type=authorization_code";
            string result = BaseRequestApi.Get(serviceAddress);
            //{"session_key":"ZJI+oAEYHY2XIUhMvqpzgg==","openid":"orPa15OKpIc0s3dexa9R9IyKfz74"}
            var val = JsonConvert.DeserializeObject<UserOpenIdResponse>(result);
            return val;
        }

    }

}
