using Microsoft.IdentityModel.Tokens;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;
using NotesApp.Dtos.UserDtos;
using NotesApp.Mappers;
using NotesApp.Services.Interfaces;
using NotesApp.Shared.CustomUserExceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NotesApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetAllUsers()
        {
            List<User> users = _userRepository.GetAll();

            List<UserDto> userDtos = new List<UserDto>();

            foreach(User user in users)
            {
                UserDto userDto = user.ToUserDto();
                userDtos.Add(userDto);
            }

            return userDtos;
        }
        public UserDto GetById(int id)
        {
            User user = _userRepository.GetById(id);

            if(user == null)
                throw new UserNotFoundException($"User with the {id} was not found");

            UserDto userDto = user.ToUserDto();

            return userDto;
        }
        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            ValidateUser(registerUserDto);

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerUserDto.Password);
            byte[] hashBytes = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hash = Encoding.ASCII.GetString(hashBytes);

            User user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Username = registerUserDto.UserName,
                Password = hash
            };

            _userRepository.Add(user);
        }
        public void UpdateUser(UpdateUserDto updateUserDto)
        {
            User user = _userRepository.GetById(updateUserDto.Id);

            if(user == null)
                throw new UserNotFoundException($"User with the {updateUserDto.Id} was not found");

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Username = updateUserDto.UserName;

            _userRepository.Update(user);
        }
        public void DeleteUser(int id)
        {
            User user = _userRepository.GetById(id);

            if(user == null)
                throw new UserNotFoundException($"User with the {id} was not found");

            _userRepository.Delete(user);
        }
        public string LoginUser(LoginUserDto loginUserDto)
        {
            if(string.IsNullOrEmpty(loginUserDto.UserName) || string.IsNullOrEmpty(loginUserDto.Password))
            {
                throw new UserDataException("Username and password are required fields!");
            }

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(loginUserDto.Password);
            byte[] hashBytes = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hash = Encoding.ASCII.GetString(hashBytes);

            User userDb = _userRepository.GetUserByUsername(loginUserDto.UserName);
            if(userDb == null)
                throw new UserNotFoundException("User was not found");

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes("Our very very secret secret key!");

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                SecurityAlgorithms.HmacSha256Signature),
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, userDb.Username),
                        new Claim("userFullName", $"{userDb.FirstName} {userDb.LastName}")
                    }
                )
            };

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(token);
        }
        private void ValidateUser(RegisterUserDto registerUserDto)
        {
            if (string.IsNullOrEmpty(registerUserDto.UserName) || string.IsNullOrEmpty(registerUserDto.Password) || string.IsNullOrEmpty(registerUserDto.ConfirmPassword))
            {
                throw new UserDataException("Username and password are required fields!");
            }
            if (registerUserDto.UserName.Length > 30)
            {
                throw new UserDataException("Username: maximum lenght is 30 characters");
            }
            if (!string.IsNullOrEmpty(registerUserDto.FirstName) && registerUserDto.FirstName.Length > 50)
            {
                throw new UserDataException("FirstName: maximum lenght is 50 characters");
            }
            if (!string.IsNullOrEmpty(registerUserDto.LastName) && registerUserDto.LastName.Length > 50)
            {
                throw new UserDataException("LastName: maximum lenght is 50 characters");
            }
            if (registerUserDto.Password != registerUserDto.ConfirmPassword)
            {
                throw new UserDataException("Passwords must match!");
            }

            var userDb = _userRepository.GetUserByUsername(registerUserDto.UserName);
            if (userDb != null)
            {
                throw new UserDataException("Username is already in use, try another one");
            }
        }
    }
}
