using System.Threading.Tasks;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Students
{
    public interface IStudentGroupValidator
    {
        Task<IServiceResult<bool>> IsStudentGroupValidFor(
            ProposalRegistration registration);
    }
}