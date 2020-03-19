using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public class DeathPlayerRepository : BaseRepository<DeathPlayer>, IDeathPlayerRepository<DeathPlayer>
    {
        public DeathPlayerRepository(TibiaDbContext context) : base(context)
        {
        }
    }
}
