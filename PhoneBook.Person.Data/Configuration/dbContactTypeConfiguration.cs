using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Configuration
{
    public class dbContactTypeConfiguration : IEntityTypeConfiguration<dbContactType>
    {
        public void Configure(EntityTypeBuilder<dbContactType> builder)
        {
            builder.HasData(

                new dbContactType()
                {
                    UUID = Guid.NewGuid(),
                    Name = "Telefon"
                },
                new dbContactType()
                {
                    UUID = Guid.NewGuid(),
                    Name = "Email"
                },
                new dbContactType()
                {
                    UUID = Guid.NewGuid(),
                    Name = "Location"
                }

            );
        }
    }
}
