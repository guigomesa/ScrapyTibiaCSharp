using System.Collections.Generic;
using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public interface IWorldRepository : IBaseRepository<World>
    {
        World FindByName(string name);
        IList<string> GetAllWorldsNames();
    }
}