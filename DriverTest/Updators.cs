using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MongoDriver.Models;
using System.Threading.Tasks;
using System;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Bson;

namespace DriverTest
{
    [TestClass]
    public class Updator
    {
        // https://gist.github.com/a3dho3yn/91dcc7e6f606eaefaf045fc193d3dcc3

        [TestMethod]
        public async Task Replace()
        {
            var context = new DbContext();

            var item = (await context.Items.Find(x => x.Name == "Special").ToListAsync()).First();

            var sis = item.Strings.ToList();
            sis.Add("dazzling");
            item.Strings = sis;

            var filter = Builders<Item>.Filter.Eq(s => s.Id, item.Id);
            await context.Items.ReplaceOneAsync(filter, item);
        }

        [TestMethod]
        public async Task ReplaceWithString()
        {
            var context = new DbContext();

            var item = (await context.Items.Find(x => x.Name == "Special").ToListAsync()).First();

            var sis = item.Strings.ToList();
            sis.Remove("cute");
            item.Strings = sis;

            await context.Items.ReplaceOneAsync("{ 'name' : 'Special' }", item);
        }


        [TestMethod]
        public async Task Update()
        {
            var context = new DbContext();

            await context.Items.UpdateManyAsync("{ 'subitems.name' : 'SubName' }", "{ $currentDate : {'subitems.0.name' : true }}", new UpdateOptions { IsUpsert = true });
        }

        [TestMethod]
        public async Task Delete()
        {
            var context = new DbContext();

            await context.Items.DeleteManyAsync("{ 'name' : 'Special' }");
        }
    }
}
