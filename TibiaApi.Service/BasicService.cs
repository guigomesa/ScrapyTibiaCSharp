
using System;
using System.Linq;
using System.Net;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public abstract class BasicService: IBasicService
    {
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

        public ModelBaseReturn SaveFromScrapy<KItemScrapy>(KItemScrapy model)
        {
            throw new NotImplementedException();
        }

        public void Add<KItem>(KItem entity)
        {
            throw new NotImplementedException();
        }

        public KItem SaveOrUpdate<KItem>(KItem entity)
        {
            throw new NotImplementedException();
        }
    }
}