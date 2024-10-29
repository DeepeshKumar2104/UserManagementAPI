using UserManagementAPI.Models;

namespace UserManagementAPI.Repository.Interface
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> GetAllEducationsAsync();
        Task AddEducationAsync(Education education);
        Task UpdateEducationAsync(Education education,int userid);
        Task DeleteEducationAsync(int id);
    }
}
