using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.XMLTools.DTO.Imports
{
    [XmlType("Car")]
    public class ImportCarsDTO
    {
        [XmlElement("make")]
        public string make { get; set; }

        [XmlElement("model")]
        public string model { get; set; }

        [XmlElement("TraveledDistance")]
        public int traveledDistance { get; set; }

        [XmlArray("parts")]
        public ImportCarPartDTO[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class ImportCarPartDTO
    {
        [XmlAttribute("id")]
        public int partId { get; set; }
    }
}
