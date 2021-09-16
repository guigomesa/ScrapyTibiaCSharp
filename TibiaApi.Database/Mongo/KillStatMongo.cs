using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Runtime.Serialization;

namespace TibiaApi.Database.Mongo
{
    public class KillStatMongo: BasicEntityMongo
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string Race { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [DataMember]
        public string KilledPlayer { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string KilledByPlayer { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime RegisterDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]
        [DataMember]
        public long MonsterKillStatId { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Document)]
        [DataMember]
        public MonsterKillStatsMongo MonsterKillStat { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [DataMember]
        public string IdWorld { get; set; }
    }
}
