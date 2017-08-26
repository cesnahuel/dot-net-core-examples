using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;


namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        /*
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        */

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().ToTable("courses");
            builder.Entity<Enrollment>().ToTable("enrollments");
            builder.Entity<Student>().ToTable("students");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=school-store.db");
        }
    }
}
