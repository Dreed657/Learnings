using System;
using System.Globalization;

namespace SharedTrip.ViewModels
{
    public class TripViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        public int UsedSeats { get; set; }

        public int AvailableSeats => this.Seats - this.UsedSeats;

        public string DepartureTimeToString => this.DepartureTime.ToString(CultureInfo.GetCultureInfo("bg-BG"));
    }
}
