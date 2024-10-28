using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.DTO;
using UserManagementAPI.Models;
using UserManagementAPI.Repository.Interface;
using UserManagementAPI.Repository.Services;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Userapicontrollers : ControllerBase
    {
        private readonly IUserRepository context;

        public Userapicontrollers(IUserRepository context)
        {
            this.context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult> CreateUser([FromBody]UserDto userDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                UserId = userDto.UserId,
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
                Username = userDto.Username,
                PhoneNumber = userDto.PhoneNumber,
                Gender = userDto.Gender,
                Bio = userDto.Bio
            };
            string data  = await context.AddUserAsync(user);
            return Ok(data);

        }
    }
}
