using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FootballManager.Data.Models
{
    public class Player
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(80)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20)]
        public string Position { get; set; }

        [Required]
        [Range(0, 10)]
        public byte Speed { get; set; }


        [Required]
        [Range(0, 10)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public Player()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new HashSet<UserPlayer>();
        }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}
