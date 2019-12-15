using System;
using System.Collections.Generic;
using System.Text;

namespace Services.User.Interfaces
{
    public interface IAuthService
    {
        byte[] CreateHash(in string password, in byte[] salt);
        byte[] CreateSalt();
        bool Auth(Entities.User.User user, string password);
    }
}
