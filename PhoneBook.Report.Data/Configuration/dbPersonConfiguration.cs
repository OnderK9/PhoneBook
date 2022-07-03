using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Data.Configuration
{
    public class dbReportConfiguration : IEntityTypeConfiguration<dbReport>
    {
        public void Configure(EntityTypeBuilder<dbReport> builder)
        {
        }
    }
}
