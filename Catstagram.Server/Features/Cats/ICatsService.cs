using Catstagram.Server.Models.Cats;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Cats
{
    public interface ICatsService
    {
       Task<int> Create(CreateRequestModeL model,string UserId);
    }
}
