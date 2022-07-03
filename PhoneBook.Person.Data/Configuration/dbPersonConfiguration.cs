using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Configuration
{
    public class dbPersonConfiguration : IEntityTypeConfiguration<dbPerson>
    {
        public void Configure(EntityTypeBuilder<dbPerson> builder)
        {
        }
    }
}
