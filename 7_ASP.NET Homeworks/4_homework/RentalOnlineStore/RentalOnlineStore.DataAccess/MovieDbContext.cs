using Microsoft.EntityFrameworkCore;
using RentalOnlineStore.Domain.Enums;
using RentalOnlineStore.Domain.Models;

namespace RentalOnlineStore.DataAccess
{
    // Imav error so StaticDb so hasData, zatoa datata se naoga tuka
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

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "John Doe",
                    Age = 30,
                    CardNumber = "123456",
                    CreatedOn = new DateTime(2024, 5, 27), // Replace with a fixed value instead of DateTime.Now
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Monthly
                },
                new User
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    Age = 25,
                    CardNumber = "789012",
                    CreatedOn = new DateTime(2024, 6, 27),
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Yearly
                }
            );

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Avengers",
                    Genre = Genre.Action,
                    Language = (int)Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2012, 5, 4),
                    Length = new TimeSpan(2, 23, 0),
                    AgeRestriction = 13,
                    Quantity = 5
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Notebook",
                    Genre = Genre.Drama,
                    Language = (int)Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2004, 6, 25),
                    Length = new TimeSpan(2, 4, 0),
                    AgeRestriction = 13,
                    Quantity = 3
                }
            );

            // Seed Casts
            modelBuilder.Entity<Cast>().HasData(
                new Cast { Id = 1, MovieId = 1, Name = "Robert Downey Jr.", Part = Part.Actor },
                new Cast { Id = 2, MovieId = 1, Name = "Joss Whedon", Part = Part.Director },
                new Cast { Id = 3, MovieId = 2, Name = "Ryan Gosling", Part = Part.Actor }
            );

            // Seed Rentals
            modelBuilder.Entity<Rental>().HasData(
                new Rental
                {
                    Id = 1,
                    MovieId = 1,
                    UserId = 1,
                    RentedOn = new DateTime(2024, 7, 24), // Replace with fixed date
                    ReturnedOn = DateTime.MinValue // Use 0001-01-01T00:00:00
                }
            );
        }
    }
}
