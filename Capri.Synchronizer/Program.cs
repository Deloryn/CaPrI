using System.IO;
using Microsoft.EntityFrameworkCore;
using Capri.Database;

namespace Capri.Synchronizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string capriWebDir = Directory.
                GetParent(Directory.GetCurrentDirectory())
                .FullName;

            var connectionString = "???";
            var optionsBuilder = 
                new DbContextOptionsBuilder<CapriDbContext>()
                    .UseSqlServer(connectionString);
            var context = new CapriDbContext(optionsBuilder.Options);   
        }
    }
}
