using Data;
using Newtonsoft.Json;
using Services;
using Services.DataTransferObject;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Importer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var db = new RealEstateDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var data = File.ReadAllText("imot.bg-raw-data-2020-07-23.json");
            var properties = JsonConvert.DeserializeObject<JsonProperty[]>(data);
            var propertyService = new PropertiesService(db);

            await InsertToDb(propertyService, properties);
        }

        private static async Task InsertToDb(PropertiesService propertyService, JsonProperty[] properties)
        {
            foreach (var property in properties.Where(x => x.Price > 500))
            {
                var timer = new Stopwatch();

                try
                {
                    timer.Start();

                    var createModel = new PropertyCreateDto
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
                    };

                    await propertyService.Create(createModel);

                    timer.Stop();

                    var propertyInfo = $"District: {property.District} ({property.Floor}/{property.TotalFloors}), {property.Year}, {property.Size}m2, Price: {property.Price}";

                    NonBlockingConsole.WriteLine($"Created: {propertyInfo}. ({timer.ElapsedMilliseconds}ms)");
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }

    public static class NonBlockingConsole
    {
        private static readonly BlockingCollection<string> m_Queue = new BlockingCollection<string>();

        static NonBlockingConsole()
        {
            var thread = new Thread(
                () =>
                {
                    while (true) Console.WriteLine(m_Queue.Take());
                })
            { IsBackground = true };
            thread.Start();
        }

        public static void WriteLine(string value)
        {
            m_Queue.Add(value);
        }
    }

}
