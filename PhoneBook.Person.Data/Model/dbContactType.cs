using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Person.Data
{
    public class dbContactType
    {
        [Key]
        public Guid UUID { get; set; }
        public string Name { get; set; }

    }
}
