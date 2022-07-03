using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Configuration
{
    public class dbContactConfiguration : IEntityTypeConfiguration<dbContact>
    {
        public void Configure(EntityTypeBuilder<dbContact> builder)
        {
            builder.Property(p => p.dbContactType).IsRequired(true);
        }
    }
}
