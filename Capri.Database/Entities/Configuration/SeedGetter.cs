using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public static class SeedGetter
    {
        public static Guid DeanRoleId { get; private set; } = Guid.NewGuid();
        public static Guid PromoterRoleId { get; private set; } = Guid.NewGuid();
        public static Guid StudentRoleId { get; private set; } = Guid.NewGuid();

        public static List<User> Users { get; private set; } = new List<User>();
        public static List<Student> Students { get; private set; } = new List<Student>();
        public static List<Promoter> Promoters { get; private set; } = new List<Promoter>();
        public static List<User> DeanEmployees { get; private set; } = new List<User>();
        public static List<Institute> Institutes { get; private set; } = new List<Institute>();
        public static List<Faculty> Faculties { get; private set; } = new List<Faculty>();
        public static List<Course> Courses { get; private set; } = new List<Course>();
        public static List<Proposal> Proposals { get; private set; } = new List<Proposal>();

        static SeedGetter()
        {
            var fileName = "dataseed.json";
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            var jsonString = File.ReadAllTextAsync(path).Result;
            var seed = JsonConvert.DeserializeObject<DataSeed>(jsonString);
            
            foreach(var user in seed.DeanEmployees)
            {
                var preparedUser = PrepareUser(user);
                Users.Add(preparedUser);
                DeanEmployees.Add(preparedUser);
            }
            foreach(var student in seed.Students)
            {
                var user = PrepareUser(student.ApplicationUser);
                Users.Add(user);
                student.ApplicationUser = null;
                student.UserId = user.Id;
                if(student.Id == Guid.Empty)
                {
                    student.Id = Guid.NewGuid();
                }
                Students.Add(student);
            }
            foreach(var institute in seed.Institutes)
            {
                if(institute.Id == Guid.Empty)
                {
                    institute.Id = Guid.NewGuid();
                }

                foreach(var promoter in institute.Promoters)
                {
                    var user = PrepareUser(promoter.ApplicationUser);
                    Users.Add(user);
                    promoter.ApplicationUser = null;
                    promoter.UserId = user.Id;
                    promoter.InstituteId = institute.Id;
                    if(promoter.Id == Guid.Empty)
                    {
                        promoter.Id = Guid.NewGuid();
                    }
                    Promoters.Add(promoter);
                }
                institute.Promoters = null;
                Institutes.Add(institute);
            }
            foreach(var faculty in seed.Faculties)
            {
                if(faculty.Id == Guid.Empty)
                {
                    faculty.Id = Guid.NewGuid();
                }  
                
                foreach(var course in faculty.Courses)
                {
                    if(course.Id == Guid.Empty)
                    {
                        course.Id = Guid.NewGuid();
                    }
                    course.FacultyId = faculty.Id;          
                    foreach(var proposal in course.Proposals)
                    {
                        if(proposal.Id == Guid.Empty)
                        {
                            proposal.Id = Guid.NewGuid();
                        }
                        proposal.CourseId = course.Id;
                        proposal.StartingDate = new DateTime(2019, 10, 1);
                        Proposals.Add(proposal);
                    }
                    course.Proposals = null;
                    Courses.Add(course);
                }
                faculty.Courses = null;
                Faculties.Add(faculty);
            }
        }

        private static User PrepareUser(User user)
        {
            if(user.Id == Guid.Empty)
            {
                user.Id = Guid.NewGuid();
            }
            user.UserName = user.Email;
            user.NormalizedUserName = new UpperInvariantLookupNormalizer()
                .Normalize(user.Email)
                .ToUpperInvariant();
            user.NormalizedEmail = new UpperInvariantLookupNormalizer()
                .Normalize(user.Email)
                .ToUpperInvariant();
            user.EmailConfirmed = true;
            user.PasswordHash = new PasswordHasher<User>().HashPassword(null, user.PasswordHash);
            user.SecurityStamp = string.Empty;
            return user;
        }
    }
}
