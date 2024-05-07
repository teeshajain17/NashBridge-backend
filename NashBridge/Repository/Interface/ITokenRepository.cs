using Microsoft.AspNetCore.Identity;

namespace NashBridge.Repository.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
