using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearn.Models
{
    public class Category
    {
        // Primary key
        public Guid CategoryID { get; set; }

        // Attibutes
        public string Name { get; set; }
        public string Summary { get; set; }

        // Navigation
        public List<Course> Courses { get; set; }
    }

    public class Course
    {
        // Primary key
        public Guid CourseID { get; set; }

        // Attributes
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        // Foreign Keys
        public Guid CategoryID { get; set; }
        public string ProfessorID { get; set; }
        
        // Navigation Properties
        public Category Category { get; set; }
        public Professor Professor { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<Exam> Examns { get; set; }
        public List<Module> Modules { get; set; }
    }

    public class Module
    {
        // Primary key
        public Guid ModuleID { get; set; }

        // Attibutes
        public string Name { get; set; }
        public int Number { get; set; }
        public string Summary { get; set; }

        // Foreign Keys
        public Guid CourseID { get; set; }
        
        // Navigation Properties
        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<ModuleProgress> ModuleProgress { get; set; }
    }

    public class Lesson
    {
        // Primary Key
        public Guid LessonID { get; set; }

        // Attibutes
        public string Name { get; set; }
        public int Number { get; set; }
        public string Summary { get; set; }

        // Foreign Keys
        // public Guid ContentID { get; set; }
        public Guid ModuleID { get; set; }

        // Navigation Properties
        public Content Content { get; set; }
        public Module Module { get; set; }
        public List<LessonProgress> LessonProgress { get; set; }
        
    }

    public class Content
    {
        // Primary Key
        public Guid ContentID { get; set; }

        // Attibutes
        public string URL { get; set; }

        // Foreign Keys
        public Guid FormatID { get; set; }
        public Guid LessonID { get; set; }

        // Navigation Properties
        public Format Format { get; set; }
        public Lesson Lesson { get; set; }
    }

    public class Format
    {
        // Primary Key
        public Guid FormatID { get; set; }

        // Attributes
        public string Name { get; set; }

        // Navigation Properties
        public List<Content> Contents { get; set; }
    }
}
