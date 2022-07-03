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
    public class ContactTypeRepositoryFake : IContactTypeRepository
    {
        public List<dbContactType> DataList = new List<dbContactType>();
        public ContactTypeRepositoryFake()
        {
            DataList = new List<dbContactType>()
            {
                new dbContactType() {
                    UUID =new Guid( "ab2bd817-98cd-4cf3-a80a-53ea0cd9c240"),
                    Name="Location"
                },
                new dbContactType() {
                    UUID =new Guid( "ab2bd817-98cd-4cf3-a80a-53ea0cd9c240"),
                    Name="Telefon"
                }
            };
        }
        public bool SaveChanges()
        {
            return true;
        }

        public dbContactType GetContactType(string name)
        {
            return DataList.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<dbContactType> GetAll()
        {
            return DataList;
        } 

    }
}
