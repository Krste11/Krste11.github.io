using System.Security.Principal;
using System.Xml;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Modals
{
    public class User : BaseEntity
    {
        public User()
        {
            
        }

        public User(string username, string password, Role role)
        {
            UserName = username;
            Password = password;
            Role = role;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public override string Print()
        {
            return $"{UserName} with the role of {Role}";
        }
    }
}
