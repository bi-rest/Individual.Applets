using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Individual.WeChat.Applets.Api
{
    /// <summary>
    /// 身份验证过滤器
    /// </summary>
    public class AuthenticationFliterConfig : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// 验证身份
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var headers = context.HttpContext.Response.Headers;
            //TODO  进行权限验证


        }
    }
}
