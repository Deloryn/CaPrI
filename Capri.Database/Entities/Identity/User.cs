using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Capri.Database.Entities.Identity
{
    public class User : IdentityUser<int>, IEntity
    {
        [PersonalData]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
    }
}
