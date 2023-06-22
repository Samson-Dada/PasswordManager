using API.DataAccess;
using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[ResponseCache(CacheProfileName = "200SecondsCache")]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<User>> GetAll()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);
        }

        [HttpGet("{userId}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound($"Cannot found user {id}");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid user data.");

            await _userService.CreateUserAsync(user);
            return CreatedAtRoute("GetById", new { userId = user.Id }, user);
            //return Ok();
        }


        [HttpPut("{userId}")]
        public  async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            if (user is null || user.Id != id)
            {
                return NotFound($" Cannot found user {id}");
            }

            await _userService.UpdateUserAsync(user);
            return Ok(user);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if(user is null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(user);
            return NoContent();
        }
    }
}
