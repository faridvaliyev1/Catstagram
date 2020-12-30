using Catstagram.Server.Data.Models;
using Catstagram.Server.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userManager;

        public IdentityController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result);

        }


    }
}
