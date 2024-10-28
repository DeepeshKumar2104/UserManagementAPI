using UserManagementAPI.Models;

namespace UserManagementAPI.Repository.Interface
{
    public interface IAddressRepository
    {
        
        Task AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address, int userId);
        Task DeleteAddressAsync(int id);
    }
}
