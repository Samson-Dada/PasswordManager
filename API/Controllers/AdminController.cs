using API.Models.UserDto;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        public AdminController(IUserService userService, IPasswordService passwordService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
            _passwordService = passwordService;
        }


        [ResponseCache(Duration = 120)]
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("userspage")]
        public async Task<IActionResult> GetAllUserByPagination(int pageNumber= 1, int pageSize=5)
        {
            var users = await _userService.AllUserByPagination(pageNumber, pageSize);
            return Ok(users);   
        }
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


        [HttpGet("username")]
        public async Task<IActionResult> GetUserByName(string username)
        {
            try
            {
                var user = await _userService.GetUserNameWithPasswordAsync(username);
                if (user is null)
                {

                    return NotFound($" Cannot found \"{username}\" try something else");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // Probabaly delete this action
        // Get all save passwords
        [HttpGet("passwords")]
        public async Task<IActionResult> GetAllPasswordByUserName(string username)
        {
            try
            {

                var user = await _userService.GetUserByUserNameAsync(username);
                if (user is null)
                {
                    return NotFound($"Cannot find username: \"{username}\". Please try something else.");
                }

                await _userService.GetUserNameWithAllPasswordAsync(user);

                var userDto = _mapper.Map<UserForGetDto>(user);
                //userDto.Password = new List<PasswordForGetDto>(); // Initialize the Password property

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }


    }
}
