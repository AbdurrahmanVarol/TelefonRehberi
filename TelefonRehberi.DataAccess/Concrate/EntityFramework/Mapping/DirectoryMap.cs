using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.DataAccess.Concrate.EntityFramework.Mapping
{
    public class DirectoryMap : IEntityTypeConfiguration<Entities.Concrate.Directory>
    {
        public void Configure(EntityTypeBuilder<Entities.Concrate.Directory> builder)
        {
            builder.HasKey(p => p.DirectoryId);

            builder.Property(p => p.DirectoryId).IsRequired();

            builder.Property(p => p.DirectoryId).HasColumnName("RehberId");

            builder.Property(p => p.DirectoryId).HasDefaultValueSql("NEWID()");

            builder.ToTable("Rehberler");
        }
    }
}
