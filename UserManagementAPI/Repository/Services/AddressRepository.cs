using System;
using System.Threading.Tasks;
using UserManagementAPI.Models;
using UserManagementAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace UserManagementAPI.Repository.Services
{
    public class AddressRepository : IAddressRepository
    {
        private readonly Project5Context _context;

        public AddressRepository(Project5Context context)
        {
            _context = context;
        }

        public async Task AddAddressAsync(Address address)
        {
            try
            {
                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                throw new Exception("An error occurred while adding the address.", ex);
            }
        }

        public async Task UpdateAddressAsync(Address address, int userId)
        {
            try
            {
                var existingAddress = await _context.Addresses
                                                    .FirstOrDefaultAsync(a => a.AddressId == address.AddressId && a.UserId == userId);
                if (existingAddress != null)
                {
                    existingAddress.Street = address.Street;
                    existingAddress.City = address.City;
                    existingAddress.State = address.State;
                    existingAddress.ZipCode = address.ZipCode;
                    existingAddress.Country = address.Country;

                    _context.Addresses.Update(existingAddress);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("Address not found for the user.");
                }
            }
            catch (KeyNotFoundException ex)
            {
                // Log the exception if needed
                throw new KeyNotFoundException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                throw new Exception("An error occurred while updating the address.", ex);
            }
        }

        public async Task DeleteAddressAsync(int id)
        {
            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == id);
                if (address != null)
                {
                    _context.Addresses.Remove(address);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("Address not found for the user.");
                }
            }
            catch (KeyNotFoundException ex)
            {
                // Log the exception if needed
                throw new KeyNotFoundException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                throw new Exception("An error occurred while deleting the address.", ex);
            }
        }
    }
}
