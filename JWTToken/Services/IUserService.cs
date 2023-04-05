using JWTToken.Models;

namespace JWTToken.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        void Update(User user);
    }
}
