using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capri.Web.Services.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpireDays { get; set; }
    }
}
