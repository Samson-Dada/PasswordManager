using API.Shared.Models.UserDto;
using Microsoft.AspNetCore.Mvc;
using API.Shared.Models.AdminDto;
using API.Shared.Role;
using API.Shared.Authentications.Services;

namespace API.Modules.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRegController : ControllerBase
    {
        private readonly IAdminAuthService _adminAuthService;
        private readonly ILogger<AdminRegController> _logger;
        public AdminRegController(IAdminAuthService adminAuthService, ILogger<AdminRegController> logger)
        {
            _adminAuthService = adminAuthService;
            _logger = logger;
        }



        // Registration
        [HttpPost]
        [Route("registeration")]
        public async Task<IActionResult> Register(AdminForSignupDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _adminAuthService.Registration(model, RoleList.Admin);
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
        public async Task<IActionResult> Login(AdminForLoginDto loginModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid payload");
                }
                var (status, message) = await _adminAuthService.Login(loginModel);
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


        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _adminAuthService.Logout();
            return RedirectToAction("Login");
        }

    }
}
