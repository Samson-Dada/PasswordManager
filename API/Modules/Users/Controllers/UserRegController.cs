using API.Modules.User.Services;
using API.Shared.Models;
using API.Shared.Models.UserDto;
using API.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Users.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UserRegController : ControllerBase
    {
        private readonly ILogger<UserRegController> _logger;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public UserRegController(ILogger<UserRegController> logger, IUserService userService,
            IAuthService authService)
        {
            _authService = authService;
            _userService = userService;
            _logger = logger;

        }


        [HttpPost]
        [Route("registeration")]
        public async Task<IActionResult> Register(UserForSignupDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _authService.Registration(model, Roles.User);
                if (status == 0)
                {
                    return BadRequest(message);
                }
                return CreatedAtAction(nameof(Register), model);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserForLoginDto loginModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid payload");
                }
                var (status, message) = await _authService.Login(loginModel);
                if (status == 0)
                {
                    return BadRequest(message);
                }
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

    }
}
