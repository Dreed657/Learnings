namespace CarDealer.XMLTools.DTO.Exports
{
    using System.Xml.Serialization;

    namespace CarDealer.XMLTools.DTO.Exports
    {
        [XmlType("car")]
        public class ExportCarBMWModelDTO
        {
            [XmlAttribute("id")]
            public int id { get; set; }

            [XmlAttribute("model")]
            public string model { get; set; }

            [XmlAttribute("travelled-distance")]
            public long travelledDistance { get; set; }
        }
    }

}
