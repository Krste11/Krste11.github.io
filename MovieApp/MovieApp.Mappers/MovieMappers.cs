using MovieApp.Domain.Models;
using MovieApp.Dtos.MovieDtos;

namespace MovieApp.Mappers
{
    public static class MovieMappers
    {
        public static MovieDto ToMovieDto(this Movie movie)
        {
            return new MovieDto
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }

        public static Movie ToMovie(this AddMovieDto addMovieDto)
        {
            return new Movie
            {
                Title = addMovieDto.Title,
                Description = addMovieDto.Description,
                Year = addMovieDto.Year,
                Genre = addMovieDto.Genre
            };
        }
    }
}
