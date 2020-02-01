using AutoMapper;
using PUT.WebServices.eDziekanatServiceClient;
using EDziekanatFaculty = PUT.WebServices.eDziekanatServiceClient.eDziekanatService.Faculty;
using Capri.Database;
using Capri.Database.Entities;

namespace Capri.Synchronizer.Synchronizers
{
    public class FacultySynchronizer : IFacultySynchronizer
    {
        const int DoctoralSchool = 1;

        private readonly IEDziekanatClient _eDziekanatClient;
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public FacultySynchronizer(
            IEDziekanatClient eDziekanatClient, 
            ISqlDbContext context,
            IMapper mapper)
        {
            _eDziekanatClient = eDziekanatClient;
            _context = context;
            _mapper = mapper;
        }

        public void Synchronize()
        {
            EDziekanatFaculty[] faculties = _eDziekanatClient.GetFaculties(true);
            foreach(EDziekanatFaculty faculty in faculties)
            {
                if(faculty.id == DoctoralSchool)
                {
                    continue;
                }
                var capriFaculty = _mapper.Map<Faculty>(faculty);
                _context.Faculties.Update(capriFaculty);
            }
        }
    }
}