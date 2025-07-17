using Avenga.RentalStore.DataAccess.Repository;
using RentalOnlineStore.DataAccess.Repositories;
using RentalOnlineStore.Domain.DomainModals;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public RentalService(
            IRentalRepository rentalRepository,
            IMovieRepository movieRepository,
            IUserRepository userRepository)
        {
            _rentalRepository = rentalRepository;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<Rental> GetActiveRentals()
        {
            // Get all rentals that haven't been returned yet
            return _rentalRepository.GetAll()
                .Where(r => r.ReturnedOn == null)
                .ToList();
        }

        public string? GetRentalById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetUserRentals(int userId)
        {
            // Get all rentals for a specific user that are still active
            return _rentalRepository.GetByUserId(userId)
                .Where(r => r.ReturnedOn == null)
                .ToList();
        }

        public Rental RentMovie(int movieId, int userId)
        {
            // 1. Validate movie exists and is available
            var movie = _movieRepository.GetById(movieId);
            if (movie == null)
            {
                throw new Exception($"Movie with ID {movieId} not found");
            }

            if (movie.Quantity <= 0)
            {
                throw new Exception($"Movie '{movie.Title}' is not available for rent");
            }

            // 2. Validate user exists and has valid subscription
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found");
            }

            if (user.IsSubscriptionExpired)
            {
                throw new Exception($"User '{user.FullName}' has an expired subscription");
            }

            // 3. Create new rental record
            var rental = new Rental
            {
                MovieId = movieId,
                UserId = userId,
                RentedOn = DateTime.UtcNow,
                ReturnedOn = default(DateTime)
            };

            // 4. Update movie inventory
            movie.Quantity--;
            if (movie.Quantity <= 0)
            {
                movie.IsAvailable = false;
            }

            // 5. Save changes
            _movieRepository.Update(movie);
            return _rentalRepository.Add(rental);
        }

        public void ReturnMovie(int rentalId)
        {
            // 1. Get the rental record
            var rental = _rentalRepository.GetById(rentalId);
            if (rental == null)
            {
                throw new Exception($"Rental with ID {rentalId} not found");
            }

            // 2. Check if already returned
            if (rental.ReturnedOn != default(DateTime))
            {
                throw new Exception($"Rental with ID {rentalId} was already returned on {rental.ReturnedOn}");
            }

            // 3. Update rental record
            rental.ReturnedOn = DateTime.UtcNow;
            _rentalRepository.Update(rental);

            // 4. Update movie inventory
            var movie = _movieRepository.GetById(rental.MovieId);
            if (movie != null)
            {
                movie.Quantity++;
                if (movie.Quantity > 0 && !movie.IsAvailable)
                {
                    movie.IsAvailable = true;
                }
                _movieRepository.Update(movie);
            }
        }
    }
}