using System.Xml.Serialization;

namespace CarDealer.XMLTools.DTO.Imports
{
    [XmlType("Sale")]
    public class ImportSalesDTO
    {
        [XmlElement("carId")]
        public int carId { get; set; }

        [XmlElement("customerId")]
        public int customerId { get; set; }

        [XmlElement("discount")]
        public int discount { get; set; }
    }
}
