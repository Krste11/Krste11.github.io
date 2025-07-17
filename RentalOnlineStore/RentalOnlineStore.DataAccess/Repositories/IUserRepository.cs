using RentalOnlineStore.Domain.DomainModals;

namespace Avenga.RentalStore.DataAccess.Repository
{
    public interface IUserRepository
    {
        User GetByCardNumber(string cardNumber);
        User GetById(int id);
        Task<User> GetByIdAsync(int id);
        User GetUserByCardNumber(string cardNumber);
        void Login(string cardNumber);
        void Update(User user);
    }
}