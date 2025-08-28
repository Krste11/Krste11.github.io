using MovieApp.DataAccess;
using MovieApp.Domain.Models;
using MovieApp.Dtos.MovieDtos;
using MovieApp.Mappers;
using MovieApp.Services.Interfaces;
using MovieApp.Shared.CustomExceptions;

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
            var moviesDb = _movieRepository.GetAll();
            return moviesDb.Select(x => x.ToNoteDto()).ToList();
        }
        public MovieDto GetMovieByIdFromQuery(int id)
        {
            if (id <= 0)
                throw new Exception("Id must be greater than zero");

            Movie movieDb = _movieRepository.GetById(id);

            if (movieDb == null)
                throw new MovieDataException($"Movie with {id} does not exist");

            if (movieDb == null)
                throw new MovieNotFoundException($"Movie with {id} not found");

            MovieDto movieDto = movieDb.ToNoteDto();
            return movieDto;
        }
        public MovieDto GetMovieByIdFromRoute(int id)
        {
            if (id <= 0)
                throw new Exception("Id must be greater than zero");

            Movie movieDb = _movieRepository.GetById(id);

            if (movieDb == null)
                throw new MovieDataException($"Movie with {id} does not exist");

            if (movieDb == null) 
                throw new MovieNotFoundException($"Movie with {id} not found");

            MovieDto movieDto = movieDb.ToNoteDto();
            return movieDto;
        }
        public List<MovieDto> FilterMovies(string? genre, int? year)
        {
            if (string.IsNullOrEmpty(genre) && year == null)
                throw new Exception("You have to send at least one filter parameter");

            var moviesDb = _movieRepository.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(genre))
                moviesDb = moviesDb.Where(x => x.Genre.ToString().ToLower() == genre.ToLower());

            if (year != null)
                moviesDb = moviesDb.Where(x => x.Year == year);

            return moviesDb.Select(x => x.ToNoteDto()).ToList();
        }
        public void AddMovie(AddMovieDto addMovieDto)
        {
            if (string.IsNullOrEmpty(addMovieDto.Title))
                throw new Exception("Title is required");

            if (addMovieDto.Description != null && addMovieDto.Description.Length > 250)
                throw new Exception("Description can not be more than 250 characters");

            if (addMovieDto.Year < 1800 || addMovieDto.Year > DateTime.Now.Year)
                throw new Exception("Year is not valid");

            Movie movie = addMovieDto.ToMovie();
            _movieRepository.Add(movie);
        }
        public void UpdateMovie(AddMovieDto updateMovieDto)
        {
            Movie movieDb = _movieRepository.GetById(updateMovieDto.Id);

            if(movieDb == null)
                throw new MovieNotFoundException($"Movie with {updateMovieDto.Id} not found");

            if(updateMovieDto.Description.Length > 250)
                throw new Exception("Description can not be more than 250 characters");

            if (string.IsNullOrEmpty(updateMovieDto.Title))
                throw new Exception("Title is required");

            if(updateMovieDto.Year < 1800 || updateMovieDto.Year > DateTime.Now.Year)
                throw new Exception("Year is not valid");

            movieDb.Title = updateMovieDto.Title;
            movieDb.Description = updateMovieDto.Description;
            movieDb.Year = updateMovieDto.Year;
            movieDb.Genre = updateMovieDto.Genre;
            _movieRepository.Update(movieDb);
        }
        public void DeleteMovieFromBody(int id)
        {
            Movie movieDb = _movieRepository.GetById(id);

            if (movieDb == null) 
                throw new MovieNotFoundException($"Movie with {id} not found");

            _movieRepository.Delete(id);
        }
        public void DeleteMovieFromRoute(int id)
        {
            Movie movieDb = _movieRepository.GetById(id);

            if (movieDb == null)
                throw new MovieNotFoundException($"Movie with {id} not found");

            _movieRepository.Delete(id);
        }
    }
}
