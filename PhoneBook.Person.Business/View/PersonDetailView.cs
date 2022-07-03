using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Business
{
    public class PersonDetailView: PersonView
    {
        public ICollection<ContactView>  Contacts { get; set; }
    }
}
