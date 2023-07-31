using API.Entities;
using API.Models.PasswordDto;
using API.Models.UserDto;
using API.Services;
using API.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IPasswordService passwordService, IMapper mapper)
        {
            _userService = userService;
            _passwordService = passwordService;
            _mapper = mapper;
        }


        // Get user by id
        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {

           var user = await _userService.GetUserByIdAsync(userId);

            if(user is null)
            {
                return NotFound($"{StatusCodes.Status404NotFound} : Cannot find user ID {userId}");
            }
            return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }


        //check result and implemtation purpose
        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(string userId, [FromBody] User user)
        {
            try
            {

                if (user is null || userId == null || user.Id != userId)
                {
                    return NotFound($" Cannot found user {user.Id}");
                }

                if (user is null || user.Id != user.Id)
                {
                    return NotFound($" Cannot found user {user.Id}");
                }
                if (await _userService.UserAlreadyExist(user.Username))
                {
                    return BadRequest($"Username \"{user.Username}\"  has already been used. Please update to another one.");
                }
                await _userService.UpdateUserAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }


        // Save or keep password 
        [HttpPost("passwords")]
        public async Task<IActionResult> AddPassword(string username, [FromForm] PasswordCreationDto passwordCreationDto)
        {
            try
            {
                var user = await _userService.GetUserByUserNameAsync(username);
                if (user is null)
                {
                    return NotFound($"Cannot find user ID");
                }

                var hashedPassword = _passwordService.HashedPassword(passwordCreationDto.HashedPassword);
                var passwordEntity = _mapper.Map<Password>(passwordCreationDto);
                passwordEntity.HashedPassword = hashedPassword;
               passwordEntity.Id = Guid.NewGuid().ToString().Remove(8);

                // Format the date
                string formattedDate = DateFormatter.DateFormat();
                passwordEntity.Date = formattedDate;

                user.Password.Add(passwordEntity);
                await _userService.UpdateUserAsync(user);

                var userPasswordDto = _mapper.Map<UserPasswordCreationDto>(user);
                return CreatedAtRoute(nameof(GetUserById), new { userId = user.Id }, userPasswordDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // change to use Dto
        // for update username
        [HttpPut("{userId}/username")]
        public async Task<IActionResult> UpdateUserName(string userId, [FromBody] UserForUpdateUserNameDto userForUpdateUserNameDto)
        {
            if (userId == null || userForUpdateUserNameDto.Username == null)
            {
                return NotFound();
            }

            if (await _userService.UserAlreadyExist(userForUpdateUserNameDto.Username))
            {
                return BadRequest($"Username \"{userForUpdateUserNameDto.Username}\"  has already been used. Please update to another one.");
            }
            await _userService.UpdateUserNameAsync(userId, userForUpdateUserNameDto.Username);
            return Ok(userForUpdateUserNameDto.Username);
        }

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

        /* Action for password*/

        [HttpGet]
        [Route("passwords")]
        public async Task<IActionResult> GetAll()
        {
            var password = await _passwordService.GetAllPassowordAsync();
            return Ok(password);
        }
    }
}

//.......................//

// Implemtation


//.. Get all password for specific user/

//..Create collection of child resoureces example
//== user to create more than one password at request/



// To Delete user
//--- use the deleteUser entity to remove user from databaseby using both the deleteuser Id and User entity


// Get list password from a user
//-- use the username or id to get all password 


// User to add multiple password at a time
// -- Use the username or id to add multiple password




/*
 
https://localhost:7000/api/users/username?username=deo

 {
  "id": 1,
  "username": "Ben",
  "email": "ben@mail.com",
  "userPassword": "54321Ben",
  "password": [
    {
      "id": 1,
      "title": "Vault Password",
      "hashedPassword": "357c20d35f34d08579cb6c458b516464fadf5a0b01e6d57d180d23ba90a72d3e",
      "userId": 1,
      "date": "2023-06-30T15:24:51.5592691"
    }
  ]
}
 
 */