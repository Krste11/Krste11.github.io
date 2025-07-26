using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalOnlineStore.DataAccess.Data;
using RentalOnlineStore.Domain.Models;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Services
{
    public class RentalService : IRentalService
    {
        public List<Rental> GetRentalsByUserId(int userId)
        {
            return StaticDb.Rentals.Where(r => r.UserId == userId && r.ReturnedOn == DateTime.MinValue).ToList();
        }

        public bool ReturnMovie(int rentalId)
        {
            var rental = StaticDb.Rentals.FirstOrDefault(r => r.Id == rentalId);
            if (rental == null) return false;

            rental.ReturnedOn = DateTime.Now;

            var movie = StaticDb.Movies.FirstOrDefault(m => m.Id == rental.MovieId);
            if (movie != null)
            {
                movie.Quantity++;
                movie.IsAvailable = true;
            }

            return true;
        }
    }
}
