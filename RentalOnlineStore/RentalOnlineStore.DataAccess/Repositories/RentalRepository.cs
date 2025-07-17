using RentalOnlineStore.Domain.DomainModals;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RentalOnlineStore.DataAccess;
using RentalOnlineStore.DataAccess.Repositories;

namespace Avenga.RentalStore.DataAccess.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly MovieDbContext _context;

        public RentalRepository(MovieDbContext context)
        {
            _context = context;
        }

        public bool Rent(int movieId, int userId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId && m.IsAvailable && m.Quantity > 0);
            if (movie == null)
                return false;

            var user = _context.Users.FirstOrDefault(u => u.Id == userId && !u.IsSubscriptionExpired);
            if (user == null)
                return false;

            var rental = new Rental
            {
                MovieId = movieId,
                UserId = userId,
                RentedOn = System.DateTime.Now,
                ReturnedOn = System.DateTime.MinValue
            };

            _context.Rentals.Add(rental);

            // Reduce available quantity
            movie.Quantity--;
            if (movie.Quantity == 0)
                movie.IsAvailable = false;

            _context.SaveChanges();

            return true;
        }

        public bool ReturnRental(int rentalId, int userId)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.Id == rentalId && r.UserId == userId && r.ReturnedOn == System.DateTime.MinValue);
            if (rental == null)
                return false;

            rental.ReturnedOn = System.DateTime.Now;

            // Increase movie quantity
            var movie = _context.Movies.FirstOrDefault(m => m.Id == rental.MovieId);
            if (movie != null)
            {
                movie.Quantity++;
                movie.IsAvailable = true;
            }

            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Rental> GetActiveRentalsByUser(int userId)
        {
            return _context.Rentals
                .Where(r => r.UserId == userId && r.ReturnedOn == System.DateTime.MinValue)
                .ToList();
        }

        public Rental GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Rental Add(Rental rental)
        {
            throw new NotImplementedException();
        }

        public void Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
