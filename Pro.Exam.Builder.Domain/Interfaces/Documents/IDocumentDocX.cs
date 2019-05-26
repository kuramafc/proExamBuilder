using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Exam.Builder.Domain.Interfaces.Documents
{
    public interface IDocumentDocX
    {
        ExamLinks CreateDocument(QuestionsDto question);
    }
}
