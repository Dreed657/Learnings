using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserDto
    {
        [Required]
        [RegularExpression(@"^([A-Z]{1}[a-z]{1,}) ([A-Z]{1}[a-z]{1,})$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        [Required]
        public CardDto[] Cards { get; set; }
    }

    public class CardDto
    {
        [Required]
        [RegularExpression(@"^(\d{4}) (\d{4}) (\d{4}) (\d{4})$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})$")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
