using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public class KillStatsService : BasicService, IKillStatsService
    {
        private IKillStatsRepository _repository;

        public KillStatsService(IKillStatsRepository repository) {

            _repository = repository;
        }

        public void Add(object entity)
        {
            throw new System.NotImplementedException();
        }

        public ModelBaseReturn SaveFromScrapy(KillStatScrapy model)
        {
            return null;
        }
    }
}