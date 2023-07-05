using System.Security.Cryptography;
using System.Text;

namespace API.Utilities
{
    public class PasswordEncrypt
    {
        public static string PasswordData(string password)
        {
            byte[] passwordBhyte = Encoding.UTF8.GetBytes(password);
            byte[] hashedBhyte = SHA256.HashData(passwordBhyte);
            string passwordHashed = BitConverter.ToString(hashedBhyte).Replace("-", "").ToLower();
            return passwordHashed;
        }
    }
}
