using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Repository
{
    public class ContactTypeRepository : Repository<dbContactType>, IContactTypeRepository
    {

        public ContactTypeRepository(PhoneBookContext context) : base(context)
        {

        }

        public dbContactType GetContactType(string name)
        {
            return base.GetFirst(x => x.Name == name);
        }

        public IEnumerable<dbContactType> GetAll()
        {
            return base.GetAll();
        }
    }
}
