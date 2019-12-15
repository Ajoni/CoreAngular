using System;
using System.Threading.Tasks;
using Data;
using Data.Repos.Interfaces;
using Entities;
using Entities.User;
using Entities.User.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;

        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM registerVm)
        {
            var user = new User(registerVm);
            if (!await _accountRepo.UsernameExists(user.Username) || !await _accountRepo.EmailExists(user.Email))
                return BadRequest();

            try
            {
                await _accountRepo.Register(user, registerVm.Password);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            try
            {
                var result = await _accountRepo.Login(vm);
                return result;
            }
            catch (ArgumentException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}