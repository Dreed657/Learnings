using System.Xml.Serialization;

namespace CarDealer.XMLTools.DTO.Exports
{
    [XmlType("car")]
    public class ExportCarModelDTO
    {
        [XmlElement("make")]
        public string make { get; set; }

        [XmlElement("model")]
        public string model { get; set; }

        [XmlElement("travelled-distance")]
        public long travelledDistance { get; set; }
    }
}
