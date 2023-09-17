using API.Modules.Services;
using API.Shared.Models.UserDto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;
        private readonly IMapper _mapper;
        const int _maxUserPageSize = 20;
        public AdminController(IAdminService adminService, ILogger<AdminController> logger, IMapper mapper)
        {
            _adminService = adminService;
            _logger = logger;
            _mapper = mapper;
        }

        // Get users
        [ResponseCache(Duration = 120)]
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUser()
        {
            _logger.LogInformation("Get All users in the API");
            var users = await _adminService.GetAllUserAsync();

            var mapp = _mapper.Map<IEnumerable<UserForGetDto>>(users);
            return Ok(mapp);
        }

        // Get user by Id with stored or saved password
        [HttpGet("{userId}", Name = "GetUserByIdWithStoredPassword")]
        public async Task<IActionResult> GetUserByIdWithStoredPassword(string userId)
        {
            try
            {
                var user = await _adminService.GetUserByIdAsync(userId);
                if (user is null)
                {
                    return NotFound($"{StatusCodes.Status404NotFound} : Cannot find user ID {userId}");
                }
                var mapUser = _mapper.Map<UserForGetDto>(user);
                return Ok(mapUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // Get users by pagination
        [HttpGet]
        [Route("userspage")]
        public async Task<IActionResult> GetUsersByPagination(int pageNumber, int pageSize)
        {
            var usersPagination = await _adminService.GetUsersByPagination(pageNumber, pageSize);
            if(pageSize > _maxUserPageSize)
            {
                return  Ok(_maxUserPageSize);
            }
            return Ok(usersPagination);
        }
    }
}
