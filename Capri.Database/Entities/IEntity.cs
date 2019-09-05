using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Database.Entities
{
    interface IEntity
    {
        Guid Id { get; set; }
    }
}
