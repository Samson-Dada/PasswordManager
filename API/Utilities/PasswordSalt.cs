﻿using System.Security.Cryptography;

namespace API.Utilities
{
    public class PasswordSalt
    {
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create() )
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
