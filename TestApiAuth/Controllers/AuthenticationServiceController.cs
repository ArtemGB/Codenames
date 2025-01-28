using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using ApiAuthDataLayer.Models;
using ApiAuthDataLayer.Interfaces;
using ApiAuthBusinessLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Config.Interfaces;
using ApiAuthDataLayer.Config;

namespace ApiAuthViewLayer.Controllers
{
    /// <summary>
    /// Класс для аутентификации 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationServiceController(IConnectableToDB connect, ILogger<AuthenticationServiceController> logger) : ControllerBase
    {

        [HttpPost]
        public async Task<JsonResult> AuthenticationServiceAsync([FromBody]PersonData data)
        {
            try
            {
                TryAuthentication authenticator = new TryAuthentication(new Config.AuthOptions());
                return new JsonResult(await authenticator.GetToken(connect, data));
            }catch (Exception ex) 
            {

                logger.LogError($"MSG = {ex.Message}; TRACE = {ex.StackTrace}");
                return new JsonResult("");  
            }
        }

        
    }
}
