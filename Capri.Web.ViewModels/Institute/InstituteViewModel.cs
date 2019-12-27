using System;
using System.Collections.Generic;

namespace Capri.Web.ViewModels.Institute
{
    public class InstituteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Guid> Promoters { get; set; }
    }
}