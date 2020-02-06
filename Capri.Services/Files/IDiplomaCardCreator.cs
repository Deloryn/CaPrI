using Capri.Web.ViewModels.Proposal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capri.Services.Files
{
    public interface IDiplomaCardCreator
    {
        IServiceResult<MemoryStream> CreateDiplomaCard(ProposalDocRecord proposalDocRecord);
    }
}
