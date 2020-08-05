using System;
using System.Text;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Services;
using Services.Contracts;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var db = new RealEstateDbContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //db.Database.Migrate();


            IPropertiesService propertiesService = new PropertiesService(db);
            IDistrictsService districtsService = new DistrictsService(db);

            var properties = propertiesService.SearchByPrice(20000, 30000);

            if (properties.Any())
            {
                foreach (var p in properties)
                {
                    Console.WriteLine($"{p.District}, fl. {p.Floor}, {p.Year}, {p.Price}, {p.PropertyType}, {p.BuildingType}");
                }
            }
            else Console.WriteLine("Empty!");

            //var districts = districtsService.GetTopDistrictsByByNumberOfProperties(15);

            //if (districts.Any())
            //{
            //    foreach (var d in districts)
            //    {
            //        Console.WriteLine($"{d.Name} => Price: {d.AveragePrice:F2} ({d.MinPrice}-{d.MaxPrice}) => Properties: {d.PropertiesCount}");
            //    }
            //}
            //else Console.WriteLine("Empty!");
        }
    }
}
