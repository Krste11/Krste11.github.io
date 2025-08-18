namespace MoviesApp.DTOs
{
    public class CreateNewMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
    }
}
