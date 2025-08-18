namespace MoviesApp.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
    }
}
