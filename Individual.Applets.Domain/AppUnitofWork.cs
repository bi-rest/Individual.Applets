using Individual.Applets.Domain.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Individual.Applets.Domain
{
    /// <summary>
    /// EF DbContext
    /// </summary>
    public class AppUnitofWork : DbContext, IAppUnitOfWork
    {
        private IMediator _mediatorR;
        /// <summary>
        /// 用户表
        /// </summary>
       // public DbSet<Users> Users { get; set; }

        public AppUnitofWork(DbContextOptions<AppUnitofWork> options, IMediator mediator) : base(options)
        {
            this._mediatorR = mediator;
            this.GetConn = base.Database.GetDbConnection().ConnectionString;
        }

        public string GetConn { get; private set; }

        /// <summary>
        /// 创建实体映射模型
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            try
            {
                //modelBuilder.ApplyConfiguration(new UserInfoConfiguring());//单个文件映射
                //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
                string path = AppDomain.CurrentDomain.BaseDirectory;
                var files = Directory.GetFiles(path, "Rextec.SOA.Configuring.dll");
                if (files.Length > 0)
                {
                    var typesToRegister = Assembly.LoadFile(files[0]).GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
                    foreach (var type in typesToRegister)
                    {
                        if (!type.FullName.Contains("BaseConfiguring"))
                        {
                            dynamic configurationInstance = Activator.CreateInstance(type);
                            modelBuilder.ApplyConfiguration(configurationInstance);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            //必须放到SaveChangesAsync前面
            //如果领域出现异常将不会持久化到数据库
            //领域事件如果发送失败 将不会持久化到数据库
            await _mediatorR.DispatchDomainEventsAsync(this);
            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
