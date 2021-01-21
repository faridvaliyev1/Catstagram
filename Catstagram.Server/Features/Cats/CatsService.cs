using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Models.Cats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Cats
{
    public class CatsService : ICatsService
    {
        private readonly ApplicationDbContext _context;

        public CatsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CatListingResponseModel>> ByUser(string UserId)
        {
            return await _context.Cats.Where(c => c.UserId == UserId)
                 .Select(c => new CatListingResponseModel
                 {
                     Id = c.Id,
                     ImageUrl = c.ImageUrl
                 })
                .ToListAsync();
        }

        public async Task<int> Create(CreateRequestModeL model,string userId)
        {
            var cat = new Cat
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            _context.Add(cat);

            await _context.SaveChangesAsync();

            return cat.Id;
        }
    }
}
