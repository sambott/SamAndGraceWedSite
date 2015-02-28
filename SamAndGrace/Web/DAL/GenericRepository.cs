using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Web.DAL
{
    public abstract class GenericRepository<TDbContext, T> :
        IGenericRepository<T>, IDisposable
        where T : class
        where TDbContext : DbContext, new()
    {
        private TDbContext m_context = new TDbContext();
        private bool m_disposed;

        public TDbContext Context
        {
            get { return m_context; }
            set { m_context = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = m_context.Set<T>();
            return query;
        }

        public T GetById(params object[] id)
        {
            return m_context.Set<T>().Find(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = m_context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            m_context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            m_context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            m_context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            m_context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (m_disposed) return;
            if (disposing)
            {
                m_context.Dispose();
            }

            m_disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}