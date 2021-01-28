namespace Services.DataTransferObject
{
    public class PropertyCreateDto
    {
        public string District { get; set; }

        public int Size { get; set; }

        public int? Year { get; set; }

        public int Price { get; set; }

        public string Url { get; set; }

        public string PropertyType { get; set; }

        public string BuildingType { get; set; }

        public int? Floor { get; set; }

        public int? MaxFloors { get; set; }
    }
}
