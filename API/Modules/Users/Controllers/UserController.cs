using API.Modules.User.Services;
using API.Shared.Models.UserDto;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService,IMapper mapper,ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets user list as a demo.
        /// </summary>
        /// <returns> </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userList = await Task.FromResult(new string[]
            {
                "John", "Ben", "Ayo", "Bola"
            });
            return Ok(userList);
        }


        /// <summary>
        /// Gets the user by identifier {GUID}.
        /// </summary>
        /// <param name="userId">The user identifier {ID} to get. {the user with the specified Id}</param>
        /// <returns>An IActionResult</returns>
        [HttpGet("{userId}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
                _logger.LogError("IdentityResult:: Cannot delete the user {user}",userId);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUsername(string username, [FromBody] UserForUpdateUserNameDto userForUpdateUserNameDto)
        {
            try
            {
                // Check if the new username is already in use
                var IsUsernameExists = await _userService.IsUsernameAlreadyExists(userForUpdateUserNameDto.Username);
                if (IsUsernameExists)
                {
                    return BadRequest($"Username \"{userForUpdateUserNameDto.Username}\" is already in use. Please choose another one.");
                }

                // Get the user by the current username
                var usernameToUpdate = await _userService.GetUserByUserNameAsync(username);
                if (usernameToUpdate == null)
                {
                    return NotFound($"User with username \"{username}\" not found.");
                }

                // Update the username
                usernameToUpdate.UserName = userForUpdateUserNameDto.Username;

                // Call the update method in your service to save the changes
                var updatedUser = await _userService.UpdateUserAsync(usernameToUpdate);

                // Return the updated user's new username directly
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
