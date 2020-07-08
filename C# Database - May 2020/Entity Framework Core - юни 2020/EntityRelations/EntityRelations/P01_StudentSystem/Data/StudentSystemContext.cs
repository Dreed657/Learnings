using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System.Reflection.Metadata;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        //public StudentSystemContext()
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=StudentSystemDb;Integrated Security=true");
        //}
        
        public StudentSystemContext(DbContextOptions options)
            : base (options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(t => t.Name)
                    .IsUnicode(true);

                entity.Property(t => t.PhoneNumber)
                    .HasColumnType("char(10)")
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(t => t.Birthday)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(t => t.Name)
                    .IsUnicode(true);

                entity.Property(t => t.Description)
                    .IsUnicode(true)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(t => t.Name)
                    .IsUnicode(true);

                entity.Property(t => t.Url)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(t => t.Content)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(k => new { k.StudentId, k.CourseId });
            });
        }
    }
}
