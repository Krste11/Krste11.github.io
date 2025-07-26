using RentalOnlineStore.DataAccess.Data;
using RentalOnlineStore.Domain.Models;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Services
{
    public class UserService : IUserService
    {
        public User GetUserByCardNumber(string cardNumber)
        {
            return StaticDb.Users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }

        public List<User> GetAllUsers()
        {
            return StaticDb.Users;
        }
    }

}
