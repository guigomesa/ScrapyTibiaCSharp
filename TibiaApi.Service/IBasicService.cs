
using System;
using System.Linq;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public interface IBasicService
    {
        void Add<KItem>(KItem entity);
        KItem SaveOrUpdate<KItem>(KItem entity);
        ModelBaseReturn SaveFromScrapy<KScrapy>(KScrapy obj);
    }
}