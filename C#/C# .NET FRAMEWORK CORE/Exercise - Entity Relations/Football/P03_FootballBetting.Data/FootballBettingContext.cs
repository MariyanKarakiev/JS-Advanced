﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        //For judge
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        //To configure connection to server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }
        }

        //To concigure database relations (DDL)
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PlayerStatistic>(e =>
            {
                e.HasKey(ps => new { ps.GameId, ps.PlayerId });
            });

            builder.Entity<Team>(e =>
            {
                e.HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(t => t.SecondaryKitColor)
                  .WithMany(c => c.SecondaryKitTeams)
                  .HasForeignKey(t => t.SecondaryKitColorId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Game>(g =>
                {
                    g.HasOne(g => g.HomeTeam)
                     .WithMany(t => t.HomeGames)
                     .HasForeignKey(g => g.HomeTeamId)
                     .OnDelete(DeleteBehavior.Restrict);

                    g.HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
