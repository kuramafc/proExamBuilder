using Pro.Exam.Builder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pro.Exam.Builder.Domain.Models
{
    public class QuestionParams
    {
        [Required]
        public Difficult Difficult { get; set; }
        public int Semester { get; set; }
        [Required]
        public string Matter { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}
