using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.DTO;
using UserManagementAPI.Repository.Interface;
using UserManagementAPI.Repository.Services;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Logincontrollers : ControllerBase
    {
        private readonly IAuthInterface authService;

        public Logincontrollers(IAuthInterface _authService)
        {
            authService = _authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var result = await authService.IsAuthenticated(loginDto);
            return result.StartsWith("Authentication successful") ? Ok(result) : Unauthorized(result);
        }
    }
}
