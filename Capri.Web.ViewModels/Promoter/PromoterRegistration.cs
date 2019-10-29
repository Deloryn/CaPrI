﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Web.ViewModels.Promoter
{
    public class PromoterRegistration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool CanSubmitBachelorProposals { get; set; }
        public bool CanSubmitMasterProposals { get; set; }
    }
}