using Capri.Synchronizer.Synchronizers;
using System;

namespace Capri.Synchronizer
{
    class Application
    {
        private readonly IRoleSynchronizer _roleSynchronizer;
        private readonly IFacultySynchronizer _facultySynchronizer;
        private readonly ICourseSynchronizer _courseSynchronizer;
        private readonly IInstituteSynchronizer _instituteSynchronizer;
        private readonly IPromoterSynchronizer _promoterSynchronizer;
        private readonly IAdminAccountSynchronizer _adminAccountSynchronizer;

        public Application(
            IRoleSynchronizer roleSynchronizer,
            IFacultySynchronizer facultySynchronizer,
            ICourseSynchronizer courseSynchronizer,
            IInstituteSynchronizer instituteSynchronizer,
            IPromoterSynchronizer promoterSynchronizer,
            IAdminAccountSynchronizer adminAccountSynchronizer
        )
        {
            _roleSynchronizer = roleSynchronizer;
            _facultySynchronizer = facultySynchronizer;
            _courseSynchronizer = courseSynchronizer;
            _instituteSynchronizer = instituteSynchronizer;
            _promoterSynchronizer = promoterSynchronizer;
            _adminAccountSynchronizer = adminAccountSynchronizer;
        }

        public void Run()
        {
            Console.WriteLine("Start role synchronization.");
            _roleSynchronizer.Synchronize();
            Console.WriteLine("End role synchronization");
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
            Console.WriteLine("Start admin account synchronization.");
            _adminAccountSynchronizer.Synchronize();
            Console.WriteLine("End admin account synchronization");
            Console.WriteLine("");
            Console.WriteLine("The synchronization process has been finished. Press any key to close the application.");
            Console.ReadKey();
        }
    }
}