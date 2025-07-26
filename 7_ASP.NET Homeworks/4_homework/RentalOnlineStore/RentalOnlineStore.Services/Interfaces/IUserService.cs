using RentalOnlineStore.Domain.Models;

namespace RentalOnlineStore.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByCardNumber(string cardNumber);
        List<User> GetAllUsers();
    }
}
