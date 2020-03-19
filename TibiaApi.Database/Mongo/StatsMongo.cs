using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TibiaApi.Comum.Utils;

namespace TibiaApi.Database.Mongo
{
    public class StatsMongo : BasicEntityMongo
    {
        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.DateTime)]
        [DataMember]
        public virtual DateTime RegisterDate { get; set; }

        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.Int32)]
        [DataMember]
        public int TotalPlayerOnline { get; set; }

        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.String)]
        [DataMember]
        public StatusWorld Status { get; set; }

        [BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
        [DataMember]
        public long WorldMongoId { get; set; }

    }
}
