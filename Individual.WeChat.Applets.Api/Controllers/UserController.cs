using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeChat.Developers.WxOpen;
using WeChat.Developers.WxOpen.WxUserModel;

namespace Individual.WeChat.Applets.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private IMediator _mediator;
        private readonly BaseReceiveParame _wxConfig;

        /// <summary>
        /// 构造函数 依赖注入
        /// </summary>
        /// <param name="mediator"></param>
        public UserController(IMediator mediator, IOptionsMonitor<BaseReceiveParame> wxConfig)
        {
            this._mediator = mediator;
            this._wxConfig = wxConfig.CurrentValue;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        [Route("get-userinfo")]
        [HttpGet]
        public async Task<bool> FindGetUserInfo()
        {
            return await Task.Run(() => { return true; });
        }
    }
}