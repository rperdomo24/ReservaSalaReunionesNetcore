using System;
using System.Collections.Generic;
using System.Text;
using CryptoHelper;

namespace ReservaSalaReuniones.Util.Cripto
{
    public  class EncriptadoPassword
    {
        // Method for hashing the password
        public static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        // Method to verify the password hash against the given password
        public static bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
