
using Individual.Applets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Individual.WeChat.Applets.Api.SystemFilter
{
    /// <summary>
    /// 返回结果过滤器
    /// </summary>
    public class ResponseResultConfig : ActionFilterAttribute
    {
        /// <summary>
        /// 请求时长计时开始
        /// </summary>
        private readonly Stopwatch watch = new Stopwatch();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            watch.Start();//开始
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// 返回结果之前执行
        /// 重新序列化返回的结果格式 基于BaseResponse 参数进行返回
        /// 为了保证参数不返回不必要的参数，次数使用匿名数组 抽象与BaseResponse
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            watch.Stop();
            //根据实际需求进行具体实现
            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                if (objectResult.Value == null)
                {
                    context.Result = new ObjectResult(new { code = 404, msg = "未找到资源", timeout = watch.ElapsedMilliseconds });
                }
                else
                {
                    context.Result = new ObjectResult(new { code = 200, msg = "请求成功!", result = objectResult.Value, timeout = watch.ElapsedMilliseconds });
                    if (objectResult.Value is BaseResponse)
                    {
                        context.Result = new ObjectResult(objectResult.Value);
                    }
                    //判读是否返回的是元组
                    //返回数据并且返回总行数（List<object>,int）
                    if (objectResult.DeclaredType != null && objectResult.DeclaredType.Name == "ValueTuple`2")
                    {
                        dynamic value = objectResult.Value;
                        if (value.Item1 != null)
                        {
                            if (value.Item1 is int)
                            {
                                //返回元组格式（int,List<object>）
                                context.Result = new ObjectResult(new { code = 200, msg = "请求成功!", timeout = watch.ElapsedMilliseconds, result = new { Count = value.Item1, Data = value.Item2 } });
                            }
                            else
                                //返回元组格式（List<object>,int）
                                context.Result = new ObjectResult(new { code = 200, msg = "请求成功!", timeout = watch.ElapsedMilliseconds, result = new { Count = value.Item2, Data = value.Item1 } });
                        }
                    }

                }
            }
            else if (context.Result is EmptyResult)
            {
                context.Result = new ObjectResult(new { code = 404, msg = "未找到资源" });
            }
            else if (context.Result is ContentResult)
            {
                context.Result = new ObjectResult(new { code = 200, msg = "", timeout = watch.ElapsedMilliseconds, result = (context.Result as ContentResult).Content });
            }
            else if (context.Result is StatusCodeResult)
            {
                context.Result = new ObjectResult(new { code = (context.Result as StatusCodeResult).StatusCode, timeout = watch.ElapsedMilliseconds, msg = "" });
            }
        }

    }
}
