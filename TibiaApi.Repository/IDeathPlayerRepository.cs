using System;
using System.Collections.Generic;
using System.Text;
using TibiaApi.Database;

namespace TibiaApi.Repository
{
    public interface IDeathPlayerRepository<T> : IBaseRepository<T> where T : BasicEntity
    {
    }
}
