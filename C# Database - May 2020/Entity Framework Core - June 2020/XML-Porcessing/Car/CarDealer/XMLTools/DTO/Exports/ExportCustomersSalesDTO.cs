using System.Xml.Serialization;

namespace CarDealer.XMLTools.DTO.Exports
{
    [XmlType("customer")]
    public class ExportCustomersSalesDTO
    {
        [XmlAttribute("full-name")]
        public string fullName { get; set; }

        [XmlAttribute("bought-cars")]
        public int count { get; set; }

        [XmlAttribute("spent-money")]
        public decimal spendMoney { get; set; }
    }
}
