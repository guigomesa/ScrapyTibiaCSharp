
using System;
using System.Linq;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public interface IBasicService<T, K> where T : IBaseRepository<K> where K : BasicEntity
    {
        void Add(K entity);
        K SaveOrUpdate(K entity);
        IQueryable<K> FindAll();
        IQueryable<K> FindAll(Predicate<K> predicate);
        ModelBaseReturn SaveFromScrapy<G>(G obj);
    }
}