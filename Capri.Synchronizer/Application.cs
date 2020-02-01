using Capri.Synchronizer.Synchronizers;

namespace Capri.Synchronizer
{
    class Application
    {
        protected readonly IFacultySynchronizer _facultySynchronizer;

        public Application(IFacultySynchronizer facultySynchronizer)
        {
            _facultySynchronizer = facultySynchronizer;
        }

        public void Run()
        {
            _facultySynchronizer.Synchronize();
        }
    }
}