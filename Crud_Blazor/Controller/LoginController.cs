using Crud_Blazor.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Blazor.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string userId="",string pass="")
        {
            UserModal login = new UserModal();
            login.userName = userId;
            login.PassWord = pass;

            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if(user.userName != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJSONWebToken(UserModal user)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var Credential = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.userName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: Credential);

      
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        private UserModal AuthenticateUser(UserModal login)
        {
            var user = new UserModal();
            if(login.userName == "softprodigy" && login.PassWord =="12345")
            {
                user = new UserModal { userName = "softprodigy", Email = "softprodig@gmail.com", PassWord = "12345", Role = "Admin" };
            }
            return user;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult post([FromBody] string value)
        {
            try
            {
                return Ok(value);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
    }
}
