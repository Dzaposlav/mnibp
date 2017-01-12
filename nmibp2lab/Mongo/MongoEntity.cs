using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nmibp2lab.Mongo
{
    public class MongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}