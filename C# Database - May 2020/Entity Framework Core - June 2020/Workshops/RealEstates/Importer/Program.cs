using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Newtonsoft.Json;
using Services;
using System.Diagnostics;
using System.Text;

namespace Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var db = new RealEstateDbContext();
            var data = File.ReadAllText("imot.bg-raw-data-2020-07-23.json");
            var properties = JsonConvert.DeserializeObject<IEnumerable<JsonProperty>>(data);
            var propertyService = new PropertiesService(db);

            foreach (var property in properties.Where(x => x.Price > 500))
            {
                var timer = new Stopwatch();

                try
                {
                    timer.Start();

                    propertyService.Create(
                        property.District,
                        property.Size,
                        property.Year,
                        property.Price,
                        property.Type,
                        property.BuildingType,
                        property.Floor,
                        property.TotalFloors
                    );

                    timer.Stop();

                    var propertyInfo = $"District: {property.District} ({property.Floor}/{property.TotalFloors}), {property.Year}, {property.Size}m2, Price: {property.Price}";

                    Console.WriteLine($"Created: {propertyInfo}. ({timer.ElapsedMilliseconds}ms)");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
