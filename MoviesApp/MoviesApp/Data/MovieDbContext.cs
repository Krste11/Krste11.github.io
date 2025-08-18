using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Inception",
                Description = "A skilled thief is offered a chance to have his past crimes forgiven if he can implant an idea into a target's subconscious.",
                Year = new DateTime(2010, 1, 1),
                Genre = "Science Fiction"
            },
            new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men form a deep bond over years, finding solace and eventual redemption through acts of decency.",
                Year = new DateTime(1994, 1, 1),
                Genre = "Drama"
            },
            new Movie
            {
                Id = 3,
                Title = "The Dark Knight",
                Description = "Batman faces his greatest psychological and physical tests when he goes up against the Joker.",
                Year = new DateTime(2008, 1, 1),
                Genre = "Drama"
            },
            new Movie
            {
                Id = 4,
                Title = "Interstellar",
                Description = "A team of explorers travels through a wormhole in space in an attempt to ensure humanity's survival.",
                Year = new DateTime(2014, 1, 1),
                Genre = "Adventure"
            },
            new Movie
            {
                Id = 5,
                Title = "Parasite",
                Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between a wealthy family and a destitute clan.",
                Year = new DateTime(2019, 1, 1),
                Genre = "Thriller"
            }
        };
            modelBuilder
                .Entity<Movie>()
                .HasData(Movies);
        }
    }
}
