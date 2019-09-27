
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongoDriver.Models
{
    public class Item
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("strings")]
        public List<string> Strings { get; set; }

        [BsonElement("subitems")]
        public IEnumerable<Item> SubItems { get; set; }
    }
}
