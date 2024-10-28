using UserManagementAPI.Models;

namespace UserManagementAPI.Repository.Interface
{
    public interface IEmploymentRepository
    {
        Task<IEnumerable<Employment>> GetAllEmploymentsAsync();
        Task<Employment> GetEmploymentByIdAsync(int id);
        Task AddEmploymentAsync(Employment employment);
        Task UpdateEmploymentAsync(Employment employment);
        Task DeleteEmploymentAsync(int id);
    }
}
