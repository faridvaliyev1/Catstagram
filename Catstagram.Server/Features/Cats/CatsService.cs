using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Models.Cats;
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
