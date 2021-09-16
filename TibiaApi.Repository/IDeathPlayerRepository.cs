using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public interface IDeathPlayerRepository<T> : IBaseRepository<T> where T : BasicEntity
    {
    }
}
