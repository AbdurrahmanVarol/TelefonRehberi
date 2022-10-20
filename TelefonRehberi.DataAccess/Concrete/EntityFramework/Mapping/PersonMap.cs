using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.DataAccess.Concrete.EntityFramework.Mapping
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonId);

            builder.Property(p => p.PersonId).IsRequired();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Company).IsRequired().HasMaxLength(100);

            builder.Property(p => p.PersonId).HasColumnName("KisiId");
            builder.Property(p => p.FirstName).HasColumnName("Ad");
            builder.Property(p => p.LastName).HasColumnName("Soyad");
            builder.Property(p => p.Company).HasColumnName("Firma");
            builder.Property(p => p.FirstName).HasColumnName("Ad");

            builder.Property(p => p.PersonId).HasDefaultValueSql("NEWID()");
            
            builder.ToTable("Kisiler");
        }
    }
}
