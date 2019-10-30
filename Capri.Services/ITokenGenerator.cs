using System;
using System.Collections.Generic;
using System.Text;
using Capri.Database.Entities.Identity;

namespace Capri.Services
{
    public interface ITokenGenerator
    {
        string GenerateTokenFor(User user);
    }
}
