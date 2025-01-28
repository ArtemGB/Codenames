using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ApiAuthDataLayer.Models;
using Config;


namespace ApiAuthViewLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckRoleTypeController : Controller
    {
        [HttpGet]
        public JsonResult CheckRoleType(string token)
        {
            PersonData personData = new PersonData();
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = AuthOptions.ISSUER,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                };
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                personData.Role = principal.Claims.Where(p => p.Type == ClaimTypes.Role).First().Value;

            }
            catch (Exception ex) 
            {
                
            }
            return Json(personData);
        }
    }
}
