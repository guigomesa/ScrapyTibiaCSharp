using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TibiaApi.Database.Mongo
{
    public class DeathPlayerMongo : BasicEntityMongo
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string DescriptionDeath { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime EventDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string PlayersMurder { get; set; }


        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [DataMember]
        public string PlayerId { get; set; }
    }
}
