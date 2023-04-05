using JWTToken.Models;

namespace JWTToken.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
