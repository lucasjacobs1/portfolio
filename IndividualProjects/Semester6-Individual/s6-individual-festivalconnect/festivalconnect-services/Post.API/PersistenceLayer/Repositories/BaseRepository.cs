using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext Context { get; }

        public BaseRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual bool Create(T entity)
        {
            Context.Set<T>().Add(entity);
            return Context.SaveChanges() == 1;
        }

        public virtual T GetById(object id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual bool Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges() == 1;
        }

        public virtual bool Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChanges() > 0;
        }

        public virtual bool DeleteAll()
        {
            List<T> list = Context.Set<T>().ToList();
            int count = list.Count;
            Context.Set<T>().RemoveRange(GetAll());
            return Context.SaveChanges() == count;
        }
    }
}
