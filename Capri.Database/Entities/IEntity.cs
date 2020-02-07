using System.ComponentModel.DataAnnotations;

namespace Capri.Database.Entities
{
    interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
