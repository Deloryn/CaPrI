﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sieve.Models;
using Capri.Web.ViewModels.Proposal;
using Capri.Web.ViewModels.Common;

namespace Capri.Services.Proposals
{
    public interface IProposalGetter
    {
        Task<IServiceResult<ProposalViewModel>> Get(Guid id);
        Task<IServiceResult<FileDescription>> GetCsvFileDescription(Guid id);
        IServiceResult<IEnumerable<ProposalViewModel>> GetAll();
        IServiceResult<IQueryable<ProposalViewModel>> GetFiltered(SieveModel sieveModel);
    }
}
