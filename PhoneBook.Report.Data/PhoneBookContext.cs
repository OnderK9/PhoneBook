using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Data
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

            modelBuilder.ApplyConfiguration(new dbReportConfiguration());
        }
        public DbSet<dbReport> dbReport { get; set; }

    }
}
