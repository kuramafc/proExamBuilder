using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Enums;
using Pro.Exam.Builder.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface IExamsRepository
    {
        Task<bool> RegisterQuestion(Question question);
        Task<bool> DeleteQuestion(long questionCode);
        Task<string> ExamGerenate(QuestionsDto question);
        Task<Question> QuestionPreview(QuestionParams param, ExamTypeEnum type);
        Task<IEnumerable<Question>> GetQuestions(string UserEmail);
    }
}
