using Capri.Synchronizer.Synchronizers;

namespace Capri.Synchronizer
{
    class Application
    {
        private readonly IRoleSynchronizer _roleSynchronizer;
        private readonly IFacultySynchronizer _facultySynchronizer;
        private readonly ICourseSynchronizer _courseSynchronizer;
        private readonly IInstituteSynchronizer _instituteSynchronizer;

        public Application(
            IRoleSynchronizer roleSynchronizer,
            IFacultySynchronizer facultySynchronizer,
            ICourseSynchronizer courseSynchronizer,
            IInstituteSynchronizer instituteSynchronizer
        )
        {
            _roleSynchronizer = roleSynchronizer;
            _facultySynchronizer = facultySynchronizer;
            _courseSynchronizer = courseSynchronizer;
            _instituteSynchronizer = instituteSynchronizer;
        }

        public void Run()
        {
            _roleSynchronizer.Synchronize();
            _facultySynchronizer.Synchronize();
            _courseSynchronizer.Synchronize();
            _instituteSynchronizer.Synchronize();
        }
    }
}