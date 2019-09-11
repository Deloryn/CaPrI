using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            for (int i = 1; i <= SeedParams.StudentIds.Length; i++)
            {
                string email = "student" + i.ToString() + "@gmail.com";
                string password = "qwerty" + i.ToString();
                builder.HasData(new Student
                {
                    Id = SeedParams.StudentIds[i - 1],
                    UserName = email,
                    NormalizedUserName = email,
                    Email = email,
                    NormalizedEmail = email,
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, password),
                    SecurityStamp = string.Empty,
                    Semester = 6,
                    StudyLevel = StudyLevelEnum.Bachelor
                });
            }
        }
    }
}
