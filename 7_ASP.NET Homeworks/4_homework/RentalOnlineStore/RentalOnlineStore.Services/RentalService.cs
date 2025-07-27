using RentalOnlineStore.DataAccess;
using RentalOnlineStore.Domain.Models;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Services
{
    public class RentalService : IRentalService
    {
        private readonly MovieDbContext _context;

        public RentalService(MovieDbContext context)
        {
            _context = context;
        }

        public List<Rental> GetRentalsByUserId(int userId)
        {
            return _context.Rentals
                .Where(r => r.UserId == userId && r.ReturnedOn == DateTime.MinValue)
                .ToList();
        }

        public bool ReturnMovie(int rentalId)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.Id == rentalId);
            if (rental == null) return false;

            rental.ReturnedOn = DateTime.Now;

            var movie = _context.Movies.FirstOrDefault(m => m.Id == rental.MovieId);
            if (movie != null)
            {
                movie.Quantity++;
                movie.IsAvailable = true;
            }

            _context.SaveChanges();
            return true;
        }
    }
}
