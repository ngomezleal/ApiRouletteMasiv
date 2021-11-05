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
        public DbSet<Wallet> UserWallets { get; set; }
        public DbSet<Bet> UserBets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roulette>(entity =>
            {
                entity.ToTable("Roulette");

                entity.HasIndex(e => e.UserId)
                    .IsUnique(false);

                entity.HasIndex(e => e.Status)
                    .IsUnique(false);
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("UserWallet");

                entity.HasIndex(e => e.UserId)
                    .IsUnique(false);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.ToTable("UserBet");

                entity.HasIndex(e => e.IdRoulette)
                    .IsUnique(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}