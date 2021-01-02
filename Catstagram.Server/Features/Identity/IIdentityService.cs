using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string UserId, string Username, string secret);
    }
}
