using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private const string basePath = @"../../../Datasets/Exports";

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            var result = GetSoldProducts(db);

            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            File.WriteAllText(basePath + "/users-sold-products.json", result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                    .AsEnumerable()
                    .Where(u => u.ProductsSold.Any(us => us.Buyer != null))
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold.Count(p => p.Buyer != null),
                            products = u.ProductsSold
                                        .Where(ps => ps.Buyer != null)
                                        .Select(p => new
                                        {
                                            name = p.Name,
                                            price = p.Price
                                        })
                                        .ToList()
                        }
                    })
                    .OrderByDescending(u => u.soldProducts.count)
                    .ToList();

            return JsonConvert.SerializeObject
                (
                    new
                    {
                        usersCount = users.Count,
                        users
                    }, 
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        Formatting = Formatting.Indented
                    }
                );
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var cats = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                    totalRevenue = x.CategoryProducts.Sum(t => t.Product.Price).ToString("f2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            return JsonConvert.SerializeObject(cats, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new 
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                })
                .ToList();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    name = x.Name, 
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var CatProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.AddRange(CatProducts);
            context.SaveChanges();

            return $"Successfully imported {CatProducts.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var Products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.AddRange(Products);
            context.SaveChanges();

            return $"Successfully imported {Products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var Categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            context.AddRange(Categories.Where(x => x.Name != null));
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static void Reset(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Created!");
        }
    }
}