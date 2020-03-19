using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public interface IPlayerRepository<T> : IBaseRepository<T> where T : BasicEntity
    {
        T FindByName(string name);
    }
}