using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public class DeathPlayerRepository : BaseRepository<DeathPlayer>, IDeathPlayerRepository
    {
        public DeathPlayerRepository(TibiaDbContext context) : base(context)
        {
        }
    }
}
