using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Capri.Database;

namespace Capri.Synchronizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // string capriWebDir = Directory.
            //     GetParent(Directory.GetCurrentDirectory())
            //     .FullName;

            var connectionString = args[0];
            var optionsBuilder = 
                new DbContextOptionsBuilder<CapriDbContext>()
                    .UseSqlServer(connectionString);
            var context = new CapriDbContext(optionsBuilder.Options);   

            var faculties = context.Faculties;
            foreach(var faculty in faculties) {
                Console.WriteLine(faculty.Name);
            }
            Console.WriteLine("po wszystkim");
        }
    }
}
