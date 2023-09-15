using System.Security.Cryptography;
using System.Text;

namespace API.Shared.Utilities.Encryptions
{
    public class PasswordHash
    {
        public static string GenerateHashPassword(string password)
        {
            //Generate a random salt
            byte[] salt = PasswordSalt.GenerateSalt();


            // Convert password and salt to bytes
            byte[] passwordBhytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPasswordBytes = new byte[passwordBhytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBhytes, 0, saltedPasswordBytes, 0, passwordBhytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPasswordBytes, passwordBhytes.Length, salt.Length);


            // Hash the salted password
            byte[] hashedBhytes = SHA256.HashData(passwordBhytes);

            //Combine the salt and hased password

            byte[] saltedHashedBytes = new byte[hashedBhytes.Length + salt.Length];
            Buffer.BlockCopy(hashedBhytes, 0, saltedHashedBytes, 0, hashedBhytes.Length);
            Buffer.BlockCopy(salt, 0, saltedHashedBytes, hashedBhytes.Length, salt.Length);

            // convert the salted hashed password to a string
            string passwordHashed = BitConverter.ToString(hashedBhytes).Replace("-", "").ToLower();
            return passwordHashed;
        }
    }
}