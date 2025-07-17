using RentalOnlineStore.Domain.DomainModals;

namespace RentalOnlineStore.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        User GetByCardNumber(string cardNumber);
        void Create(User user);
        void Update(User user);
        bool IsSubscriptionExpired(int userId);
    }
}