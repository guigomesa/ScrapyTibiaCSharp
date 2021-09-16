using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public interface IWorldService : IBasicService
    {
        World FindByName(string name);
        ModelBaseReturn GetAllWorldsNames();
    }
}
