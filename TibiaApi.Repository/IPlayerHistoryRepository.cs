using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public interface IPlayerHistoryRepository<T> : IBaseRepository<T> where T : BasicEntity
    {
        
    }
}