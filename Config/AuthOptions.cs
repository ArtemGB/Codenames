using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Config
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "p0OIieDng9264Qw3fL_fiuhvbHGdigSuwe323!";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));

    }
}
