using MovieApp.Domain.Enums;

namespace MovieApp.Dtos.MovieDtos
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
