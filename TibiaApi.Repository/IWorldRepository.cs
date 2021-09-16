using System.Collections.Generic;
using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public interface IWorldRepository<T> : IBaseRepository<T> where T : World
    {
        World FindByName(string name);
        IList<string> GetAllWorldsNames();
    }
}