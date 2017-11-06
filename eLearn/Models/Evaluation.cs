using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearn.Models
{
    public class Evaluation
    {
        // Primary key
        public Guid EvaluationID { get; set; }

        // Attributes
        public DateTime StartDate { get; set; }
        public DateTime EndingDate { get; set; }
        public double Score { get; set; }

        // Foreign keys
        public Guid ExamID { get; set; }
        public string StudentID { get; set; }

        // Navigation properties
        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public List<Answer> Answers { get; set; }
    }
    
    public class Answer
    {
        // Primary key
        public Guid AnswerID { get; set; }
        
        // Attributes
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string MyAnswer { get; set; }
        public string ImageCorrect { get; set; }
        public string ImageMyAnswer { get; set; }

        // Foreign keys
        public Guid EvaluationID { get; set; }

        // Navigation properties
        public Evaluation Evaluation { get; set; }
    }
}
