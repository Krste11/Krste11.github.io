using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Enums;
using MovieApp.Domain.Models;

namespace MovieApp.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options) {}

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
        }
    }
}
