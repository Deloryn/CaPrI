using Capri.Web.ViewModels.Proposal;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Capri.Services.DiplomaCard
{
    public interface ITableGetter
    {
        Table getTableWithUniversityInformation(ProposalDocRecord record);
        Table getTableWithStudentsInformation(ProposalDocRecord record);
        Table getTableWithProposalInformation(ProposalDocRecord record);
        Table getTableWithSignature();
        Table getTableWithCity(ProposalDocRecord record);
    }
}
