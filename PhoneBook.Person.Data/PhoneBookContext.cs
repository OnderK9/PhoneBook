using Microsoft.EntityFrameworkCore;
using PhoneBook.Person.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new dbContactTypeConfiguration());
        }
        public DbSet<dbPerson> dbPerson { get; set; }
        public DbSet<dbContact> dbContact { get; set; }
        public DbSet<dbContactType> dbContactType { get; set; }

    }
}
