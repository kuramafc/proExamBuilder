using Pro.Exam.Builder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Exam.Builder.Domain.Dtos
{
    public class ExamDto
    {
        public List<QuestionParams> questionParams { get; set; }
    }
}
