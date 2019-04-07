using Pro.Exam.Builder.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface IExamsService
    {
        Task RegisterQuestions(QuestionsDto questions);
        Task<string> ExamGerenate(ExamDto exam);
    }
}
