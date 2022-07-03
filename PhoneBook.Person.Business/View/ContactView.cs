using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Business
{
    public class ContactView
    {
        public Guid UUID { get; set; }
        public string Content { get; set; }
        public Guid PersonUUID { get; set; }
        public Guid ContactTypeUUID { get; set; }
    }
}
