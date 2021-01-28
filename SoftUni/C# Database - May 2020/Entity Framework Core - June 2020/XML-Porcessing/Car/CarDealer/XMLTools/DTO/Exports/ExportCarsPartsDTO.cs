using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.XMLTools.DTO.Exports
{
    [XmlType("car")]
    public class ExportCarsWithPartsDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public List<CarPart> Parts { get; set; }
    }

    [XmlType("part")]
    public class CarPart
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
