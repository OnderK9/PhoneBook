using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Repository
{
    public class ContactRepository : Repository<dbContact>, IContactRepository
    {

        public ContactRepository(PhoneBookContext context) : base(context)
        {

        }

        public void Add(dbContact contact)
        {
            base.Insert(contact);
        }

        public void Delete(Guid id)
        {
            base.Delete(id);
        }

        public List<dbContact> GetAll()
        {
            return base.GetAllList();
        }

        public IEnumerable<dbContact> GetPersonContacts(Guid personId)
        {
            return base.GetMany(x => x.dbPersonUUID == personId);
        }


    }
}
