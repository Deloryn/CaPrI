namespace Capri.Services.SystemSettings
{
    public interface ISystemSettingsSetter
    {
        IServiceResult<int> SetMaxNumOfMasterProposalsPerPromoter(int number);
        IServiceResult<int> SetMaxNumOfBachelorProposalsPerPromoter(int number);
    }
}