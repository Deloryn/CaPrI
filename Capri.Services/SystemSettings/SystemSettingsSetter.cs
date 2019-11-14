using Microsoft.Extensions.Options;

namespace Capri.Services.SystemSettings
{
    public class SystemSettingsSetter : ISystemSettingsSetter
    {
        private int _maxNumOfMasterProposalsPerPromoter;
        private int _maxNumOfBachelorProposalsPerPromoter;

        public SystemSettingsSetter(
            IOptions<Capri.Services.Settings.SystemSettings> systemSettingsOptions)
        {
            var settings = systemSettingsOptions.Value;
            _maxNumOfBachelorProposalsPerPromoter = settings.MaxNumOfBachelorProposalsPerPromoter;
            _maxNumOfMasterProposalsPerPromoter = settings.MaxNumOfMasterProposalsPerPromoter;
        }

        public IServiceResult<int> SetMaxNumOfMasterProposalsPerPromoter(int number)
        {
            _maxNumOfMasterProposalsPerPromoter = number;
            return ServiceResult<int>.Success(_maxNumOfMasterProposalsPerPromoter);
        }

        public IServiceResult<int> SetMaxNumOfBachelorProposalsPerPromoter(int number) {
            _maxNumOfBachelorProposalsPerPromoter = number;
            return ServiceResult<int>.Success(_maxNumOfBachelorProposalsPerPromoter);
        }   
    }
}