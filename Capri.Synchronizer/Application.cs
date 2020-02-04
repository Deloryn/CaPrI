using Capri.Synchronizer.Synchronizers;
using System;

namespace Capri.Synchronizer
{
    class Application
    {
        private readonly IFacultySynchronizer _facultySynchronizer;
        private readonly ICourseSynchronizer _courseSynchronizer;
        private readonly IInstituteSynchronizer _instituteSynchronizer;
        private readonly IPromoterSynchronizer _promoterSynchronizer;

        public Application(
            IFacultySynchronizer facultySynchronizer,
            ICourseSynchronizer courseSynchronizer,
            IInstituteSynchronizer instituteSynchronizer,
            IPromoterSynchronizer promoterSynchronizer
        )
        {
            _facultySynchronizer = facultySynchronizer;
            _courseSynchronizer = courseSynchronizer;
            _instituteSynchronizer = instituteSynchronizer;
            _promoterSynchronizer = promoterSynchronizer;
        }

        public void Run()
        {
            Console.WriteLine("Start faculty synchronization.");
            _facultySynchronizer.Synchronize();
            Console.WriteLine("End faculty synchronization.");
            Console.WriteLine("Start course synchronization.");
            _courseSynchronizer.Synchronize();
            Console.WriteLine("End course synchronization.");
            Console.WriteLine("Start institute synchronization.");
            _instituteSynchronizer.Synchronize();
            Console.WriteLine("End institute synchronization.");
            Console.WriteLine("Start promoters synchronization.");
            _promoterSynchronizer.Synchronize();
            Console.WriteLine("End promoters synchronization.");
            Console.WriteLine("");
            Console.WriteLine("Synchronization process has been finished. Press any key to close application.");
            Console.ReadKey();
        }
    }
}