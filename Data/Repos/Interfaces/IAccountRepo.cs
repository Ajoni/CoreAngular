using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.User;
using Entities.User.VM;
using Microsoft.AspNetCore.Mvc;

namespace Data.Repos.Interfaces
{
    public interface IAccountRepo
    {
        Task<User> Register(User user, string password);
        Task<ObjectResult> Login(LoginVM vm);
        Task<bool> UsernameExists(string username);
        Task<bool> EmailExists(string email);
        Task<User> GetUser(string login);
        Task<User> GetUser(int id);
    }
}
