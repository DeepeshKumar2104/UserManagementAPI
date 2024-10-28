using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagementAPI.DTO;
using UserManagementAPI.Models;
using UserManagementAPI.Repository.Interface;

namespace UserManagementAPI.Repository.Services
{
    public class AuthServices : IAuthInterface
    {
        private readonly Project5Context context;

        public AuthServices(Project5Context context)
        {
            this.context = context;
        }
        public async Task<string> IsAuthenticated(LoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return "Invalid login credentials.";
            }

            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email && u =>u.Us);
            if (user == null)
            {
                return "User not found.";
            }

            var passwordHasher = new PasswordHasher<User>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                return "Authentication successful.";
            }
            else
            {
                return "Invalid password.";
            }
        }

    }
}
