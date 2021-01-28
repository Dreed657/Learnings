using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerTicketDTO
    {
        [Required]
        [XmlElement("FirstName")]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [XmlElement("LastName")]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [XmlElement("Age")]
        [Range(12, 110)]
        public int Age { get; set; }

        [Required]
        [XmlElement("Balance")]
        [Range(typeof(decimal), "0.01", "100000")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public ImportTicketDTO[] Tickets { get; set; }
    }

    [XmlType("Ticket")]
    public class ImportTicketDTO
    {
        [XmlElement("ProjectionId")]
        [Required]
        public int ProjectionId { get; set; }

        [Required]
        [XmlElement("Price")]
        [Range(typeof(decimal), "0.01", "100000")]
        public decimal Price { get; set; }
    }
}
