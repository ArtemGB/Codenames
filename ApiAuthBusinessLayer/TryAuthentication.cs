//using Amazon.Runtime.Internal.Util;
using ApiAuthDataLayer.Interfaces;
using System.Security.Cryptography;
using ApiAuthDataLayer.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Config;
using Microsoft.Extensions.Logging;
using ApiAuthBusinessLayer;
using ApiAuthDataLayer;

namespace ApiAuthBusinessLayer
{
    /// <summary>
    /// Выдает токен пользователю при условии успешного чека логина\пароля
    /// </summary>
    public class TryAuthentication
    {
        private AuthOptions _options;

        /// <summary>
        /// Для инита настройки для токена и логер для собственно логирования
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public TryAuthentication(AuthOptions options) 
        {
            _options = options;
            Console.WriteLine($"\t{this}: create TryAuthentication.");
        }

        /// <summary>
        /// Тут мы передаем куда и как именно надо подключаться для проверки пользователя
        /// Если проверка успешно - генерим токен
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public async Task<string> GetToken(IConnectableToDB connection, PersonData personForCheck)
        {
            try 
            {
                Console.WriteLine($"{this}: Start getToken");
                PersonData ckeckedPerson = await connection.GetPersonAsync(personForCheck.Email);
                if(!ckeckedPerson.Email.Equals("") && ckeckedPerson.HashPass.Equals($"{GetHashFromPassword.GetdHash(personForCheck.HashPass)}"))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, ckeckedPerson.UserName),
                        new Claim(ClaimTypes.Role, ckeckedPerson.Role),
                        new Claim(ClaimTypes.Email, ckeckedPerson.Email),
                        new Claim(ClaimTypes.UserData, $"{ckeckedPerson.Id.ToString()}"),
                        new Claim(ClaimTypes.Expired, $"{DateTime.UtcNow.Add(TimeSpan.FromMinutes(2))}"),
                    };
                    Console.WriteLine($"{this}: Claims = [{ckeckedPerson.Id.ToString()}, {ckeckedPerson.UserName}, {ckeckedPerson.Email}, {ckeckedPerson.Role}]");
                    // создаем JWT-токен
                    var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            claims: claims,
                            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                    Console.WriteLine($"{this}: token was created.");
                    return new JwtSecurityTokenHandler().WriteToken(jwt);
                }
                else
                {
                    Console.WriteLine($"{this}: didnt found person with {ckeckedPerson.Email}");
                    return "";
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{this}: MSG = {ex.Message}, Trace = {ex}");
                return "";
            }
        }
    }
}
