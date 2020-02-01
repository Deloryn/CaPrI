using System;
using System.Collections.Generic;

namespace Capri.Web.ViewModels.Institute
{
    public class InstituteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<int> Promoters { get; set; }
    }
}