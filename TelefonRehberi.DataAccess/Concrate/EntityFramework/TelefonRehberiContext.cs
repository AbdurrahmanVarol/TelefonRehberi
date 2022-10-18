using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccess.Concrate.EntityFramework.Mapping;
using TelefonRehberi.Entities.Concrate;

namespace TelefonRehberi.DataAccess.Concrate.EntityFramework
{
    public class TelefonRehberiContext : DbContext
    {
        public TelefonRehberiContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Entities.Concrate.Directory> Directories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new DirectoryMap());
        }
    }
}
