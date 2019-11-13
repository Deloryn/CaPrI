namespace Capri.Services
{
    public interface ISettingsService
    {
        IServiceResult<int> GetMaxNumOfMasterProposalsPerPromoter();
        IServiceResult<int> GetMaxNumOfBachelorProposalsPerPromoter();
        IServiceResult<int> SetMaxNumOfMasterProposalsPerPromoter(int number);
        IServiceResult<int> SetMaxNumOfBachelorProposalsPerPromoter(int number);
    }
}