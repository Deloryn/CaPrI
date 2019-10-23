using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capri.Database.Entities
{
    interface IEntity
    {
        [Key]
        Guid Id { get; set; }
    }
}
