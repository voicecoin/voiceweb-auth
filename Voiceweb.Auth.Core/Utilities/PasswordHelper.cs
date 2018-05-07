using System;
using System.Security.Cryptography;
using System.Text;

namespace Voiceweb.Auth.Core.Utilities
{
    public static class PasswordHelper
    {
        public static string Hash(string password, string salt)
        {
            var bytes = ASCIIEncoding.ASCII.GetBytes(password + salt);
            var hashed = new MD5CryptoServiceProvider().ComputeHash(bytes);

            return Convert.ToBase64String(hashed);
        }

        public static string GetSalt()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }
    }
}
