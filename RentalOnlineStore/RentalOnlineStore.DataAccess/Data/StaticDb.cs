using RentalOnlineStore.Domain.DomainModals;
using System;
using System.Collections.Generic;

namespace RentalOnlineStore.Data
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Inception",
                Genre = "Sci-Fi",
                Language = "English",
                IsAvailable = true,
                ReleaseDate = new DateTime(2010, 7, 16),
                Length = new TimeSpan(2, 28, 0),
                AgeRestriction = 13,
                Quantity = 5
            },
            new Movie
            {
                Id = 2,
                Title = "The Godfather",
                Genre = "Crime",
                Language = "English",
                IsAvailable = true,
                ReleaseDate = new DateTime(1972, 3, 24),
                Length = new TimeSpan(2, 55, 0),
                AgeRestriction = 18,
                Quantity = 3
            }
        };

        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FullName = "John Doe",
                Age = 25,
                CardNumber = "1234-5678-9012-3456",
                CreatedOn = DateTime.Now.AddMonths(-6),
                IsSubscriptionExpired = false,
                SubscriptionType = "Premium"
            },
            new User
            {
                Id = 2,
                FullName = "Jane Smith",
                Age = 30,
                CardNumber = "9876-5432-1098-7654",
                CreatedOn = DateTime.Now.AddYears(-1),
                IsSubscriptionExpired = true,
                SubscriptionType = "Basic"
            }
        };

        public static List<Cast> Casts = new List<Cast>
        {
            new Cast
            {
                Id = 1,
                MovieId = "1",
                Name = "Leonardo DiCaprio",
                Part = "Cobb"
            },
            new Cast
            {
                Id = 2,
                MovieId = "2",
                Name = "Marlon Brando",
                Part = "Don Vito Corleone"
            }
        };

        public static List<Rental> Rentals = new List<Rental>
        {
            new Rental
            {
                Id = 1,
                MovieId = 1,
                UserId = 1,
                RentedOn = DateTime.Now.AddDays(-5),
                ReturnedOn = DateTime.Now.AddDays(-1)
            },
            new Rental
            {
                Id = 2,
                MovieId = 2,
                UserId = 2,
                RentedOn = DateTime.Now.AddDays(-10),
                ReturnedOn = DateTime.Now.AddDays(-2)
            }
        };
    }
}
