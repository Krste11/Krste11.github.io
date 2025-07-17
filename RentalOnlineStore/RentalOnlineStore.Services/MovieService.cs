using Avenga.RentalStore.DataAccess.Repository;
using RentalOnlineStore.DataAccess.Repositories;
using RentalOnlineStore.Domain.DomainModals;
using RentalOnlineStore.Domain.Enums;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public IEnumerable<Movie> GetByGenre(Genre genre)
        {
            return _movieRepository.GetAll()
                .Where(m => m.Genre == genre.ToString());
        }

        public IEnumerable<Movie> GetAvailableMovies()
        {
            return _movieRepository.GetAll()
                .Where(m => m.IsAvailable && m.Quantity > 0);
        }

        public void Create(Movie movie)
        {
            _movieRepository.Create(movie);
        }

        public void Update(Movie movie)
        {
            _movieRepository.Update(movie);
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }
    }
}