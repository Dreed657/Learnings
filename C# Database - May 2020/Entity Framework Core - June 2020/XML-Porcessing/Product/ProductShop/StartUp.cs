using ProductShop.Dtos.Import;
using ProductShop.XMLTools;
using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //Reset(db);

            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");

            //Console.WriteLine(ImportUsers(db, usersXml));
            //Console.WriteLine(ImportProducts(db, productsXml));
            //Console.WriteLine(ImportCategories(db, categoriesXml));
            //Console.WriteLine(ImportCategoryProducts(db, categoriesProductsXml));

            var result = GetUsersWithProducts(db);
            File.WriteAllText("../../../Export/user-and-products.xml", result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToArray()
                .Where(x => x.ProductsSold.Any())
                .Select(x => new ExportUserDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    soldProducts = new ExportProductCountDTO
                    {
                        count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(p => new ExportProductDTO
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .OrderByDescending(p => p.price)
                            .ToArray()
                    }
                })
                .OrderByDescending(x => x.soldProducts.count)
                .Take(10)
                .ToArray();

            var result = new ExportUserCountDTO
                {
                    count = context.Users.Count(x => x.ProductsSold.Any()),
                    Users = users
                };

            return XmlConverter.Serialize(result, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new ExportCategoriesByCountDTO
                {
                    name = x.Name,
                    count = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Average(p=> p.Product.Price),
                    totalRevenues = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.count)
                .ThenBy(x => x.totalRevenues)
                .ToList();

            return XmlConverter.Serialize(categories, "Categories");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new ExportUsersAndProductsDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p => new UserProductDTO
                        {
                            name = p.Name,
                            price = p.Price
                        })
                        .Take(5)
                        .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            return XmlConverter.Serialize(users, "Users");
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ExportProductInRangeDTO
                {
                    name = x.Name,
                    price = x.Price,
                    buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.price)
                .Take(10)
                .ToList();

            return XmlConverter.Serialize(products, "Products");
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var CategoryProductsResult = XmlConverter.Deserializer<ImportCategoryProductsDTO>(inputXml, "CategoryProducts");

            var categoriesId = context.Categories.Select(x => x.Id).ToList();
            var productIds = context.Products.Select(x => x.Id).ToList();

            var CategoryProducts = CategoryProductsResult
                .Where(x => categoriesId.Contains(x.CategoryId) && productIds.Contains(x.ProductId))
                .Select(x => new CategoryProduct
                {
                    ProductId = x.ProductId,
                    CategoryId = x.CategoryId
                })
                .ToList();

            context.CategoryProducts.AddRange(CategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {CategoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesResult = XmlConverter.Deserializer<ImportCategoryDTO>(inputXml, "Categories");

            var categories = categoriesResult
                .Where(x => x.name != null)
                .Select(x => new Category
                {
                    Name = x.name
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var ProductsResult = XmlConverter.Deserializer<ImportProductDTO>(inputXml, "Products");

            var Products = ProductsResult.Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerId = x.BuyerId,
                    SellerId = x.SellerId
                })
                .ToList();

            context.Products.AddRange(Products);
            context.SaveChanges();

            return $"Successfully imported {Products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var UsersResult = XmlConverter.Deserializer<ImportUsersDTO>(inputXml, "Users");

            var Users = UsersResult.Select(x => new User
                {
                    FirstName = x.firstName,
                    LastName = x.lastName,
                    Age = x.age
                })
                .ToList();

            context.Users.AddRange(Users);
            context.SaveChanges();

            return $"Successfully imported {Users.Count}";
        }

        public static void Reset(DbContext db)
        {
            db.Database.EnsureDeleted();

            Console.WriteLine("Database Delete!");
            
            db.Database.EnsureCreated();

            Console.WriteLine("Database Created!");
        }
    }
}