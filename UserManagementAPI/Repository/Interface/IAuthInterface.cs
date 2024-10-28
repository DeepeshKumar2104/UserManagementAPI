using UserManagementAPI.DTO;
using UserManagementAPI.Models;

namespace UserManagementAPI.Repository.Interface
{
    public interface IAuthInterface
    {
        Task<string> IsAuthenticated(LoginDTO loginDto);
    }
}
