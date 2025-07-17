using RentalOnlineStore.Domain.DomainModals;
using System.Collections.Generic;

namespace Avenga.RentalStore.DataAccess.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);

        // Additional movie-specific methods
        IEnumerable<Movie> GetAvailableMovies();
        IEnumerable<Movie> GetByGenre(string genre);
    }
}
