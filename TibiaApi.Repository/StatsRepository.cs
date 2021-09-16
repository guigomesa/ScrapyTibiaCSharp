using System;
using System.Linq;
using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public class StatsRepository : BaseRepository<Stats>, IStatsRepository
    {
        protected StatsRepository(TibiaDbContext context) : base(context)
        {
        }

        public override IQueryable<Stats> Find(Predicate<Stats> predicate)
        {
            return _Context.Statses.Where(s => predicate(s));
        }

        public override IQueryable<Stats> FindAll(Predicate<Stats> predicate)
        {
            return _Context.Statses.Where(s => predicate(s));
        }
    }
}
