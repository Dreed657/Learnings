using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class GameDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000000000000)]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }
        
        [Required]
        public string[] Tags { get; set; }
    }
}
