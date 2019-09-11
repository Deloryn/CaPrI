using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Database.Entities.Configuration
{
    /*
     * Here you can define how many seed users should be.
     * All the credentials use the same pattern.
     * email: admin/dean/student/promoter + number(1, 2, 3, ...) + @gmail.com
     * password: qwerty + number(1, 2, 3, ...)
     * 
     * For example: 
     * admin1@gmail.com, qwerty1
     * dean7@gmail.com, qwerty7
     * student3@gmail.com, qwerty3
     */
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
