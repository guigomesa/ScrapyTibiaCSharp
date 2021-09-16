using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public class KillStatsRepository : BaseRepository<KillStat>, IKillStatsRepository<KillStat>
    {
        public KillStatsRepository(TibiaDbContext context) : base(context)
        {
        }
    }
}
