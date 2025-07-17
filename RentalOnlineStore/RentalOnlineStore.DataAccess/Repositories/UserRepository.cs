using RentalOnlineStore.Domain.DomainModals;
using Microsoft.EntityFrameworkCore;
using RentalOnlineStore.DataAccess;

namespace Avenga.RentalStore.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _context;

        public UserRepository(MovieDbContext context)
        {
            _context = context;
        }

        public User GetByCardNumber(string cardNumber)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByCardNumber(string cardNumber)
        {
            return _context.Users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }

        public void Login(string cardNumber)
        {
            var user = GetUserByCardNumber(cardNumber);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid card number.");
            }
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
