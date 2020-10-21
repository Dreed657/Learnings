using Data;
using Newtonsoft.Json;
using Services;
using Services.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var db = new RealEstateDbContext();
            await db.Database.EnsureDeletedAsync();
            await db.Database.EnsureCreatedAsync();

            var data = await File.ReadAllTextAsync("imot.bg-raw-data-2020-07-23.json");
            var properties = JsonConvert.DeserializeObject<List<JsonProperty>>(data);
            var propertyService = new PropertiesService(db);

            var timer = new Stopwatch();
            timer.Start();

            await InsertToDb(propertyService, properties);

            propertyService.BulkUpdateTags();

            timer.Stop();
            Console.WriteLine($"Time spend on this task: {timer.Elapsed}!");
        }

        private static async Task InsertToDb(PropertiesService propertyService, IEnumerable<JsonProperty> properties)
        {
            var converted = properties
                .Select(property => new PropertyCreateDto
                {
                    District = property.District,
                    Size = property.Size,
                    Year = property.Year,
                    Price = property.Price,
                    Url = property.Url,
                    PropertyType = property.Type,
                    BuildingType = property.BuildingType,
                    Floor = property.Floor,
                    MaxFloors = property.TotalFloors
                })
                .ToArray();

            await propertyService.BulkInsert(converted);
        }
    }
}
