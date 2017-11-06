using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace eLearn.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string PaternalSurname { get; set; }
        public string MaternalSurname { get; set; }
    }

    public class Student : ApplicationUser
    {
        // Attributes
        public string University { get; set; }

        // Navigation properties
        public List<Enrollment> Enrollments { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<LessonProgress> LessonProgress { get; set; }
        public List<ModuleProgress> ModuleProgress { get; set; }
    }

    public class Professor : ApplicationUser
    {
        // Attributes
        public string Grade { get; set; }
        public string Speciality { get; set; }
        public double Rating { get; set; }
        public double PeopleRating { get; set; }

        // Navigation properties
        public List<Course> Courses { get; set; }
    }
}
