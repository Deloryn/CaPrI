using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Database.Entities.Configuration
{
    public static class SeedParams
    {
        private static readonly int _numOfAdmins = 1;
        private static readonly int _numOfDeans = 2;
        private static readonly int _numOfStudents = 8;
        private static readonly int _numOfPromoters = 2;

        public static Guid[] AdminIds = GenArrayOfGuids(_numOfAdmins);
        public static Guid[] DeanIds = GenArrayOfGuids(_numOfDeans);
        public static Guid[] StudentIds = GenArrayOfGuids(_numOfStudents);
        public static Guid[] PromoterIds = GenArrayOfGuids(_numOfPromoters);
        public static Guid AdminRoleId = Guid.NewGuid();
        public static Guid DeanRoleId = Guid.NewGuid();
        public static Guid StudentRoleId = Guid.NewGuid();
        public static Guid PromoterRoleId = Guid.NewGuid();

        private static Guid[] GenArrayOfGuids(int n)
        {
            Guid[] arrayOfGuids = new Guid[n];
            for(int i = 0; i < n; i++)
            {
                arrayOfGuids[i] = Guid.NewGuid();
            }
            return arrayOfGuids;
        }
    }
}
