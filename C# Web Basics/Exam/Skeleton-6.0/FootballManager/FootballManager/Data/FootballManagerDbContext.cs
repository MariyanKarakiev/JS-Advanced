namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballManagerDbContext : DbContext
    {
        public FootballManagerDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=FootballManager;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=True;");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<UserPlayer> UserPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserPlayer>()
                .HasKey(k => new { k.PlayerId, k.UserId });
        }
    }
}
