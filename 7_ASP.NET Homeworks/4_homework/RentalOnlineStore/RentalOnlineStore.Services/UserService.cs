using RentalOnlineStore.DataAccess;
using RentalOnlineStore.DataAccess.Data;
using RentalOnlineStore.Domain.Models;
using RentalOnlineStore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RentalOnlineStore.Services
{
    public class UserService : IUserService
    {
        private readonly MovieDbContext _context;

        public UserService(MovieDbContext context)
        {
            _context = context;
        }

        public User GetUserByCardNumber(string cardNumber)
        {
            return _context.Users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
