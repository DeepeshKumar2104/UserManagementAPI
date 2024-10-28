using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagementAPI.DTO;
using UserManagementAPI.Repository.Interface;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthInterface authService;

    public AccountController(IAuthInterface authService)
    {
        this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var token = await authService.IsAuthenticated(loginDto);
        return token == null ? Unauthorized("Invalid credentials") : Ok(new { Token = token });
    }
}
