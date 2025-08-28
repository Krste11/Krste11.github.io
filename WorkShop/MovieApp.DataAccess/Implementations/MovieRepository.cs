using MovieApp.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace MovieApp.DataAccess.Implementations
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieAppDbContext _movieAppDbContext;
        public MovieRepository(MovieAppDbContext context)
        {
            _movieAppDbContext = context;
        }
        public List<Movie> GetAll()
        {
            return _movieAppDbContext.Movies.ToList();
        }
        public Movie GetById(int id)
        {
            return _movieAppDbContext.Movies.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Movie entity)
        {
            _movieAppDbContext.Movies.Add(entity);
            _movieAppDbContext.SaveChanges();
        }
        public void Update(Movie entity)
        {
            _movieAppDbContext.Movies.Update(entity);
            _movieAppDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            _movieAppDbContext.Movies.Remove(GetById(id));
            _movieAppDbContext.SaveChanges();
        }
    }
}
