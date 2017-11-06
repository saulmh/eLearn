using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eLearn.Models;
using Microsoft.AspNetCore.Identity;

namespace eLearn.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }

        public DbSet<Format> Formats { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ModuleProgress> ModuleProgress { get; set; }
        public DbSet<LessonProgress> LessonProgress { get; set; }

        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Declaración de relación muchos a muchos de Enrollment
            builder.Entity<Enrollment>()
                .HasOne(st => st.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(st => st.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Enrollment>()
                .HasOne(ct => ct.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(ct => ct.CourseID)
                .OnDelete(DeleteBehavior.Cascade);

            // Declaración de relación muchos a muchos de ModuleProgress
            builder.Entity<ModuleProgress>()
                .HasOne(mt => mt.Student)
                .WithMany(m => m.ModuleProgress)
                .HasForeignKey(mt => mt.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ModuleProgress>()
                .HasOne(mt => mt.Module)
                .WithMany(m => m.ModuleProgress)
                .HasForeignKey(mt => mt.ModuleID)
                .OnDelete(DeleteBehavior.Cascade);

            // Declaración de relación muchos a muchos de LessonProgress
            builder.Entity<LessonProgress>()
                .HasOne(mt => mt.Student)
                .WithMany(m => m.LessonProgress)
                .HasForeignKey(mt => mt.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<LessonProgress>()
                .HasOne(mt => mt.Lesson)
                .WithMany(m => m.LessonProgress)
                .HasForeignKey(mt => mt.LessonID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
