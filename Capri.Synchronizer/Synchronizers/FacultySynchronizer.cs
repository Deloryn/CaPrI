using System.Linq;
using AutoMapper;
using PUT.WebServices.eDziekanatServiceClient;
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
            var eDziekanatFaculties = _eDziekanatClient.GetFaculties(true);
            foreach(var eDziekanatFaculty in eDziekanatFaculties)
            {
                if(eDziekanatFaculty.id == DoctoralSchool)
                {
                    continue;
                }
                var faculty = _mapper.Map<Faculty>(eDziekanatFaculty);
                AddOrUpdate(faculty);
            }
            _context.SaveChanges();
        }

        private void AddOrUpdate(Faculty faculty)
        {
            if(_context.Faculties.Any(f => f.Id == faculty.Id))
            {
                _context.Faculties.Update(faculty);
            }
            else
            {
                _context.Faculties.Add(faculty);
            }
        }
    }
}