
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongoDriver.Models
{
    public class SubItem
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("strings")]
        public List<string> Strings { get; set; }
    }
}
