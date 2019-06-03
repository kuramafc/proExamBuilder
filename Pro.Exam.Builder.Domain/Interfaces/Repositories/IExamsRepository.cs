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
        Task<bool> ExamGerenate(ExamLinks examLinks);
        Task<Question> QuestionPreview(QuestionParams param, ExamTypeEnum type);
        Task<IEnumerable<Question>> GetQuestions(string UserEmail);
        Task<bool> DesableQuestion(long code);
        Task<IEnumerable<ExamLinks>> Historic(long userCode);
        Task<IEnumerable<string>> QuestionPreviewOptions(long questionId);
    }
}
