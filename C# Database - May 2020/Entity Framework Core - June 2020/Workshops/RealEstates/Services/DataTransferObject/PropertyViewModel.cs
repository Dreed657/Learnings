using System.Collections.Generic;
using Models;

namespace Services.DataTransferObject
{
    public class PropertyViewModel
    {
        public string District { get; set; }

        public string BuildingType { get; set; }

        public string PropertyType { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public int? Year { get; set; }

        public string Floor { get; set; }

        public string Url { get; set; }
    }
}
