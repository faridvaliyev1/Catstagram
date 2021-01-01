using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Controllers
{
    [ApiController]
    public class HomeController : ApiController
    {
       [Authorize]
       [Route("[controller]")]
       public ActionResult Get()
       {
            return Ok("Works");
       }
    }
}
