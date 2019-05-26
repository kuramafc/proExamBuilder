using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface IExamsService
    {
        Task<bool> RegisterQuestion(Question question);
        Task<bool> DeleteQuestion(long questionCode);
        Task<ExamLinks> ExamGerenate(QuestionsDto question);
        Task<QuestionsDto> ExamGerenatePreview(ExamDto exam);
        Task<IEnumerable<Question>> GetQuestions(string userEmail);
        Task<IEnumerable<ExamLinks>> Historic(long userCode);
    }
}
