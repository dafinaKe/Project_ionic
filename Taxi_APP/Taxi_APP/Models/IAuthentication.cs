using System.Security.Claims;
namespace Taxi_APP.Models
{
    public interface IAuthentication
    {
        string GenerateJwtToken(ApplicationUser user);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        string GenerateRefreshToken();
        /* string ValidateToken(string token);*/
    }
}
