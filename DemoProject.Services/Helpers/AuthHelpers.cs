using DemoProject.Dtos;
using DemoProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoProject.Helpers
{
    public interface IAuthHelpers
    {
        string GenerateJWTToken(TokenGenerateDto user);
    }
    public class AuthHelpers : IAuthHelpers
    {
        string? issuer = "";
        string? issuerKey = "";
        public AuthHelpers(IConfiguration configuration)
        {
            this.issuer = configuration["jwt:issuer"];
            this.issuerKey = configuration["jwt:key"];
        }
        public string GenerateJWTToken(TokenGenerateDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] { new Claim(ClaimTypes.Name, user.Id), new Claim(ClaimTypes.Role, user.Role) };
            var tokenHandler = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
            string token = new JwtSecurityTokenHandler().WriteToken(tokenHandler);
            return token;
        }
    }
}
