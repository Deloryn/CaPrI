using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capri.Web.Services.Settings
{
    public class JwtAuthorizationDetails
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpireDays { get; set; }
    }
}
