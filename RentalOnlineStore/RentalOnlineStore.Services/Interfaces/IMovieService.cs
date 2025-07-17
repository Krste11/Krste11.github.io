using RentalOnlineStore.Domain.DomainModals;
using RentalOnlineStore.Domain.Enums;

namespace RentalOnlineStore.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        IEnumerable<Movie> GetByGenre(Genre genre);
        IEnumerable<Movie> GetAvailableMovies();
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}