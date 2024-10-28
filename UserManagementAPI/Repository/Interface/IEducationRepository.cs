using UserManagementAPI.Models;

namespace UserManagementAPI.Repository.Interface
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> GetAllEducationsAsync();
        Task<Education> GetEducationByIdAsync(int id);
        Task AddEducationAsync(Education education);
        Task UpdateEducationAsync(Education education);
        Task DeleteEducationAsync(int id);
    }
}
