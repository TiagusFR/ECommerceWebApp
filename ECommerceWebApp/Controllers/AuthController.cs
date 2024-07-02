using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            if (string.IsNullOrEmpty(loginUser.Email) || string.IsNullOrEmpty(loginUser.Password))
            {
                return BadRequest("Email and password are required.");
            }

            var user = await _userService.AuthenticateAsync(loginUser.Email, loginUser.Password);

            if (user == null)
                return Unauthorized();

            // Ensure user.Role and user.Id are not null
            if (string.IsNullOrEmpty(user.Role))
            {
                return Unauthorized("User role is missing.");
            }

            if (!user.Id.HasValue)
            {
                return Unauthorized("User ID is missing.");
            }

            var token = _jwtService.GenerateToken(user.Id.Value.ToString(), user.Role);

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User registerUser)
        {
            if (string.IsNullOrEmpty(registerUser.Email) || string.IsNullOrEmpty(registerUser.Password))
            {
                return BadRequest("Email and password are required.");
            }

            var registerDto = new RegisterDto
            {
                Email = registerUser.Email,
                Password = registerUser.Password
            };

            var user = await _userService.RegisterAsync(registerDto);

            if (user == null)
                return BadRequest("Registration failed.");

            return Ok(user);
        }
    }
}
