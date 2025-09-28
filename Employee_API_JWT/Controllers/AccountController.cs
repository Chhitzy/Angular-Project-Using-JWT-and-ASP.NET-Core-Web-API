using Employee_API_JWT.Models.ViewModels;
using Employee_API_JWT.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_API_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginVM loginVM)
        {
            var user = await _userService.Authenticate(loginVM);
            if (user == null) return BadRequest("Wrong User|Password");

            return Ok(user);
        }

    }
}
