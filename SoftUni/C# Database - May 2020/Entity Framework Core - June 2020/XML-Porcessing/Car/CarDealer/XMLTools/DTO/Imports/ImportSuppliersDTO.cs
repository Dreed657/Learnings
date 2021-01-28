using System.Xml.Serialization;

namespace CarDealer.XMLTools.DTO.Imports
{
    [XmlType("Supplier")]
    public class ImportSuppliersDTO
    {
        [XmlElement("name")]
        public string name { get; set; }
        
        [XmlElement("isImporter")]
        public bool isImporter { get; set; }
    }
}
