using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public class WorldRepository : BaseRepository<World>, IWorldRepository
    {
        public WorldRepository(TibiaDbContext context) : base(context)
        {
        }

        public World FindByName(string name)
        {
            return this.FindAll().Include(w => w.Statistics).Where(w => w.Name.Equals(name)).FirstOrDefault();
        }

        public IList<string> GetAllWorldsNames()
        {
            return this.FindAll().Select(w => w.Name).Distinct().ToList();
        }
    }
}
