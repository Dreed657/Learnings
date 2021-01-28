using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        [RegularExpression(@"^([(A-Z0-9]*|[a-z0-9]*)$")]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        [RegularExpression(@"^(\d{3})-(\d{3})-(\d{4})$")]
        public string Phone { get; set; }

        public List<int> Tasks { get; set; }
    }
}
