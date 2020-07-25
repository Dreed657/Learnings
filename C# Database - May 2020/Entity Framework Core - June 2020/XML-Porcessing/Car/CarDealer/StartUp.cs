using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.XMLTools.DTO.Exports;
using CarDealer.XMLTools.DTO.Exports.CarDealer.XMLTools.DTO.Exports;
using CarDealer.XMLTools.DTO.Imports;
using Microsoft.EntityFrameworkCore;
using ProductShop.XMLTools;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //Reset(db);

            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");

            //Console.WriteLine(ImportSuppliers(db, suppliersXml));
            //Console.WriteLine(ImportParts(db, partsXml));
            //Console.WriteLine(ImportCars(db, carsXml));
            //Console.WriteLine(ImportCustomers(db, customersXml));
            //Console.WriteLine(ImportSales(db, salesXml));

            var result = GetSalesWithAppliedDiscount(db);
            File.WriteAllText("../../../Exports/sales-discounts.xml", result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var targetSales = context.Sales
                .Select(x => new ExportSalesWithAppliedDiscountDTO
                {
                    Car = new CarInfo { Make = x.Car.Make, Model = x.Car.Model, TravelledDistance = x.Car.TravelledDistance },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(pc => pc.Part.Price) - x.Car.PartCars.Sum(pc => pc.Part.Price) * x.Discount / 100.0M
                }).ToArray();

            return XmlConverter.Serialize(targetSales, "sales");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Sales
                .Where(x => x.Customer.Sales.Any())
                .Select(x => new ExportCustomersSalesDTO
                {
                    fullName = x.Customer.Name,
                    count = x.Customer.Sales.Count,
                    spendMoney = x.Car.PartCars.Sum(c => c.Part.Price)
                })
                .OrderByDescending(x => x.spendMoney)
                .ToList();

            return XmlConverter.Serialize(customers, "customers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var targetCars = context.Cars
                .Select(x => new ExportCarsWithPartsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars
                        .Select(pc => new CarPart { Name = pc.Part.Name, Price = pc.Part.Price })
                        .OrderByDescending(pc => pc.Price)
                        .ToList()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();

            return XmlConverter.Serialize(targetCars, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var targetSuppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new ExportLocalSuppliersDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                }).ToArray();

            return XmlConverter.Serialize(targetSuppliers, "suppliers");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportCarBMWModelDTO
                {
                    id = x.Id,
                    model = x.Model,
                    travelledDistance = x.TravelledDistance
                })
                .ToList();

            return XmlConverter.Serialize(cars, "cars");
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Select(x => new ExportCarModelDTO
                {
                    make = x.Make,
                    model = x.Model,
                    travelledDistance = x.TravelledDistance
                })
                .Take(10)
                .ToList();
            
            return XmlConverter.Serialize(cars, "cars");
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var salesResult = XmlConverter.Deserializer<ImportSalesDTO>(inputXml, "Sales");

            var cars = context.Cars.Select(x => x.Id).ToList();

            var sales = salesResult
                .Where(x => cars.Contains(x.carId))
                .Select(x => new Sale
                {
                    CarId = x.carId,
                    CustomerId = x.customerId,
                    Discount = x.discount
                })
                .ToList();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var customersResult = XmlConverter.Deserializer<ImportCustomersDTO>(inputXml, "Customers");

            var customers = customersResult.Select(x => new Customer
                {
                    Name = x.name,
                    BirthDate = x.birthDate,
                    IsYoungDriver = x.isYoungDriver
                })
                .ToList();

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsResult = XmlConverter.Deserializer<ImportCarsDTO>(inputXml, "Cars");

            var parts = context.Parts.Select(x => x.Id).ToList();

            var cars = new List<Car>();

            foreach (var car in carsResult)
            {
                var distinctParts = car.Parts.Select(x => x.partId).Distinct().ToArray();
                var realPart = distinctParts.Where(id => parts.Contains(id));

                var newCar = new Car()
                {
                    Make = car.make,
                    Model = car.model,
                    TravelledDistance = car.traveledDistance,
                    PartCars = realPart.Select(id => new PartCar
                    {
                        PartId = id
                    }).ToArray()
                };

                cars.Add(newCar);
            }
            
            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsResult = XmlConverter.Deserializer<ImportPartsDTO>(inputXml, "Parts");

            var suppliers = context.Suppliers.Select(x => x.Id).ToList();

            var parts = partsResult
                .Where(x => suppliers.Contains(x.supplierId))
                .Select(x => new Part
                {
                    Name = x.name,
                    Price = x.price,
                    Quantity = x.quantity,
                    SupplierId = x.supplierId
                })
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var suppliersResult = XmlConverter.Deserializer<ImportSuppliersDTO>(inputXml, "Suppliers");

            var suppliers = suppliersResult.Select(x => new Supplier
                {
                    Name = x.name,
                    IsImporter = x.isImporter
                })
                .ToList();

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static void Reset(DbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Console.WriteLine("Database Reseted!");
        }
    }
}