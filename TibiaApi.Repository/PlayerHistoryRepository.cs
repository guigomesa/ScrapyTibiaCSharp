using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public class PlayerHistoryRepository : BaseRepository<PlayerHistory>, IPlayerHistoryRepository
    {
        public PlayerHistoryRepository(TibiaDbContext context) : base(context)
        {
        }
    }
}
