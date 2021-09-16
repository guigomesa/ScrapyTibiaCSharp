using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TibiaApi.Comum.Utils;

namespace TibiaApi.Database.Mongo
{
    public class PlayerMongo : BasicEntityMongo
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string Name { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string OlderNames { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public Sex Sex { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [DataMember]
        public int Level { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [DataMember]
        public int AchievementPoints { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string ResidenceCity { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string House { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string GuildName { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string LastLogin { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string AccountStatus { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string InfoAccount { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public DateTime CreationDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public DateTime LastScrapyDate { get; set; } = DateTime.Now;


        [BsonRepresentation(MongoDB.Bson.BsonType.Document)]
        [DataMember]
        public WorldMongo World { get; set; }
    }
}
