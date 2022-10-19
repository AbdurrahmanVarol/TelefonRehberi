using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.DataAccess.Concrate.EntityFramework.Mapping
{
    public class InfoMap : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder.HasKey(p => p.InfoId);

            builder.Property(p => p.InfoId).IsRequired();
            builder.Property(p => p.InfoType).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(250);
            
            builder.Property(p => p.InfoId).HasColumnName("BilgiId");
            builder.Property(p => p.InfoType).HasColumnName("BilgiTuru");
            builder.Property(p => p.Description).HasColumnName("Aciklama");

            builder.Property(p => p.InfoId).HasDefaultValueSql("NEWID()");

            builder.ToTable("Bilgiler");
        }
    }
}
