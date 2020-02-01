using Capri.Synchronizer.Synchronizers;

namespace Capri.Synchronizer
{
    class Application
    {
        private readonly IFacultySynchronizer _facultySynchronizer;
        private readonly ICourseSynchronizer _courseSynchronizer;
        private readonly IInstituteSynchronizer _instituteSynchronizer;

        public Application(
            IFacultySynchronizer facultySynchronizer,
            ICourseSynchronizer courseSynchronizer,
            IInstituteSynchronizer instituteSynchronizer
        )
        {
            _facultySynchronizer = facultySynchronizer;
            _courseSynchronizer = courseSynchronizer;
            _instituteSynchronizer = instituteSynchronizer;
        }

        public void Run()
        {
            _facultySynchronizer.Synchronize();
            _courseSynchronizer.Synchronize();
            _instituteSynchronizer.Synchronize();
        }
    }
}