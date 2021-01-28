using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportUserCountDTO
    {
        [XmlElement("count")]
        public int count { get; set; }

        [XmlArray("users")]
        public ExportUserDTO[] Users { get; set; }
    }

    [XmlType("User")]
    public class ExportUserDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportProductCountDTO soldProducts { get; set; }
    }

    public class ExportProductCountDTO
    {
        [XmlElement("count")]
        public int count { get; set; }

        [XmlArray("products")]
        public ExportProductDTO[] Products { get; set; }
    }

    [XmlType("Product")]
    public class ExportProductDTO
    {
        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("price")]
        public decimal price { get; set; }
    }
}
