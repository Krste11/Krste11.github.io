using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Enums;
using MovieApp.Domain.Models;

namespace MovieApp.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Title)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(x => x.Description)
                .HasMaxLength(250);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Year)
                .IsRequired();

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Matrix",
                    Description = "A hacker discovers reality is a simulation.",
                    Year = 1999,
                    Genre = Genre.Action
                },
                new Movie
                {
                    Id = 2,
                    Title = "Superbad",
                    Description = "Two friends try to enjoy one last party before graduation.",
                    Year = 2007,
                    Genre = Genre.Comedy
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Shawshank Redemption",
                    Description = "Two imprisoned men bond over years, finding solace and redemption.",
                    Year = 1994,
                    Genre = Genre.Drama
                },
                new Movie
                {
                    Id = 4,
                    Title = "The Conjuring",
                    Description = "Paranormal investigators help a family terrorized by dark forces.",
                    Year = 2013,
                    Genre = Genre.Horror
                }
            );
        }
    }
}
