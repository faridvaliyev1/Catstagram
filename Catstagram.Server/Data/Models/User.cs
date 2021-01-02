using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Server.Data.Models
{
    public class User:IdentityUser
    {
        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();
    }
}
