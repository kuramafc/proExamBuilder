using Pro.Exam.Builder.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Exam.Builder.Domain.Interfaces.Documents
{
    public interface IDocumentDocX
    {
        void CreateDocument(QuestionsDto question);
    }
}
