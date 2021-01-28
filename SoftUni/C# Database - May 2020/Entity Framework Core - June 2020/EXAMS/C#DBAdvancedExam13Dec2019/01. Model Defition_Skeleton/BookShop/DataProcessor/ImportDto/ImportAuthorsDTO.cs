using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorsDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<ImportBookDto> Books { get; set; } = new List<ImportBookDto>();
    }

    public class ImportBookDto
    {
        public int? Id { get; set; }
    }
}
