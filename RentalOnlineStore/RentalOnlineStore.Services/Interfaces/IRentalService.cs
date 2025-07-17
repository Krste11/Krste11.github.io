using RentalOnlineStore.Domain.DomainModals;

namespace RentalOnlineStore.Services.Interfaces
{
    public interface IRentalService
    {
        Rental RentMovie(int movieId, int userId);
        void ReturnMovie(int rentalId);
        IEnumerable<Rental> GetUserRentals(int userId);
        IEnumerable<Rental> GetActiveRentals();
        string? GetRentalById(int id);
    }
}