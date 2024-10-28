using UserManagementAPI.Models;

namespace UserManagementAPI.Repository.Interface
{
    public interface IUserRepository
    {
 
        Task<string> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
