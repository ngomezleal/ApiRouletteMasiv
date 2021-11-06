using ApiRouletteMasiv.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiRouletteMasiv
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<Roulette> Roulettes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Bet> Bets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roulette>(entity =>
            {
                entity.ToTable("Roulette");

                entity.HasIndex(e => e.Status)
                    .IsUnique(false);
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.HasIndex(e => e.UserId)
                    .IsUnique(false);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.ToTable("Bet");

                entity.HasIndex(e => e.IdRoulette)
                    .IsUnique(false);

                entity.HasIndex(e => e.UserId)
                    .IsUnique(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}