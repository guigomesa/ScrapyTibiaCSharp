using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Runtime.Serialization;
using TibiaApi.Comum.Utils;

namespace TibiaApi.Database.Mongo
{
    public class WorldMongo : BasicEntityMongo
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string Name { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string Location { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime CreationDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public PvpType PvpType { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime ScrapyDate { get; set; }
    }
}
