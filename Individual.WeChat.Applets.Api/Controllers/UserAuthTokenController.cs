using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Individual.Applets.ViewModel;
using Individual.Applets.ViewModel.UserAuthToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeChat.Developers.WxOpen;
using WeChat.Developers.WxOpen.WxUserModel;

namespace Individual.WeChat.Applets.Api.Controllers
{
    /// <summary>
    /// 令牌Token认证
    /// </summary>
    [Route("api/user-token")]
    [ApiController]
    public class UserAuthTokenController : ControllerBase
    {
        private readonly BaseReceiveParame _wxConfig;

        public UserAuthTokenController(IOptionsMonitor<BaseReceiveParame> wxConfig)
        {
            this._wxConfig = wxConfig.CurrentValue;
        }
        /// <summary>
        /// 登录并注册用户，返回Token
        /// </summary>
        /// <param name="wxOpenId">微信Id</param>
        /// <returns>请求Token</returns>
        [Route("get-token")]
        [HttpGet, Description("获取Api认证密钥")]
        public UserAuthTokenResponse FindGetAuthUserToken(LoginGetAuthUserTokenReceive parame)
        {
            var wxOpen = WxUser.FindGetUserOpenId(new UserOpenIdReceive
            {
                WxCode = "0330e6MM15Asz61xuFNM1lk4MM10e6MQ",
                WxConfig = _wxConfig
            });
            return new UserAuthTokenResponse { _TokenKey = Guid.NewGuid().ToString(), ExpiredTime = DateTime.Now.AddDays(1) };
        }



    }
}