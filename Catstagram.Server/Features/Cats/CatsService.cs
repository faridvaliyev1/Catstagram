using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Models.Cats;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<CatListingServiceModel>> ByUser(string UserId)
        {
            return await _context.Cats.Where(c => c.UserId == UserId)
                 .Select(c => new CatListingServiceModel
                 {
                     Id = c.Id,
                     ImageUrl = c.ImageUrl
                 })
                .ToListAsync();
        }


        public async Task<int> Create(CreateCatRequestModel model,string userId)
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

        public async Task<CatDetailsServiceModel> Details(int Id)
        {
           return await _context.Cats.Where(c => c.Id == Id)
                .Select(c => new CatDetailsServiceModel
                {
                   Id=c.Id,
                   UserId=c.UserId,
                   ImageUrl=c.ImageUrl,
                   Description=c.Description,
                   UserName=c.user.UserName
                }).
                FirstOrDefaultAsync();
        }

        public async Task<bool> Update(int id, string description, string userId)
        {
            var cat = await _context.Cats.
                 Where(c => c.Id == id && c.UserId == userId)
                 .FirstOrDefaultAsync();

            if (cat == null)
                return false;

            cat.Description = description;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
