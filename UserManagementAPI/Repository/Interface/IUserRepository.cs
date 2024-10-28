using UserManagementAPI.Models;

namespace UserManagementAPI.Repository.Interface
{
    public interface IUserRepository
    {
 
        Task<string> AddUserAsync(User user);
        Task<string> UpdateUserAsync(User user);
        Task<string> DeleteUserAsync(int id);
    }
}
