using SharedTrip.Services;
using SharedTrip.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Globalization;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        [HttpGet]
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.startPoint))
            {
                return this.Error("Starting point is mandatory to create trip.");
            }

            if (string.IsNullOrEmpty(model.endPoint))
            {
                return this.Error("End point is mandatory to create trip.");
            }

            if (!DateTime.TryParseExact(model.departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return this.Error("Departure time must be in correct format.");
            }

            if (model.seats < 2 || model.seats > 6)
            {
                return this.Error("Seats must be between 2 and 6.");
            }

            if (string.IsNullOrEmpty(model.description) || model.description.Length > 80)
            {
                return this.Error("Description must be less then 80 characters.");
            }

            this.tripService.CreateTrip(model);
            return this.Redirect("/Trips/All");
        }

        [HttpGet]
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var models = this.tripService.GetAllTrips();
            return this.View(models);
        }

        [HttpGet]
        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = this.tripService.GetTripDetails(tripId);
            return this.View(model);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripService.HasAvailableSeats(tripId))
            {
                return this.Error("No more seats available.");
            }

            var userId = this.GetUserId();

            if(!this.tripService.AddToTrip(tripId, userId))
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }

            return this.Redirect("/Trips/All");
        }
    }
}
