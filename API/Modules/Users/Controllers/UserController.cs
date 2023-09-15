using API.Modules.User.Services;
using API.Shared.Entities;
using API.Shared.Models.PasswordDto;
using API.Shared.Models.UserDto;
using API.Shared.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.User
{
    //[Authorize(Roles = "User")]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;



        public UserController
            (
            IUserService userService,
            IPasswordService passwordService, 
            IMapper mapper, 
            ILogger<UserController> logger
            )
        {
            _userService = userService;
            _passwordService = passwordService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userList = await Task.FromResult(new string[]
            {
                "John", "Ben", "Ayo", "Bola"
            });
            return Ok(userList);
        }


        // Get user by id
        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            if (!Guid.TryParse(userId, out Guid _))
            {
                return BadRequest("Invalid user ID format.");
            }
            var user = await _userService.GetById(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }
            var map = _mapper.Map<UserForGetDto>(user);
            return Ok(map);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);
                if (user is null)
                {
                    return NotFound($"{StatusCodes.Status404NotFound} : Cannot find user ID {userId}");
                }
                await _userService.DeleteUserAsync(user);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /*************/

        // change to use Dto
        // for update username
        //[HttpPut("{userId}/username")]
        //public async Task<IActionResult> UpdateUserName(string userId, [FromBody] UserForUpdateUserNameDto userForUpdateUserNameDto)
        //{
        //    if (userId == null || userForUpdateUserNameDto.Username == null)
        //    {
        //        return NotFound();
        //    }

        //    if (await _userService.UserAlreadyExist(userForUpdateUserNameDto.Username))
        //    {
        //        return BadRequest($"Username \"{userForUpdateUserNameDto.Username}\"  has already been used. Please update to another one.");
        //    }
        //    await _userService.UpdateUserNameAsync(userId, userForUpdateUserNameDto.Username);
        //    return Ok(userForUpdateUserNameDto.Username);
        //}

        /****************/



        //[HttpPut("{userId}/username")]
        //public async Task<IActionResult> UpdateUserName(string userId, [FromBody] User userForUpdateDto)
        //{
        //    if (userId == null || userForUpdateDto.Username == null)
        //    {
        //        return NotFound();
        //    }

        //    if (await _userService.UserAlreadyExist(userForUpdateDto.Username))
        //    {
        //        return BadRequest($"Username \"{userForUpdateDto.Username}\"  has already been used. Please update to another one.");
        //    }
        //    await _userService.UpdateUserNameAsync(userId, userForUpdateDto.Username);
        //    return Ok(userForUpdateDto.Username);
        //}

    }
}
