using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nmibp2lab.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nmibp2lab.Mongo
{
    public class MongoNewsHelper
    {
        protected readonly MongoConnectionHandler<News> MongoConnectionHandler;

        public MongoNewsHelper()
        {
            this.MongoConnectionHandler = new MongoConnectionHandler<News>();
        }

        public void PostNews(News newNews)
        {
            this.MongoConnectionHandler.MongoCollection.InsertOne(newNews);
        }

        public void PostComment(ObjectId id, string comment)
        {
            var filter = Builders<News>.Filter.Eq("Id", id);
            var update = Builders<News>.Update.Push("comments", comment);
            this.MongoConnectionHandler.MongoCollection.UpdateOne(filter, update);
        }

        public List<News> GetNews(int number)
        {
            var sorter = Builders<News>.Sort.Descending("_id");
            return this.MongoConnectionHandler.MongoCollection.Find(x => true).Sort(sorter).Limit(number).ToList();
        }
    }
}