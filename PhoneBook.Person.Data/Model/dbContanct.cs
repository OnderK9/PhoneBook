using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Person.Data
{
    public class dbContact
    {
        [Key]
        public Guid UUID { get; set; }
        public string Content { get; set; }
        public Guid dbPersonUUID { get; set; }
        public Guid dbContactTypeUUID { get; set; }
        [ForeignKey("dbContactTypeUUID")]
        public dbContactType dbContactType { get; set; }
    }
}
