using Pro.Exam.Builder.Domain.Enums;
using Pro.Exam.Builder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Exam.Builder.Domain.Dtos
{
    public class ExamDto
    {
        public List<QuestionParams> QuestionParams { get; set; }
        public ExamTypeEnum Type { get; set; }
    }
}
