using RentalOnlineStore.DataAccess.Data;
using RentalOnlineStore.Domain.Models;
using RentalOnlineStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RentalOnlineStore.DataAccess;

namespace RentalOnlineStore.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public bool RentMovie(int movieId, int userId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null || movie.Quantity <= 0) return false;

            movie.Quantity--;
            if (movie.Quantity == 0) movie.IsAvailable = false;

            var rental = new Rental
            {
                MovieId = movieId,
                UserId = userId,
                RentedOn = DateTime.Now,
                ReturnedOn = DateTime.MinValue
            };

            _context.Rentals.Add(rental);
            _context.SaveChanges(); // Save all changes to the DB
            return true;
        }
    }
}
