using UserManagementAPI.Models;
using Microsoft.AspNetCore.Identity;
using UserManagementAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
namespace UserManagementAPI.Repository.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly Project5Context context;

        public UserRepository(Project5Context context)
        {
            this.context = context;
        }
        public async Task<string> AddUserAsync(User user)
        {
            if (user == null)
            {
                return "User data is null";
            }

            // Check if the user already exists
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Username == user.Username );
            if (existingUser != null)
            {
                return $"User with this email address already exists: {existingUser.Name}";
            }

            // Hash the user's password
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordHash); // Assuming user has a Password property

            // Add the user to the context and save
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return "User registered successfully";
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
