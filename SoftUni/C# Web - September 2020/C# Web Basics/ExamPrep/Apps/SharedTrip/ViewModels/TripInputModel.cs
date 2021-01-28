using System;

namespace SharedTrip.ViewModels
{
    public class TripInputModel
    {
        public string startPoint { get; set; }

        public string endPoint { get; set; }

        public string departureTime { get; set; }

        public string imagePath { get; set; }

        public int seats { get; set; }

        public string description { get; set; }
    }
}
