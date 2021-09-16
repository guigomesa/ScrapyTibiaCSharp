using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public interface IKillStatsRepository<T> : IBaseRepository<T> where T : BasicEntity
    {
        
    }
}