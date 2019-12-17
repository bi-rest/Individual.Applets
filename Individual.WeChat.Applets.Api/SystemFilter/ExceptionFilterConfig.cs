using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Individual.WeChat.Applets.Api.SystemFilter
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class ExceptionFilterConfig : IExceptionFilter
    {

        /// <summary>
        /// 发生异常时进入
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                context.Result = new ObjectResult(new { code = 404, msg = context.Exception.Message });
            }
            context.ExceptionHandled = true;
        }

        /// <summary>
                /// 异步发生异常时进入
                /// </summary>
                /// <param name="context"></param>
                /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}
