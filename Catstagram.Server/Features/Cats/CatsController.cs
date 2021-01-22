using Catstagram.Server.Infrastructure;
using Catstagram.Server.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Cats
{
    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatsService _catsService;
        public CatsController(ICatsService catsService)
        {
            _catsService = catsService;
        }
        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        {
            var userId = User.GetId();

            var cats = await _catsService.ByUser(userId);

            return cats;
        }

        [HttpGet]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
        {
            var cat = await _catsService.Details(id);

            if (cat == null)
                return NotFound();

            return cat;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var id = await _catsService.Create(model, userId);

            return Created(nameof(Create),id);
        }
    }
}
