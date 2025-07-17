using Microsoft.EntityFrameworkCore;
using RentalOnlineStore.Data;
using RentalOnlineStore.Domain.DomainModals;

namespace RentalOnlineStore.DataAccess
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasData(StaticDb.Movies);

            modelBuilder.Entity<User>()
                .HasData(StaticDb.Users);

            modelBuilder.Entity<Cast>()
                .HasData(StaticDb.Casts);

            modelBuilder.Entity<Rental>()
                .HasData(StaticDb.Rentals);
        }
    }
}
