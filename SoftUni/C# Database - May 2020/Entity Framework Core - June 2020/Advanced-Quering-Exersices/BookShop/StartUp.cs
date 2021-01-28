using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using System;
    using System.Linq;
    using System.Text;
    using BookShop.Initializer;

    public class StartUp
    {
        public static void Main()
        {
            var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //var input = Console.ReadLine();
            //var input = int.Parse(Console.ReadLine());

            var result = RemoveBooks(db);
            Console.WriteLine(result);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Copies < 4200).ToList();

            context.RemoveRange(books);
            context.SaveChanges();

            return books.Count();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Books = x.CategoryBooks
                        .Select(x => new
                        {
                            Title = x.Book.Title,
                            Date = x.Book.ReleaseDate
                        })
                        .Where(b => b.Date != null)
                        .OrderByDescending(x => x.Date)
                        .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var cat in categories)
            {
                sb.AppendLine($"--{cat.Name}");

                foreach (var book in cat.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Date.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var catProfit = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Profit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var item in catProfit)
            {
                sb.AppendLine($"{item.Name} ${item.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var bookCopies = context.Authors
                .Select(x => new
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    Copies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            foreach (var bookCopy in bookCopies)
            {
                sb.AppendLine($"{bookCopy.AuthorName} - {bookCopy.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(x => x.Title.Length > lengthCheck);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName
                })
                .OrderBy(x => x.BookId)
                .ToList()
                .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()));

            foreach (var x in books)
            {
                sb.AppendLine( $"{x.Title} ({x.FirstName} {x.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            foreach (var title in authors)
            {
                sb.AppendLine($"{title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input.ToLower()))
                .Select(x => new
                {
                    Name = x.FirstName + " " + x.LastName
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var x in authors)
            {
                sb.AppendLine(x.Name);
            } 

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext db, string date)
        {
            var sb = new StringBuilder();

            var dateValid = DateTime.Parse(date, new CultureInfo("bg-BG"));

            var books = db.Books
                .Where(x => x.ReleaseDate < dateValid)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new 
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            books.ForEach(x => sb.AppendLine($"{x.Title} - {x.EditionType} - ${x.Price:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext db, string input)
        {
            var sb = new StringBuilder();

            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower()).ToArray();

            var books = new List<string>();

            foreach (var category in categories)
            {
                var curCatBookTitles =
                    db.Books
                        .Where(x => x.BookCategories.Any(bc => bc.Category.Name.ToLower() == category))
                        .Select(x => x.Title)
                        .ToList();

                books.AddRange(curCatBookTitles);
            }

            foreach (var book in books.OrderBy(t => t))
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext db, int year)
        {
            var sb = new StringBuilder();

            var books = db.Books
                .Select(a => new
                {
                    a.BookId,
                    a.Title,
                    a.ReleaseDate
                })
                .AsEnumerable()
                .Where(x => DateTime.Parse(x.ReleaseDate.ToString()).Year != year)
                .OrderBy(x => x.BookId);

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext db)
        {
            var sb = new StringBuilder();

            var books = db.Books
                .Where(x => x.Price > 40)
                .Select(a => new
                {
                    a.Title,
                    a.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            books.ForEach(book => sb.AppendLine($"{book.Title} - ${book.Price:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        {
            var sb = new StringBuilder();

            var books = db.Books
                .Select(a => new
                {
                    Title = a.Title,
                    a.AgeRestriction
                })
                .ToList()
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(a => a.Title);

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext db)
        {
            var sb = new StringBuilder();

            var books = db.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .Select(x => new
                {
                    x.BookId,
                    x.Title
                })
                .OrderBy(x => x.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
