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
        // ����ʱ�����ô˷����� ʹ�ô˷�����������ӵ�������
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Swashbuckle.AspNetCore api�����ĵ����ɹ���
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("1.01", new OpenApiInfo { Title = "WeChat Applets Api", Version = "1.01" });
                option.CustomSchemaIds(type => type.FullName); // �����ͬ�����ᱨ�������
                option.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), "Individual.WeChat.Applets.Api.xml")); // ��עҪʹ�õ� XML �ĵ�
            });
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ResponseResultConfig));
                options.Filters.Add(typeof(ExceptionFilterConfig));
                options.RespectBrowserAcceptHeader = true;
            });
            services.AddMvc()
            //ʹ��NewtonsoftJson���л�����
            .AddNewtonsoftJson(options =>
            {
                //ȡ������������
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //���÷���datetimeʱ���ʽ
                //options.SerializerSettings.DateFormatString=

            }
            );
            //���AddMediatRע��
            //services.AddMediatR(typeof(CreateUserCommand).GetType());
            //���΢��С����AppId����Կ
            services.Configure<BaseReceiveParame>(Configuration.GetSection("WxConfig"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ����ʱ�����ô˷����� ʹ�ô˷���������HTTP����ܵ���
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
            //�����м����������Swagger��ΪJSON�ս��
            app.UseSwagger();
            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.01/swagger.json", "wechat applets Api");
            });
        }
    }
}
