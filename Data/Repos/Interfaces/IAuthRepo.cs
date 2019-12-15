using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.User;

namespace Data.Repos.Interfaces
{
    public interface IAuthRepo
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UsernameExists(string username);
        Task<bool> EmailExists(string email);
    }
}
