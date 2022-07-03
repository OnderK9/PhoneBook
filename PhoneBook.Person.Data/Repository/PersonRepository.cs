using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Repository
{
    public class PersonRepository : Repository<dbPerson>, IPersonRepository
    {

        public PersonRepository(PhoneBookContext context) : base(context)
        {

        }

        public void Add(dbPerson person)
        {
            Insert(person);
        }

        public dbPerson Get(Guid id)
        {
            return base.GetFirst(x => x.UUID == id);
        }

        public void Delete(Guid id)
        {
            base.Delete(id);
        }

        IEnumerable<dbPerson> IPersonRepository.GetAll()
        {
            return base.GetAll();
        }
    }
}
