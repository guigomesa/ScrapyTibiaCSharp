using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public interface IKillStatsService<KillStatRepository> : IBasicService<IKillStatsRepository<KillStat>, KillStat>
    {       
    }
}
