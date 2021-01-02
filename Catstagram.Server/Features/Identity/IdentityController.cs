using Catstagram.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<AppSettings> options;
        private readonly IIdentityService _identityService;

        public IdentityController(UserManager<User> userManager,IOptions<AppSettings> options,IIdentityService identityService)
        {
            _userManager = userManager;
            this.options = options;
            _identityService = identityService;
        }
        [Route(nameof(Register))]
        [HttpPost]
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

        [Route(nameof(Login))]
        [HttpPost]
        public async Task<ActionResult<object>> Login(LoginRequestModel model)
        {
            var user =await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
                return Unauthorized();

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
                return Unauthorized();

            var token = _identityService.GenerateJwtToken(user.Id, user.UserName, options.Value.Secret);

            return new LoginResponseModel
            {
                Token = token
            };
        }
    }
}
