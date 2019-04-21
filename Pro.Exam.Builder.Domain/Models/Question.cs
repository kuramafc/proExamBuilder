using Pro.Exam.Builder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pro.Exam.Builder.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public Difficult Difficult { get; set; }
        [Required]
        public List<string> Options { get; set; }
        [Required]
        public string RightQuestion { get; set; }
        [DefaultValue(false)]
        public bool Used { get; set; }
        [Required]
        public string Image { get; set; }
        [DefaultValue("Anonymous")]
        public string Author { get; set; }
        [DefaultValue(true)]
        public bool HasOption { get; set; }
        public int Semester { get; set; }
        public string Matter { get; set; }
        public string Subject { get; set; }
    }
}
