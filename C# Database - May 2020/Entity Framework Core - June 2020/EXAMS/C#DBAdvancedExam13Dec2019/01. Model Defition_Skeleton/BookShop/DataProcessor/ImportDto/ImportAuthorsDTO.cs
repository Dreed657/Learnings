using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorsDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ImportBookDTO[] Books { get; set; }
    }

    public class ImportBookDTO
    {
        public int Id { get; set; }
    }
}
