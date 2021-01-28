using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        string CreateTrip(TripInputModel model);

        IEnumerable<TripViewModel> GetAllTrips();

        TripDetailViewModel GetTripDetails(string tripId);

        bool AddToTrip(string tripId, string userId);

        bool HasAvailableSeats(string tripId);
    }
}
