using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CimeqApi.DTOs;
using CimeqApi.Models;
using CimeqApi.ModelView;
using CimeqApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CimeqApi.Controllers
{
    [ApiController]
    [Route("/login")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult SignIn([FromBody] LoginDTO login)
        {
            var client = ClientService.SignIn(login.Email, login.Password);

            if (client != null)
            {
                
                var token = GenerateJwtToken(client);
                return Ok(new ClientToken
                {
                    Id = client.Id,
                    Email = client.Email,
                    Username = client.Username,
                    LastName = client.LastName,
                    Token = token,
                });
            }

            return BadRequest(new { Message = "Login and/or password not found" });
        }

        private string GenerateJwtToken(Client user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration["AppSettings:Secret"];
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                //Expires = DateTime.UtcNow.AddDays(1),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
