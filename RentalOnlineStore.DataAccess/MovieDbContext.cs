using Microsoft.EntityFrameworkCore;
using RentalOnlineStore.DataAccess.Data;
using RentalOnlineStore.Domain.Models;

namespace RentalOnlineStore.DataAccess
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(StaticDb.Users);

            modelBuilder.Entity<Movie>()
                .HasData(StaticDb.Movies);

            modelBuilder.Entity<Cast>()
                .HasData(StaticDb.Casts);

            modelBuilder.Entity<Rental>()
                .HasData(StaticDb.Rentals);
        }
    }
}