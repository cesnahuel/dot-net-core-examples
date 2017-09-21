using ContosoUniversity.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstMidName="Carson", LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01") },
                new Student { FirstMidName="Meredith", LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01") },
                new Student { FirstMidName="Arturo", LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01") },
                new Student { FirstMidName="Gytis", LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01") },
                new Student { FirstMidName="Yan", LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01") },
                new Student { FirstMidName="Peggy", LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01") },
                new Student { FirstMidName="Laura", LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01") },
                new Student { FirstMidName="Nino", LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01") }
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            await context.SaveChangesAsync();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            await context.SaveChangesAsync();

            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Abercrombie").InstructorId },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Fakhouri").InstructorId },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Harui").InstructorId },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Kapoor").InstructorId }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            await context.SaveChangesAsync();

            var courses = new Course[]
            {
                new Course {CourseId = 1050, Title = "Chemistry",      Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Engineering").DepartmentId
                },
                new Course {CourseId = 4022, Title = "Microeconomics", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Economics").DepartmentId
                },
                new Course {CourseId = 4041, Title = "Macroeconomics", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Economics").DepartmentId
                },
                new Course {CourseId = 1045, Title = "Calculus",       Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Mathematics").DepartmentId
                },
                new Course {CourseId = 3141, Title = "Trigonometry",   Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Mathematics").DepartmentId
                },
                new Course {CourseId = 2021, Title = "Composition",    Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "English").DepartmentId
                },
                new Course {CourseId = 2042, Title = "Literature",     Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "English").DepartmentId
                },
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            await context.SaveChangesAsync();

            var enrollments = new Enrollment[]
            {
                new Enrollment { StudentId=1, CourseId=1050,Grade=Grade.A},
                new Enrollment { StudentId=1, CourseId=4022,Grade=Grade.C},
                new Enrollment { StudentId=1, CourseId=4041,Grade=Grade.B},
                new Enrollment { StudentId=2, CourseId=1045,Grade=Grade.B},
                new Enrollment { StudentId=2, CourseId=3141,Grade=Grade.F},
                new Enrollment { StudentId=2, CourseId=2021,Grade=Grade.F},
                new Enrollment { StudentId=3, CourseId=1050},
                new Enrollment { StudentId=4, CourseId=1050},
                new Enrollment { StudentId=4, CourseId=4022,Grade=Grade.F},
                new Enrollment { StudentId=5, CourseId=4041,Grade=Grade.C},
                new Enrollment { StudentId=6, CourseId=1045},
                new Enrollment { StudentId=7, CourseId=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            await context.SaveChangesAsync();
        }
    }
}
