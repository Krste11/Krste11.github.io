using RentalOnlineStore.Domain.Models;

namespace RentalOnlineStore.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        bool RentMovie(int movieId, int userId);
    }
}
