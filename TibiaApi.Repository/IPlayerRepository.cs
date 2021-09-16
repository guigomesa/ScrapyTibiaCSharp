using System.Collections.Generic;
using TibiaApi.Database.Sql;

namespace TibiaApi.Repository
{
    public interface IPlayerRepository<T> : IBaseRepository<T> where T : BasicEntity
    {
        T FindByName(string name);
        IEnumerable<T> FindAllByNames(params string[] names);
    }
}