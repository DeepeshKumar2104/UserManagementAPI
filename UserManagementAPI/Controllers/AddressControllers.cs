using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] Address address)
        {
            if (address == null)
            {
                return BadRequest("Address is null.");
            }

            try
            {
                await _context.AddAddressAsync(address);
                return Ok("Address added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] Address address, [FromQuery] int userId)
        {
            if (address == null || id != address.AddressId)
            {
                return BadRequest("Invalid address data.");
            }

            try
            {
                await _context.UpdateAddressAsync(address, userId);
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

        [HttpDelete("{id}")]
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
