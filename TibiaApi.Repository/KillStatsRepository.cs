using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public class KillStatsRepository : BaseRepository<KillStat>, IKillStatsRepository<KillStat>
    {
        public KillStatsRepository(TibiaDbContext context) : base(context)
        {
        }
    }
}
