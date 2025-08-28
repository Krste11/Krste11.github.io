using MovieApp.Dtos.MovieDtos;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieDto> GetAllMovies();
        MovieDto GetMovieByIdFromRoute(int id);
        MovieDto GetMovieByIdFromQuery(int id);
        List<MovieDto> FilterMovies(string? genre, int? year);
        void AddMovie(AddMovieDto addMovieDto);
        void UpdateMovie(AddMovieDto updateMovieDto);
        void DeleteMovieFromBody(int id);
        void DeleteMovieFromRoute(int id);
    }
}
