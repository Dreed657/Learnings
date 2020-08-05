using System.Globalization;
using System.Linq;
using AutoMapper;
using Cinema.XMLTools;

namespace Cinema.DataProcessor
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using ImportDto;
    using Data.Models;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var moviesResult = JsonConvert.DeserializeObject<ImportMovieDTO[]>(jsonString);
            var movies = new List<Movie>();

            foreach (var dto in moviesResult)
            {
                if (IsValid(dto))
                {

                    var movie = Mapper.Map<Movie>(dto);

                    movies.Add(movie);

                    sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var hallsResults = JsonConvert.DeserializeObject<ImportHallDTO[]>(jsonString);

            foreach (var hallDto in hallsResults)
            {
                if (IsValid(hallDto))
                {
                    var hall = Mapper.Map<Hall>(hallDto);
                    
                    context.Halls.Add(hall);
                    context.SaveChanges();

                    AddSeatsToHall(context, hall.Id, hallDto.Seats);

                    sb.AppendLine(string.Format(SuccessfulImportHallSeat, hallDto.Name, GetProjectionType(hall), hallDto.Seats));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString().Trim();
        }

        private static string GetProjectionType(Hall hall)
        {
            var result = "Normal";

            if (hall.Is3D && hall.Is4Dx)
                result = "4Dx/3D";
            else if (hall.Is3D)
                result = "3D";
            else if (hall.Is4Dx)
                result = "4Dx";

            return result;
        }

        private static void AddSeatsToHall(CinemaContext context, int hallId, int count)
        {
            var seats = new List<Seat>();

            for (var i = 0; i < count; i++)
            {
                seats.Add(new Seat { HallId = hallId });
            }

            context.Seats.AddRange(seats);
            context.SaveChanges();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var projectionsResult = XmlConverter.Deserializer<ImportProjectionsDTO>(xmlString, "Projections");

            foreach (var projectionsDto in projectionsResult)
            {
                if (IsValid(projectionsDto) && IsMovieExists(context, projectionsDto.MovieId) && IsHallExists(context, projectionsDto.HallId))
                {
                    var projection = Mapper.Map<Projection>(projectionsDto);

                    context.Projections.Add(projection);
                    context.SaveChanges();

                    sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title, projection.DateTime.ToString("MM/dd/yyyy")));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }
            
            return sb.ToString().Trim();
        }

        private static bool IsHallExists(CinemaContext context, int hallId)
        {
            return context.Halls.Any(x => x.Id == hallId);
        }

        private static bool IsMovieExists(CinemaContext context, int movieId)
        {
            return context.Movies.Any(x => x.Id == movieId);
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var customersResult = XmlConverter.Deserializer<ImportCustomerTicketDTO>(xmlString, "Customers");

            foreach (var customerDto in customersResult)
            {
                if (IsValid(customerDto))
                {
                    var customer = Mapper.Map<Customer>(customerDto);

                    context.Customers.Add(customer);
                    context.SaveChanges();

                    var ticketsCount = AddTicketToCustomer(context, customer.Id, customerDto.Tickets);

                    sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, ticketsCount));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString().Trim();
        }

        private static int AddTicketToCustomer(CinemaContext context, int customerId, IEnumerable<ImportTicketDTO> customerDtoTickets)
        {
            var tickets = customerDtoTickets
                .Where(x => IsValid(x) && IsProjectionExists(context, x.ProjectionId))
                .Select(x => new Ticket
                {
                    CustomerId = customerId,
                    ProjectionId = x.ProjectionId,
                    Price = x.Price
                })
                .ToList();

            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            return tickets.Count;
        }

        private static bool IsProjectionExists(CinemaContext context, int projectionId)
        {
            return context.Projections.Any(x => x.Id == projectionId);
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}