using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public interface IWorldService<WorldRepository> : IBasicService<IWorldRepository<World>, World>
    {
        World FindByName(string name);
        ModelBaseReturn GetAllWorldsNames();
        //ModelBaseReturn GetAllWorldsNames();
    }
}
