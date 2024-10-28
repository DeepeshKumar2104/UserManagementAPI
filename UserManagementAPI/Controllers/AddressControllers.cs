using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagementAPI.DTO;
using UserManagementAPI.Models;
using UserManagementAPI.Repository.Interface;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressControllers : ControllerBase
    {
        private readonly IAddressRepository _context;

        public AddressControllers(IAddressRepository context)
        {
            _context = context;
        }

        [HttpPost("create-address")]
        public async Task<IActionResult> AddAddress([FromBody] AddressDTO address)
        {
            if (address == null)
            {
                return BadRequest("Address is null.");
            }

            try
            {
                var addresss = new Address
                {
                    UserId = address.UserId,
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    CreatedAt = DateTime.UtcNow, // Setting created date as current UTC time
                    UpdatedAt = DateTime.UtcNow  // Initializing updated date as current UTC time
                };
                await _context.AddAddressAsync(addresss);
                return Ok("Address added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("update-address{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] AddressDTO address, [FromQuery] int userId)
        {
            if (address == null || id != address.AddressId)
            {
                return BadRequest("Invalid address data.");
            }

            try
            {
                var updateaddress = new Address 
                {
                    UserId = address.UserId,
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow
                };

                await _context.UpdateAddressAsync(updateaddress, userId);
                return Ok("Address updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("delete-address{id}")]
        public async Task<IActionResult> DeleteAddress( int userId)
        {
            try
            {
                await _context.DeleteAddressAsync( userId);
                return Ok("Address deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
