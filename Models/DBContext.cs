using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDriver.Models
{
    class DbContext
    {
        public const string CONNECTION_STRING_NAME = "drivertest";
        public const string DATABASE_NAME = "drivertest";
        public const string ITEMS_COLLECTION_NAME = "items";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static DbContext()
        {
            var connectionString = "mongodb+srv://dealogic_mongo:W4RAXDsy18bBFvNM@dealogicsamplecluster-xtf3z.azure.mongodb.net/test?retryWrites=true&w=majority";
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Item> Items
        {
            get { return _database.GetCollection<Item>(ITEMS_COLLECTION_NAME); }
        }
    }
}
