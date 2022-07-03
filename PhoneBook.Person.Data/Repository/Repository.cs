using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Data.Repository
{
    public class Repository<TEntity> where TEntity : class
    {
        public PhoneBookContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(PhoneBookContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    
        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = GetByID(id);
            if (entityToDelete != null)
                Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public virtual List<TEntity> GetAllList()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return _dbSet.FirstOrDefault<TEntity>(predicate);
        }

    }
}
