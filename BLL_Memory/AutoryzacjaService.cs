using BLL;
using BLL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Memory
{
    public class AutoryzacjaService : IAutoryzacjaService
    {
        private readonly IConfiguration _configuration;

        public AutoryzacjaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoggedUserDTO Login(LoginFormDTO loginFormDTO)
        {
            if(loginFormDTO.Login.Trim().ToLower() == "admin" && loginFormDTO.Password == "Password")
            {
                var jwtSettings = _configuration.GetSection("JWT");
                var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

                Claim[] claims = [
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim(ClaimTypes.Role, "GetOsoby")
                    ];

                double tokenLifetime = double.Parse(jwtSettings["ExpiresInMinutes"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(tokenLifetime),
                    Issuer = jwtSettings["Issuer"],
                    Audience = jwtSettings["Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string tokenString = tokenHandler.WriteToken(token);
                return new LoggedUserDTO(tokenString);
            }

            throw new ApplicationException("Podano niepoprawny Login lub Hasło.");
        }
    }
}
