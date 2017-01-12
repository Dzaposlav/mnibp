using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace nmibp2lab.Mongo
{
    public class MongoConnectionHandler<T> where T : MongoEntity
    {
        public IMongoCollection<T> MongoCollection { get; private set; }

        public MongoConnectionHandler()
        {
            IMongoClient client = new MongoClient();
            IMongoDatabase database = client.GetDatabase("bazeLab");
            MongoCollection = database.GetCollection<T>("news");
        }
    }
}