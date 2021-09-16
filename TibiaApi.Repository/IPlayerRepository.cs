using System.Collections.Generic;
using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Player FindByName(string name);
        IEnumerable<Player> FindAllByNames(params string[] names);
    }
}