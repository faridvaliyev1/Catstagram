using Catstagram.Server.Models.Cats;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Cats
{
    public interface ICatsService
    {
       Task<int> Create(CreateRequestModeL model,string UserId);
       Task<IEnumerable<CatListingResponseModel>> ByUser(string UserId);
    }
}
