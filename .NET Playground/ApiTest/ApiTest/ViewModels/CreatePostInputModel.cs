using System.ComponentModel.DataAnnotations;

namespace ApiTest.ViewModels
{
    public class CreatePostInputModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(5)]
        public string Content { get; set; }
    }
}
