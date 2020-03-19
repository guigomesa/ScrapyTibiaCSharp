using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository<Player>
    {
        public PlayerRepository(TibiaDbContext context) : base(context)
        {
        }
        public Player FindByName(string name) => this.FindAll()
            .Where(p => p.Name.Equals(name))
            .FirstOrDefault();
    }
}
