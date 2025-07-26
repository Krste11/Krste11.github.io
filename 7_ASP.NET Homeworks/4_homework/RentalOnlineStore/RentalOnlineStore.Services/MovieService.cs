using RentalOnlineStore.DataAccess.Data;
using RentalOnlineStore.Domain.Models;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Services
{
    public class MovieService : IMovieService
    {
        public List<Movie> GetAllMovies()
        {
            return StaticDb.Movies;
        }

        public Movie GetMovieById(int id)
        {
            return StaticDb.Movies.FirstOrDefault(m => m.Id == id);
        }

        public bool RentMovie(int movieId, int userId)
        {
            var movie = StaticDb.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null || movie.Quantity <= 0) return false;

            movie.Quantity--;
            if (movie.Quantity == 0) movie.IsAvailable = false;

            var rental = new Rental
            {
                Id = StaticDb.Rentals.Count + 1,
                MovieId = movieId,
                UserId = userId,
                RentedOn = DateTime.Now,
                ReturnedOn = DateTime.MinValue // Not returned yet
            };

            StaticDb.Rentals.Add(rental);
            return true;
        }
    }
}
