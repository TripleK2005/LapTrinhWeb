using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Day_12_lab1.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Majors.Any())
                {
                    return;// DB has been seeded
                }
                var majors = new Major[]
                {
                    new Major{MajorName="IT"},
                    new Major{MajorName="Economics"},
                    new Major{MajorName="Mathematics"},
                };
                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                var learners = new Learner[]
                {
                    new Learner{FirstMidName="John",LastName="Doe",EnrollmentDate=DateTime.Parse("2020-09-01"),MajorID=majors[0].MajorID},
                    new Learner{FirstMidName="Jane",LastName="Smith",EnrollmentDate=DateTime.Parse("2019-09-01"),MajorID=majors[1].MajorID},
                    new Learner{FirstMidName="Sam",LastName="Brown",EnrollmentDate=DateTime.Parse("2021-09-01"),MajorID=majors[2].MajorID},
                };
                foreach (var learner in learners)
                {
                    context.Learners.Add(learner);
                }
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course{CourseID = 1050,Title="Database Systems",Credits=3},
                    new Course{CourseID = 4022,Title="Microeconomics",Credits=4},
                    new Course{CourseID = 4041,Title="Calculus",Credits=4},
                };
                foreach (var course in courses)
                {
                    context.Courses.Add(course);
                }
                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                    new Enrollment{LearnerID=learners[0].LearnerID,CourseID=courses[0].CourseID,Grade=5.5f},
                    new Enrollment{LearnerID=learners[1].LearnerID,CourseID=courses[1].CourseID,Grade=7.5f},
                    new Enrollment{LearnerID=learners[2].LearnerID,CourseID=courses[2].CourseID,Grade=3.5f},
                };
                foreach (var enrollment in enrollments)
                {
                    context.Enrollments.Add(enrollment);
                }
                context.SaveChanges();
            }
        }
    }
}
