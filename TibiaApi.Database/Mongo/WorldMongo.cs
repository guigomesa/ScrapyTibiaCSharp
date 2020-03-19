using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TibiaApi.Comum.Utils;

namespace TibiaApi.Database.Mongo
{
    public class WorldMongo : BasicEntity
    {
        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string Name { get; set; }

        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public string Location { get; set; }

        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime CreationDate { get; set; }

        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public PvpType PvpType { get; set; }

        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public DateTime ScrapyDate { get; set; }
    }
}
