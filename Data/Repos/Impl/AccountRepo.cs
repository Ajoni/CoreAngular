using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data.Repos.Interfaces;
using Entities;
using Entities.User;
using Entities.User.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Services.User.Interfaces;

namespace Data.Repos.Impl
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly bool _lockoutOnFailure;

        public AccountRepo(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _lockoutOnFailure =
#if DEBUG
                !
#endif
                    true;
        }

        public async Task<IdentityResult> Register(IdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<ObjectResult> Login(LoginVM vm)
        {
            var user = await _userManager.FindByNameAsync(vm.Login) ?? await _userManager.FindByEmailAsync(vm.Login);

            if (user == null)
                throw new ArgumentException("User with given login not found");

            var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password, _lockoutOnFailure);
            if (!result.Succeeded)
                throw new ArgumentException($"Given password does not match");

            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var token = _tokenService.GenerateAccessToken(userClaims);

            return new ObjectResult(new
            {
                token,
                refreshToken = _tokenService.GenerateRefreshToken()
            });
        }

    }
}
