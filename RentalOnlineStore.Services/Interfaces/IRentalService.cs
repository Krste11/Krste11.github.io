using RentalOnlineStore.Domain.Models;

namespace RentalOnlineStore.Services.Interfaces
{
    public interface IRentalService
    {
        List<Rental> GetRentalsByUserId(int userId);
        bool ReturnMovie(int rentalId);
    }
}
