using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearn.Models
{
    public class Exam
    {
        // Primary key
        public Guid ExamID { get; set; }

        // Attibutes
        public string Summary { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndingDate { get; set; }

        // Foreign keys
        public Guid CourseID { get; set; }

        // Navigation properties
        public Course Course { get; set; }
        public Question Questions { get; set; }
    }

    public class Question
    {
        // Primary key
        public Guid QuestionID { get; set; }

        // Attributes
        public string Description { get; set; }
        public int CorrectAnswer { get; set; }
        public string Imagen { get; set; }

        // Foreign keys
        public Guid ExamID { get; set; }

        // Navigation properties
        public Exam Exam { get; set; }
        public List<Option> Options { get; set; }
    }

    public class Option
    {
        // Primary key
        public Guid OptionID { get; set; }

        // Attributes
        public int Number { get; set; }
        public string Summary { get; set; }
        public string Imagen { get; set; }

        // Foreign key
        public Guid QuestionID { get; set; }

        // Navigation properties
        public Question Question { get; set; }
    }
}
