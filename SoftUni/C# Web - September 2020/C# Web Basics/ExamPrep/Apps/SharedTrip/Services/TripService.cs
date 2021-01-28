using SharedTrip.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext db;

        public TripService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool AddToTrip(string tripId, string userId)
        {
            if (this.db.UserTrips.Any(x => x.TripId == tripId && x.UserId == userId))
            {
                return false;
            }

            var entity = new UserTrip()
            {
                UserId = userId,
                TripId = tripId,
            };
            this.db.UserTrips.Add(entity);
            this.db.SaveChanges();
            return true;
        }

        public string CreateTrip(TripInputModel model)
        {
            var entity = new Trip()
            {
                StartPoint = model.startPoint,
                EndPoint = model.endPoint,
                DepartureTime = DateTime.ParseExact(model.departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = model.imagePath,
                Seats = model.seats,
                Description = model.description,
            };
            
            this.db.Trips.Add(entity);
            this.db.SaveChanges();

            return entity.Id;
        }

        public IEnumerable<TripViewModel> GetAllTrips()
        {
            return this.db.Trips.Select(x => new TripViewModel()
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint, 
                Seats = x.Seats, // Return available seats.
                DepartureTime = x.DepartureTime,
                UsedSeats = x.Trips.Count(),
            }).ToList();
        }

        public TripDetailViewModel GetTripDetails(string tripId)
        {
            return this.db.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new TripDetailViewModel
                {
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    EndPoint = x.EndPoint,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    StartPoint = x.StartPoint,
                    UsedSeats = x.Trips.Count(),
                })
                .FirstOrDefault();
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new { x.Seats, takenSeats = x.Trips.Count() })
                .FirstOrDefault();

            return trip.Seats - trip.takenSeats > 0;
        }
    }
}
