using API.Entities;
using API.Models.UserDto;
using API.Services;
using API.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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


    [HttpGet("{id}", Name = "GetRegisterById")]
    public async Task<IActionResult> GetById(string userId)
    {
        try
        {

            var user = await _userService.GetUserByIdAsync(userId);

            if (user is null)
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


    [HttpPost]
    [Route("adds")]
    public async Task<IActionResult> CreateUser([FromForm] UserForSignupDto userForSignupDto)
    {
        try
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid user data");
            }
            if (await _userService.UserAlreadyExist(userForSignupDto.Username))
            {
                return BadRequest("Username already exist");
            }
            var userDto = _mapper.Map<User>(userForSignupDto);
            userDto.Id = Guid.NewGuid().ToString();
            GuidFormatter.RemoveHyphens(userDto.Id);

            await _userService.CreateUserAsync(userDto);
            return CreatedAtRoute("GetRegisterById", new { userId = userDto.Id }, userForSignupDto);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
//98a6910a-d9d2-4c1b-a4f1-264a7353af1b