using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;


namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        /**/
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        /**/

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().ToTable("courses");
            builder.Entity<Enrollment>().ToTable("enrollments");
            builder.Entity<Student>().ToTable("students");
            builder.Entity<Instructor>().ToTable("instructors");
            builder.Entity<Department>().ToTable("departments");
            builder.Entity<OfficeAssignment>().ToTable("office_assignments");
            builder.Entity<CourseAssignment>().ToTable("course_assignments");

            // diasable cascade deletion
            builder.Entity<Department>()
                .HasOne(d => d.Administrator)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseId, c.InstructorId });
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=school-store.db");
        }
        */
    }
}
