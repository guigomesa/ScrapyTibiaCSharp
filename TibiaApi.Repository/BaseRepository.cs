using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BasicEntity
    {
        protected TibiaDbContext _Context { get; set; }

        protected BaseRepository(TibiaDbContext context)
        {
            _Context = context;
        }

        public Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction TransactionContext()
        {
            return _Context.Database.BeginTransaction();
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public virtual T AddOrUpdate(T entity)
        {
            return entity.Id == 0 ? Add(entity) : Update(entity);
        }

        public virtual T Add(T entity)
        {
            return _Context.Add(entity).Entity;
        }
        public virtual T Update(T entity)
        {
            return _Context.Update(entity).Entity;
        }

        public virtual T FindById(long id)
        {
            return FindAll(temp => temp.Id == id).FirstOrDefault();
        }

        public virtual IQueryable<T> FindAll()
        {
            return _Context.Set<T>();
        }

        public virtual IQueryable<T> FindAll(Predicate<T> predicate)
        {
            return _Context.Set<T>().Where(temp => predicate(temp));
        }

        public virtual IQueryable<T> Find(Predicate<T> predicate)
        {
            return FindAll(temp => predicate(temp));
        }
        public virtual T Remove(T entity)
        {
            var retorno = _Context.Remove(entity);
            return retorno.Entity;
        }
    }
}
