using System;
using System.Threading.Tasks;
using Data;
using Data.Repos.Interfaces;
using Entities;
using Entities.User;
using Entities.User.VM;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM registerVm)
        {
            try
            {
                await _accountRepo.Register(registerVm.GetUser(), registerVm.Password);
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

        [AllowAnonymous]
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