using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearn.Models
{
    public class Enrollment
    {
        // Primary key
        public Guid EnrollmentID { get; set; }

        // Attributes
        public double Progress { get; set; }
        
        // Foreign keys
        public Guid CourseID { get; set; }
        public string StudentID { get; set; }

        // Navigation properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }

    public class ModuleProgress
    {
        // Primary key
        public Guid ModuleProgressID { get; set; }

        // Attibutes
        public double Progress { get; set; }

        // Foreign keys
        public Guid ModuleID { get; set; }
        public string StudentID { get; set; }

        // Navigation properties
        public Module Module { get; set; }
        public Student Student { get; set; }
    }

    public class LessonProgress
    {
        // Primary key
        public Guid LessonProgressID { get; set; }

        // Attributes
        public double Progress { get; set; }

        // Foreign keys
        public Guid LessonID { get; set; }
        public string StudentID { get; set; }

        // Navigation properties
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}
