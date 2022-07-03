using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Person.Data
{
    public class dbPerson
    {
        [Key]
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        [ForeignKey("dbPersonUUID")]
        public ICollection<dbContact> dbContacts { get; set; }
    }
}
