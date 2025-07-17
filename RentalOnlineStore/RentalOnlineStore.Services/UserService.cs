using Avenga.RentalStore.DataAccess.Repository;
using RentalOnlineStore.Domain.DomainModals;
using RentalOnlineStore.Services.Interfaces;

namespace RentalOnlineStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByCardNumber(string cardNumber)
        {
            return _userRepository.GetByCardNumber(cardNumber);
        }

        public void Create(User user)
        {
            user.CreatedOn = DateTime.UtcNow;
            // Replace _userRepository.Create(user); with appropriate logic
            // Since IUserRepository does not have a Create method, consider using Add or another method if available.
            // If not, you may need to add an Add method to IUserRepository and its implementation.
            throw new NotImplementedException("Create method is not implemented in IUserRepository. Please add an appropriate method to persist the user.");
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public bool IsSubscriptionExpired(int userId)
        {
            var user = _userRepository.GetById(userId);
            return user.IsSubscriptionExpired;
        }
    }
    
}