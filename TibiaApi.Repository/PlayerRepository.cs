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

        public IEnumerable<Player> FindAllByNames(params string[] names) =>
            this.FindAll().Where(p => names.Contains(p.Name));

        public Player FindByName(string name) => this.FindAllByNames(name).FirstOrDefault();
    }
}
