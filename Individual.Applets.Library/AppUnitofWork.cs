using Individual.Applets.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Individual.Applets.Library
{
    public class AppUnitofWork : DbContext
    {

        //构造注入
        public AppUnitofWork(DbContextOptions<AppUnitofWork> option) : base(option)
        {
            this._databaseConn = base.Database.GetDbConnection().ConnectionString;
        }
        /// <summary>
        /// 数据库链接地址
        /// </summary>
        public string _databaseConn { get; private set; }

        public DbSet<Corpor> Corpors { get; set; }
        public DbSet<Corporacredit> Corporacredits { get; set; }
        public DbSet<CorporComment> CorporComments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Parceltransfer> Parceltransfers { get; set; }
        public DbSet<ParceltransferFind> ParceltransferFinds { get; set; }
        public DbSet<ParceltransferSell> ParceltransferSells { get; set; }
        public DbSet<Postjob> Postjobs { get; set; }
        public DbSet<PostjobUrgent> PostjobUrgents { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<ResumeExperience> ResumeExperiences { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopComment> ShopComments { get; set; }
        public DbSet<SysCarousel> SysCarousels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserNoteCorpor> UserNoteCorpor { get; set; }
        public DbSet<UserNotePosts> UserNotePostss { get; set; }
        public DbSet<UserNoteShop> UserNoteShops { get; set; }
        public DbSet<UserPosts> UserPostss { get; set; }

        /// <summary>
        /// 实体映射方法
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
