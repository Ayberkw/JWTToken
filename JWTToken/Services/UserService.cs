using System.Collections.Generic;
using System.Linq;
using JWTToken.Models;
using JWTToken.Services;

namespace JWTToken.Services
{
    public class UserService : IUserService
    {
        // In this example, we're using hardcoded user data
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe", Username = "johndoe", Password = "password", Role = "User" },
            new User { Id = 2, FirstName = "Jane", LastName = "Doe", Username = "janedoe", Password = "password", Role = "Admin" }
        };


        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

        public void Update(User user)
        {
            var index = _users.FindIndex(u => u.Username == user.Username);
            if (index != -1)
            {
                _users[index] = user;
            }
        }
        public User GetById(int id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }
    }
}
