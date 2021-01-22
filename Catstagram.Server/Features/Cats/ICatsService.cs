using Catstagram.Server.Models.Cats;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Cats
{
    public interface ICatsService
    {
       Task<int> Create(CreateCatRequestModel model,string UserId);
       Task<IEnumerable<CatListingServiceModel>> ByUser(string UserId);
       Task<CatDetailsServiceModel> Details(int Id);
    }

}
