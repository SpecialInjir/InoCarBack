using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InoCarWebAPI.Controllers
{
    public class BaseController : ControllerBase
    {

        protected string GetUserId()
        {
            string UserId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            return UserId;
        }
    }
}
