using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Respository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
