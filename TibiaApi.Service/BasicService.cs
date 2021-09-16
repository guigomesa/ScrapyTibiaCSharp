
using System;
using System.Linq;
using System.Net;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public abstract class BasicService<T, K> : IBasicService<T, K>
        where T : IBaseRepository<K>
        where K : BasicEntity
    {
        protected T _repository { get; set; }

        protected BasicService(T repository)
        {
            _repository = repository;
        }

        public void Save()
        {
            _repository.Save();
        }

        public abstract ModelBaseReturn SaveFromScrapy<Object>(Object obj);

        public void Add(K entity)
        {
            _repository.Add(entity);
        }

        public K AddOrUpdate(K entity)
        {
            _repository.AddOrUpdate(entity);
            return entity;
        }

        public K SaveOrUpdate(K entity)
        {
            _repository.AddOrUpdate(entity);
            _repository.Save();
            
            return entity;
        }

        public IQueryable<K> FindAll()
        {
            return _repository.FindAll();
        }

        public IQueryable<K> FindAll(Predicate<K> predicate)
        {
            return _repository.FindAll(predicate);
        }

        protected ModelReturn<TEntidade> CreateReturn<TEntidade>(TEntidade model, HttpStatusCode status, string message = null)
        {
            return new ModelReturn<TEntidade>(model, status, message);
        }

        protected ModelReturn<object> CreateReturnCreated()
        {
            return CreateReturn<object>(null, HttpStatusCode.Created);
        }

        protected ModelReturn<object> CreateReturnCreated(long id)
        {
            return CreateReturn<object>(id, HttpStatusCode.Created);
        }

        protected ModelReturn<TEntidade> CreateReturnOk<TEntidade>(TEntidade model)
        {
            return CreateReturn(model, HttpStatusCode.OK);
        }

        protected ModelReturn<string> CreateReturnErrorValidation(string message)
        {
            return CreateReturnErrorValidation(message);
        }

        protected ModelReturn<TEntidade> CreateReturnErrorValidation<TEntidade>(TEntidade errorModel, string message = null)
        {
            return CreateReturn(errorModel, HttpStatusCode.BadRequest, message);
        }

        protected ModelReturn<string> CreateReturnErrorInternal(string message)
        {
            return CreateReturnErrorInternal(message, message);
        }

        protected ModelReturn<TEntidade> CreateReturnErrorInternal<TEntidade>(TEntidade errorModel, string message)
        {
            return CreateReturn(errorModel, HttpStatusCode.InternalServerError, message);
        }
    }
}