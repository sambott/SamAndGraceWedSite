using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Web.DAL
{
    public abstract class GenericRepository<TDbContext, T> :
        IGenericRepository<T>
        where T : class
        where TDbContext : DbContext, new()
    {
        private TDbContext _context = new TDbContext();

        public TDbContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}