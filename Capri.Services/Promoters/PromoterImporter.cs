using AutoMapper;
using Capri.Web.ViewModels.Promoter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capri.Services.Promoters
{
    public class PromoterImporter : IPromoterImporter
    {
        private readonly IPromoterUpdater _promoterUpdater;
        private readonly IMapper _mapper;

        public PromoterImporter(
            IPromoterUpdater promoterUpdater,
            IMapper mapper)
        {
            _promoterUpdater = promoterUpdater;
            _mapper = mapper;
        }

        public async Task<IServiceResult<int>> Import(IEnumerable<PromoterJsonRecord> promotersList)
        {
            int correctImport = 0;
            foreach (var newPromoter in promotersList)
            {
                var promoter = _mapper.Map<PromoterUpdate>(newPromoter);

                var result = await _promoterUpdater.Update(newPromoter.Id, promoter);

                if (result.Successful())
                {
                    correctImport++;
                }
            }

            return ServiceResult<int>.Success(correctImport);
        }
    }
}
