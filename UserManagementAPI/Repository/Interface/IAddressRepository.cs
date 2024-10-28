using UserManagementAPI.Models;

namespace UserManagementAPI.Repository.Interface
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);
    }
}
