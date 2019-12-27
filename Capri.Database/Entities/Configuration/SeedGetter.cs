using System;
using System.IO;
using System.Collections.Generic;
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
        private static DataSeed Seed = LoadDataSeed();

        private static DataSeed LoadDataSeed()
        {
            var jsonString = File.ReadAllText("../Capri.Database/Entities/Configuration/dataseed.json");
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
                if(student.Id == null || student.Id.Equals(Guid.Empty))
                {
                    student.Id = Guid.NewGuid();
                }
                Students.Add(student);
            }
            foreach(var institute in seed.Institutes)
            {
                if(institute.Id == null|| institute.Id.Equals(Guid.Empty))
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
                    if(promoter.Id == null || promoter.Id.Equals(Guid.Empty))
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
                if(faculty.Id == null || faculty.Id.Equals(Guid.Empty))
                {
                    faculty.Id = Guid.NewGuid();
                }  
                
                foreach(var course in faculty.Courses)
                {
                    if(course.Id == null || course.Id.Equals(Guid.Empty))
                    {
                        course.Id = Guid.NewGuid();
                    }
                    course.FacultyId = faculty.Id;          
                    foreach(var proposal in course.Proposals)
                    {
                        if(proposal.Id == null || proposal.Id.Equals(Guid.Empty))
                        {
                            proposal.Id = Guid.NewGuid();
                        }
                        proposal.CourseId = course.Id;
                        proposal.StartingDate = new DateTime(2020, 3, 1);
                        Proposals.Add(proposal);
                    }
                    course.Proposals = null;
                    Courses.Add(course);
                }
                faculty.Courses = null;
                Faculties.Add(faculty);
            }

            return seed;
        }

        private static User PrepareUser(User user)
        {
            if(user.Id == null || user.Id.Equals(Guid.Empty))
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
