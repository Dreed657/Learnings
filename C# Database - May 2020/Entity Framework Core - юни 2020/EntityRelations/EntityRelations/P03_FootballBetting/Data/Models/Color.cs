using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Team> PrimaryKitTeams { get; set; } = new HashSet<Team>();

        public virtual ICollection<Team> SecondaryKitTeams { get; set; } = new HashSet<Team>();
    }
}
