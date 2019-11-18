using Microsoft.Extensions.Options;
using Capri.Services;
using Capri.Services.SystemSettings;

namespace Capri.Web.Configuration
{
    public class SystemSettingsGetter : ISystemSettingsGetter
    {
        private int _maxNumOfMasterProposalsPerPromoter;
        private int _maxNumOfBachelorProposalsPerPromoter;

        public SystemSettingsGetter(
            IOptionsMonitor<SystemSettings> settingsMonitor)
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