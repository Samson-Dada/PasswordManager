using API.Modules.User.Services;
using API.Shared.Entities;
using API.Shared.Models.PasswordDto;
using API.Shared.Models.UserDto;
using API.Shared.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Users.Controllers
{
    [Route("api/users/passwords")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserService _userService;
        private ILogger<PasswordController> _logger;
        private readonly IMapper _mapper;

        public PasswordController(
            IPasswordService passwordService,
            IUserService userService,
            IMapper mapper,
            ILogger<PasswordController> logger)
        {
            _passwordService = passwordService;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;

        }

        //Endpoint to get password by Id
        [HttpGet("{passwordId}")]
        //[Route("passwords")]
        public async Task<ActionResult<Password>> GetPasswordById(string passwordId)
        {

            if (!Guid.TryParse(passwordId, out Guid _))
            {
                return BadRequest("Invalid user ID format.");
            }
            var passwordEntity = await _passwordService.GetPasswordByIdAsync(passwordId);
            var mapPassword = _mapper.Map<PasswordForGetDto>(passwordEntity);
            string formatedDate = DateFormatter.DateFormat();
            passwordEntity.Date = formatedDate;
            return Ok(mapPassword);
        }

        // Endpoint to save, store or keep password
        [HttpPost("passwords")]
        public async Task<IActionResult> AddPassword(string username, [FromForm] PasswordCreationDto passwordCreationDto)
        {
            try
            {
                var user = await _userService.GetUserByUserNameAsync(username);
                if (user == null)
                {
                    return NotFound($"Cannot find user ID");
                }

                var hashedPassword = _passwordService.HashedPassword(passwordCreationDto.HashedPassword);
                var passwordEntity = _mapper.Map<Password>(passwordCreationDto);
                passwordEntity.HashedPassword = hashedPassword;
                passwordEntity.Id = Guid.NewGuid().ToString();
                string formattedDate = DateFormatter.DateFormat();
                passwordEntity.Date = formattedDate;
                user.Password.Add(passwordEntity);
                await _userService.UpdateUserAsync(user);
                var userPasswordDto = _mapper.Map<UserPasswordCreationDto>(user);
                return CreatedAtRoute(nameof(GetPasswordById), new { userId = user.Id }, userPasswordDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception error in password creations", username);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        // Endpoint to get all password
        [HttpGet]
        [Route("password")]
        public async Task<IActionResult> GetAllPassword()
        {
            var password = await _passwordService.GetAllPassowordAsync();
            return Ok(password);
        }


        // Endpoint to delete saved or stored password
        [HttpDelete("{passwordId}")]
        public async Task<IActionResult> DeletePassword(string passwordId)
        {
            try
            {
                var password = await _passwordService.GetPasswordByIdAsync(passwordId);
                if (password is null)
                {
                    return NotFound("Password with the provided ID doesn't exist");
                }
                await _passwordService.DeletePasswordAsync(passwordId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return NoContent();
        }


        // Endpoint to search passwords by title
        [HttpGet]
        [Route("{search}")]
        public async Task<ActionResult<IEnumerable<PasswordForGetDto>>> SearchPasswords([FromQuery(Name = "title")] string passwordTitle)
        {
            var searchResult = await _passwordService.GetPasswordBySearchAsync(passwordTitle);
            var mappedPasswords = _mapper.Map<IEnumerable<PasswordForGetDto>>(searchResult);
            return Ok(mappedPasswords);
        }

        // Endpoint to filter passwords by title
        [HttpGet]
        [Route("{passwordTitle}")]
        public async Task<ActionResult<IEnumerable<PasswordForGetDto>>> FilterPasswords([FromQuery(Name = "title")] string passwordTitle)
        {
            var filterResult = await _passwordService.GetPasswordByFilterAsync(passwordTitle);
            var mappedPasswords = _mapper.Map<IEnumerable<PasswordForGetDto>>(filterResult);
            return Ok(mappedPasswords);
        }

        //// Endpoint to delete saved or password by user Id
        //[HttpDelete("{userId}")]
        //public async Task<IActionResult> DeletePasswordByUserId(string userId)
        //{
        //    try
        //    {
        //        if(!Guid.TryParse(userId, out var id))
        //        {
        //            return BadRequest("Invalid userId format");
        //        }
        //        var isDeleted = await _passwordService.DeletePasswordByUserIdAsync(userId);
        //        if (!isDeleted)
        //        {
        //            return NotFound("Password with the provided ID doesn't exist");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        //    }
        //    return NoContent();
        //}

    }
}
