using System;
using System.Collections.Generic;
using System.Text;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public interface IPlayerService: IBasicService
    {
        ModelBaseReturn SaveFromScrapy(IList<PlayerScrapy> models);
        ModelBaseReturn SaveFromScrapy(PlayerScrapy scrapyModel, Player playerDb);
    }
}
