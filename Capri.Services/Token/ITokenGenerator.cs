using System.Collections.Generic;
using Capri.Database.Entities.Identity;

namespace Capri.Services.Token
{
    public interface ITokenGenerator
    {
        string GenerateTokenFor(User user);
        string GenerateTokenFor(User user, IList<string> roles);
    }
}
