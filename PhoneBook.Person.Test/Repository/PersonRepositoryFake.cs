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
    public class PersonRepositoryFake : IPersonRepository
    {
        public List<dbPerson> DataList = new List<dbPerson>();
        public PersonRepositoryFake()
        {
            DataList.Add(new dbPerson()
            {
                UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Company = "Test Company 3",
                Name = "Test3",
                Surname = "3"
            });
        }
        public bool SaveChanges()
        {
            return true;
        }

        public void Add(dbPerson person)
        {
            DataList.Add(person);
        }

        public dbPerson Get(Guid id)
        {
            return DataList.FirstOrDefault(x => x.UUID == id);
        }

        public void Delete(Guid id)
        {
            DataList.Remove(DataList.FirstOrDefault(x => x.UUID == id));
        }

        public IEnumerable<dbPerson> GetAll()
        {
            return DataList;
        }

    }
}
