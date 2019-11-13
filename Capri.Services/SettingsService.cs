using Microsoft.Extensions.Options;
using Capri.Services.Settings;

namespace Capri.Services
{
    public class SettingsService : ISettingsService
    {
        private int MaxNumOfMasterProposalsPerPromoter;
        private int MaxNumOfBachelorProposalsPerPromoter;

        public SettingsService(IOptions<SystemSettings> systemSettingsOptions)
        {
            var settings = systemSettingsOptions.Value;
            MaxNumOfBachelorProposalsPerPromoter = settings.MaxNumOfBachelorProposalsPerPromoter;
            MaxNumOfMasterProposalsPerPromoter = settings.MaxNumOfMasterProposalsPerPromoter;
        }

        public IServiceResult<int> GetMaxNumOfMasterProposalsPerPromoter()
        {
            return ServiceResult<int>.Success(MaxNumOfMasterProposalsPerPromoter);
        }

        public IServiceResult<int> GetMaxNumOfBachelorProposalsPerPromoter() 
        {
            return ServiceResult<int>.Success(MaxNumOfBachelorProposalsPerPromoter);
        }

        public IServiceResult<int> SetMaxNumOfMasterProposalsPerPromoter(int number)
        {
            MaxNumOfMasterProposalsPerPromoter = number;
            return ServiceResult<int>.Success(MaxNumOfMasterProposalsPerPromoter);
        }

        public IServiceResult<int> SetMaxNumOfBachelorProposalsPerPromoter(int number) {
            MaxNumOfBachelorProposalsPerPromoter = number;
            return ServiceResult<int>.Success(MaxNumOfBachelorProposalsPerPromoter);
        }
    }
}