using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Capri.Database.Entities.Identity
{
    public class IntUserToken : IdentityUserToken<int>
    {
        [Key]
        public int Id { get; set; }
    }
}
