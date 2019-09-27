using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MongoDriver.Models;
using System.Threading.Tasks;
using System;

namespace DriverTest
{
    [TestClass]
    public class Generators
    {
        [TestMethod]
        public void Generate0()
        {
            var item = new Item();
            item.Name = "NameSync";
            item.Strings = new List<string>()
            {
                "string1",
                "string2",
                "string3"
            };

            var si = new SubItem();
            si.Name = "SubName";
            si.Strings = new List<string>()
            {
                "subString1",
                "subString2",
                "subString3"
            };
            item.SubItems = new List<SubItem>()
            {
                si
            };

            var context = new DbContext();

            context.Items.InsertOne(item);
        }

        [TestMethod]
        public async Task Generate1()
        {
            var item = new Item();
            item.Name = "NameAsync";
            item.Strings = new List<string>()
            {
                "string1",
                "string2",
                "string3"
            };

            var si = new SubItem();
            si.Name = "SubName";
            si.Strings = new List<string>()
            {
                "subString1",
                "subString2",
                "subString3"
            };
            item.SubItems = new List<SubItem>()
            {
                si
            };

            var context = new DbContext();

            await context.Items.InsertOneAsync(item);
        }

        [TestMethod]
        public async Task GenerateMany()
        {
            for (int i=0;i<100;i++)
            {
                var item = new Item();
                item.Name = "Many" + i.ToString();
                item.Strings = new List<string>()
                {
                    "string1",
                    "string2",
                    "string3"
                };

                var sis = new List<SubItem>();
                Random rnd = new Random();
                int max = rnd.Next(1, 100);

                for (int j = 0; j < max;j++)
                {
                    var si = new SubItem();
                    si.Name = "SubName" + j.ToString();
                    si.Strings = new List<string>()
                    {
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString()
                    };
                    sis.Add(si);
                }

                item.SubItems = sis;

                var context = new DbContext();

                await context.Items.InsertOneAsync(item);
            }
        }

        [TestMethod]
        public async Task GenerateSpecial()
        {
            var item = new Item();
            item.Name = "Special";
            item.Strings = new List<string>()
            {
                "beautiful",
                "intelligent",
                "cute"
            };

            var si = new SubItem();
            si.Name = "Snowflake";
            si.Strings = new List<string>()
            {
                "fluffy",
                "sweet",
                "sexy"
            };
            var si2 = new SubItem();
            si2.Name = "HughJackman";
            si2.Strings = new List<string>()
            {
                "handsome",
                "strong",
                "musky"
            };
            item.SubItems = new List<SubItem>()
            {
                si,
                si2
            };

            var context = new DbContext();

            await context.Items.InsertOneAsync(item);
        }

        [TestMethod]
        public async Task GenerateMany2()
        {
            Random rnd = new Random();
            int m = rnd.Next(200, 300);
            for (int i = 200; i < m; i++)
            {
                var item = new Item();
                item.Name = "Many" + i.ToString();
                item.Strings = new List<string>()
                {
                    "string1",
                    "string2",
                    "string3"
                };

                var sis = new List<SubItem>();
                
                int max = rnd.Next(1, 100);

                for (int j = 0; j < max; j++)
                {
                    var si = new SubItem();
                    si.Name = "SubName" + j.ToString();
                    si.Strings = new List<string>()
                    {
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString(),
                        "subString" + rnd.Next(1, 10000).ToString()
                    };
                    sis.Add(si);
                }

                item.SubItems = sis;

                var context = new DbContext();

                await context.Items.InsertOneAsync(item);
            }
        }
    }
}
