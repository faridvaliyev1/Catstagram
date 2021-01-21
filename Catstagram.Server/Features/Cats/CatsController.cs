using Catstagram.Server.Infrastructure;
using Catstagram.Server.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Cats
{
    public class CatsController : ApiController
    {
        private readonly ICatsService _catsService;
        public CatsController(ICatsService catsService)
        {
            _catsService = catsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CatListingResponseModel>> Mine()
        {
            var userId = User.GetId();

            var cats = await _catsService.ByUser(userId);

            return cats;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequestModeL model)
        {
            var userId = this.User.GetId();

            var id = await _catsService.Create(model, userId);

            return Created(nameof(Create),id);
        }
    }
}
