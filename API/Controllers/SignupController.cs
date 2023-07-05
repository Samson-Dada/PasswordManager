using API.Entities;
using API.Models.UserDto;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace API.Controllers
{
    [Route("api/signup")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public SignupController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromForm] UserForSignupDto userForSignupDto)
        //{
        //    try
        //    {

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid user data");
        //        }
        //        if (await _userService.UserAlreadyExist(userForSignupDto.Username))
        //        {
        //            return NotFound("Username already exist");
        //        }
        //        var userDto = _mapper.Map<User>(userForSignupDto);

        //        await _userService.CreateUserAsync(userDto);
        //        return CreatedAtRoute("GetById", new { userId = userDto.Id }, userForSignupDto);
        //    }

        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserPasswordCreationDto userPasswordCreationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid user data");
                }
                if (await _userService.UserAlreadyExist(userPasswordCreationDto.Username))
                {
                    return NotFound("Username already exists");
                }
                var userDto = _mapper.Map<User>(userPasswordCreationDto);
                await _userService.CreateUserAsync(userDto);

                return CreatedAtRoute("GetById", new { userId = userDto.Id }, userPasswordCreationDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
