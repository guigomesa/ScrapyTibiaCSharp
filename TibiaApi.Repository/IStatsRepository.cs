using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public interface IStatsRepository<T> : IBaseRepository<T> where T : BasicEntity
    {
        
    }
}