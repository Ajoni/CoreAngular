using System;
using System.Collections.Generic;
using System.Text;
using Services.User.Interfaces;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Services.User.Impl
{
    public class AuthService : IAuthService
    {
        public byte[] CreateHash(in string password, in byte[] salt)
        {
            var hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
            return hash;
        }

        public byte[] CreateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public bool Auth(Entities.User.User user, string password)
        {
            var sentHash = CreateHash(password, user.Salt);
            return sentHash == user.PasswordHash;
        }
    }
}
