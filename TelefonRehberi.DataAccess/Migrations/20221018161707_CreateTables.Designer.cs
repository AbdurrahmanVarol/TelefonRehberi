﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelefonRehberi.DataAccess.Concrete.EntityFramework;

#nullable disable

namespace TelefonRehberi.DataAccess.Migrations
{
    [DbContext(typeof(TelefonRehberiContext))]
    [Migration("20221018161707_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TelefonRehberi.Entities.Concrate.Directory", b =>
                {
                    b.Property<Guid>("DirectoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RehberId")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("DirectoryId");

                    b.ToTable("Rehberler", (string)null);
                });

            modelBuilder.Entity("TelefonRehberi.Entities.Concrate.Person", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("KisiId")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Firma");

                    b.Property<Guid>("DirectoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Ad");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Soyad");

                    b.HasKey("PersonId");

                    b.HasIndex("DirectoryId");

                    b.ToTable("Kisiler", (string)null);
                });

            modelBuilder.Entity("TelefonRehberi.Entities.Concrate.Person", b =>
                {
                    b.HasOne("TelefonRehberi.Entities.Concrate.Directory", "Directory")
                        .WithMany("People")
                        .HasForeignKey("DirectoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Directory");
                });

            modelBuilder.Entity("TelefonRehberi.Entities.Concrate.Directory", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
