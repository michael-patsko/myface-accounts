using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;
using MyFace.Models.Request;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace MyFace.Utilities
{
    public interface IAuthorizeUser
    {
        bool CheckUsernameAndPassword(string username, string password);
    }

    public class AuthorizeUser : IAuthorizeUser
    {
        private readonly MyFaceDbContext _context;

        public AuthorizeUser(MyFaceDbContext context)
        {
            _context = context;
        }

        public bool CheckUsernameAndPassword(string username, string password)
        {
            try
            {
                User user = _context.Users.Where(u => u.Username == username).Single();
                byte[] salt = user.Salt;
                string hash = Convert.ToBase64String(
                    KeyDerivation.Pbkdf2(
                        password: password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8
                    )
                );
                return hash == user.HashedPassword;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}
