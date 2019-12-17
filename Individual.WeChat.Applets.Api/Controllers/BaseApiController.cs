using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Individual.WeChat.Applets.Api.Controllers
{
    /// <summary>
    /// 所有控制器基类，不包括[UserAuthTokenController]控制器
    /// 验证当前用户的权限信息
    /// </summary>
    [ApiController, AuthenticationFliterConfig]
    
    public class BaseApiController : ControllerBase
    {


    }
}