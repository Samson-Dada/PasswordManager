using API.Shared.Models.UserDto;
using Microsoft.AspNetCore.Http;
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
        private readonly IAuthService _authService;
        private readonly ILogger<AdminRegController> _logger;
        public AdminRegController(IAuthService authService, ILogger<AdminRegController> logger)
        {
            _authService = authService;
            _logger = logger;
        }



        // Registration
        //[HttpPost]
        //[Route("registeration")]
        //public async Task<IActionResult> Register(AdminForSignupDto model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest("Invalid payload");
        //        var (status, message) = await _authService.Registration(model, RoleList.Admin);
        //        if (status == 0)
        //        {
        //            return BadRequest(message);
        //        }
        //        return CreatedAtAction(nameof(Register), model);

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}


        //[HttpPost]
        //[Route("registeration")]
        //public async Task<IActionResult> Register(UserForSignupDto model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest("Invalid payload");
        //        var (status, message) = await _authService.Registration(model, Roles.Admin);
        //        if (status == 0)
        //        {
        //            return BadRequest(message);
        //        }
        //        return CreatedAtAction(nameof(Register), model);

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}



    }
}
