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
        [Required]
        public int MatterId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public bool HasOptions { get; set; }
    }
}
