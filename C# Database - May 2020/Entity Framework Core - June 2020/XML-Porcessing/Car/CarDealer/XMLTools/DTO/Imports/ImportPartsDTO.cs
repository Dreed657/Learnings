using System.Xml.Serialization;

namespace CarDealer.XMLTools.DTO.Imports
{
    [XmlType("Part")]
    public class ImportPartsDTO
    {
        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("price")]
        public decimal price { get; set; }

        [XmlElement("quantity")]
        public int quantity { get; set; }

        [XmlElement("supplierId")]
        public int supplierId { get; set; }
    }
}
