using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Promoter;
using Newtonsoft.Json;
using System.Text;
using Capri.Web.ViewModels.Common;

namespace Capri.Services.Promoters
{
    public class PromoterGetter : IPromoterGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public PromoterGetter(
            ISqlDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<PromoterViewModel>> Get(Guid id)
        {
            var promoter = 
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promoter == null)
            {
                return ServiceResult<PromoterViewModel>.Error(
                    $"Promoter with id {id} does not exist");
            }

            var promoterViewModel = _mapper.Map<PromoterViewModel>(promoter);
            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }

        public IServiceResult<IEnumerable<PromoterViewModel>> GetAll()
        {
            var promoters = _context.Promoters
                .Include(p => p.Proposals);
                
            var promoterViewModels = promoters.Select(p => _mapper.Map<PromoterViewModel>(p));
            return ServiceResult<IEnumerable<PromoterViewModel>>.Success(promoterViewModels);
        }

        public IServiceResult<FileDescription> GetAllWithJsonFormat()
        {
            var promoters = _context.Promoters
                .Include(p => p.ApplicationUser)
                .Include(p => p.Proposals);

            var promoterJsonModels = promoters.Select(p => _mapper.Map<PromoterJsonRecord>(p));

            var jsonText = JsonConvert.SerializeObject(promoterJsonModels, Formatting.Indented);

            var bytes = Encoding.UTF8.GetBytes(jsonText);
            var fileName = $"promoters-export.json";

            var fileDescription = new FileDescription
            {
                Name = fileName,
                Bytes = bytes
            };

            return ServiceResult<FileDescription>.Success(fileDescription);
        }
    }
}
