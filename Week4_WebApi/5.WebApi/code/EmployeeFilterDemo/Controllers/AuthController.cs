using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeFilterDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]  // Allows requests without auth
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetToken()
        {
            var token = GenerateJSONWebToken(1001, "Admin");
            return Ok(token);
        }

        private string GenerateJSONWebToken(int userId, string userRole)
        {
            // ✅ SAME long key as Program.cs
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVeryLongJWTSecretKey123456"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10), // valid for 10 minutes
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
