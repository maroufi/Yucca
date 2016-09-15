

using System;
using System.Security.Cryptography;
using System.Web.Helpers;

namespace Yucca.Utility.Security
{
    public class Encryption
    {
        public static string EncryptingPassword(string password)
        {
            return Crypto.HashPassword(Crypto.SHA256(password));
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, Crypto.SHA256(password));
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] bytes;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(password, 16, 1000))
            {
                salt = rfc2898DeriveByte.Salt;
                bytes = rfc2898DeriveByte.GetBytes(32);
            }
            byte[] numArray = new byte[49];
            Buffer.BlockCopy(salt, 0, numArray, 1, 16);
            Buffer.BlockCopy(bytes, 0, numArray, 17, 32);
            return Convert.ToBase64String(numArray);
        }
    }
}