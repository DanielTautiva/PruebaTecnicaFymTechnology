using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnicaFymTechnology.Jwt
{
    public class Jwt : IJwt
    {

        public IConfiguration configuration;

        public Jwt(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        public string GenerarToken(string Email, string UserName)
        {
            var claims = new[]
            {
                new Claim("email", Email),
                new Claim("username", UserName)
            };

            var llave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Get<string>() ?? string.Empty));

            var credentials = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
