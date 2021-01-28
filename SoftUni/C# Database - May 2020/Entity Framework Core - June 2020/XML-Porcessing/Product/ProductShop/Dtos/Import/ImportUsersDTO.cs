using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("User")]
    public class ImportUsersDTO
    {
        [XmlElement("firstName")]
        public string firstName { get; set; }

        [XmlElement("lastName")]
        public string lastName { get; set; }

        [XmlElement("age")]
        public int? age { get; set; }
    }
}
