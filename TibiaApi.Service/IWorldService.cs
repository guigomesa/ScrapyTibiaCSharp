using System;
using System.Collections.Generic;
using System.Text;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public interface IWorldService<WorldRepository> : IBasicService<IWorldRepository<World>, World>
    {
        World FindByName(string name);
        ModelBaseReturn GetAllWorldsNames();
        //ModelBaseReturn GetAllWorldsNames();
    }
}
