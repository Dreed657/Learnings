using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private const string basePath = @"../../../Datasets";

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //InitDb(db);

            if (!Directory.Exists(basePath + "/Exports"))
            {
                Directory.CreateDirectory(basePath + "/Exports");
            }

            var result = GetSalesWithAppliedDiscount(db);
            File.WriteAllText(basePath + "/Exports/sales-discounts.json", result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new
                {
                    car = new { x.Car.Make, x.Car.Model, x.Car.TravelledDistance },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(p => p.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) * (1M - x.Discount / 100M)).ToString("F2")
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new { x.Make, x.Model, x.TravelledDistance },
                    parts = x.PartCars.Select(p => new
                        {
                            p.Part.Name,
                            Price = p.Part.Price.ToString("F2")
                        })
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ToList()
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    x.IsYoungDriver
                });

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var Sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            context.AddRange(Sales);
            context.SaveChanges();

            return $"Successfully imported {Sales.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var Customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.AddRange(Customers);
            context.SaveChanges();

            return $"Successfully imported {Customers.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var FullCars = JsonConvert.DeserializeObject<List<CarTransferModel>>(inputJson);
            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var FullCar in FullCars)
            {

                var newCar = new Car()
                {
                    Make = FullCar.Make,
                    Model = FullCar.Model,
                    TravelledDistance = FullCar.TravelledDistance,

                };
                cars.Add(newCar);

                foreach (var carPartId in FullCar.PartsId.Distinct())
                {
                    var newCarPart = new PartCar()
                    {
                        PartId = carPartId,
                        Car = newCar
                    };
                    carParts.Add(newCarPart);
                }

            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliersIDs = context.Suppliers.Select(x => x.Id).ToList();

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(x => suppliersIDs.Contains(x.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var Suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(Suppliers);
            context.SaveChanges();

            return $"Successfully imported {Suppliers.Count}.";
        }

        private static void Reset(DbContext db)
        {
            db.Database.EnsureDeleted();

            Console.WriteLine("Deleted!");

            db.Database.EnsureCreated();

            Console.WriteLine("Created!");
        }

        private static void InitDb(CarDealerContext db)
        {
            Reset(db);

            var carsJson = File.ReadAllText(basePath + "/cars.json");
            var customersJson = File.ReadAllText(basePath + "/customers.json");
            var partsJson = File.ReadAllText(basePath + "/parts.json");
            var salesJson = File.ReadAllText(basePath + "/sales.json");
            var suppliersJson = File.ReadAllText(basePath + "/suppliers.json");

            Console.WriteLine(ImportCustomers(db, customersJson) + " Customers");
            Console.WriteLine(ImportSuppliers(db, suppliersJson) + " Suppliers");
            Console.WriteLine(ImportParts(db, partsJson) + " Parts");
            Console.WriteLine(ImportCars(db, carsJson) + " Cars");
            Console.WriteLine(ImportSales(db, salesJson) + " Sales");
        }
    }
}