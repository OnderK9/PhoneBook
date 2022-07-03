using Microsoft.EntityFrameworkCore;
using PhoneBook.Person.Business;
using PhoneBook.Person.Data;
using PhoneBook.Person.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Test
{
    public class ContactRepositoryFake : IContactRepository
    {
        public List<dbContact> DataList = new List<dbContact>();
        public bool SaveChanges()
        {
            return true;
        }

        public void Add(dbContact contact)
        {
            DataList.Add(contact);
        }

        public void Delete(Guid id)
        {
            DataList.Remove(DataList.FirstOrDefault(x => x.UUID == id));
        }
        public List<dbContact> GetAll()
        {
            return DataList;
        }
        public IEnumerable<dbContact> GetPersonContacts(Guid personId)
        {
            return DataList.Where(x => x.dbPersonUUID == personId);
        }

    }
}
