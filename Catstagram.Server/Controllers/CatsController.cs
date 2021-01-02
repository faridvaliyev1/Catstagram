using Catstagram.Server.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers
{
    public class CatsController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequestModeL model)
        {

        }
    }
}
