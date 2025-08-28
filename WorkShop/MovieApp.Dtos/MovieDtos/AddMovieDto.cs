using MovieApp.Domain.Enums;

namespace MovieApp.Dtos.MovieDtos
{
    public class AddMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
