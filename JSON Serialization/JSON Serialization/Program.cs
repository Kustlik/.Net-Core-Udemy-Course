using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace JSON_Serialization
{
    class Program
    {

        static void Main(string[] args)
        {
//            string playerSerialized = File.ReadAllText(@"C: \Users\Sobala\source\repos\JSON Serialization\JSON Serialization\playerSerialized.json");
//            Player player = JsonConvert.DeserializeObject<Player>(playerSerialized);

            var player = new Player()
            {
                Name = "Mario",
                Level = 1,
                HealthPoints = 100,
                Statistics = new List<Statistic>()
                {
                    new Statistic()
                    {
                        Name = "Strength",
                        Points = 10
                    },
                    new Statistic()
                    {
                        Name = "Intelligence",
                        Points = 10
                    }
                }
            };

            //..
            player.Level++;

            string playerSerialized = JsonConvert.SerializeObject(player);
            File.WriteAllText(@"C:\Users\Sobala\source\repos\JSON Serialization\JSON Serialization\playerSerialized.json", playerSerialized);
        }
    }
}
