using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Promoter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capri.Services.Promoters
{
    public class PromoterImporter: IPromoterImporter
    {
        private readonly IPromoterGetter _promoterGetter;
        private readonly IPromoterUpdater _promoterUpdater;
        private readonly IMapper _mapper;

        public PromoterImporter(
            IPromoterGetter promoterGetter,
            IPromoterUpdater promoterUpdater,
            IMapper mapper)
        {
            _promoterGetter = promoterGetter;
            _promoterUpdater = promoterUpdater;
            _mapper = mapper;
        }

        public async Task<IServiceResult<int>> Import(IEnumerable<PromoterJsonRecord> promotersList)
        {
            int correctImport = 0;
            foreach (var newPromoter in promotersList)
            {
                var existingPromoter = await _promoterGetter.Get(newPromoter.Id);

                if (existingPromoter.Successful())
                {
                    var promoter = _mapper.Map<PromoterUpdate>(newPromoter);

                    var success = await _promoterUpdater.Update(newPromoter.Id, promoter);

                    if (success.Successful())
                    {
                        correctImport++;
                    }
                }
            }

            return ServiceResult<int>.Success(correctImport);
        }
    }
}
