using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public class PlayerHistoryRepository : BaseRepository<PlayerHistory>, IPlayerHistoryRepository<PlayerHistory>
    {
        public PlayerHistoryRepository(TibiaDbContext context) : base(context)
        {
        }
    }
}
