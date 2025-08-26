using MovieApp.DataAccess;
using MovieApp.Domain.Models;
using MovieApp.Dtos.MovieDtos;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieDto> GetAllMovies()
        {
            var movieDb = _movieRepository.GetAll();
        }
        public void DeleteMovieFromBody(int id)
        {
            throw new NotImplementedException();
        }
        public void DeleteMovieFromRoute(int id)
        {
            throw new NotImplementedException();
        }
        public List<MovieDto> FilterMovies(string? genre, int? year)
        {
            throw new NotImplementedException();
        }
        public void AddMovie(AddMovieDto addMovieDto)
        {
            throw new NotImplementedException();
        }
        public void UpdateMovie(AddMovieDto updateMovieDto)
        {
            throw new NotImplementedException();
        }
        public MovieDto GetMovieByIdFromQuery(int id)
        {
            throw new NotImplementedException();
        }
        public MovieDto GetMovieByIdFromRoute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
