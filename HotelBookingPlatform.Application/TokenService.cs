using HotelBookingPlatform.Core.Entities.Identity;
using HotelBookingPlatform.Core.Services.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Application
{
    public class TokenService : ITokenService
    {
        public async Task<string> CreateToken(AppUsers user, UserManager<AppUsers> userManager)
        {
            // 1. Header  --> security algorithm (e.g., HS256) , type of token (JWT)
            // 2. Payload --> 1. Registered claims (iss, sub, aud, exp, iat), 2. Private claims (custom data)
            // 3. Signature (Key) --> HMACSHA256( base64UrlEncode(header) + "." + base64UrlEncode(payload), secretKey)  --> Install Package Authentication.JwtBearer

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.DisplayName),
            };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_key")));
            var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_validIssuer"),
            audience: Environment.GetEnvironmentVariable("JWT_validAudience"),
            expires: DateTime.UtcNow.AddDays(7),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
