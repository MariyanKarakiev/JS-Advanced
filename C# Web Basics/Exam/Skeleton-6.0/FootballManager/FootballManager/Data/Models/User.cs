using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FootballManager.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new HashSet<UserPlayer>();
        }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}

