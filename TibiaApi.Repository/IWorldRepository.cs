using System.Collections.Generic;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public interface IWorldRepository<T> : IBaseRepository<T> where T : World
    {
        World FindByName(string name);
        IList<string> GetAllWorldsNames();
    }
}