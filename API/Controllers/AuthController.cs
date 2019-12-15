using System.Threading.Tasks;
using Data;
using Data.Repos.Interfaces;
using Entities;
using Entities.User;
using Entities.User.VM;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;

        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM registerVm)
        {
            var user = new User(registerVm);
            if (!await _authRepo.UsernameExists(user.Username) || !await _authRepo.EmailExists(user.Email))
                return BadRequest();

            await _authRepo.Register(user, registerVm.Password);

            return Ok();
        }
    }
}