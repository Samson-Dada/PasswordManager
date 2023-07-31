using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/passwords")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
       
        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

       

    }
}
