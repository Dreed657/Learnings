using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class ExportCategoriesByCountDTO
    {
        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("count")]
        public int count { get; set; }

        [XmlElement("averagePrice")]
        public decimal averagePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal totalRevenues { get; set; }
    }
}
