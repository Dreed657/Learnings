using System;
using System.Xml.Serialization;

namespace CarDealer.XMLTools.DTO.Imports
{
    [XmlType("Customer")]
    public class ImportCustomersDTO
    {
        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("birthDate")]
        public DateTime birthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool isYoungDriver { get; set; }
    }
}
