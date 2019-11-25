using Microsoft.Extensions.Options;

namespace Capri.Services.SystemSettings
{
    public class SystemSettingsGetter : ISystemSettingsGetter
    {
        private int _maxNumOfMasterProposalsPerPromoter;
        private int _maxNumOfBachelorProposalsPerPromoter;

        public SystemSettingsGetter(
            IOptionsMonitor<Capri.Services.Settings.SystemSettings> settingsMonitor)
        {
            settingsMonitor.OnChange(vals => {
                _maxNumOfBachelorProposalsPerPromoter = vals.MaxNumOfBachelorProposalsPerPromoter;
                _maxNumOfMasterProposalsPerPromoter = vals.MaxNumOfMasterProposalsPerPromoter;
            });
            
            var settings = settingsMonitor.CurrentValue;
            _maxNumOfBachelorProposalsPerPromoter = settings.MaxNumOfBachelorProposalsPerPromoter;
            _maxNumOfMasterProposalsPerPromoter = settings.MaxNumOfMasterProposalsPerPromoter;
        }

        public IServiceResult<int> GetMaxNumOfMasterProposalsPerPromoter()
        {
            return ServiceResult<int>.Success(_maxNumOfMasterProposalsPerPromoter);
        }

        public IServiceResult<int> GetMaxNumOfBachelorProposalsPerPromoter() 
        {
            return ServiceResult<int>.Success(_maxNumOfBachelorProposalsPerPromoter);
        }
    }
}