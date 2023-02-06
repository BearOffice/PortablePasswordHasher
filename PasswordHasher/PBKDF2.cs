using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHasher;

internal static class PBKDF2
{
    public static string GeneratePasswordHash(string password, string saltStr, int iteration = 10000, int len = 48)
    {
        var encoder = new UTF8Encoding();
        var salt = encoder.GetBytes(saltStr);

        var iter = new Rfc2898DeriveBytes(password, salt, iteration);
        
        var bytesLen = Math.Ceiling(len * 6.0 / 8.0);
        var bytes = iter.GetBytes((int)bytesLen);
        var hashed = Convert.ToBase64String(bytes);
        return hashed[..len];
    }
}
