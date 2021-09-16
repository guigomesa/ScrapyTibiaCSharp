using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TibiaApi.Database.Mongo
{
    public class MonsterKillStatsMongo : BasicEntityMongo
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime RegisterDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [DataMember]
        public string IdWorld { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Document)]
        [DataMember]
        public virtual WorldMongo World { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Document)]
        [DataMember]
        public List<KillStatMongo> KillStats { get; set; }
    }
}
