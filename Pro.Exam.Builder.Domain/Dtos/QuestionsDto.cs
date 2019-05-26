using Pro.Exam.Builder.Domain.Enums;
using Pro.Exam.Builder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Exam.Builder.Domain.Dtos
{
    public class QuestionsDto
    {
        public List<Question> Questions { get; set; }
        public ExamTypeEnum ExamType { get; set; }
        public string UserCode { get; set; }
    }
}
