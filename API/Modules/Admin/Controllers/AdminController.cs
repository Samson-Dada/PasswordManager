using API.Modules.Services;
using API.Shared.Models.UserDto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;
        const int maxUserPageSize = 20;
        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }


        //[ResponseCache(Duration = 120)]
        //[HttpGet]
        //[Route("users")]
        //public async Task<IActionResult> GetAll()
        //{
        //    _logger.LogInformation("Get All users in the API");
        //    var users = await _adminService.GetAllUserAsync();
        //    return Ok(users);
        //}



        //[HttpGet]
        //[Route("userspage")]
        //public async Task<IActionResult> GetAllUserPage(int pageNumber = 1, int pageSize = 10)
        //{
        //    if(pageSize > maxUserPageSize)
        //    {
        //        pageSize = maxUserPageSize;
        //    }
        //    var users = await _adminService.GetAllPagination(pageNumber , pageSize);


        //    return Ok(users);
        //}

        //[HttpGet("{userId}", Name = "GetById")]
        //public async Task<IActionResult> GetById(string userId)
        //{
        //    try
        //    {

        //        var user = await _userService.GetUserByIdAsync(userId);

        //        if (user is null)
        //        {
        //            return NotFound($"{StatusCodes.Status404NotFound} : Cannot find user ID {userId}");
        //        }
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        //    }
        //}


        //[HttpGet("username")]
        //public async Task<IActionResult> GetUserByName(string username)
        //{
        //    try
        //    {
        //        var user = await _adminService.GetUserNameWithPasswordAsync(username);
        //        if (user is null)
        //        {

        //            return NotFound($" Cannot found \"{username}\" try something else");
        //        }
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}


        // Probabaly delete this action
        // Get all save passwords
        //[HttpGet("passwords")]
        //public async Task<IActionResult> GetAllPasswordByUserName(string username)
        //{
        //    try
        //    {

        //        var user = await _adminService.GetUserByUserNameAsync(username);
        //        if (user is null)
        //        {
        //            return NotFound($"Cannot find username: \"{username}\". Please try something else.");
        //        }

        //        await _adminService.GetUserNameWithAllPasswordAsync(user);

        //        var userDto = _mapper.Map<UserForGetDto>(user);
        //        //userDto.Password = new List<PasswordForGetDto>(); // Initialize the Password property

        //        return Ok(userDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        //    }
        //}


    }
}
