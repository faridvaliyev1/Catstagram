using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Controllers
{
    [ApiController]
    public class HomeController : ApiController
    {
       
       public ActionResult Get()
       {
            return Ok("Works");
       }
    }
}
