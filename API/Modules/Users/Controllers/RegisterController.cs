using API.Modules.User.Services;
using API.Shared.Models.UserDto;
using API.Shared.Utilities;
using SharedUser = API.Shared.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
// At the top of your code file

namespace API.Modules.Users.Controllers;

[Route("api/registers")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public RegisterController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }


    //[HttpPost]
    //[Route("adds")]
    //public async Task<IActionResult> CreateUser([FromForm] UserForSignupDto userForSignupDto)
    //{
    //    try
    //    {

    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest("Invalid user data");
    //        }
    //        if (await _userService.UserAlreadyExists(userForSignupDto.UserName))
    //        {
    //            return BadRequest("Username already exist");
    //        }
    //        var userDto = _mapper.Map<IdentityUser>(userForSignupDto);
    //        //userDto.Id = Guid.NewGuid().ToString();
    //        //GuidFormatter.RemoveHyphens(userDto.Id);

    //        await _userService.CreateUserAsyncs(userDto, userDto.PasswordHash);
    //        return CreatedAtRoute("GetRegisterById", new { userId = userDto.Id }, userForSignupDto);
    //    }

    //    catch (Exception ex)
    //    {
    //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    //    }
    //}


    //[HttpPost]
    //[Route("adds")]
    //public async Task<IActionResult> CreateUser([FromForm] UserForSignupDto userForSignupDto)
    //{
    //    try
    //    {

    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest("Invalid user data");
    //        }
    //        if (await _userService.UserAlreadyExist(userForSignupDto.UserName))
    //        {
    //            return BadRequest("Username already exist");
    //        }
    //        var userDto = _mapper.Map<SharedUser.User>(userForSignupDto);
    //        userDto.Id = Guid.NewGuid().ToString();
    //        GuidFormatter.RemoveHyphens(userDto.Id);

    //        await _userService.CreateUserAsync(userDto);
    //        return CreatedAtRoute("GetRegisterById", new { userId = userDto.Id }, userForSignupDto);
    //    }

    //    catch (Exception ex)
    //    {
    //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    //    }
    //}
}