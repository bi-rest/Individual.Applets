using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.IO;
using Individual.WeChat.Applets.Api.SystemFilter;
using Newtonsoft.Json.Serialization;
using MediatR;
using WeChat.Developers.WxOpen;

namespace Individual.WeChat.Applets.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // 运行时将调用此方法。 使用此方法将服务添加到容器。
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Swashbuckle.AspNetCore api中文文档生成工具
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("1.01", new OpenApiInfo { Title = "WeChat Applets Api", Version = "1.01" });
                option.CustomSchemaIds(type => type.FullName); // 解决相同类名会报错的问题
                option.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), "Individual.WeChat.Applets.Api.xml")); // 标注要使用的 XML 文档
            });
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ResponseResultConfig));
                options.Filters.Add(typeof(ExceptionFilterConfig));
                options.RespectBrowserAcceptHeader = true;
            });
            services.AddMvc()
            //使用NewtonsoftJson序列化数据
            .AddNewtonsoftJson(options =>
            {
                //取消骆驼命名法
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置返回datetime时间格式
                //options.SerializerSettings.DateFormatString=

            }
            );
            //添加AddMediatR注入
            //services.AddMediatR(typeof(CreateUserCommand).GetType());
            //添加微信小程序AppId和密钥
            services.Configure<BaseReceiveParame>(Configuration.GetSection("WxConfig"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 运行时将调用此方法。 使用此方法来配置HTTP请求管道。
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.01/swagger.json", "wechat applets Api");
            });
        }
    }
}
