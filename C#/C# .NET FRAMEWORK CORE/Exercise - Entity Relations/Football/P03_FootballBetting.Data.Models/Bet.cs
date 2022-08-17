using P03_FootballBetting.Data.Models.Enumerables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public Prediction Prediction { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        virtual public User User { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        virtual public Game Game { get; set; }
    }
}
