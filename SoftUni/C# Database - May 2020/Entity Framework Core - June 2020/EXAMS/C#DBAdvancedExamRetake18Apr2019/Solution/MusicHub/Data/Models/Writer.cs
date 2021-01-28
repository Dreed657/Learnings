﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [RegularExpression("[A-Z][a-z]+ [A-Z][a-z]+")]
        public string Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
