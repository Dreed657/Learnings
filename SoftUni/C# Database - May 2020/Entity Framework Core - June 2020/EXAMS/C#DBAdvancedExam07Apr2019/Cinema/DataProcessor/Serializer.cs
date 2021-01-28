using System.Linq;
using Cinema.DataProcessor.ExportDto;
using Cinema.XMLTools;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Any()))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = x.Projections.SelectMany(p => p.Tickets.Select(t => new
                    {
                        t.Customer.FirstName,
                        t.Customer.LastName,
                        Balance =t.Customer.Balance.ToString("F2")
                    }))
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToArray()
                })
                
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(movies, Formatting.Indented);
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(t => t.Price))
                .Take(10)
                .Select(x => new ExportCustomersDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(t => t.Price).ToString("F2"),
                    TimeSpend = TimeSpan.FromSeconds(
                            x.Tickets.Sum(s => s.Projection.Movie.Duration.TotalSeconds))
                        .ToString(@"hh\:mm\:ss")
                })
                .ToArray();

            return XmlConverter.Serialize<ExportCustomersDto>(customers, "Customers");
        }
    }
}