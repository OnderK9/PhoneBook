using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Test
{
    public class RepositoryFake<T> where T : class
    {
        public IList<T> DataList = new List<T>();

        public bool SaveChanges()
        {
            return true;
        }

        public virtual void Insert(T entity)
        {
            DataList.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            DataList.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DataList;
        }

        public T GetFirst(Func<T, bool> predicate)
        {
            return DataList.FirstOrDefault<T>(predicate);
        }

        public virtual IEnumerable<T> GetMany(Func<T, bool> where)
        {
            return DataList.Where(where).ToList();
        }


    }
}
