﻿using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Infrastructure;
using Catstagram.Server.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers
{
    public class CatsController : ApiController
    {
        private readonly ApplicationDbContext data;

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequestModeL model)
        {
            var userId = this.User.GetId();

            var cat = new Cat
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            data.Add(cat);

             await data.SaveChangesAsync();

            return Created(nameof(Create), cat.Id);
        }
    }
}
