﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public class StatsRepository : BaseRepository<Stats>, IStatsRepository<Stats>
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
