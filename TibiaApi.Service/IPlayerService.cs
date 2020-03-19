using System;
using System.Collections.Generic;
using System.Text;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public interface IPlayerService<PlayerRepository> : IBasicService<IPlayerRepository<Player>,Player>     
    {
        ModelBaseReturn SaveFromScrapy<TScrapy>(IList<TScrapy> models);
    }
}
