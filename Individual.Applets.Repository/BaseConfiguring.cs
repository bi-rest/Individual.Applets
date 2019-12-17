using Individual.Applets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.Repository
{
    /// <summary>
    /// 通用字段映射
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseConfiguring<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.KeyId);
            builder.Property(x => x.CreateUserKeyId).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreateUserName).HasMaxLength(50);
            builder.Property(x => x.CreateTime).HasColumnType("datetime");
            builder.Property(x => x.ModifyUserKeyId).HasMaxLength(50);
            builder.Property(x => x.ModifyUserName).HasMaxLength(50);
            builder.Property(x => x.ModifyTime).HasColumnType("datetime");
            builder.Property(x => x.CreateTime).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
        }
    }
}
