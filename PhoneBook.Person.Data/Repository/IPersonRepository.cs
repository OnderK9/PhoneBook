using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Repository
{
    public interface IPersonRepository : IRepository
    {

        void Add(dbPerson person);
        void Delete(Guid id);
        dbPerson Get(Guid id);
        IEnumerable<dbPerson> GetAll();

    }
}
