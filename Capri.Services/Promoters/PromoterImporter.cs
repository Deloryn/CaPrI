using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Promoter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services.Promoters
{
    public class PromoterImporter: IPromoterImporter
    {
        private readonly ISqlDbContext _context;
        private readonly IPromoterGetter _promoterGetter;
        private readonly IPromoterCreator _promoterCreator;
        private readonly IPromoterUpdater _promoterUpdater;
        private readonly IMapper _mapper;

        public PromoterImporter(
            ISqlDbContext context,
            IPromoterGetter promoterGetter,
            IPromoterCreator promoterCreator,
            IPromoterUpdater promoterUpdater,
            IMapper mapper)
        {
            _context = context;
            _promoterGetter = promoterGetter;
            _promoterCreator = promoterCreator;
            _promoterUpdater = promoterUpdater;
            _mapper = mapper;
        }

        public async Task<IServiceResult<int>> Import(IEnumerable<PromoterJsonRecord> promotersList)
        {
            int correctImport = 0;
            foreach (var promoter in promotersList)
            {
                if (promoter.Id != null || !promoter.Id.Equals(Guid.Empty))
                {
                    var exists = await _promoterGetter.Get(promoter.Id);
                    var promoterRegistration = _mapper.Map<PromoterRegistration>(promoter);
                    IServiceResult<PromoterViewModel> x = null;

                    if (exists.Successful())
                    {
                        x = await _promoterUpdater.Update(promoter.Id, promoterRegistration, true);
                    }
                    else
                    {
                        x = await _promoterCreator.Create(promoterRegistration, true);
                    }

                    if (x.Successful()) correctImport++;
                }
            }

            return ServiceResult<int>.Success(correctImport);
        }
    }
}
