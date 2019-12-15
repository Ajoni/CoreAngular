using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Services.User.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
