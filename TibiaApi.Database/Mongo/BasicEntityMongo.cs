using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;
using System;
using System.Runtime.Serialization;

namespace TibiaApi.Database.Mongo
{
    public class BasicEntityMongo : Entity
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime UpdatedAt { get; set; }
    }
}
