

using System;
using System.Linq;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public interface IBaseRepository<T> where T : BasicEntity
    {

        T AddOrUpdate(T entity);
        IQueryable<T> FindAll();
        IQueryable<T> FindAll(Predicate<T> predicate);
        IQueryable<T> Find(Predicate<T> predicate);
        T FindById(long id);
        T Add(T entity);
        T Update(T entity);
        T Remove(T entity);
        void Save();
        Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction TransactionContext();

    }
}
