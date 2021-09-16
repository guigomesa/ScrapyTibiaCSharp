using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public class KillStatsRepository : BaseRepository<KillStat>, IKillStatsRepository
    {
        public KillStatsRepository(TibiaDbContext context) : base(context)
        {
        }
    }
}
