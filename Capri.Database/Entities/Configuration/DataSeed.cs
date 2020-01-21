using System.Collections.Generic;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class DataSeed
    {
        public List<User> DeanEmployees { get; set; }
        public List<Student> Students { get; set; }
        public List<Institute> Institutes { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}