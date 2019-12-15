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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Services.User.Interfaces;

namespace Data.Repos.Impl
{
    public class AccountRepo : IAccountRepo
    {
        private readonly DataContext _dataContext;
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountRepo(DataContext dataContext, IAccountService accountService, ITokenService tokenService)
        {
            _dataContext = dataContext;
            _accountService = accountService;
            _tokenService = tokenService;
        }

        public async Task<User> Register(User user, string password)
        {
            var salt = _accountService.CreateSalt();
            var hash = _accountService.CreateHash(password, salt);

            user.Salt = salt;
            user.PasswordHash = hash;

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<ObjectResult> Login(LoginVM vm)
        {
            var user = await GetUser(vm.Login);

            var isHashCorrect = _accountService.Auth(user, vm.Password);
            if (!isHashCorrect)
                throw new ArgumentException($"Given password does not match");

            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var token = _tokenService.GenerateAccessToken(userClaims);

            return new ObjectResult(new
            {
                token,
                refreshToken = _tokenService.GenerateRefreshToken()
            });
        }

        public async Task<bool> UsernameExists(string username) => await _dataContext.Users.AnyAsync(x => x.Username == username);

        public async Task<bool> EmailExists(string email) => await _dataContext.Users.AnyAsync(x => x.Email == email);
        public async Task<User> GetUser(string login)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Username == login);
            if (user == null)
                user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Email == login);
            if (user == null)
                throw new ArgumentException($"User with login '{login}' does not exist");

            return user;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}
