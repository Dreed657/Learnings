﻿using System;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public string Prediction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
