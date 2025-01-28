using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiAuthDataLayer.Models;
using ApiAuthDataLayer.Interfaces;
using ApiAuthBusinessLayer;

namespace ApiAuthViewLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegNewUserController(IConnectableToDB connect, ILogger<RegNewUserController> logger) : Controller
    {
        [HttpPost]
        public async Task<JsonResult> RegNewUser(PersonData newPerson)
        {
            logger.LogInformation($"{this}: Start registration new user.");

            TryCreateNewUser creatorNewUser = new TryCreateNewUser();
            bool resp = await creatorNewUser.CreateUniqueUserAsync(connect, newPerson);

            return Json(resp);
        }

    }
}
