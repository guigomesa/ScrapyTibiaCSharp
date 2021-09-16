using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibiaApi.DatabaseMongo
{
    public abstract class BasicEntity : Entity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; }
    }
}
