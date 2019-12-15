using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repos.Interfaces;
using Entities;
using Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Services.User.Interfaces;

namespace Data.Repos.Impl
{
    public class AuthRepo : IAuthRepo
    {
        private readonly DataContext _dataContext;
        private readonly IAuthService _authService;

        public AuthRepo(DataContext dataContext, IAuthService authService)
        {
            _dataContext = dataContext;
            _authService = authService;
        }

        public async Task<User> Register(User user, string password)
        {
            var salt = _authService.CreateSalt();
            var hash = _authService.CreateHash(password, salt);

            user.Salt = salt;
            user.PasswordHash = hash;

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Username == username);
            if (user == null)
                throw new ArgumentException($"User '{username}' does not exist");

            var isHashCorrect = _authService.Auth(user, password);
            if(!isHashCorrect)
                throw new ArgumentException($"Given password does not match");

            return user;
        }

        public async Task<bool> UsernameExists(string username) => await _dataContext.Users.AnyAsync(x => x.Username == username);

        public async Task<bool> EmailExists(string email) => await _dataContext.Users.AnyAsync(x => x.Email == email);
    }
}
