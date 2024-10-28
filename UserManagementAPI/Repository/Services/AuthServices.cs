//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using UserManagementAPI.DTO;
//using UserManagementAPI.Models;
//using UserManagementAPI.Repository.Interface;

//namespace UserManagementAPI.Repository.Services
//{
//    public class AuthServices : IAuthInterface
//    {
//        private readonly Project5Context context;

//        public AuthServices(Project5Context context)
//        {
//            this.context = context;
//        }
//        public async Task<string> IsAuthenticated(LoginDTO loginDto)
//        {
//            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
//            {
//                return "Invalid login credentials.";
//            }

//            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email );
//            if (user == null)
//            {
//                return "User not found.";
//            }

//            var passwordHasher = new PasswordHasher<User>();
//            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

//            if (passwordVerificationResult == PasswordVerificationResult.Success)
//            {
//                return "Authentication successful.";
//            }
//            else
//            {
//                return "Invalid password.";
//            }
//        }

//    }
//}


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagementAPI.DTO;
using UserManagementAPI.Models;
using UserManagementAPI.Repository.Interface;

namespace UserManagementAPI.Repository.Services
{
    public class AuthServices : IAuthInterface
    {
        private readonly Project5Context context;
        private readonly IConfiguration configuration;

        public AuthServices(Project5Context context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task<string> IsAuthenticated(LoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return "Invalid login credentials.";
            }

            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null)
            {
                return "User not found.";
            }

            var passwordHasher = new PasswordHasher<User>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                // Generate JWT token
                var token = GenerateJwtToken(user);
                return token; // Return the generated token
            }
            else
            {
                return "Invalid password.";
            }
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("Secret");
            var issuer = jwtSettings.GetValue<string>("Issuer");
            var audience = jwtSettings.GetValue<string>("Audience");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

