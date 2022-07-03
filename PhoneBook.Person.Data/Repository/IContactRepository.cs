using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Repository
{
    public interface IContactRepository : IRepository
    {

        void Add(dbContact person);
        void Delete(Guid id);
        IEnumerable<dbContact> GetPersonContacts(Guid personId);
        List<dbContact> GetAll();
    }
}
