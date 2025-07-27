using RentalOnlineStore.Domain;
using RentalOnlineStore.Domain.Enums;
using RentalOnlineStore.Domain.Models;

namespace RentalOnlineStore.DataAccess.Data
{
    public static class StaticDb
    {
        public static List<User> Users { get; set; }
        public static List<Movie> Movies { get; set; }
        public static List<Cast> Casts { get; set; }
        public static List<Rental> Rentals { get; set; }

        static StaticDb()
        {
            LoadUsers();
            LoadMovies();
            LoadCasts();
            LoadRentals();
        }

        private static void LoadUsers()
        {
            Users = new List<User>
            {
                new User
                {
                Id = 1,
                FullName = "John Doe",
                Age = 30,
                CardNumber = "123456",
                CreatedOn = DateTime.Now.AddMonths(-2),
                IsSubscriptionExpired = false,
                SubscriptionType = SubscriptionType.Monthly,
                },
                new User
                {
                Id = 2,
                FullName = "Jane Smith",
                Age = 25,
                CardNumber = "789012",
                CreatedOn = DateTime.Now.AddMonths(-1),
                IsSubscriptionExpired = false,
                SubscriptionType = SubscriptionType.Yearly
                }
            };
        }
        private static void LoadMovies()
        {
            Movies = new List<Movie>
        {
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
        };
        }
        private static void LoadCasts()
        {
            Casts = new List<Cast>
        {
            new Cast { Id = 1, MovieId = 1, Name = "Robert Downey Jr.", Part = Part.Actor },
            new Cast { Id = 2, MovieId = 1, Name = "Joss Whedon", Part = Part.Director },
            new Cast { Id = 3, MovieId = 2, Name = "Ryan Gosling", Part = Part.Actor }
        };
        }
        private static void LoadRentals()
        {
            Rentals = new List<Rental>
        {
            new Rental
            {
                Id = 1,
                MovieId = 1,
                UserId = 1,
                RentedOn = DateTime.Now.AddDays(-3),
                ReturnedOn = new DateTime(0001, 01, 01, 00, 00, 00)
            }
        };
        }
    }
}
