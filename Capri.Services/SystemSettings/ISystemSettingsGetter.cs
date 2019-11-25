namespace Capri.Services.SystemSettings
{
    public interface ISystemSettingsGetter
    {
        IServiceResult<int> GetMaxNumOfMasterProposalsPerPromoter();
        IServiceResult<int> GetMaxNumOfBachelorProposalsPerPromoter();
    }
}