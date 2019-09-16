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
            foreach(var userId in SeedParams.StudentIds)
            {
                builder.HasData(new Student
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Semester = 6,
                    StudyLevel = StudyLevelEnum.Bachelor
                });
            }
        }
    }
}
