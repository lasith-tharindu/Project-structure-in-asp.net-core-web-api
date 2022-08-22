using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Common.Utilities
{
    public static class AuthUtlis
    {
        public static string GetHashed(string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value);
        }

        public static string GetUnHashed(string value)
        {
            return BCrypt.Net.BCrypt.HashString(value);
        }

        public static bool VerifyPassword(string passwordText, string passwordHashed)
        {
            return BCrypt.Net.BCrypt.Verify(passwordText, passwordHashed);
        }

    }
}
