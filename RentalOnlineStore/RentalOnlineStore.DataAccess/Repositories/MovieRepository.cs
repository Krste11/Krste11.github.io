using RentalOnlineStore.Domain.DomainModals;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RentalOnlineStore.DataAccess;

namespace Avenga.RentalStore.DataAccess.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetAvailableMovies()
        {
            return _context.Movies.Where(m => m.IsAvailable).ToList();
        }

        public IEnumerable<Movie> GetByGenre(string genre)
        {
            return _context.Movies
                .Where(m => m.Genre.ToLower() == genre.ToLower())
                .ToList();
        }
    }
}
